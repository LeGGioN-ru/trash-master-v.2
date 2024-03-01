using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CharacterController _playerController;
    [SerializeField] private Transform _character;
    [SerializeField] private Animator _animator;

    public override void InstallBindings()
    {
        Container.BindInstance(_playerController).AsSingle();
        Container.BindInstance(_character).AsSingle();
        Container.BindInterfacesAndSelfTo<CharacterControllerMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveUser>().AsSingle();
        Container.BindInterfacesAndSelfTo<Rotater>().AsSingle();

        BindAnimations();
    }

    private void BindAnimations()
    {
        Container.BindInstances(_animator);
        Container.BindInterfacesAndSelfTo<MoveAnimation>().AsSingle();
    }
}