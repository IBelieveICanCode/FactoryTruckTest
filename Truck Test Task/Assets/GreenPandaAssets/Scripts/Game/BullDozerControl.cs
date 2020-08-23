using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BullDozerControl : MonoBehaviour, ILoadGoodable
{
    [Inject]
    private BullDozerConfig _config;
    [SerializeField]
    private BullDozerView bullDozerView;
    private bool _isVisited = false;
    public bool IsVisited => _isVisited;
    [Inject]
    private readonly SignalBus _signalBus;
    private IWaitForGoodable _truck;

    [Inject]
    public void Construct(Transform spawnPoint)
    {
        transform.position = spawnPoint.position;
        transform.parent = spawnPoint;
    }
    
    public void Start()
    {
        _signalBus.Subscribe<TruckReachedDestination>(Refresh);
    }
    void Refresh()
    {
        _isVisited = false;
    }
    public void LoadComplete()
    {
        bullDozerView.FinishLoadingAnim();       
        _truck.ResumeMovement();
    }

    public void StartLoadGoods(IWaitForGoodable truck)
    {       
        this._truck = truck;        
        _isVisited = true;
        bullDozerView.LoadGoodsAnim();
        
    }   

    public class BullDozerFactory : PlaceholderFactory<Transform, BullDozerControl> { }
}
