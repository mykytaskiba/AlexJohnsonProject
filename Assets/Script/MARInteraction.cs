using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MARInteraction : EventInteraction
{
    float currentTime;
    [SerializeField] float waitTime;
    [SerializeField] UnityEvent OnDone;
    public override void OnInteract()
    {
        if (Player.Get().toolAmount >= 5)
        {
            currentTime += Time.deltaTime;

            if (currentTime > waitTime)
            {
                Player.Get().toolAmount = 0;

                OnDone.Invoke();
            }
        }
    }

    public override void OnStartInteract()
    {
        currentTime = 0;
        base.OnStartInteract();
    }

    public override void OnStopInteract()
    {
        base.OnStopInteract();
    }
}
