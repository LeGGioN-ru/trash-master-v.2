using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Drawer : MonoBehaviour
{
    private List<IDrawable> _drawables = new List<IDrawable>();

    [Inject]
    public void Construct(List<IDrawable> drawables)
    {
        _drawables = drawables;
    }

    private void OnDrawGizmos()
    {
        _drawables.ForEach(drawable => drawable?.Draw());
    }
}