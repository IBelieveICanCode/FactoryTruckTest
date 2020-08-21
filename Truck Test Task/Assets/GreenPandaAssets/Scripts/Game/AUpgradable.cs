using UnityEngine;

namespace GreenPandaAssets.Scripts
{
    public abstract class AUpgradable : MonoBehaviour
    {
        protected int _level;

        public int Level => _level;

        protected int _maxLevel;
        protected float _startPrice;
        protected float _priceStepFactor;       
        
        public virtual void Upgrade()
        {
            _level++;
        }

        public bool IsMax()
        {
            return _level >= _maxLevel;
        }

        public float GetPrice()
        {
            return _startPrice * Mathf.Pow(_priceStepFactor, _level - 1);
        }
    }
}