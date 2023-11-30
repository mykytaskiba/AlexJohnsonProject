using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

[assembly : InternalsVisibleTo("EditMode")]
public class CameraRotate : MonoBehaviour
{
    /// <summary>
    /// Keeps track of the rotation internally
    /// </summary>
    Vector2 rotation;

    /// <summary>
    /// The x rotation will not go above this limit
    /// </summary>
    [SerializeField] internal float upperRotationLimit = 80;

    /// <summary>
    /// The x rotation will not go below this limit
    /// </summary>
    [SerializeField] internal float lowerRotationLimit = -80;

    /// <summary>
    /// The input system to get rotation change from
    /// </summary>
    [SerializeField] internal InputSystem inputSystem;

    [SerializeField] Transform upAxisTransform;
    [SerializeField] Transform rightAxisTransform;



    private void Start()
    {
        rotation.y = transform.rotation.eulerAngles.x;
        rotation.x = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(inputSystem.GetRotation());
    }

    /// <summary>
    /// Rotate the camera x degrees on the up axis and y degrees on the right axis
    /// The y rotation will be clamped to not loop the camera upside down.
    /// </summary>
    /// <param name="x">The rotation in degrees on the up axis (y in Euler)</param>
    /// <param name="y">The rotation in degrees on the right axis (x in Euler)</param>
    internal void Rotate(float x, float y)
    {
        rotation.x += x;
        rotation.y += y;

        rotation.y = Mathf.Clamp(rotation.y, lowerRotationLimit, upperRotationLimit);

        Quaternion upRotation = Quaternion.AngleAxis(rotation.x, Vector3.up);
        Quaternion rightRotation = Quaternion.AngleAxis(rotation.y, Vector3.right);

        upAxisTransform.localRotation = upRotation;

        rightAxisTransform.localRotation = rightRotation;

        //transform.localRotation = upRotation * rightRotation;

    }

    /// <summary>
    /// Rotate the camera x degrees on the up axis and y degrees on the right axis
    /// The y rotation will be clamped to not loop the camera upside down.
    /// </summary>
    /// <param name="rotation">the rotation vector to draw x and y from</param>
    internal void Rotate(Vector2 rotation)
    {
        Rotate(rotation.x, rotation.y);
    }
}
