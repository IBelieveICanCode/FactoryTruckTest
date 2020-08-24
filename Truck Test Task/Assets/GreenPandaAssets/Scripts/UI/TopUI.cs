using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.Scripts
{
    public class TopUI : MonoBehaviour
    {
        [Inject]
        private CoinConfig _coinConfig;
        public static TopUI Instance;
        
        private float _coins;

        private void Awake()
        {
            _coins = _coinConfig.Coins;
        }
        private void Start()
        {
            Instance = this;
            CoinsText.text = "x" + _coins;
        }
        public void AddCoins(int amount)
        {
            Coins += amount;
            print(_coins);
        }
        public float Coins
        {
            get { return _coins; }
            set
            {
                _coins = value;
                CoinsText.text = "x" + _coins;
            }
        }

        public TextMeshProUGUI CoinsText;


    }
}