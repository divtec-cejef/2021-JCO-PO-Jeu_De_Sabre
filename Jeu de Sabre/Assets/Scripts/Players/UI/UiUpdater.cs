using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class UiUpdater
{
    private Text text_j1;
    private Text text_j2;

    private GameObject stamina_j1;
    private GameObject stamina_j2;

    private Text timer_j1;
    private Text timer_j2;

    private bool isSound = false;
    
    public UiUpdater(Text text_j1, Text text_j2, GameObject stamina_j1, GameObject stamina_j2, Text timer_j1, Text timer_j2)
    {
        this.text_j1 = text_j1;
        this.text_j2 = text_j2;

        this.stamina_j1 = stamina_j1;
        this.stamina_j2 = stamina_j2;

        this.timer_j1 = timer_j1;
        this.timer_j2 = timer_j2;
    }

    public void onScoreUpdate(Player.Joueur player)
    {
        if (player == Player.Joueur.P1)
            text_j1.text = formatScore(Player.getScore(player));
        else
            text_j2.text = formatScore(Player.getScore(player));
    }


    public void onStaminaUpdate(Player.Joueur player)
    {
        if (player == Player.Joueur.P1)
        {
            stamina_j1.transform.localScale = new Vector3(
                Player.getStamina(player), 
                stamina_j1.transform.localScale.y,
                stamina_j1.transform.localScale.z);


        }
        else
        {
            stamina_j2.transform.localScale = new Vector3(
                Player.getStamina(player), 
                stamina_j2.transform.localScale.y,
                stamina_j2.transform.localScale.z);
            
            //stamina_j2.transform.position = position;
        }
    }

    private String formatScore(int score)
    {
        String scoreString;
        
        if (score >= 1000)
            scoreString =  score.ToString();
        else
        {
            scoreString = "0" + score;

            if (score >= 100) 
                return "Score : " + scoreString;
            
            scoreString = "0" + scoreString;
            
            if (score < 10)
                scoreString = "0" + scoreString;
        }
        
        return "Score : " + scoreString;
    }
    
    public void onTimerUpdate()
    {
        timer_j1.text = timer_j2.text = formatTime(GameInit.getTimer().getTimer());
    }
    
    private String formatTime(int time)
    {
        String format = "";

        if (time <= 20 && !isSound)
        {
            var position = new Vector3(11.9f, 11.0f, 15.6f);
            var rotation = new Quaternion(0, 0, 0, 0);
            MonoBehaviour.Instantiate(GameInit.getSoundHandler().getTimerSound(), position, rotation);
            isSound = true;
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
}
