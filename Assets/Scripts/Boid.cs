using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// These could be round or box colliders
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Boid : MonoBehaviour
{
    Collider2D boidCollider;
    public Collider2D BoidCollider { get { return boidCollider; } }
    
    // Start is called before the first frame update
    void Start()
    {
        boidCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 velocity) 
    {
        transform.up = velocity;
        transform.position += (Vector3 )velocity * Time.deltaTime;
    }
 

}
