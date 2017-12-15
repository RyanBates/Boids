using UnityEngine;

public interface IMoveable
{
    Vector3 Update_Agent(float dt);
    bool AddForce(float a, Vector3 b);
}

[CreateAssetMenu]
public class Boid : Ryan.Agent, IMoveable
{    
    public void Initalize()
    {
        mass = 2;
        max_speed = 5;

        acceleration = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1));
        velocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        force = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }
    

    public Vector3 Update_Agent(float deltaTime)
    {
        acceleration = force / mass;
        velocity += acceleration * deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, max_speed);
        position += velocity * deltaTime;

        return position;
    }

    public bool AddForce(float a, Vector3 b)
    {
        force = b * a;

        return true;
    }
}