using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class GameSignalsInstaller : Installer<GameSignalsInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<StartLoadingGoodsInTruck>();
        Container.DeclareSignal<FinishLoadingGoodsInTruck>();

        Container.BindSignal<StartLoadingGoodsInTruck>().ToMethod<BullDozer>(x => x.StartLoadGoods).FromResolveAll();
        Container.BindSignal<FinishLoadingGoodsInTruck>().ToMethod<TruckControl>(x => x.ContinueMovement).FromResolveAll();
        // Include these just to ensure BindSignal works
        //Container.BindSignal<PlayerDiedSignal>().ToMethod<PlayerDiedSignalObserver>(x => x.OnPlayerDied).FromNew();
        //Container.BindSignal<EnemyKilledSignal>().ToMethod(() => Debug.Log("Fired EnemyKilledSignal"));
    }
}