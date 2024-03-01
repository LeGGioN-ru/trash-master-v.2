using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameRoot : MonoInstaller
{
    [SerializeField] private Joystick _joystickPrefab;
    [SerializeField] private Canvas _ui;

    public override void InstallBindings()
    {
        InjectInputMove();
    }

    private void InjectInputMove()
    {
        DeviceType device = SystemInfo.deviceType;

        switch (device)
        {
            case DeviceType.Handheld:
                Joystick joystick = Container.InstantiatePrefabForComponent<Joystick>(_joystickPrefab, _ui.transform);
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
