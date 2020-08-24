using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GreenPandaAssets.BullDozerScripts
{
    public class BullDozerView : MonoBehaviour
    {
        private List<GameObject> _bullDozerSkins = new List<GameObject>();
        private int _currentSkinLevel = 1;
        private BullDozer _bullDozer;

        public void SetupView(List<GameObject> skins, BullDozer bullDozer)
        {
            _bullDozer = bullDozer;
            SetupAvailableSkins(skins);
            UpdateSkin(_currentSkinLevel);
        }

        private void SetupAvailableSkins(List<GameObject> skins)
        {
            ClearAllSkins();
            foreach (GameObject skin in skins)
            {
                GameObject mySkin = Instantiate(skin, _bullDozer.SkinPlace.transform);
                mySkin.transform.parent = _bullDozer.SkinPlace.transform;
                mySkin.gameObject.SetActive(false);
                _bullDozerSkins.Add(mySkin);
            }
        }
        private void ClearAllSkins()
        {
            foreach (Transform child in _bullDozer.SkinPlace.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void SetSkinLevel(int skinLevel)
        {
            _currentSkinLevel = skinLevel;
            UpdateSkin(_currentSkinLevel);
        }
        public void UpdateSkin(int skinLevel)
        {
            if (skinLevel <= _bullDozerSkins.Count)
            {
                _bullDozerSkins[skinLevel - 1].SetActive(true);
            }
        }
    }
}
