using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDropRandomization : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawned < spawnLimit)
        {
            if (currentCooldown > spawnCooldown)
            {
                Spawn();
                currentCooldown = 0;
                currentSpawned++;
            }
        }

        currentCooldown += Time.deltaTime;
    }

    void Spawn()
    {
        GameObject clone = GameObject.Instantiate(baloonPrefab);
        clone.transform.position = GetRandomPoint();
    }

    [SerializeField] GameObject baloonPrefab;

    [SerializeField] float spawnCooldown;
    float currentCooldown;

    int currentSpawned;
    [SerializeField] int spawnLimit;

    [SerializeField] float radius;
    Vector3 GetRandomPoint()
    {

        float r = radius * Mathf.Sqrt(Random.value);
        float theta = Random.value * 2 * Mathf.PI;
        float x =r * Mathf.Cos(theta);
        float z = r * Mathf.Sin(theta);

        return new Vector3(x, transform.position.y, z);
    }
}
