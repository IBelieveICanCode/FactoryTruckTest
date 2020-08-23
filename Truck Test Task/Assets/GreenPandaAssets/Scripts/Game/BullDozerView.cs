using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullDozerView : MonoBehaviour
{
    private bool _isLoading = false;
    public bool IsLoading => _isLoading;
    [SerializeField]
    private GameObject _rock;
    [SerializeField]
    private Animator _animator;

    public void LoadGoodsAnim()
    {
        if (!_isLoading)
        {
            _animator.SetTrigger("Loading");
            _isLoading = true;
        }
    }

    
    public void TakeRock() //activate inside Animation Events
    {
        _rock.SetActive(true);
    }

    public void FinishLoadingAnim()
    {
        _rock.SetActive(false);
        _isLoading = false;
    }
}
