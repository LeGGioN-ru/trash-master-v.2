using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

public class InventoryRig : InventoryVisual, ITickable
{
    private readonly Container _container;
    private readonly IInputMove _inputMove;

    private bool _isChanged;

    public InventoryRig(SignalBus signalBus, List<Transform> transforms, Inventory inventory, Container container, IInputMove inputMove) : base(signalBus, transforms, inventory)
    {
        _container = container;
        _inputMove = inputMove;
    }

    protected override void OnScoreChange(InventoryItemsChangeEvent inventoryItemsChangeEvent)
    {
        if (inventoryItemsChangeEvent.AmountItems > 0)
        {
            EnableVisual();
        }
        else
        {
            DisableVisual();
        }
    }

    public override void EnableVisual()
    {
        _container.Rig.weight = 1;
    }

    public override void DisableVisual()
    {
        _container.Rig.weight = 0;
    }

    private void EnableUpPoint()
    {
        _container.LeftHand.localRotation = _container.LeftHandUpPoint.localRotation;
        _container.RightHand.localRotation = _container.RightHandUpPoint.localRotation;

        _container.CenterInventory.position = _container.InventoryUpPoint.position;
        _container.LeftHand.position = _container.LeftHandUpPoint.position;
        _container.RightHand.position = _container.RightHandUpPoint.position;
    }

    private void EnableDownPoint()
    {
        _container.LeftHand.localRotation = _container.LeftHandDownPoint.localRotation;
        _container.RightHand.localRotation = _container.RightHandDownPoint.localRotation;

        _container.CenterInventory.position = _container.InventoryDownPoint.position;
        _container.LeftHand.position = _container.LeftHandDownPoint.position;
        _container.RightHand.position = _container.RightHandDownPoint.position;
    }

    public void Tick()
    {

        if (_inputMove.GetDirectionMove() == Vector2.zero && _isChanged == false)
        {
            _isChanged = true;
            EnableUpPoint();
        }
        else if (_inputMove.GetDirectionMove() != Vector2.zero && _isChanged == true)
        {
            _isChanged = false;
            EnableDownPoint();
        }
    }

    [Serializable]
    public class Container
    {
        [field: SerializeField] public Transform CenterInventory { get; private set; }
        [field: SerializeField] public Transform LeftHand { get; private set; }
        [field: SerializeField] public Transform RightHand { get; private set; }
        [field: SerializeField] public Rig Rig { get; private set; }
        [field: SerializeField] public Transform LeftHandUpPoint { get; private set; }
        [field: SerializeField] public Transform RightHandUpPoint { get; private set; }
        [field: SerializeField] public Transform LeftHandDownPoint { get; private set; }
        [field: SerializeField] public Transform RightHandDownPoint { get; private set; }
        [field: SerializeField] public Transform InventoryUpPoint { get; private set; }
        [field: SerializeField] public Transform InventoryDownPoint { get; private set; }

        public Container(Transform centerInventory, Transform leftHand, Transform rightHand,
            Rig rig, Transform leftHandUpPoint, Transform rightHandUpPoint,
            Transform leftHandDownPoint, Transform rightHandDownPoint, Transform inventoryUpPoint, Transform inventoryDownPoint)
        {
            CenterInventory = centerInventory;
            LeftHand = leftHand;
            RightHand = rightHand;
            Rig = rig;
            LeftHandUpPoint = leftHandUpPoint;
            RightHandUpPoint = rightHandUpPoint;
            LeftHandDownPoint = leftHandDownPoint;
            RightHandDownPoint = rightHandDownPoint;
            InventoryUpPoint = inventoryUpPoint;
            InventoryDownPoint = inventoryDownPoint;
        }
    }

}
