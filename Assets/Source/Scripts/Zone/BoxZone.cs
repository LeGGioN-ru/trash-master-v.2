using System.Linq;
using UnityEngine;

public class BoxZone : Zone, IDrawable
{
    protected Vector3 HalfSize => Size * 0.5f;

    public BoxZone(Color color, Transform center) : base(color, center)
    {
    }

    protected override bool GetObjectInZone<T>(out T component)
    {
        Collider[] colliders = Physics.OverlapBox(Center.position, HalfSize);

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

    protected override bool GetObjectsInZone<T>(out T[] components)
    {
        Collider[] colliders = Physics.OverlapBox(Center.position, HalfSize);

        components = colliders.Select(collider => collider.GetComponent<T>()).OfType<T>().ToArray();

        return components.Length > 0;
    }

    public override void SetSize(Vector3 size)
    {
        Size = size;
    }

    public void Draw()
    {
        Gizmos.color = Color;
        Gizmos.DrawCube(Center.position, Size);
    }
}
