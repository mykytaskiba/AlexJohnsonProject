using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactRandomizer : MonoBehaviour
{
    [SerializeField] string[] allFacts;

    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = allFacts[Random.Range(0, allFacts.Length)];    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
