using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantView : MonoBehaviour
{
    public List<GameObject> FactorySkins;

    private float _animDuration = .5f;
    private Animator _anim;
    private int _currentSkinLevel = 1;
    
    void Start()
    {
        AddAllAvailableSkins();
        _anim = GetComponent<Animator>();
        UpdateSkin(_currentSkinLevel);
    }

    private void AddAllAvailableSkins()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            child.gameObject.SetActive(false);
            FactorySkins.Add(child.gameObject);
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
        if (skinLevel <= FactorySkins.Count)
        {
            FactorySkins[skinLevel - 1].SetActive(true);
        }
        else
            print("Max Level Reached");
    }
}

