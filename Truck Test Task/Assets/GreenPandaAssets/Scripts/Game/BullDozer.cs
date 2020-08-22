using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BullDozer : MonoBehaviour, ILoadGoodable
{
    [SerializeField]
    private GameObject _rock;
    [SerializeField]
    private Animator _animator;
    private bool _isLoading = false;
    private bool _isVisited = false;
    public bool IsLoading => _isLoading; 
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
        PutRock();
        _isLoading = false;
        _truck.ResumeMovement();
    }

    public void StartLoadGoods(IWaitForGoodable truck)
    {
        if (!_isLoading)
        {
            this._truck = truck;
            _animator.SetTrigger("Loading");
            _isLoading = true;
            _isVisited = true;
        }
    }

    void TakeRock()
    {
        _rock.SetActive(true);
    }

    void PutRock()
    {
        _rock.SetActive(false);
    }

    public class BullDozerFactory : PlaceholderFactory<Transform, BullDozer> { }
}
