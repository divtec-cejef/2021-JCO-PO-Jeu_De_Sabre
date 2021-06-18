using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SoundHandler
{

    private GameObject timerSound;
    private GameObject damageSound;
    
    public SoundHandler(GameObject timerSound, GameObject damageSound)
    {
        this.timerSound = timerSound;
        this.damageSound = damageSound;
    }

    public GameObject getTimerSound()
    {
        return timerSound;
    }

    public GameObject getDamangeSound()
    {
        return damageSound;
    }
}
