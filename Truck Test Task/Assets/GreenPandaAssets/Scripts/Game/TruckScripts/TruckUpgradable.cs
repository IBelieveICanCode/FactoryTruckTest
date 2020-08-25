using GreenPandaAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckUpgradable : AUpgradable
{
    [SerializeField]
    private TruckView _truckView;
    public void SetupSettings(TruckConfig config, Truck truck)
    {
        this.Config = config;
        var skin = ChooseSkin(config.Skins);
        _truckView.SetupView(truck, skin);
    }

    public override void Upgrade()
    {
        base.Upgrade();
        Config.Speed += 5;
    }

    private GameObject ChooseSkin(List<GameObject> skins)
    {
        int skinLevel = 1 + (Level / 5);
        if (skinLevel <= skins.Count)
            return skins[skinLevel - 1];
        else
            return skins[skins.Count - 1];
    }
}
