using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
public class TruckView : MonoBehaviour
{
    private TruckControl _myTruck;

    public void SetupView(TruckControl truck, GameObject skin)
    {
        _myTruck = truck;
        SetupAvailableSkin(skin);
    }

    private void SetupAvailableSkin(GameObject skin)
    {      
        GameObject mySkin = Instantiate(skin, transform);
        mySkin.transform.parent = transform;        
    }
}
