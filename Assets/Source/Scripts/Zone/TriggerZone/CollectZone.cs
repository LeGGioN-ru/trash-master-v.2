public class CollectZone : TriggerZone<Item>
{
    private readonly PlayerSettings.CollectorSettings _collectorSettings;
    private readonly IObjectMoveStrategy _flyStrategy;
    private readonly PlayerFacade _playerFacade;

    public CollectZone(Zone zone, PlayerSettings.CollectorSettings collectorSettings, IObjectMoveStrategy objectMoveStrategy, PlayerFacade playerFacade) : base(zone)
    {
        _collectorSettings = collectorSettings;
        _flyStrategy = objectMoveStrategy;
        _playerFacade = playerFacade;
    }

    public override void Initialize()
    {
        Zone.SetSize(_collectorSettings.Size);
    }

    protected override bool GetObjectInZone(out Item component)
    {
        if (Zone.GetObjectInZone(out ItemFacade itemFacade))
        {
            component = itemFacade.Item;
            return true;
        }

        component = null;
        return false;
    }

    protected override void OnActivate(Item item)
    {
        item.Activate();
        _flyStrategy.Move(_playerFacade.PlayerModel.Center, item.Transform, item.OnEndFly);
    }
}
