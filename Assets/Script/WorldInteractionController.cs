using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldInteractionController : MonoBehaviour
{

    [SerializeField] WorldInteraction currentInteraction;

    [SerializeField] WorldInteraction[] allInteraction;

    
    [SerializeField] Movement movement;

    [SerializeField] GameObject uiObject;
    [SerializeField] TextMeshProUGUI interactionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        allInteraction = GameObject.FindObjectsOfType<WorldInteraction>();

        if (currentInteraction != null)
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                StopInteraction();
            } else
            {
                currentInteraction.OnInteract();
            }


        } else
        {
            WorldInteraction closest = GetClosest();
            if (closest == null)
            {
                uiObject.SetActive(false);
                return;
            }
            if (closest.WithinRange())
            {
                uiObject.SetActive(true);
                interactionText.text = closest.GetMessage();

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    StartInteraction(closest);
                }
            } else
            {
                uiObject.SetActive(false);

            }
        }
    }

    void StopInteraction()
    {
        currentInteraction.OnStopInteract();
        currentInteraction = null;

        movement.enabled = true;

    }

    void StartInteraction(WorldInteraction interaction)
    {
        interaction.OnStartInteract();
        currentInteraction = interaction;

        movement.enabled = false;

    }

    public void EndInteraction()
    {
        StopInteraction();
    }

    WorldInteraction GetClosest()
    {
        WorldInteraction closest = null;
        foreach (WorldInteraction worldInteraction in allInteraction)
        {
            if (worldInteraction.CanInteract())
            {
                if (closest == null || worldInteraction.DistanceToPlayer() < closest.DistanceToPlayer())
                {

                    closest = worldInteraction;
                }
            }
        }

        return closest;
    }
}
