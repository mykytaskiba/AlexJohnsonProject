using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventInteraction : WorldInteraction
{

    [SerializeField] UnityEvent OnStartInteraction;
    [SerializeField] UnityEvent OnEndInteraction;

    public override void OnStartInteract()
    {
        OnStartInteraction.Invoke();
    }

    public override void OnStopInteract()
    {
        OnEndInteraction.Invoke();
    }

}
