using UnityEngine;

public class KeyboardInputMove : IInputMove
{
    public Vector2 GetDirectionMove()
    {
        return new Vector2(Input.GetAxisRaw(AppConstants.Horizontal), Input.GetAxisRaw(AppConstants.Vertical));
    }
}
