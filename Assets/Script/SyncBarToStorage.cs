using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncBarToStorage : MonoBehaviour
{

    [SerializeField] WaterStorage representedStorage;
    [SerializeField] Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(1, representedStorage.GetRatio(), 1);
        
    }
}
