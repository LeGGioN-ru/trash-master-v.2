using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrashHeap : MonoBehaviour
{
    public void Collect(out int delay)
    {
        delay = 1;

    }

    public class Factory : PlaceholderFactory<TrashHeap> { }
}
