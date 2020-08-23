using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantView : MonoBehaviour
{
    [SerializeField]
    private Transform _skinPlace;
    private List<GameObject> _plantSkins = new List<GameObject>();
    private int _currentSkinLevel = 1;
    
    private float _animDuration = .5f;
    private Animator _anim;
      
    private Timer _timer;
    
    public void SetupView(List<GameObject> skins)
    {
        SetupAvailableSkins(skins);
        _anim = GetComponent<Animator>();
        UpdateSkin(_currentSkinLevel);
    }

    private void SetupAvailableSkins(List<GameObject> skins)
    {
        ClearAllSkins();
        foreach (GameObject skin in skins)
        {
            GameObject mySkin = Instantiate(skin, _skinPlace);
            mySkin.transform.parent = _skinPlace.transform;
            mySkin.gameObject.SetActive(false);
            _plantSkins.Add(mySkin);
        }
    }

    private void ClearAllSkins()
    {
        foreach (Transform child in _skinPlace.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetSkinLevel(int skinLevel)
    {
        _anim.SetBool("isUpgrading", true);
        _currentSkinLevel = skinLevel;
        _timer = new Timer(_animDuration / 2, AnimSkinUpdate);
        _timer.Restart();
    }

    private void AnimSkinUpdate()
    {
        _anim.SetBool("isUpgrading", false);
        UpdateSkin(_currentSkinLevel);
    }
    
    private void UpdateSkin(int skinLevel)
    {
        if (skinLevel <= _plantSkins.Count)
        {
            _plantSkins[skinLevel - 1].SetActive(true);
        }
        else
            print("Max Level Reached");
    }
}

