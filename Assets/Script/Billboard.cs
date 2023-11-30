using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform billboardTo;

    [SerializeField] bool billboardY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = billboardTo.position - transform.position;
        if (!billboardY)
        {
            forward.y = 0;
        }

        transform.forward = forward;
    }
}
