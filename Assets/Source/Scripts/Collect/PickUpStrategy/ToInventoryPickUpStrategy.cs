using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToInventoryPickUpStrategy : IPickUpStrategy
{
    public Quaternion EndRotation => Quaternion.Euler(0, 0, 90);

    private readonly PlayerFacade _playerFacade;
    private readonly IObjectRotateStrategy _objectRotateStrategy;
    private readonly IObjectMoveStrategy _objectMoveStrategy;

    public ToInventoryPickUpStrategy(PlayerFacade playerFacade, IObjectMoveStrategy objectMoveStrategy,
        IObjectRotateStrategy objectRotateStrategy)
    {
        _playerFacade = playerFacade;
        _objectRotateStrategy = objectRotateStrategy;
        _objectMoveStrategy = objectMoveStrategy;
    }

    public void PickUp(ItemFacade item, params Action[] pickUpEnd)
    {
        _playerFacade.Inventory.Add(item.Item);
        pickUpEnd = pickUpEnd.Add(() => _playerFacade.InventoryVisual.AddToParent(item.Item)).Add(_objectRotateStrategy.Stop);
        _objectMoveStrategy.Move(_playerFacade.InventoryVisual.CurrentPoint, item.transform, pickUpEnd);
        _objectRotateStrategy.Rotate(item.transform, EndRotation);
    }
}
