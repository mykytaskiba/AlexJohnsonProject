using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    [SerializeField] GroundDetector groundDetector;
    [SerializeField] GameObject toolsPrefab;
    [SerializeField] Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (groundDetector.IsOnGround())
        {
            GameObject clone = GameObject.Instantiate(toolsPrefab);

            clone.transform.position = spawnPosition.position;

            GameObject.Destroy(gameObject);
        }
    }
}
