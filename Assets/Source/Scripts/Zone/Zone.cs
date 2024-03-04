using System;
using System.Linq;
using UnityEngine;

[Serializable]
public abstract class Zone : IDrawable
{
    protected Color Color;

    public Transform Center { get; protected set; }
    public Vector3 Size { get; protected set; }

    public Zone(Color color, Transform center)
    {
        Color = color;
        Center = center;
    }

    public bool GetObjectInZone<T>(out T component) where T : MonoBehaviour
    {
        Collider[] colliders = GetColliders();

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out T obj))
            {
                component = obj;
                return true;
            }
        }

        component = null;
        return false;
    }

    public bool GetObjectsInZone<T>(out T[] components) where T : MonoBehaviour
    {
        Collider[] colliders = GetColliders();

        components = colliders.Select(collider => collider.GetComponent<T>()).OfType<T>().ToArray();

        return components.Length > 0;
    }
    protected abstract Collider[] GetColliders();
    public abstract void Draw();
    public abstract void SetSize(Vector3 size);
}