using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.BullDozerScripts
{
    public class BulldozerManager : MonoBehaviour
    {
        [SerializeField]
        private BullDozerUpgradable _bullDozerUpgradable;
        [Inject]
        private BullDozerConfig _config;
        [Inject]
        private BullDozer.BullDozerFactory _bullDozerFactory;

        private BullDozer _createdBullDozer;
        private void Start()
        {
            CreateBullDozer();
        }

        void CreateBullDozer()
        {
            _createdBullDozer = _bullDozerFactory.Create(transform, _config);
            _bullDozerUpgradable.SetupSettings(_config, _createdBullDozer);
        }
    }
}