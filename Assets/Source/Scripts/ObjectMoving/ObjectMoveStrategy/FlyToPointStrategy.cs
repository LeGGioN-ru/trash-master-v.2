using System;
using System.Collections;
using UnityEngine;

public class FlyToPointStrategy : IObjectMoveStrategy
{
    private readonly CoroutineManager _coroutineManager;
    private readonly CollectSettings.Settings _collectSettings;
    public float Speed => _collectSettings.Speed;


    public FlyToPointStrategy(CoroutineManager coroutineManager, CollectSettings.Settings collectSettings)
    {
        _coroutineManager = coroutineManager;
        _collectSettings = collectSettings;
    }

    public void Move(Transform endPoint, Transform obj,  params Action[] onEnd)
    {
        _coroutineManager.StartCoroutine(FlyToTarget(endPoint, obj,onEnd));
    }

    private IEnumerator FlyToTarget(Transform endPoint, Transform obj, Action[] onEnd)
    {
        while (Vector3.Distance(obj.position, endPoint.position) > 0.1f)
        {
            Vector3 currentPosition = obj.position;
            Vector3 targetPosition = endPoint.position;
            Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, Speed * Time.deltaTime);
            obj.position = newPosition;

            yield return null;
        }

        foreach (Action action in onEnd)
        {
            action?.Invoke();
        }
    }
}