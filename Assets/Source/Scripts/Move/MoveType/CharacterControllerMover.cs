using UnityEngine;

public class CharacterControllerMover : IMover
{
    private readonly CharacterController _characterController;
    private readonly PlayerSettings.MoveSettings _moveSettings;

    public CharacterControllerMover(CharacterController characterController, PlayerSettings.MoveSettings moveSettings)
    {
        _characterController = characterController;
        _moveSettings = moveSettings;
    }

    public void Move(Vector2 direction)
    {
        _characterController.Move(_moveSettings.MoveSpeed * Time.fixedDeltaTime * new Vector3(direction.x, 0, direction.y));
    }
}
