
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectZone : TriggerZone<Item>
{
    private readonly PlayerSettings.CollectorSettings _collectorSettings;
    private readonly Inventory _inventory;

    public CollectZone(Zone zone, PlayerSettings.CollectorSettings collectorSettings, Inventory inventory) : base(zone)
    {
        _collectorSettings = collectorSettings;
        _inventory = inventory;
    }

    public override void Initialize()
    {
        Zone.SetSize(_collectorSettings.Size);
    }

    protected override bool GetObjectsInZone(out List<Item> components)
    {
        if (Zone.GetObjectsInZone(out ItemFacade[] facades))
        {
            components = facades.Select(facade => facade.Item).ToList();
            return true;
        }

        components = null;
        return false;
    }

    protected override void OnActivate(Item item)
    {
        if (_inventory.CurrentAmountItems + 1 < _inventory.Settings.MaxItems)
        {
            item.Activate();
        }
    }
}
