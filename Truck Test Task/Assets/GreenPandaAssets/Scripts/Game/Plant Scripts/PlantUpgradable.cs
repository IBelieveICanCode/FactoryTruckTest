using System;
using UnityEngine;

namespace GreenPandaAssets.Scripts
{
    public class PlantUpgradable : AUpgradable
    {
        [SerializeField]
        private PlantView _plantView;

        public void SetupSettings(PlantConfig config)
        {
            this.Config = config;
            _plantView.SetupView(Config.Skins);
        }
        
        public override void Upgrade()
        {
            base.Upgrade();
            int skinLevel = Level / 5;
            print(skinLevel);
            _plantView.SetSkinLevel(skinLevel + 1);
        }
    }
}