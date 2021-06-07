using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public int maxTime;
    private float timer;
    public GameObject FXFinal;
    private bool final = false;
    public Camera CAM;
    

    private void Start()
    {
        timer = maxTime;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }


    private String formatTime(int time)
    {
        String format = "";

        if (time <= 0)
        {
            if (!final)
            {
                final = true;
                GameObject effect = Instantiate(FXFinal, transform.position, transform.rotation);
                Rect a = new Rect(0, 0, 1, 1);
                CAM.rect = a;
                
                return "AAAAAAAAAAAAAAAAAAAA !!!!!!!!!!";
            }
        }
        
        if (time / 60 < 10)
        {
            format += "0";
        }

        format += time / 60 + ":";

        if (time % 60 < 10)
        {
            format += "0";
        }

        format += time % 60;

        return format;
    }

    private void OnGUI()
    {
        GUI.TextArea(new Rect(Screen.width / 2 - 75, 30, 150, 20), "Time : " + formatTime((int) timer));
    }
}
