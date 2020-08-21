using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant Config", menuName = "Create Plant Config")]
public class PlantConfig : ScriptableObject
{
    [SerializeField]
    private int _startLevel;
    public int StartLevel => _startLevel;
    [SerializeField]
    private int _maxLevelPlant;
    public int MaxLevelPlant => _maxLevelPlant;

    [SerializeField]
    private int _startPrice;
    public int StartPrice => _startPrice;
    
    [SerializeField]
    private float _priceStepFactor;
    public float PriceStepFactor => _priceStepFactor;

    [SerializeField]
    private List<GameObject> _skins;
    public List<GameObject> Skins => _skins;

   

}