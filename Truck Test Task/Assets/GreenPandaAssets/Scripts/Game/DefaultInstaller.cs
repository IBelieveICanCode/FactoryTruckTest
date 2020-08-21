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
        Container.BindFactory<Vector3, Vector3, TruckControl, TruckControl.TruckFactory>()
           .FromComponentInNewPrefab(prefabConfig.TruckPefab)
           .WithGameObjectName("Truck");
    }
}
