using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class TriggerZone<T> : IInitializable, IFixedTickable
{
    protected Zone Zone;
    private bool _isActive = true;

    public TriggerZone(Zone zone)
    {
        Zone = zone;
    }

    public abstract void Initialize();

    public void FixedTick()
    {
        if (_isActive == false)
            return;

        if (GetObjectsInZone(out List<T> components))
        {
            foreach (var component in components)
            {
                if (component is IActivable activable && activable.CanBeActivated && activable.IsActivable == false)
                    OnActivate(component);
            }
        }
    }

    protected abstract void OnActivate(T component);

    public void TrunOn()
    {
        _isActive = true;
    }

    public void TurnOff()
    {
        _isActive = false;
    }

    protected abstract bool GetObjectsInZone(out List<T> components);
}