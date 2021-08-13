using System;
using System.Collections;
using System.Collections.Generic;
using Init;
using UnityEngine;

public class Timer
{
    private float timer;
    private GameObject sound;

    /// <summary>
    /// Constructeur du Timer
    /// </summary>
    /// <param name="time">La durée du timer</param>
    /// <param name="sound">Le son du timer</param>
    public Timer(int time, GameObject sound)
    {
        timer = time;
        this.sound = sound;
    }

    public void OnUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            GameInit.GetUiUpdater().OnTimerUpdate();
        }
    }

    /// <summary>
    /// Permet de récupérer le timer
    /// </summary>
    /// <returns>Le timer</returns>
    public int GetTimer()
    {
        return (int) timer;
    }

    /// <summary>
    /// Permet de récupérer le son du timer
    /// </summary>
    /// <returns>Le son du timer</returns>
    public GameObject GetSound()
    {
        return sound;
    }

}
