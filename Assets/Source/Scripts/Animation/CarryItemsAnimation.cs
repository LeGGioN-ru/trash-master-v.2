using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarryItemsAnimation : IAnimation, ITickable
{
    private readonly Inventory _inventory;
    private readonly Animator _animator;

    public CarryItemsAnimation(Inventory inventory, Animator animator)
    {
        _inventory = inventory;
        _animator = animator;
    }

    public void DisableAnimation()
    {
        _animator.SetBool(AnimationConstants.MoveAnimtaion.IsCarring, false);
    }

    public void EnableAnimation()
    {
        _animator.SetBool(AnimationConstants.MoveAnimtaion.IsCarring, true);
    }

    public void Tick()
    {
        if (_inventory.CurrentAmountItems > 0)
            EnableAnimation();
        else
            DisableAnimation();
    }
}
