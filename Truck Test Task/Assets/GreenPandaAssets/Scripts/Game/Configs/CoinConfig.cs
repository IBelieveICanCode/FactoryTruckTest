using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin Config", menuName = "Create Coin Config")]
public class CoinConfig : ScriptableObject
{
    [SerializeField]
    private int _coins;
    public int Coins => _coins;

}
