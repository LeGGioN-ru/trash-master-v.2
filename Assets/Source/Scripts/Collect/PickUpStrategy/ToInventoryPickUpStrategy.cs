using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToInventoryPickUpStrategy : IPickUpStrategy
{
    public Quaternion EndRotation => Quaternion.Euler(0, 0, 90);

    private readonly Inventory _inventory;
    private readonly InventoryVisual _visual;
    private readonly IObjectRotateStrategy _objectRotateStrategy;
    private readonly IObjectMoveStrategy _objectMoveStrategy;

    public ToInventoryPickUpStrategy(Inventory inventory, InventoryVisual inventoryVisual, IObjectMoveStrategy objectMoveStrategy,
        IObjectRotateStrategy objectRotateStrategy)
    {
        _inventory = inventory;
        _visual = inventoryVisual;
        _objectRotateStrategy = objectRotateStrategy;
        _objectMoveStrategy = objectMoveStrategy;
    }

    public void PickUp(ItemFacade item, params Action[] pickUpEnd)
    {
        _inventory.Add(item.Item);
        pickUpEnd = pickUpEnd.Add(() => _visual.AddToParent(item.Item)).Add(_objectRotateStrategy.Stop);
        _objectMoveStrategy.Move(_visual.CurrentPoint, item.transform, pickUpEnd);
        _objectRotateStrategy.Rotate(item.transform, EndRotation);
    }
}
