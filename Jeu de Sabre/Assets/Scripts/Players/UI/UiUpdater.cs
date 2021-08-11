using System;
using System.Collections;
using System.Diagnostics;
using Init;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class UiUpdater
{
    private TextMeshProUGUI text_j1;
    private TextMeshProUGUI text_j2;

    private Slider stamina_j1;
    private Slider stamina_j2;

    private TextMeshProUGUI timer_j1;
    private TextMeshProUGUI timer_j2;
    
    private Slider parade_j1;
    private Slider parade_j2;

    private bool isSound = false;
    
    public UiUpdater(TextMeshProUGUI text_j1, TextMeshProUGUI text_j2, Slider stamina_j1, Slider stamina_j2, TextMeshProUGUI timer_j1, TextMeshProUGUI timer_j2, Slider parade_j1, Slider parade_j2)
    {
        Debug.Log("\tRécupération des composants graphiques...");
        this.text_j1 = text_j1;
        this.text_j2 = text_j2;

        this.stamina_j1 = stamina_j1;
        this.stamina_j2 = stamina_j2;

        this.timer_j1 = timer_j1;
        this.timer_j2 = timer_j2;

        this.parade_j1 = parade_j1;
        this.parade_j2 = parade_j2;

        this.stamina_j1.maxValue = GameInit.getGameConfig().stamina_amount;
        this.stamina_j2.maxValue = GameInit.getGameConfig().stamina_amount;
        
        this.parade_j1.maxValue = GameInit.getGameConfig().parade_duration - 1;
        this.parade_j2.maxValue = GameInit.getGameConfig().parade_duration - 1;
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
            stamina_j1.value = Player.getStamina(player);
        }
        else
        {
            stamina_j2.value = Player.getStamina(player);
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


    public void updateParadeTimer(Player.Joueur player)
    {
        if (player == Player.Joueur.P1)
        {
            float timer = GameInit.getKatanaPlayer1().getParade().getParadeTimer();
            timer--;
            
            parade_j1.value = timer;
        }
        else
        {
            float timer = GameInit.getKatanaPlayer2().getParade().getParadeTimer();
            timer--;
            parade_j2.value = timer;
        }
    }

    // public void onUpdateParadeCooldown(Player.Joueur player)
    // {
    //     if (player == Player.Joueur.P1)
    //     {
    //         float cooldown = GameInit.getKatanaPlayer1().getParade().getCooldownTimer();
    //         cooldown--;
    //         
    //         parade_j1.value = cooldown;
    //     }
    //     else
    //     {
    //         float cooldown = GameInit.getKatanaPlayer2().getParade().getCooldownTimer();
    //         cooldown--;
    //         parade_j2.value = cooldown;
    //     }
    // }

    public void onParadeEnabled(Player.Joueur player)
    {
        if (player == Player.Joueur.P1)
        {
            parade_j1.gameObject.SetActive(true);
        }
        else
        {
            parade_j2.gameObject.SetActive(true);
        }
        
    }

    public void onParadeDisabled(Player.Joueur player)
    {
        if (player == Player.Joueur.P1)
        {
            parade_j1.value = parade_j1.maxValue;
            parade_j1.gameObject.SetActive(false);
        }
        else
        {
            parade_j2.value = parade_j2.maxValue;
            parade_j2.gameObject.SetActive(false);
        }
    }
    
}
