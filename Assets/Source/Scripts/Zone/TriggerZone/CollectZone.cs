
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

    protected override bool GetObjectInZone(out Item component)
    {
        if (Zone.GetObjectsInZone(out ItemFacade[] itemsFacades))
        {
            ItemFacade itemFacade = itemsFacades.FirstOrDefault(x => x.Item is IActivable activable && activable.IsActivable == false);

            if (itemFacade != null)
            {
                component = itemFacade.Item;
                return true;
            }
        }

        component = null;
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
