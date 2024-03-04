using UnityEngine;
using Zenject;

public class TrashHeap : MonoBehaviour
{
    public class Factory : PlaceholderFactory<TrashHeap>
    {

    }
}
