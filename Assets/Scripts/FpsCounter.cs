using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    public Text FPS;

    float i = 1;

    void Start()
    {
        FPS.text = (int)(1f / Time.unscaledDeltaTime) + " FPS";
    }
    
    void Update()
    {
        if (i > 0)
            i -= Time.deltaTime;
        else
        {
            i = 1;
            FPS.text = (int)(1f / Time.unscaledDeltaTime) + " FPS";
        }
    }
}
