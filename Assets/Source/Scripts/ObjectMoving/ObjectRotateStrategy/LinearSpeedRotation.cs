using System.Collections;
using UnityEngine;

public class LinearSpeedRotation : IObjectRotateStrategy
{
    private readonly EndRotateType _endRotateType;
    private int _speed = 300;
    private CoroutineManager _coroutineManager;
    private Transform _obj;
    private Coroutine _currentRotate;
    private Quaternion _targetRotate;

    public LinearSpeedRotation(CoroutineManager coroutineManager, EndRotateType endRotateType)
    {
        _coroutineManager = coroutineManager;
        _endRotateType = endRotateType;
    }

    public void Rotate(Transform obj, Quaternion targetRotate)
    {
        _obj = obj;
        _targetRotate = targetRotate;
        _currentRotate = _coroutineManager.StartCoroutine(Rotating(obj, targetRotate));
    }

    public void Stop()
    {
        Debug.Log("zzz");
        Debug.Log(_targetRotate.eulerAngles);
        _coroutineManager.StopCoroutine(_currentRotate);
        _obj.localRotation = _targetRotate;
    }

    private IEnumerator Rotating(Transform obj, Quaternion targetRotate)
    {
        while (Quaternion.Angle(obj.localRotation, targetRotate) > 0.001f && _endRotateType == EndRotateType.Infinite)
        {
            obj.localRotation = Quaternion.RotateTowards(obj.localRotation, targetRotate, _speed * Time.deltaTime);

            yield return null;
        }

        _obj.localRotation = _targetRotate;
    }
}
