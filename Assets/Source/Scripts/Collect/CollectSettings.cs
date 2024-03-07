using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "CollectSettings", menuName = "CollectSettings/CollectZone", order = 3)]
public class CollectSettings : ScriptableObjectInstaller<CollectSettings>
{
    [SerializeField] private Settings _settings;

    public override void InstallBindings()
    {
        Container.BindInstance(_settings);
    }

    [Serializable]
    public class Settings
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}
