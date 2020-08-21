using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class TruckControl : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [Inject]
    PlantControl plantControl; //The reference to the class which creates my truck. If I remove it, NullReferenceException for factory occurs  
    [Inject]
    private readonly SignalBus signalBus;
    
    [Inject]
    public void Construct(Vector3 spawnPoint, Vector3 finishPoint)
    {
        agent.Warp(spawnPoint);
        agent.destination = finishPoint;
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
    private void OnTriggerEnter(Collider other)
    {
        ILoadGoodable bullDozerLoad = other.gameObject.GetComponent<ILoadGoodable>();
        if (bullDozerLoad != null && !bullDozerLoad.IsVisited)
        {
            StopMovement();
            signalBus.Fire<StartLoadingGoodsInTruck>();
        }
    }


    public class TruckFactory : PlaceholderFactory<Vector3, Vector3, TruckControl>{}

}
