using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ToolCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Tools: " + Player.Get().toolAmount + " / " + Player.Get().maxTools;
    }
}
