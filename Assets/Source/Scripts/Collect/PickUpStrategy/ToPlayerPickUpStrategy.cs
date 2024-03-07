using UnityEngine;

public class ToPlayerPickUpStrategy : IPickUpStrategy
{
    public Transform PickPoint => _player.PlayerModel.Center;
    public Quaternion EndRotation => _item.transform.rotation;

    private readonly PlayerFacade _player;
    private readonly ItemFacade _item;

    public ToPlayerPickUpStrategy(PlayerFacade player, ItemFacade item)
    {
        _player = player;
        _item = item;
    }

    public void PickUp()
    {
        GameObject.Destroy(_item.gameObject);
    }
}
