using UnityEngine;
using Zenject;

public class ItemFacade : MonoBehaviour
{
    public Item Item { get; private set; }

    [Inject]
    public void Construct(Item item)
    {
        Item = item;
    }

    public class Factory : PlaceholderFactory<ItemFacade>
    {

    }
}
