using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Scriptable Object Installer", menuName = "Create SO Installer")]
public class ScripObjectInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private CoinConfig _coinConfig;
    [SerializeField]
    private TruckConfig _truckConfig;
    [SerializeField]
    private BullDozerConfig _bullDozerConfig;
    [SerializeField]
    private PlantConfig _plantConfig;
    [SerializeField]
    private PrefabConfig _prefabConfig;

    public override void InstallBindings()
    {
        Container.BindInstance(_prefabConfig);
        Container.BindInstance(_plantConfig);
        Container.BindInstance(_bullDozerConfig);
        Container.BindInstance(_truckConfig);
        Container.BindInstance(_coinConfig);
    }
}
