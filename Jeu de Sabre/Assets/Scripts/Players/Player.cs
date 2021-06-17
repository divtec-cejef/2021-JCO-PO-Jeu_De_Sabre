using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public enum Joueur
    {
        P1,
        P2
    }

    public static void updatePlayerScore(Joueur j, int score, Text text)
    {
        Score.updateScore(j, score, text);
    }

    public static int getScore(Joueur j)
    {
        return Score.getScore(j);
    }

    public static void reinitScore(Joueur j)
    {
        Score.reinitScore(j);
    }

    public static bool decreaseStamina(Joueur j, float amount)
    {
        return Stamina.decreaseStamina(j, amount);
    }
    
    public static float getStamina(Joueur j)
    {
        return Stamina.getStamina(j);
    }
    
}
