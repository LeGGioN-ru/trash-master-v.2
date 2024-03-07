using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrashSpawnerInstaller : MonoInstaller
{
    [SerializeField] private Transform _trashSpawnerCenter;
    [SerializeField] private TrashHeap _prefab;
    [SerializeField] private Color _trashZoneColor;

    public override void InstallBindings()
    {
        BoxZone boxZoneInstance = new BoxZone(_trashZoneColor, _trashSpawnerCenter);

        Container.Bind<Zone>().FromInstance(boxZoneInstance);
        Container.Bind<List<IDrawable>>().FromInstance(new List<IDrawable>() { boxZoneInstance });
        Container.BindInterfacesAndSelfTo<TrashSpawner>().AsSingle();
        Container.BindFactory<TrashHeap, TrashHeap.Factory>().FromComponentInNewPrefab(_prefab).AsSingle();
    }
}
