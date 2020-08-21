using GreenPandaAssets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlantControl : MonoBehaviour
{
    [Inject]
    private PlantConfig plantConfig;
    [SerializeField]
    private PlantUpgradable plantUpgradable;
    [SerializeField]
    Transform startPointForTruck, finishPointForTruck;

    [Inject]
    private readonly TruckControl.TruckFactory truckFactory;
    void Start()
    {
        plantUpgradable.SetupSettings(plantConfig);

        //truckFactory.Create(startPointForTruck.position, finishPointForTruck.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
