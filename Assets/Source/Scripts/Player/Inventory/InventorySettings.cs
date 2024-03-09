using System;
using UnityEngine;
using Zenject;
[CreateAssetMenu(fileName ="Inventory Settings",menuName ="Inventory/Settings",order =5)]
public class InventorySettings : ScriptableObjectInstaller<InventorySettings>
{
    [SerializeField] private Settings _settings;

    public override void InstallBindings()
    {
        Container.BindInstance(_settings);
    }

    [Serializable]
    public class Settings
    {
        [field: SerializeField] public int MaxItems { get; private set; }
    }
}
