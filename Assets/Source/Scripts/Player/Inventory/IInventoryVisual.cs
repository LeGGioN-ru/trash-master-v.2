using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class InventoryVisual : IInitializable, IDisposable
{
    public Transform CurrentPoint => _pointsInventory[_inventory.CurrentAmountItems - 1];

    protected List<Transform> _pointsInventory = new List<Transform>();
    private readonly SignalBus _signalBus;
    private readonly Inventory _inventory;

    public InventoryVisual(SignalBus signalBus, List<Transform> pointsInventory, Inventory inventory)
    {
        _signalBus = signalBus;
        _inventory = inventory;
        _pointsInventory = pointsInventory;
    }

    public void Initialize()
    {
        _signalBus.Subscribe<InventoryItemsChangeEvent>(OnScoreChange);
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<InventoryItemsChangeEvent>(OnScoreChange);
    }

    public void AddToParent(Item item)
    {
        item.Transform.parent = CurrentPoint;
    }

    protected abstract void OnScoreChange(InventoryItemsChangeEvent inventoryItemsChangeEvent);
    public abstract void EnableVisual();
    public abstract void DisableVisual();
}
