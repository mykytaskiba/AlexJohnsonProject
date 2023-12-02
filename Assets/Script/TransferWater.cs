using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferWater : EventInteraction
{
    [SerializeField] WaterStorage from;
    [SerializeField] WaterStorage to;
    [SerializeField] float transferRate;


    public override void OnStartInteract()
    {
        base.OnStartInteract();
    }

    public override void OnStopInteract()
    {
        base.OnStopInteract();
    }
    public override void OnInteract()
    {
        to.FillBucket(from.EmptyBucket(transferRate * Time.deltaTime));
    }
}
