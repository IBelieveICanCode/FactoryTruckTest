
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
    private Transform _startPointForTruck, _finishPointForTruck;
    public Transform StartPointForTruck => _startPointForTruck;
    public Transform FinishPointForTruck => _finishPointForTruck;
    [SerializeField]
    Transform _bullDozerPos;
    
    [Inject]
    private BullDozerControl.BullDozerFactory _bullDozerFactory;

    void Start()
    {
        _plantUpgradable.SetupSettings(_plantConfig);
        CreateBullDozer();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //    _plantUpgradable.Upgrade();
    }    

    void CreateBullDozer()
    {
        _bullDozerFactory.Create(_bullDozerPos);
    }
}
