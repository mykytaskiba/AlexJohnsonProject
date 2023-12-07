using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldInteraction : MonoBehaviour
{

    [SerializeField] float range;

    public abstract void OnInteract();

    public abstract void OnStartInteract();
    public abstract void OnStopInteract();

    public virtual bool CanInteract()
    {
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public bool WithinRange()
    {
        return (DistanceToPlayer() < range);
    }

    public float DistanceToPlayer()
    {
        return (transform.position - Player.Get().transform.position).magnitude;
    }

    [SerializeField] string displayMessage;
    public string GetMessage()
    {
        return displayMessage;
    }
}
