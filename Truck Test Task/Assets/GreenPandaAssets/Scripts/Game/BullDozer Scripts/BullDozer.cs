using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.BullDozerScripts
{
    public class BullDozer : MonoBehaviour
    {
        [SerializeField]
        private BullDozerAnim _bullDozeranim;
        [Inject]
        BulldozerManager _manager;
        [SerializeField]
        private Transform _skinPlace;
        public Transform SkinPlace => _skinPlace;
        [Inject]
        public void Construct(Transform spawnPoint, BullDozerConfig config)
        {
            transform.position = spawnPoint.position;
            transform.parent = spawnPoint;
            _bullDozeranim.SetAnimSettings(config.AnimationSpeed);
        }

        public void UpdateAnim(float animSec)
        {
            _bullDozeranim.SpeedUpAnim(animSec);
        }

        public class BullDozerFactory : PlaceholderFactory<Transform, BullDozerConfig, BullDozer> { }
    }
}