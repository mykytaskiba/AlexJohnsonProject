using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRandomization : MonoBehaviour
{

    [SerializeField] float radius;
    [SerializeField] Vector3 center;

    Vector3 from;
    Vector3 to;

    [SerializeField] float flyTime;
    float currentFlightTime;

    void CreateNewFlightPath()
    {
        float degree = Random.Range(0f, 360f);
        Vector3 vector = new Vector3(Mathf.Cos(degree), 0, Mathf.Sin(degree));

        to = vector* radius + center;
        from = vector * radius * -1 + center;

        transform.forward = from - to;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateNewFlightPath();               
    }

    // Update is called once per frame
    void Update()
    {
        currentFlightTime += Time.deltaTime;

        Vector3 position = Vector3.Lerp(from, to, currentFlightTime / flyTime);
        transform.position = position;

        if (currentFlightTime > flyTime)
        {
            currentFlightTime = 0;
            CreateNewFlightPath();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
