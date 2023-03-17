using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : Boid_Behaviour
{
    public Boid_Behaviour[] behaviors;
    public float[] weights;
    public override Vector2 CalculateMove(Boid agent, List<Transform> context, Flock flock)
    {
        if (behaviors.Length != weights.Length)
        {
            Debug.LogError("Data mismatch in" + name , this);
            return Vector2.zero;
        }

        //set up move
        Vector2 move = Vector2.zero;

        //iterate on behaviors
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partMove = behaviors[i].CalculateMove(agent, context, flock)*weights[i];
            if (partMove != Vector2.zero)
            {
                if (partMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partMove.Normalize();
                    partMove *= weights[i];
                }

                move += partMove;
            }
        }
        return move;
    }

    public override string GetNameBehavior()
    {
        return "Composite";
    }
}
