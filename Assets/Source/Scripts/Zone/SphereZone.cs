using UnityEngine;

public class SphereZone : Zone
{
    public SphereZone(Color color, Transform center) : base(color, center)
    {
    }

    public override void SetSize(Vector3 size)
    {
        Size = size;
    }

    public override void Draw()
    {
        Gizmos.color = Color;
        Gizmos.DrawSphere(Center.position, Size.magnitude);
    }

    protected override Collider[] GetColliders()
    {
        return Physics.OverlapSphere(Center.position, Size.magnitude);
    }
}
