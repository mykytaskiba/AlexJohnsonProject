using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int toolAmount;

    public void AddTool()
    {
        toolAmount++;
    }

    private void Awake()
    {
        instance = this;
    }
    static Player instance;

    public static Player Get()
    {
        return instance;
    }
}
