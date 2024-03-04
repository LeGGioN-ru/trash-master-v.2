using System.Linq;
using UnityEngine;

public class BoxZone : Zone
{
    protected Vector3 HalfSize => Size * 0.5f;

    public BoxZone(Color color, Transform center) : base(color, center)
    {
    }

    public override void SetSize(Vector3 size)
    {
        Size = size;
    }

    public override void Draw()
    {
        Gizmos.color = Color;
        Gizmos.DrawCube(Center.position, Size);
    }

    protected override Collider[] GetColliders()
    {
        return Physics.OverlapBox(Center.position, Size);
    }
}
