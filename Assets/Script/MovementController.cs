using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("EditMode")]
public class MovementController : MonoBehaviour
{
    /// <summary>
    /// The rigidbody that is affected by this movement controller
    /// </summary>
    [SerializeField] internal Rigidbody targetRigidbody;

    /// <summary>
    /// The component that is responsible for the jump behaviour
    /// </summary>
    [SerializeField] internal Jump jump;

    /// <summary>
    /// The component that is responsible for determining when the object is on the ground
    /// </summary>
    [SerializeField] internal GroundDetector groundDetector;

    /// <summary>
    /// The drag of the object when it is on the ground
    /// </summary>
    [SerializeField] internal float groundDrag;

    /// <summary>
    /// The drag of the object when it is in the air
    /// </summary>
    [SerializeField] internal float airDrag;

    /// <summary>
    /// Updates the relevant movement properties (such as jumping and drag) depending on the state of the object
    /// </summary>
    internal void UpdateMovementProperties()
    {
        UpdateDrag();
        UpdateJump();
    }

    /// <summary>
    /// Updates the drag of the object depending on if its in the air or not
    /// </summary>
    internal void UpdateDrag()
    {
        targetRigidbody.drag = groundDrag;
        if (!groundDetector.IsOnGround())
        {
            targetRigidbody.drag = airDrag;
        }
    }

    /// <summary>
    /// Turns on the jump component if the object object is on the ground
    /// </summary>
    internal void UpdateJump()
    {
        jump.enabled = groundDetector.IsOnGround();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateMovementProperties();
    }
}
