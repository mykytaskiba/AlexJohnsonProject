using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStorage : MonoBehaviour
{
    /*
    static PlayerBucket instance;

    public static PlayerBucket Get()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }*/

    [SerializeField] float waterStored;

    [SerializeField] float maxWater;
    [SerializeField] float minWater;

    public void FillBucket(float fill)
    {
        waterStored += fill;
        if (waterStored > maxWater)
        {
            waterStored = maxWater;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="desiredEmpty">Desired amount to empty</param>
    /// <returns>the actual amount emptied</returns>
    public float EmptyBucket(float desiredEmpty)
    {
        float emptied = Mathf.Min(desiredEmpty, waterStored);

        waterStored += -emptied;
        if (waterStored < minWater)
        {
            waterStored = minWater;
        }

        return emptied;
    }

    public float GetRatio()
    {
        return (waterStored-minWater) / (maxWater-minWater);
    }
}
