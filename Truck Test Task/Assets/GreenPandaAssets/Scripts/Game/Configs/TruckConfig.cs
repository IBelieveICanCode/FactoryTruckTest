using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Truck Config", menuName = "Create Truck Config")]
public class TruckConfig : BaseConfig
{
    public void Reset()
    {
        Speed = StartSpeed;
    }
}
