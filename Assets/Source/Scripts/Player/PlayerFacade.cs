using UnityEngine;
using Zenject;

public class PlayerFacade : MonoBehaviour
{
    public PlayerModel PlayerModel { get; private set; }

    [Inject]
    public void Construct(PlayerModel playerModel)
    {
        PlayerModel = playerModel;
    }
}
