using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TrashSpawnerSettings", menuName = "Trash/TrashSpawner/Settings", order = 2)]
public class TrashSpawnerSettings : ScriptableObjectInstaller<TrashSpawnerSettings>
{
    [SerializeField] private Settings _settings;

    public override void InstallBindings()
    {
        Container.BindInstance(_settings);
    }

    [Serializable]
    public class Settings
    {
        [field: SerializeField] public Vector3 Size { get; private set; }
        [field: SerializeField] public int MaxHeaps { get; private set; }
        [field: SerializeField] public float SpawnDelay { get; private set; }
        [field: SerializeField] public float MinDistanceBetweenPlayer { get; private set; }
    }
}
