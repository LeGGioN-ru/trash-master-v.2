using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerModel
{
    public Transform Transform { get; private set; }
    public Transform Center { get; private set; }

    public PlayerModel(Transform playerTransform, Transform center)
    {
        Transform = playerTransform;
        Center = center;
    }
}
