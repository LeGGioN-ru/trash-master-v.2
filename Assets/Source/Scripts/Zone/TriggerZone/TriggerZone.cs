using System;
using UnityEngine;
using Zenject;

public abstract class TriggerZone<T> : IInitializable, ITickable
{
    protected Zone Zone;
    private float _delay;
    private bool _isActive = true;

    public TriggerZone(Zone zone)
    {
        Zone = zone;
    }

    public abstract void Initialize();

    public void AddDelay(float delay)
    {
        if (delay < 0)
            throw new ArgumentException("Задержка не может быть отрицательной!");

        _delay += delay;
    }

    public void Tick()
    {
        if (_isActive == false)
            return;

        if (_delay > 0)
        {
            _delay -= Time.deltaTime;
            return;
        }

        if (GetObjectInZone(out T component))
        {
            if (component is ITouchable touchable && touchable.CanBeTouched)
            {
                touchable.Touch();
            }

            if (component is IActivable activable && activable.IsActivable == false && activable.CanBeActivated)
            {
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

    protected abstract bool GetObjectInZone(out T component);
}