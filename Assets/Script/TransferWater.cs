using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferWater : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] WaterStorage from;
    [SerializeField] WaterStorage to;
    [SerializeField] float transferRate;
    [SerializeField] float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < range)
        {
            to.FillBucket(from.EmptyBucket(transferRate * Time.deltaTime));
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
