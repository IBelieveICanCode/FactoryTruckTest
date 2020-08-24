using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GreenPandaAssets.BullDozerScripts;
public class DefaultInstaller : MonoInstaller
{
    [Inject]
    private PrefabConfig prefabConfig;
    public override void InstallBindings()
    {
        GameSignalsInstaller.Install(Container);        
        Container.BindFactory<TruckConfig, Truck, Truck.TruckFactory>()
            .FromComponentInNewPrefab(prefabConfig.TruckPefab)
            .WithGameObjectName("Truck");
        Container.BindFactory<Transform, BullDozerConfig, BullDozer, BullDozer.BullDozerFactory>()
            .FromComponentInNewPrefab(prefabConfig.BulldozerPrefab)
            .WithGameObjectName("Bulldozer");
    }
}
