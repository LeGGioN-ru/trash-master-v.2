using UnityEngine;

public class JoystickInputMove : IInputMove
{
    private readonly Joystick _joystick;

    public JoystickInputMove(Joystick joystick)
    {
        _joystick = joystick;
    }

    public Vector2 GetDirectionMove()
    {
        return _joystick.Direction;
    }
}
