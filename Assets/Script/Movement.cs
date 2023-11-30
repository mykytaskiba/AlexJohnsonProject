using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

[assembly : InternalsVisibleTo("EditMode"), InternalsVisibleTo("PlayMode")]
public class Movement : MonoBehaviour
{
    /// <summary>
    /// The acceleration of the object when moving
    /// </summary>
    [SerializeField] internal float acceleration;
    
    /// <summary>
    /// The air modifier of the acceleration when the object is in the air
    /// </summary>
    //[SerializeField] float airAccelerationModifier;

    /// <summary>
    /// The maximum flat speed the object will move at
    /// </summary>
    [SerializeField]  internal float speed;

    /// <summary>
    /// The input system to draw input from
    /// </summary>
    [SerializeField] internal InputSystem inputSystem;

    Vector3 input;

    /// <summary>
    /// Target rigidbody to manipulate
    /// </summary>
    [SerializeField] internal Rigidbody targetRigidbody;

    /// <summary>
    /// The transform that is used for the forward vector
    /// </summary>
    [SerializeField] internal Transform forwardTransform;


    private void Start()
    {
        Debug.Assert(forwardTransform != null);
        Debug.Assert(targetRigidbody != null);
    }


    Vector3 GetInput()
    {
        Vector3 result = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            result.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            result.z += -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            result.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            result.x += 1;
        }

        return result;

    }



    void FixedUpdate()
    {
        input = inputSystem.GetMovement();
        ProcessPhysics(GetFlatTransformVector(input));
    }

    /// <summary>
    /// Processes the current FixedUpdate physics
    /// Applies force to the rigidbody based on the movement vector
    /// </summary>
    /// <param name="movementVector">The Movement vector to process, in global space</param>
    internal void ProcessPhysics(Vector3 movementVector)
    {
        Vector3 targetVelocity = speed * movementVector;
        targetRigidbody.AddForce(acceleration * targetVelocity, ForceMode.Force);
        LimitSpeed();
    }

    /// <summary>
    /// </summary>
    /// <param name="inVector">the input vector to transform</param>
    /// <returns>A normalized transformed flat vector relative to the forwardTransform object</returns>
    internal Vector3 GetFlatTransformVector(Vector3 inVector)
    {

        Vector3 result = forwardTransform.TransformVector(inVector);
        result.y = 0;

        return result.normalized;
    }


    /// <summary>
    /// Limits the current object's travelling speed by the speed limit. Should be called on physics update
    /// </summary>
    internal void LimitSpeed()
    {
        Vector3 flatVelocity = new Vector3(targetRigidbody.velocity.x, 0, targetRigidbody.velocity.z);

        if (flatVelocity.magnitude > speed)
        {
            flatVelocity = flatVelocity.normalized * speed;
            targetRigidbody.velocity = new Vector3(flatVelocity.x, targetRigidbody.velocity.y, flatVelocity.z);

        }
    }
}
