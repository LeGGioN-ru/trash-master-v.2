using System;
using UnityEngine;
using Zenject;

public abstract class Item : IActivable
{
    private bool _isActive = false;
    private readonly IPickUpStrategy _pickUpStrategy;
    private readonly ItemFacade _itemFacade;

    public bool IsActivable => _isActive;
    public bool CanBeActivated => true;
    public Transform Transform => _itemFacade.transform;

    public Item(IPickUpStrategy pickUpStrategy, ItemFacade itemFacade)
    {
        _pickUpStrategy = pickUpStrategy;
        _itemFacade = itemFacade;
    }

    public virtual void OnEndFly()
    {

    }

    public void Activate()
    {
        if (_isActive == false)
        {
            _isActive = true;
            _pickUpStrategy.PickUp(_itemFacade, OnEndFly);
        }
    }
}
