using System;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.Scripts
{
    public class PlantUpgradable : AUpgradable
    {
        [Inject]
        private readonly SignalBus _signalBus;
        [SerializeField]
        private PlantView _plantView;
        private int _coinsPerDeliver;
        public int CoinsPerDeliver => _coinsPerDeliver;
    public void SetupSettings(PlantConfig config)
        {
            this.Config = config;
            _plantView.SetupView(Config.Skins);
            _coinsPerDeliver = config.CoinsPerDeliver;
            _signalBus.Subscribe<TruckReachedDestination>(IncreaseCoins);
        }
        
        public override void Upgrade()
        {
            base.Upgrade();
            int skinLevel = Level / 5;
            _coinsPerDeliver += 1;
            _plantView.SetSkinLevel(skinLevel + 1);
        }

        public void IncreaseCoins()
        {
            TopUI.Instance.AddCoins(_coinsPerDeliver);
        }
    }
}