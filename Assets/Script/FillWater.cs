using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWater : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] WaterStorage waterStorage;
    [SerializeField] float range;
    [SerializeField] float fillPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < range)
        {
            waterStorage.FillBucket(fillPerSecond * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
