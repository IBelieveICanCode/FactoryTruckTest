using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TruckEngine : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent agent;
    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
    public void StopMovement()
    {
        if (!agent.isStopped)
            agent.isStopped = true;
    }

    public void ResumeMovement()
    {
        if (agent.isStopped)
            agent.isStopped = false;
    }
}
