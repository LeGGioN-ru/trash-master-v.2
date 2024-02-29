using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObjectInstaller<PlayerSettings>
{
    [SerializeField] private MoveSettings _moveSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(_moveSettings).AsSingle();
    }

    [Serializable]
    public class MoveSettings
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
    }
}


