using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefab Config", menuName = "Create Prefab Config")]
public class PrefabConfig : ScriptableObject
{
    [SerializeField]
    private GameObject plantPrefab, truckPefab, bulldozerPrefab;
    public GameObject PlantPrefab => plantPrefab;
    public GameObject TruckPefab => truckPefab;
    public GameObject BulldozerPrefab => bulldozerPrefab;
}