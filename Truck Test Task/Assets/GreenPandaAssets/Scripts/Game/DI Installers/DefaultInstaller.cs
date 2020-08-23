using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    [Inject]
    private PrefabConfig prefabConfig;
    public override void InstallBindings()
    {
        GameSignalsInstaller.Install(Container);
        Container.BindFactory<TruckConfig, TruckControl, TruckControl.TruckFactory>()
            .FromComponentInNewPrefab(prefabConfig.TruckPefab)
            .WithGameObjectName("Truck");
        Container.BindFactory<Transform, BullDozerControl, BullDozerControl.BullDozerFactory>()
            .FromComponentInNewPrefab(prefabConfig.BulldozerPrefab)
            .WithGameObjectName("Bulldozer");
        Container.Bind<TruckControl>().AsCached();
    }
}
