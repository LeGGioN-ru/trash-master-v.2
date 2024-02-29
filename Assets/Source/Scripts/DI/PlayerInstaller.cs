using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CharacterController _playerController;

    public override void InstallBindings()
    {
        Container.BindInstance(_playerController).AsSingle();
        Container.BindInterfacesAndSelfTo<CharacterControllerMover>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveUser>().AsSingle();
    }
}