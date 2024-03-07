using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemSettings : ScriptableObjectInstaller<ItemSettings>
{
    public class Settings
    {
        [field: SerializeField] public float AddDelay { get; private set; }
    }
}
