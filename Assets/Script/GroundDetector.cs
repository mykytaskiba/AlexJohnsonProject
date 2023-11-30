using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("EditMode")]
public class GroundDetector : MonoBehaviour
{
    /// <summary>
    /// The radius of the ground detection. The center is always placed on the position of the GameObject the component is attached to.
    /// </summary>
    [SerializeField] internal float radius;

    /// <summary>
    /// The layer mask that determines what is considered the ground
    /// </summary>
    [SerializeField] internal LayerMask groundLayerMask;

    /// <summary>
    /// true when the value needs to be recalculated
    /// </summary>
    internal bool needsUpdate;

    /// <summary>
    /// true when the object is touching the ground
    /// </summary>
    internal bool value;

    /// <summary>
    /// Uses the physics system to determine if the object is currently on ground
    /// </summary>
    /// <returns>true if the object is on the ground</returns>
    internal bool GroundCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, groundLayerMask);

        return (colliders.Length > 0);
    }
    
    /// <summary>
    /// Checks whether the object is on the ground or not. Minimizes the physics raycast to a minimum
    /// </summary>
    /// <returns>true if the object is on the ground</returns>
    public bool IsOnGround()
    {
        if (needsUpdate)
        {
            value = GroundCheck();
        }

        return value;
    }

    private void Update()
    {
        needsUpdate = true;
    }

    /*
    public T GetGroundComponent<T>() where T : Component
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Ground"));

        foreach (Collider collider in colliders)
        {
            T result = collider.GetComponent<T>();
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }*/


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
