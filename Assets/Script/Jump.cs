using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("EditMode"), InternalsVisibleTo("PlayMode")]
public class Jump : MonoBehaviour
{
    /// <summary>
    /// Time of the last jump
    /// </summary>
    internal float lastJumpTime;

    /// <summary>
    /// Time to wait between each jump
    /// </summary>
    [SerializeField] internal float jumpCooldown;

    /// <summary>
    /// The force of the jump, using the object's mass
    /// </summary>
    [SerializeField] internal float jumpForce;

    /// <summary>
    /// The rigidbody the force is applied to for the jump
    /// </summary>
    [SerializeField] internal Rigidbody targetRigidbody;

    /// <summary>
    /// The input system to draw input from
    /// </summary>
    [SerializeField] internal InputSystem inputSystem;

    // Update is called once per frame
    void Update()
    {
        if (inputSystem.GetJump())
        {
            ProcessJump();
        }

    }

    /// <summary>
    /// Initiates the jump,
    /// if all the preconditions are met
    /// JUMP PRECONDITIONS:
    /// The time since last jump must be more than the cooldown
    /// </summary>
    internal void ProcessJump()
    {
        //To Do: Separate the space bar
        float timeSinceJump = Time.time - lastJumpTime;
        if (timeSinceJump > jumpCooldown)
        {
            lastJumpTime = Time.time;
            InitiateJump();
        }

    }

    /// <summary>
    /// Initiates the jump,
    /// without checking any preconditions
    /// </summary>
    internal void InitiateJump()
    {
        targetRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
