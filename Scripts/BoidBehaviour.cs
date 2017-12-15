using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : AgentBehaviour
{
    IMoveable moveable;
    Boid boid;
    
    public void SetMoveable(IMoveable mover)
    {
        moveable = mover;
    }
    
    public void LateUpdate()
    {

        transform.position = moveable.Update_Agent(Time.deltaTime);
    }
}