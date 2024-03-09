using UnityEngine;

public interface IObjectRotateStrategy
{
    public void Rotate(Transform obj,Quaternion targetRotate);
    public void Stop();
}
