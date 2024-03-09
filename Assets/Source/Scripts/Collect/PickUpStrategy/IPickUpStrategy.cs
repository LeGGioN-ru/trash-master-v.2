using System;
using UnityEngine;

public interface IPickUpStrategy
{
    public void PickUp(ItemFacade item,params Action[] onEndPickUp);
}
