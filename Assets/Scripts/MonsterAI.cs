using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool isPatrolling = true;
    private bool isChasing = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (isPatrolling == true)
        {
            GotoNextPoint();
        }
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return; 
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
