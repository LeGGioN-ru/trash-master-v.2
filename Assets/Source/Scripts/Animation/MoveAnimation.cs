using UnityEngine;
using Zenject;

public class MoveAnimation : IAnimation, ITickable
{
    private readonly Animator _animator;
    private readonly IInputMove _inputMove;

    public MoveAnimation(Animator animator, IInputMove inputMove)
    {
        _animator = animator;
        _inputMove = inputMove;
    }

    public void EnableAnimation()
    {
        _animator.SetBool(AnimationConstants.MoveAnimtaion.IsMoving, true);
    }

    public void DisableAnimation()
    {
        _animator.SetBool(AnimationConstants.MoveAnimtaion.IsMoving, false);
    }

    public void Tick()
    {
        if (_inputMove.GetDirectionMove() != Vector2.zero)
            EnableAnimation();
        else
            DisableAnimation();
    }
}
