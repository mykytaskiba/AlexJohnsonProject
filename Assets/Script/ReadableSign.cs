using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadableSign : EventInteraction
{
    [SerializeField] GameObject targetCanvas;
    public override void OnInteract()
    {
    }

    bool reading = false;

    public override void OnStartInteract()
    {
        Time.timeScale = 0;

        targetCanvas.SetActive(true);

        reading = true;
    }

    private void Update()
    {
        if (reading)
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                targetCanvas.SetActive(false);
            }
        }
    }

}
