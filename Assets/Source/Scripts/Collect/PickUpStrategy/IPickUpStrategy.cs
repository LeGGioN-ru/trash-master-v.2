using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickUpStrategy
{
    public Transform PickPoint { get; }
    public Quaternion EndRotation { get; }
    public void PickUp();
}
