using UnityEngine;

public class Bottle : Item
{
    public Bottle( IPickUpStrategy pickUpStrategy, ItemFacade itemFacade) : base( pickUpStrategy, itemFacade)
    {
    }
}
