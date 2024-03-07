using UnityEngine;

public interface IActivable 
{
    public bool IsActivable { get; }
    public bool CanBeActivated { get; }
    public int Delay { get; }
    public void Activate();
}
