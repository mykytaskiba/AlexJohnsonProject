using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSystem : MonoBehaviour
{

    /// <summary>
    /// Gets the movement vector the input system wants to move in
    /// </summary>
    /// <returns>The movement vector</returns>
    public abstract Vector3 GetMovement();

    /// <summary>
    /// Retrieves if the input system wants to jump
    /// </summary>
    /// <returns>
    /// true if a jump is desired
    /// </returns>
    public abstract bool GetJump();


    /// <summary>
    /// Retrieves if the input systems wants to rotate
    /// </summary>
    /// <returns>The x and y direction in which to rotate</returns>
    public abstract Vector2 GetRotation();

    /// <summary>
    /// Retrieves whether the input system wants to call menu
    /// </summary>
    /// <returns></returns>
    public virtual bool GetMainMenu()
    {
        return false;
    }
}
