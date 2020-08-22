using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantView : MonoBehaviour
{
    [SerializeField]
    private Transform _skinPlace;
    public List<GameObject> PlantSkins;

    private float _animDuration = .5f;
    private Animator _anim;
    private int _currentSkinLevel = 1;
    
    public void SetupView()
    {
        SetupAvailableSkins();
        _anim = GetComponent<Animator>();
        UpdateSkin(_currentSkinLevel);
    }

    private void SetupAvailableSkins()
    {
        ClearAllSkins();
        foreach (GameObject skin in PlantSkins)
        {
            GameObject mySkin = Instantiate(skin, _skinPlace);
            mySkin.transform.parent = _skinPlace.transform;
        }
    }

    private void ClearAllSkins()
    {
        foreach (Transform child in _skinPlace.transform)
        {
            Destroy(child.gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var skin = _currentSkinLevel + 1;
            SetSkinLevel(skin);
        }
    }

    public void SetSkinLevel(int skinLevel)
    {
        _anim.SetBool("isUpgrading", true);

        _currentSkinLevel = skinLevel;

        StartCoroutine(WaitForSkinUpdate());
    }

    private IEnumerator WaitForSkinUpdate()
    {
        yield return new WaitForSeconds(_animDuration / 2);
        _anim.SetBool("isUpgrading", false);
        UpdateSkin(_currentSkinLevel);
    }
    
    private void UpdateSkin(int skinLevel)
    {
        if (skinLevel <= PlantSkins.Count)
        {
            PlantSkins[skinLevel - 1].SetActive(true);
        }
        else
            print("Max Level Reached");
    }
}

