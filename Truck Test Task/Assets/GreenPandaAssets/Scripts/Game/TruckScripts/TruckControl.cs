using System;
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
    private TruckEngine _truckEngine;
    [Inject]
    PlantControl _plantControl;
    
    [Inject]
    public void Construct(TruckConfig config)
    {
        transform.position =  _plantControl.StartPointForTruck.position;
        _truckEngine.SetNavmesh(config.StartSpeed, _plantControl.FinishPointForTruck.position);
    }
 

    public class TruckFactory : PlaceholderFactory<TruckConfig, TruckControl>{}

}
