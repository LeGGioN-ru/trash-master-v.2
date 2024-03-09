public class InventoryItemsChangeEvent
{
    public int AmountItems { get; private set; }
    public Item Item { get; private set; }

    public InventoryItemsChangeEvent(int amountItems, Item item)
    {
        AmountItems = amountItems;
        Item = item;
    }
}
