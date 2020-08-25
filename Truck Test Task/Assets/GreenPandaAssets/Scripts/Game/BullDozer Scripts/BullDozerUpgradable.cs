using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.BullDozerScripts
{
    public class BullDozerUpgradable : AUpgradable
    {
        [SerializeField]
        private BullDozerView _bullDozerView;
        private float _animSec;
        private BullDozer _bullDozer;
        public void SetupSettings(BullDozerConfig config, BullDozer bullDozer)
        {
            this.Config = config;
            _animSec = config.AnimationSpeed;
            _bullDozer = bullDozer;
            _bullDozerView.SetupView(config.Skins, _bullDozer);
        }

        public override void Upgrade()
        {
            base.Upgrade();
            int skinLevel = Level / 5;
            _animSec += 0.1f;
            _bullDozer.UpdateAnim(_animSec);
            _bullDozerView.SetSkinLevel(skinLevel + 1);
        }

    }
}