using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

[assembly : InternalsVisibleTo("PlayMode")]
public class MockInputSystem : InputSystem
{
    internal bool jump;
    public override bool GetJump()
    {
        return jump;
    }


    internal Vector3 movement;
    public override Vector3 GetMovement()
    {
        return movement;
    }

    internal Vector2 rotation;
    public override Vector2 GetRotation()
    {
        return rotation;
    }

    internal bool mainMenu;
    public override bool GetMainMenu()
    {
        return mainMenu;
    }

}
