using System;
using UnityEngine;

[Serializable]
public abstract class Zone
{
    protected Color Color;

    public Transform Center { get; protected set; }
    public Vector3 Size { get; protected set; }

    public Zone(Color color, Transform center)
    {
        Color = color;
        Center = center;
    }

    public abstract void SetSize(Vector3 size);
    protected abstract bool GetObjectInZone<T>(out T component) where T : MonoBehaviour;
    protected abstract bool GetObjectsInZone<T>(out T[] components) where T : MonoBehaviour;
}