using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToPlayerPickUpStrategy : IPickUpStrategy
{
    public Transform PickPoint => _player.PlayerModel.Center;
    private readonly PlayerFacade _player;
    private readonly ItemFacade _item;
    private readonly IObjectMoveStrategy _moveStrategy;

    public ToPlayerPickUpStrategy(PlayerFacade player, ItemFacade item, IObjectMoveStrategy objectMoveStrategy)
    {
        _moveStrategy = objectMoveStrategy;
        _player = player;
        _item = item;
    }

    public void OnEndPickUp()
    {
        GameObject.Destroy(_item.gameObject);
    }

    public void PickUp(ItemFacade item, params Action[] onEndPickUp)
    {
        List<Action> actions = onEndPickUp.ToList();
        actions.Add(OnEndPickUp);
        onEndPickUp = actions.ToArray();

        _moveStrategy.Move(PickPoint, item.transform, onEndPickUp);
    }
}
