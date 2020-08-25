using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.BullDozerScripts
{

    [RequireComponent(typeof(Animator))]
    public class BullDozerAnim : MonoBehaviour, ILoadGoodable
    {
        #region LoadGoods
        [SerializeField]
        private GameObject _rock;

        private IWaitForGoodable _truck;

        private bool _isLoading = false;
        public bool IsLoading => _isLoading;
        private bool _isVisited = false;
        public bool IsVisited => _isVisited;

        [Inject]
        private readonly SignalBus _signalBus;

        [SerializeField]
        private Animator _animator;
        public void SetAnimSettings(float speed)
        {
            _animator.speed = speed;
            _signalBus.Subscribe<TruckReachedDestination>(Refresh);
        }

        public void SpeedUpAnim(float anim)
        {
            _animator.speed += anim;
        }
        void Refresh()
        {
            _isVisited = false;
        }
        public void LoadComplete() //called from animation event
        {
            FinishLoadingAnim();
            _truck.ResumeMovement();
        }

        public void StartLoadGoods(IWaitForGoodable truck)
        {
            this._truck = truck;
            _isVisited = true;
            LoadGoodsAnim();
        }

        public void LoadGoodsAnim()
        {
            _animator.SetBool("loading", true);
        }

        public void TakeRock() //activated inside Animation Events
        {
            _rock.SetActive(true);
        }

        public void FinishLoadingAnim()
        {
            _rock.SetActive(false);
            _animator.SetBool("loading", false);
        }
        #endregion
    }
}