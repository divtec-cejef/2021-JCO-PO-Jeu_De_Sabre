using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UiUpdater
{
    private Text text_j1;
    private Text text_j2;
    
    public UiUpdater(Text text_j1, Text text_j2)
    {
        this.text_j1 = text_j1;
        this.text_j2 = text_j2;
    }
    
    
    
    public void onScoreUpdate(Player.Joueur j, int score)
    {
        
    }

    private String formatScore(int score)
    {
        String scoreString = "0000";
        if (score >= 1000)
            scoreString =  score.ToString();
        
        if (score >= 100) 
            scoreString = "0" + score;

        if (score >= 10)
            scoreString = "00" + score;
        
        if (score >= 1)
            scoreString = "000" + score;

        return "Score : " + scoreString;
    }
}
