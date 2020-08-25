
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.PlantScripts
{
    public class PlantControl : MonoBehaviour
    {
        [Inject]
        private PlantConfig _plantConfig;
        [SerializeField]
        private PlantUpgradable _plantUpgradable;
        [SerializeField]
        private Transform _startPointForTruck, _finishPointForTruck;
        public Transform StartPointForTruck => _startPointForTruck;
        public Transform FinishPointForTruck => _finishPointForTruck;


        void Start()
        {
            _plantUpgradable.SetupSettings(_plantConfig);
        }

    }
}
