using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")]
public class SteeredCohesionBehavior : Boid_Behaviour
{
    Vector2 currentVelocity;
    public float boidSmoothTime = 0.5f;

    public override Vector2 CalculateMove(Boid agent, List<Transform> context, Flock flock)
    {
        // no neighbors
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // add points and calculate average
        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        //calculate offset
        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, boidSmoothTime);

        return cohesionMove;
    }

    public override string GetNameBehavior()
    {
        return "SteeredCohesion";
    }
}
