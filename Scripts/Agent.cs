using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ryan
{
    public abstract class Agent : ScriptableObject
    {
        public float mass, max_speed;

        public Vector3 seperation, alignment, cohesion;

        public Vector3 acceleration, velocity, force, position;
    }
}