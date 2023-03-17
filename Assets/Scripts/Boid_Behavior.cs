using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boid_Behaviour : ScriptableObject
{

    public abstract Vector2 CalculateMove(Boid agent, List<Transform> context, Flock flock);
    public abstract string GetNameBehavior();
}
