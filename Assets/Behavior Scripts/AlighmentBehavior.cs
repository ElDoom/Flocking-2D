using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alighment")]
public class AlighmentBehavior : Boid_Behaviour
{
    public override Vector2 CalculateMove(Boid agent, List<Transform> context, Flock flock)
    {
        // no neighbors
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // add points and calculate average
        Vector2 alighmentMove = Vector2.zero;
        foreach (Transform item in context)
        {
            alighmentMove += (Vector2)item.transform.up;
        }
        alighmentMove /= context.Count;

        return alighmentMove;
    }

    public override string GetNameBehavior()
    {
        return "Alighmnet";
    }
}
