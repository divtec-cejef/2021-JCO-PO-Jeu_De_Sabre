using System;
using System.Collections;
using System.Collections.Generic;
using Init;
using UnityEngine;

public class Timer
{
    private float timer;
    private GameObject sound;

    public Timer(int time, GameObject sound)
    {
        timer = time;
        this.sound = sound;
    }

    public void onUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            GameInit.getUiUpdater().onTimerUpdate();
        }
    }

    public int getTimer()
    {
        return (int) timer;
    }

    public GameObject getSound()
    {
        return sound;
    }

}
