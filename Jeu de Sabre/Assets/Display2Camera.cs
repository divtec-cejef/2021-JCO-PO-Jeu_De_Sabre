using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display2Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Premet de changé la taille de la fenetre
        for (int i  = 0; i < Display.displays.Length;i++)
        {
            Display.displays[i].Activate(1920,1080,60);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
