using UnityEngine;
using Zenject;

public class PlayerFacade : MonoBehaviour
{
    public PlayerModel PlayerModel { get; private set; }
    public InventoryVisual InventoryVisual { get; private set; }
    public Inventory Inventory { get; private set; }

    [Inject]
    public void Construct(PlayerModel playerModel, InventoryVisual inventoryVisual,Inventory inventory)
    {
        PlayerModel = playerModel;
        Inventory = inventory;
        InventoryVisual = inventoryVisual;
    }
}
