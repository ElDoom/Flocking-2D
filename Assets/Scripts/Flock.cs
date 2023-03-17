using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public Boid boidPrefab;
    List<Boid> boids = new List<Boid>();
    public Boid_Behaviour behavior;

    [Range(10, 500)]
    public int initialAmount = 250;
    const float boidDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadius = 0.5f;

    float squaredMaxSpeed;
    float squaredNeighborRaius;
    float squaredAvoidanceRadius;

    public ScreenBounds screenBounds;

    public float SquaredAvoidanceRadius { get { return squaredAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squaredMaxSpeed = maxSpeed * maxSpeed;
        squaredNeighborRaius = neighborRadius * neighborRadius;
        squaredAvoidanceRadius = avoidanceRadius * avoidanceRadius;
        for (int i = 0; i < initialAmount; i++)
        {
            Boid newBoid = Instantiate(
                boidPrefab,
                Random.insideUnitCircle * initialAmount * boidDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newBoid.name = "Boid " + i;
            newBoid.GetComponentInChildren<SpriteRenderer>().color = new Color(Random.Range(0f,1f), 0, Random.Range(0f, 1f),1f);
            //newBoid.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.blue, (i+1)/initialAmount);
            boids.Add(newBoid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Boid b in boids)
        {
            List<Transform> context = GetNearBoids(b);

            //test
            //b.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count /6f);

            Vector2 move = behavior.CalculateMove(b, context, this);
            move *= driveFactor;

            if (move.sqrMagnitude > squaredMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            wrapAround(b);

            b.Move(move);
            
        }
    }

    void wrapAround(Boid b)
    {
        //check wrap here
        Vector3 tempPosition = b.transform.localPosition;
        //Debug.Log(tempPosition);
        if (screenBounds.AmIOutOfBounds(tempPosition))
        {
            Vector2 newPosition = screenBounds.CalculateWrappedPosition(tempPosition);
            b.transform.position = newPosition;
            //Debug.Log("Boid out of bounds");
        }
        else
        {
            b.transform.position = tempPosition;
        }
        //check wrap end
    }

    List<Transform> GetNearBoids(Boid boid)
    {
        List<Transform> context = new List<Transform>();
        //we apply this next line instead of the calculation
        Collider2D[] contextCollider = Physics2D.OverlapCircleAll(boid.transform.position, neighborRadius);
        foreach (Collider2D c in contextCollider)
        {
            if (c != boid.BoidCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
