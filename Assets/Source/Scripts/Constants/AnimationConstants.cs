using UnityEngine;

public static class AnimationConstants
{
    public static class MoveAnimtaion
    {
        public static int IsMoving = Animator.StringToHash(nameof(IsMoving));
        public static int IsCarring = Animator.StringToHash(nameof(IsCarring));
    }
}
