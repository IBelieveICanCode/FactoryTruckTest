using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlantControl : MonoBehaviour
{
    [SerializeField]
    GameObject truck;
    [SerializeField]
    Transform startPointForTruck, finishPointForTruck;

    [Inject]
    private readonly TruckControl.TruckFactory truckFactory;
    void Start()
    {
        truckFactory.Create(startPointForTruck.position, finishPointForTruck.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
