using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CharacterController _playerController;
    [SerializeField] private Transform _character;
    [SerializeField] private Transform _centerCharacter;
    [SerializeField] private Animator _animator;
    [SerializeField] private Drawer _drawer;
    [SerializeField] private Color _collecterZoneColor;
    [Header("Inventory")]
    [SerializeField] private List<Transform> _inventoryPoints = new List<Transform>();
    [SerializeField] private InventoryRig.Container _container;
    public override void InstallBindings()
    {
        PlayerModel playerModel = new PlayerModel(_character, _centerCharacter);
        Container.BindInterfacesAndSelfTo<LinearSpeedRotation>().AsSingle();
        Container.BindInstance(playerModel.Transform);
        Container.BindInstance(playerModel);

        Container.Bind<IObjectMoveStrategy>().To<LinearSpeedMove>().AsSingle();
        Container.BindInstance(_playerController).AsSingle();
        Container.BindInterfacesAndSelfTo<CharacterControllerMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveUser>().AsSingle();
        Container.BindInterfacesAndSelfTo<Rotater>().AsSingle();

        BindCollector();
        BindAnimations();
        BindInventory();
    }

    private void BindAnimations()
    {
        Container.BindInstances(_animator);
        Container.BindInterfacesAndSelfTo<MoveAnimation>().AsSingle();
        Container.BindInterfacesAndSelfTo<CarryItemsAnimation>().AsSingle();
    }

    private void BindInventory()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().AsSingle().NonLazy();
        Container.DeclareSignal<InventoryItemsChangeEvent>();

        Container.Bind<InventoryRig>().AsSingle().WithArguments(_inventoryPoints, _container).NonLazy();
        Container.Bind<InventoryVisual>().To<InventoryRig>().FromResolve();
        Container.Bind<IInitializable>().To<InventoryRig>().FromResolve();
        Container.Bind<IDisposable>().To<InventoryRig>().FromResolve();
        Container.Bind<ITickable>().To<InventoryRig>().FromResolve();
    }

    private void BindCollector()
    {
        Container.BindInterfacesAndSelfTo<CollectZone>().AsSingle();
        SphereZone sphereZone = new SphereZone(_collecterZoneColor, _character);
        Container.Bind<Zone>().To<SphereZone>().FromInstance(sphereZone);
        Container.Bind<List<IDrawable>>().FromInstance(new List<IDrawable>() { sphereZone });
    }
}