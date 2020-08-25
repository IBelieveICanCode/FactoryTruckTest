using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;
public class GameSignalsInstaller : Installer<GameSignalsInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<TruckReachedDestination>();

        //Container.BindSignal<StartLoadingGoodsInTruck>().ToMethod<BullDozer>(x => x.StartLoadGoods).FromResolveAll();
        Container.BindSignal<TruckReachedDestination>().ToMethod<TruckManager>(x => x.UnloadTruck).FromResolveAll();
    }
}