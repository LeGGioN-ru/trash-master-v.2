using System;
using System.Collections;
using UnityEngine;

public class LinearSpeedMove : IObjectMoveStrategy
{
    private readonly CoroutineManager _coroutineManager;
    public float Speed => 50;


    public LinearSpeedMove(CoroutineManager coroutineManager)
    {
        _coroutineManager = coroutineManager;
    }

    public void Move(Transform endPoint, Transform obj, params Action[] onEnd)
    {
        _coroutineManager.StartCoroutine(FlyToTarget(endPoint, obj, onEnd));
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