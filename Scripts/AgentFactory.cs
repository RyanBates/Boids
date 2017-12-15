using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFactory : MonoBehaviour
{
    public GameObject agent;
    public GameObject target;


    public List<Ryan.Agent> agents;
    public List<BoidBehaviour> BB;

    public void Create(int count)
    {
        for (int i = 0; i <= count; ++i)
        {
            var go = Instantiate(agent,
                new Vector3(Random.Range(-15, 15),
                Random.Range(-15, 15),
                Random.Range(-15, 15)),
                Quaternion.identity);

            var bb = go.AddComponent<BoidBehaviour>();
            
            var boid = ScriptableObject.CreateInstance<Boid>();

            boid.Initalize();

            agents.Add(boid);

            BB.Add(bb);

            bb.SetMoveable(boid);
        }
    }

    public Vector3 Cohesion(Boid b)
    {
        foreach (Boid B in agents)
            if (B != b)
            {
                b.cohesion = b.cohesion + B.position;
            }

        b.cohesion = b.cohesion / (agents.Count - 1);

        return ((b.cohesion - b.position) / 100);
    }



    public Vector3 Dispersion(Boid b)
    {
        Vector3 c = new Vector3(0, 0, 0);

        foreach (Boid B in agents)
            if (B != b)
                if (Vector3.Magnitude(B.position - b.position) < 5)
                    c = c - (B.position - b.position);

        return c;
    }




    public Vector3 Alignment(Boid b)
    {
        foreach (Boid B in agents)
            if (B != b)
            {
                b.alignment = b.alignment + B.velocity;
            }

        b.alignment = b.alignment / (agents.Count - 1);

        return ((b.alignment - b.velocity) / 8);
    }

    public List<Boid> GetBoids()
    {
        List<Boid> results = new List<Boid>();

        foreach (Boid B in agents)
            results.Add(B);

        return results;
    }

    public void MoveBoids()
    {
        Vector3 v1, v2, v3;

        foreach (Boid b in agents)
        {
            v1 = Cohesion(b);
            v2 = Dispersion(b);
            v3 = Alignment(b);

            b.velocity = b.velocity + v1 + v2 + v3;
            b.position = b.velocity / 25;
        }

     
    }

    private void Start()
    {
        Create(20);
        GetBoids();   
    }

    private void Update()
    {
        MoveBoids();

        if (Input.GetKey(KeyCode.Mouse1))
        {
            var go = Instantiate(agent,
                new Vector3(Random.Range(-15, 15),
                Random.Range(-15, 15),
                Random.Range(-15, 15)),
                Quaternion.identity);

            var bb = go.AddComponent<BoidBehaviour>();

            var boid = ScriptableObject.CreateInstance<Boid>();

            boid.Initalize();

            agents.Add(boid);

            bb.SetMoveable(boid);

            BB.Add(bb);
        }
    }
}