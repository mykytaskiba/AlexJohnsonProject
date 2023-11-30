using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

[assembly : InternalsVisibleTo("EditMode")]
public class MainMenu : MonoBehaviour
{

    [SerializeField] internal InputSystem inputSystem;


    [SerializeField] internal GameObject menuObject;

    internal bool menuState;
    internal void SwitchMenuState()
    {
        menuState = !menuState;

        menuObject.SetActive(menuState);

        Cursor.visible = menuState;

        Cursor.lockState = CursorLockMode.None;

        if (!menuState)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (inputSystem.GetMainMenu())
        {
            SwitchMenuState();
        }
    }
}
