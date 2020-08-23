using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Truck Config", menuName = "Create Truck Config")]
public class TruckConfig : BaseConfig
{
    [SerializeField]
    private float _startSpeed = 5f;
    public float StartSpeed => _startSpeed;
}
