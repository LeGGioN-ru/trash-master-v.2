using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CharacterController _playerController;
    [SerializeField] private Transform _character;
    [SerializeField] private Transform _centerCharacter;
    [SerializeField] private Animator _animator;
    [SerializeField] private Drawer _drawer;
    [SerializeField] private Color _collecterZoneColor;

    public override void InstallBindings()
    {
        PlayerModel playerModel = new PlayerModel(_character, _centerCharacter);
        Container.BindInstance(playerModel.Transform);
        Container.BindInstance(playerModel);

        Container.Bind<IObjectMoveStrategy>().To<FlyToPointStrategy>().AsSingle();
        Container.BindInstance(_playerController).AsSingle();
        Container.BindInterfacesAndSelfTo<CharacterControllerMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveUser>().AsSingle();
        Container.BindInterfacesAndSelfTo<Rotater>().AsSingle();

        BindCollector();
        BindAnimations();
    }

    private void BindCollector()
    {
        Container.BindInterfacesAndSelfTo<CollectZone>().AsSingle();
        SphereZone sphereZone = new SphereZone(_collecterZoneColor, _character);
        Container.Bind<Zone>().To<SphereZone>().FromInstance(sphereZone);
        Container.Bind<List<IDrawable>>().FromInstance(new List<IDrawable>() { sphereZone });
    }

    private void BindAnimations()
    {
        Container.BindInstances(_animator);
        Container.BindInterfacesAndSelfTo<MoveAnimation>().AsSingle();
    }
}