using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class TruckControl : MonoBehaviour, IWaitForGoodable
{
    private float _destinationReachedTreshold => _agent.radius * 2f;
    [SerializeField]
    private NavMeshAgent _agent;
    [Inject]
    PlantControl _plantControl;
    private Vector3 _finishPoint;
    [Inject]
    private readonly SignalBus _signalBus;
    
    [Inject]
    public void Construct(Vector3 spawnPoint, Vector3 finishPoint)
    {
        transform.position = spawnPoint;
        this._finishPoint = finishPoint;
    }

    void Start()
    {
        print(_signalBus);
        _agent.destination = _finishPoint;
    }
    public void StopMovement()
    {
        if (!_agent.isStopped)
            _agent.isStopped = true;
    }

    public void ResumeMovement()
    {
        if (_agent.isStopped)
            _agent.isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        ILoadGoodable bullDozerLoad = other.gameObject.GetComponent<ILoadGoodable>();
        if (bullDozerLoad != null && !bullDozerLoad.IsVisited)
        {
            StopMovement();
            bullDozerLoad.StartLoadGoods(this);
        }
    }

    private void Update()
    {
        CheckIfDestinationReached();
    }

    private void CheckIfDestinationReached()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _finishPoint);
        if (distanceToTarget < _destinationReachedTreshold)
        {
            _signalBus.Fire<TruckReachedDestination>();
        }
    }

    public class TruckFactory : PlaceholderFactory<Vector3, Vector3, TruckControl>{}

}
