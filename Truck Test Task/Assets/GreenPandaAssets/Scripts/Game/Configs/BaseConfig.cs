using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConfig : ScriptableObject
{
    [SerializeField]
    private int _level = 1;
    public int Level => _level;
    [SerializeField]
    private int _maxLevel = 15;
    public int MaxLevel => _maxLevel;

    [SerializeField]
    private int _startPrice = 100;
    public int StartPrice => _startPrice;

    [SerializeField]
    private float _priceStepFactor = 2;
    public float PriceStepFactor => _priceStepFactor;

    [SerializeField]
    private List<GameObject> _skins;
    public List<GameObject> Skins => _skins;
}
