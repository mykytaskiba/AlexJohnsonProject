using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EmptyWaterStorageEvent : MonoBehaviour
{
    [SerializeField] WaterStorage storage;
    [SerializeField] UnityEvent triggeredEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (storage.GetRatio() == 0)
        {
            triggeredEvent.Invoke();
            this.enabled = false;
        }
    }
}
