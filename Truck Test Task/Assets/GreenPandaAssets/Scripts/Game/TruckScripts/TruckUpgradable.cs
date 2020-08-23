using GreenPandaAssets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckUpgradable : AUpgradable
{
    [SerializeField]
    private TruckView _truckView;

    public void SetupSettings(TruckConfig config, TruckControl truck)
    {
        this.Config = config;
        var skin = ChooseSkin(config.Skins);
        _truckView.SetupView(truck, skin);
    }

    public override void Upgrade()
    {
        base.Upgrade();     
    }

    private GameObject ChooseSkin(List<GameObject> skins)
    {
        int skinLevel = Level / 5;
        if (skinLevel <= skins.Count)
            return skins[Level - 1];
        else
            return null;
    }
}
