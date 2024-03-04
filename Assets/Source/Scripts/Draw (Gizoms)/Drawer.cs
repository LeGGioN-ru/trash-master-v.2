using UnityEngine;
using Zenject;

public class Drawer : MonoBehaviour
{
    private IDrawable _drawable;

    [Inject]
    public void Construct(IDrawable drawable)
    {
        _drawable = drawable;
    }

    private void OnDrawGizmos()
    {
        _drawable?.Draw();
    }
}
