using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
public class TruckView : MonoBehaviour
{
    private Truck _myTruck;

    public void SetupView(Truck truck, GameObject skin)
    {
        _myTruck = truck;
        SetupAvailableSkin(skin);
    }

    private void SetupAvailableSkin(GameObject skin)
    {      
        GameObject mySkin = Instantiate(skin, _myTruck.transform);
        mySkin.transform.parent = _myTruck.transform;        
    }

}
