using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant Config", menuName = "Create Plant Config")]
public class PlantConfig : BaseConfig
{

    [SerializeField]
    private int _coinsPerDeliver = 1;
    public int CoinsPerDeliver => _coinsPerDeliver;
}