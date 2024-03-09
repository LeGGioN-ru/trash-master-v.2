using System.Collections.Generic;
using Zenject;

public class Inventory
{
    public InventorySettings.Settings Settings { get; private set; }
    public int CurrentAmountItems=>_items.Count;
    private readonly SignalBus _signalBus;

    private List<Item> _items = new List<Item>();

    public Inventory(InventorySettings.Settings settings, SignalBus signalBus)
    {
        Settings = settings;
        _signalBus = signalBus;
    }

    public void Add(Item item)
    {
        if (Settings.MaxItems > _items.Count)
        {
            _items.Add(item);
            _signalBus.Fire(new InventoryItemsChangeEvent(_items.Count, item));
        }
    }
}
