using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickup : EventInteraction
{
    float currentTime;
    [SerializeField] float waitTime;
    [SerializeField] string pickupAnimation;
    public override void OnInteract()
    {
        currentTime += Time.deltaTime;

        if (currentTime > waitTime)
        {
            Player.Get().toolAmount++;

            Player.Get().GetComponent<WorldInteractionController>().EndInteraction();


            GameObject.Destroy(gameObject);
        }
    }
    public override void OnStartInteract()
    {
        currentTime = 0;

        Player.Get().GetComponent<AnimationManager>().OverrideAnimation(pickupAnimation);

        base.OnStartInteract();
    }

    public override void OnStopInteract()
    {

        Player.Get().GetComponent<AnimationManager>().ClearOverride();

        base.OnStopInteract();
    }

}
