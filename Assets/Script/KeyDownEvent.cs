using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KeyDownEvent : MonoBehaviour
{
    [SerializeField] KeyCode targetKey;
    [SerializeField] UnityEvent triggeredEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(targetKey))
        {
            triggeredEvent.Invoke();
        }
    }
}
