using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolPickup : EventInteraction
{
    float currentTime;
    [SerializeField] float waitTime;
    [SerializeField] string pickupAnimation;


    static int currentFact = 0;

    [SerializeField] string[] allFacts;

    [SerializeField] TextMeshProUGUI text;

    public override bool CanInteract()
    {
        return (Player.Get().toolAmount < Player.Get().maxTools);
    }

    public override void OnInteract()
    {
        currentTime += Time.deltaTime;

        if (currentTime > waitTime)
        {
            Player.Get().toolAmount++;
            currentFact++;

            Player.Get().GetComponent<WorldInteractionController>().EndInteraction();


            GameObject.Destroy(gameObject);
        }
    }
    public override void OnStartInteract()
    {
        currentTime = 0;

        Player.Get().GetComponent<AnimationManager>().OverrideAnimation(pickupAnimation);

        if (currentFact < 0 || currentFact >= allFacts.Length)
        {
            text.text = "";
        }
        else
        {
            text.text = allFacts[currentFact];
        }

        base.OnStartInteract();
    }

    public override void OnStopInteract()
    {

        Player.Get().GetComponent<AnimationManager>().ClearOverride();

        base.OnStopInteract();
    }

}
