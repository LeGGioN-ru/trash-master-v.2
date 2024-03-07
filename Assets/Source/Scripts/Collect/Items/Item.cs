using System;
using UnityEngine;
using Zenject;

public abstract class Item : IActivable
{
    private int _delay = 5;
    private bool _isActive = false;
    private readonly IPickUpStrategy _pickUpStrategy;
    private readonly ItemFacade _itemFacade;

    public bool IsActivable => _isActive;
    public int Delay => _delay;
    public bool CanBeActivated => true;
    public Transform Transform => _itemFacade.transform;

    public Item(IPickUpStrategy pickUpStrategy, ItemFacade itemFacade)
    {
        _pickUpStrategy = pickUpStrategy;
        _itemFacade = itemFacade;
    }

    public virtual void OnEndFly()
    {
        _pickUpStrategy.PickUp();
    }

    public void Activate()
    {
        _isActive = true;
    }
}
