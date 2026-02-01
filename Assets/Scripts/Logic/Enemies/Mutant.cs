using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mutant : Enemy
{

    private NavMeshAgent agent;

    private void Awake()
    {
        Health = new Health(3200);
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.1f)
        {
            agent.destination = transform.position + Vector3.Scale(new Vector3(1.0f, 0.0f, 1.0f), Random.onUnitSphere).normalized * 5;
        }
    }
}
