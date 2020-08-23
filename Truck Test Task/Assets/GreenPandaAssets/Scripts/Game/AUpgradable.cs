using UnityEngine;

namespace GreenPandaAssets.Scripts
{
    public abstract class AUpgradable : MonoBehaviour
    {
        [HideInInspector]
        public BaseConfig Config;
        
        private int _level;
        public int Level => _level;

        private void Start()
        {
            _level = Config.Level;
        }
        public virtual void Upgrade()
        {
            _level++;
        }

        public bool IsMax()
        {
            return _level >= Config.MaxLevel;
        }

        public float GetPrice()
        {
            return Config.StartPrice * Mathf.Pow(Config.PriceStepFactor, _level - 1);
        }
    }
}