using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameRoot : MonoInstaller
{
    [SerializeField] private Joystick _joystickPrefab;
    [SerializeField] private Canvas _ui;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private CoroutineManager _coroutineManager;

    public override void InstallBindings()
    {
        InjectInputMove();
        Container.BindInstance(new PlayerModel(_playerTransform)).AsSingle();
        Container.BindInstance(_coroutineManager).AsSingle();
    }

    private void InjectInputMove()
    {
        DeviceType device = SystemInfo.deviceType;

        switch (device)
        {
            case DeviceType.Handheld:
                Container.InstantiatePrefabForComponent<Joystick>(_joystickPrefab, _ui.transform);
                Container.BindInstance(_joystickPrefab).AsSingle();
                Container.BindInterfacesAndSelfTo<JoystickInputMove>().AsSingle();
                break;

            case DeviceType.Desktop:
                Container.BindInterfacesAndSelfTo<KeyboardInputMove>().AsSingle();
                break;

            default:
                throw new InvalidProgramException("Неизвестный и/или недопустимый тип девайса.");
        }
    }
}
