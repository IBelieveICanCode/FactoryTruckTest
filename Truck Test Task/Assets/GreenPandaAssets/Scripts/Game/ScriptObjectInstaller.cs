using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Scriptable Object Installer", menuName = "Create SO Installer")]
public class ScripObjectInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private PlantConfig plantConfig;
    [SerializeField]
    private PrefabConfig prefabConfig;

    public override void InstallBindings()
    {
        Container.BindInstance(prefabConfig);
        Container.BindInstance(plantConfig);
    }
}
