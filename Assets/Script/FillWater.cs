using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWater : EventInteraction
{
    [SerializeField] WaterStorage waterStorage;
    [SerializeField] float fillPerSecond;


    public override void OnInteract()
    {
        waterStorage.FillBucket(fillPerSecond * Time.deltaTime);
        
    }

    public override void OnStartInteract()
    {
        base.OnStartInteract();
    }

    public override void OnStopInteract()
    {
        base.OnStopInteract();
    }
}
