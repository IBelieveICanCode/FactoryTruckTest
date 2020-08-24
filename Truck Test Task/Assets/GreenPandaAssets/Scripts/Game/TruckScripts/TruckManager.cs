using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TruckManager : MonoBehaviour
{
    [SerializeField]
    private TruckUpgradable _truckUpgradable;
    
    [Inject]
    private readonly TruckConfig _truckConfig;
    [Inject]
    private readonly Truck.TruckFactory _truckFactory;

    private Truck _createdTruck;

    private void Start()
    {
        CreateTruck();
    }
    void CreateTruck()
    {
        _createdTruck = _truckFactory.Create(_truckConfig);
        _truckUpgradable.SetupSettings(_truckConfig, _createdTruck);
    }
    public void UnloadTruck()
    {
        Destroy(_createdTruck.gameObject);
        CreateTruck();
    }
}
