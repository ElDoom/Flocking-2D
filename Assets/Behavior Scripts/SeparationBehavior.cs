using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Separation")]
public class SeparationBehavior : Boid_Behaviour
{
    public override Vector2 CalculateMove(Boid agent, List<Transform> context, Flock flock)
    {
        // no neighbors
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        // add points and calculate average
        Vector2 separationMove = Vector2.zero;
        int nAvoid = 0;

        foreach (Transform item in context)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquaredAvoidanceRadius)
            {
                nAvoid++;
                separationMove += (Vector2)(agent.transform.position - item.position);
            }
        }

        if (nAvoid > 0)
        {
            separationMove /= nAvoid;
        }

        return separationMove;
    }

    public override string GetNameBehavior()
    {
        return "Separation";
    }
}
