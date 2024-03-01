using UnityEngine;
using Zenject;

public class Rotater : ITickable
{
    private readonly IInputMove _inputMove;
    private readonly Transform _transform;
    private readonly PlayerSettings.MoveSettings _moveSettings;

    private bool _needRotate = true;
    private Vector3 _directionMove;

    public Rotater(IInputMove inputMove, Transform transform, PlayerSettings.MoveSettings moveSettings)
    {
        _inputMove = inputMove;
        _transform = transform;
        _moveSettings = moveSettings;
    }

    public void Tick()
    {
        if (_needRotate)
        {
            if (_inputMove.GetDirectionMove() != Vector2.zero)
            {
                _directionMove = _inputMove.GetDirectionMove();
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(_directionMove.x, 0, _directionMove.y));

                float maxRotationSpeed = _moveSettings.RotateSpeed * Time.deltaTime;

                _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, maxRotationSpeed);
            }
        }
    }
}
