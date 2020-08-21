using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BullDozer : MonoBehaviour, ILoadGoodable
{
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private Animator animator;
    private bool isLoading = false;
    private bool isVisited = false;
    public bool IsLoading => isLoading; 
    public bool IsVisited => isVisited;

    [Inject]
    readonly SignalBus signalBus;
    public void LoadComplete()
    {
        PutRock();
        isLoading = false;
        signalBus.Fire<FinishLoadingGoodsInTruck>();
    }

    public void StartLoadGoods()
    {
        if (!isLoading)
        {            
            animator.SetTrigger("Loading");
            isLoading = true;
            isVisited = true;
        }
    }

    void TakeRock()
    {
        rock.SetActive(true);
    }

    void PutRock()
    {
        rock.SetActive(false);
    }

}
