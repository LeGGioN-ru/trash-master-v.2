using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectMoveStrategy
{
    public float Speed { get; }
    public void Move(Transform endPoint, Transform obj, params Action[] onEnd);
}
