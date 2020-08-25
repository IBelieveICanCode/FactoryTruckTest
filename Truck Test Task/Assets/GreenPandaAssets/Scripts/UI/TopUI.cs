using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.UIScripts
{
    public class TopUI : Singleton<TopUI>
    {
        [Inject]
        private CoinConfig _coinConfig;
        
        private float _coins;

        private void Awake()
        {
            _coins = _coinConfig.Coins;
        }
        private void Start()
        {
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