
using GreenPandaAssets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlantControl : MonoBehaviour
{
    [Inject]
    private PlantConfig _plantConfig;
    [SerializeField]
    private PlantUpgradable _plantUpgradable;
    [SerializeField]
    Transform _startPointForTruck, _finishPointForTruck;
    [SerializeField]
    Transform _bullDozerPos;
    [Inject]
    private readonly TruckControl.TruckFactory truckFactory;
    [Inject]
    private BullDozer.BullDozerFactory _bullDozerFactory;

    private TruckControl createdTruck;
    void Start()
    {
        _plantUpgradable.SetupSettings(_plantConfig);
        CreateTruck();
        CreateBullDozer();
    }

    public void UnloadTruck()
    {
        Destroy(createdTruck.gameObject);
        CreateTruck();
    }

    void CreateTruck()
    {
        createdTruck = truckFactory.Create(_startPointForTruck.position, _finishPointForTruck.position);
    }

    void CreateBullDozer()
    {
        _bullDozerFactory.Create(_bullDozerPos);
    }
}
