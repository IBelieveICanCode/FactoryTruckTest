using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TruckEngine : MonoBehaviour, IWaitForGoodable
{
    #region Movement
    [SerializeField]
    private NavMeshAgent _agent;
    private float _destinationReachedTreshold => _agent.radius * 2f;
    private Vector3 _finishPoint;
    [Inject]
    private readonly SignalBus _signalBus;
    
    public void SetNavmesh(float speed, Vector3 finishPoint)
    {
        _finishPoint = finishPoint;
        this._agent.speed = speed;
    }

    void Start()
    {
        this._agent.destination = _finishPoint;
        _agent.updateRotation = false;
    }
    private void Update()
    {
        CheckIfDestinationReached();
    }

    void LateUpdate()
    {
        if (!this._agent.isStopped)
            CheckRotation();
    }

    public void StopMovement()
    {
        if (!this._agent.isStopped)
        {
            _agent.velocity = Vector3.zero;
            this._agent.isStopped = true;
        }
    }

    public void ResumeMovement()
    {
        if (this._agent.isStopped)
        {
            this._agent.isStopped = false;
        }
           
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
    
    private void CheckIfDestinationReached()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _finishPoint);
        if (distanceToTarget < _destinationReachedTreshold)
        {
            _signalBus.Fire<TruckReachedDestination>();
        }
    }

    private void CheckRotation()
    {
        var targetRotation = Quaternion.LookRotation(_agent.velocity.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _agent.speed * Time.deltaTime);
    }
    #endregion
}
