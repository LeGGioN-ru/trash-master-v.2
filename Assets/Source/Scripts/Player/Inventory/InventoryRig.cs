using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

public class InventoryRig : InventoryVisual
{
    private readonly Rig _inventoryRig;

    public InventoryRig(SignalBus signalBus, List<Transform> transforms, Inventory inventory, Rig rig) : base(signalBus, transforms, inventory)
    {
        _inventoryRig = rig;
    }

    protected override void OnScoreChange(InventoryItemsChangeEvent inventoryItemsChangeEvent)
    {
        if (inventoryItemsChangeEvent.AmountItems > 0)
        {
            EnableVisual();
        }
        else
        {
            DisableVisual();
        }
    }

    public override void EnableVisual()
    {
        _inventoryRig.weight = 1;
    }

    public override void DisableVisual()
    {
        _inventoryRig.weight = 0;
    }
}
