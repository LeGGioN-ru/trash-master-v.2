using UnityEngine;

public class PlayerModel
{
    public Transform Transform { get; private set; }

    public PlayerModel(Transform playerTransform)
    {
        Transform = playerTransform;
    }
}
