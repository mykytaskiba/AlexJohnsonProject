using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquiferDepletion : MonoBehaviour
{
    [SerializeField] float depletionRate;
    [SerializeField] float depletionAcceleration;
    [SerializeField] WaterStorage waterStorage;
    

    // Update is called once per frame
    void Update()
    {
        waterStorage.EmptyBucket(depletionRate * Time.deltaTime);

        depletionRate += depletionAcceleration * Time.deltaTime;
    }
}
