using Zenject;
using UnityEngine;

public class ItemInstaller : MonoInstaller
{
    [SerializeField] private ItemFacade _itemFacade;

    public override void InstallBindings()
    {
        Container.Bind<Item>().To<Bottle>().AsSingle();
        Container.BindInstance(_itemFacade);

        Container.Bind<IPickUpStrategy>().To<ToPlayerPickUpStrategy>().AsSingle();
    }
}
