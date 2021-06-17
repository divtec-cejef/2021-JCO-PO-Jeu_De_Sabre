using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    
    private int width = 150;
    
    private float time = 0.0f;
    private int frameRate;
    private int fps;

    private void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, width, 20), "FPS : " + frameRate.ToString());

    }

    private void Update()
    {
        
        if (time > 1.0f)
        {
            
            frameRate = fps;
            fps = 0;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
            fps++;
        }
    }
}
