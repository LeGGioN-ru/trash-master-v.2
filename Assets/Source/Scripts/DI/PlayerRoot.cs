using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

public class PlayerRoot : MonoInstaller
{
    [SerializeField] private List<Transform> _inventoryPoints = new List<Transform>();
    [SerializeField] private Rig _rig;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().AsSingle();
        Container.DeclareSignal<InventoryItemsChangeEvent>();

        Container.Bind<InventoryRig>().AsSingle().WithArguments(_inventoryPoints, _rig).NonLazy();
        Container.Bind<InventoryVisual>().To<InventoryRig>().FromResolve();
        Container.Bind<IInitializable>().To<InventoryRig>().FromResolve();
        Container.Bind<IDisposable>().To<InventoryRig>().FromResolve();
    }
}
