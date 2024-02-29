using Zenject;

public class MoveUser : ITickable
{
    private readonly IInputMove _inputMove;
    private readonly IMover _mover;
    private bool _needMove = true;

    public MoveUser(IInputMove inputMove, IMover moverType)
    {
        _inputMove = inputMove;
        _mover = moverType;
    }

    public void Tick()
    {
        if (_needMove)
            _mover.Move(_inputMove.GetDirectionMove());
    }
}
