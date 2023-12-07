using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSetter : MonoBehaviour
{
    [SerializeField] bool cursorVisible;
    [SerializeField] CursorLockMode cursorLockMode;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = cursorVisible;
        Cursor.lockState = cursorLockMode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
