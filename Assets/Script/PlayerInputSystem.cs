using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The input that is recieved from the key board inputs
/// </summary>
public class PlayerInputSystem : InputSystem
{
    public override bool GetJump()
    {
        return (Input.GetKey(KeyCode.Space));
    }

    public override Vector3 GetMovement()
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

    public override Vector2 GetRotation()
    {
        Vector2 result = new Vector2();
        result.x = Input.GetAxis("Mouse X");
        result.y = -Input.GetAxis("Mouse Y");

        return result;
    }

    public override bool GetMainMenu()
    {
        return (Input.GetKeyDown(KeyCode.Escape));
    }

}
