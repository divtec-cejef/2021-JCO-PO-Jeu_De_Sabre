using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public enum Joueur
    {
        P1,
        P2,
        Other
    }

    public static void updatePlayerScore(Joueur j, int score)
    {
        Score.updateScore(j, score);
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

    public static void setStamina(Joueur j, float stamina)
    {
        Stamina.setStamina(j, stamina);
    }
    
    public static float getStamina(Joueur j)
    {
        return Stamina.getStamina(j);
    }
    
}
