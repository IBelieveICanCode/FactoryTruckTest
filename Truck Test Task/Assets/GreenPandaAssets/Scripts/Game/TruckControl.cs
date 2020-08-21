using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class TruckControl : MonoBehaviour, IInitializable
{
    private Vector3 destination;
    [SerializeField]
    TruckEngine engine;

    [Inject]
    PlantControl plantControl;
    [Inject]
    public readonly SignalBus signalBus;

    Vector3 spawnPos;
    Vector3 finishPos;
    [Inject]
    public void Construct(Vector3 spawnPoint, Vector3 finishPoint)
    {
        spawnPos = spawnPoint;
        finishPos = finishPoint;
    }

    [Inject]
    public void Initialize()
    {
        //engine.agent.Warp(spawnPos);
        //engine.SetDestination(finishPos);
    }
    private void OnTriggerEnter(Collider other)
    {
        ILoadGoodable bullDozerLoad = other.gameObject.GetComponent<ILoadGoodable>();
        if (bullDozerLoad != null && !bullDozerLoad.IsVisited)
        {
            engine.StopMovement();
            signalBus.Fire<StartLoadingGoodsInTruck>();
        }
    }

    public void ContinueMovement()
    {
        engine.ResumeMovement();
    }


    public class TruckFactory : PlaceholderFactory<Vector3, Vector3, TruckControl>
    {
    }
}
