using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TruckManager : MonoBehaviour
{
    [SerializeField]
    private TruckUpgradable _truckUpgradable;
    [Inject]
    private TruckConfig _truckConfig;
    [Inject]
    private readonly TruckControl.TruckFactory _truckFactory;

    [Inject]
    private TruckControl _createdTruck;

    private void Start()
    {
        CreateTruck();
    }
    void CreateTruck()
    {
        _createdTruck = _truckFactory.Create(_truckConfig);
        _truckUpgradable.SetupSettings(_truckConfig,_createdTruck);
    }

    public void UnloadTruck()
    {
        Destroy(_createdTruck.gameObject);
        CreateTruck();
    }
}
