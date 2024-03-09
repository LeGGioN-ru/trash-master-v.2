using Zenject;
using UnityEngine;

public class ItemInstaller : MonoInstaller
{
    [SerializeField] private ItemFacade _itemFacade;
    [SerializeField] private ItemPickUpType _pickUpType;
    [SerializeField] private EndRotateType _endRotateType;

    public override void InstallBindings()
    {
        Container.Bind<Item>().To<Bottle>().AsSingle();
        Container.BindInstance(_itemFacade);
        Container.BindInterfacesAndSelfTo<LinearSpeedMove>().AsSingle();
        Container.BindInterfacesAndSelfTo<LinearSpeedRotation>().AsSingle().WithArguments(_endRotateType);

        if (_pickUpType == ItemPickUpType.ToPlayer)
        {
            Container.Bind<IPickUpStrategy>().To<ToPlayerPickUpStrategy>().AsSingle();
        }
        else if (_pickUpType == ItemPickUpType.ToInventory)
        {
            Container.Bind<IPickUpStrategy>().To<ToInventoryPickUpStrategy>().AsSingle();
        }
    }
}
