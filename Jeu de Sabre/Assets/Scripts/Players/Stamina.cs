using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private static float stamJ1 = 100.0f;
    private static float stamJ2 = 100.0f;

    public static bool canRegenJ1 = true;
    public static bool canRegenJ2 = true;

    // private static bool isRegenJ1 = false;
    // private static bool isRegenJ2 = false;

    public static float timerJ1 = 0;
    public static float timerJ2 = 0;

    private float regenRate = 0.1f;
    
    /// <summary>
    /// Permet de mettre à jour le score de chaque joueur
    /// </summary>
    /// <param name="j">Le joueur auquel on veut attribuer les points</param>
    /// <param name="score">Le nombre de point à ajouter à son score</param>
    private static void updateStamina(Player.Joueur j, float score)
    {
        if (j == Player.Joueur.P1)
            stamJ1 += score;
        else
            stamJ2 += score;
    }
    
    /// <summary>
    /// Renvoie le score actuel
    /// </summary>
    /// <param name="j">Le joueur auquel on veut récupérer les points</param>
    /// <returns></returns>
    public static float getStamina(Player.Joueur j)
    {
        return j == Player.Joueur.P1 ? stamJ1 : stamJ2;
    }

    /// <summary>
    /// Réinitialise le score du joueur passé en paramètre
    /// </summary>
    /// <param name="j">Le joueur auquel on veut réinitialiser les points</param>
    public static void reinitStamina(Player.Joueur j)
    {
        if (j == Player.Joueur.P1)
            stamJ1 = 0;
        else
            stamJ2 = 0;
    }
    
    public static bool decreaseStamina(Player.Joueur j, float amount)
    {

        if (j == Player.Joueur.P1)
        {
            if (stamJ1 < amount)
            {
                return false;
            }
            
            stamJ1 -= amount;
            canRegenJ1 = false;
            return true;
        }
        else
        {
            if (stamJ2 < amount)
            {
                return false;
            }
            stamJ2 -= amount;
            canRegenJ2 = false;
            return true;
        }
    }


    public static void resetTimer(Player.Joueur j)
    {
        if (j == Player.Joueur.P1)
            timerJ1 = 0.0f;
        else
            timerJ2 = 0.0f;
    }
    
    private void Update()
    {
        if (!canRegenJ1)
            timerJ1 += Time.deltaTime;
        
        if (!canRegenJ2)
            timerJ2 += Time.deltaTime;
        
        if (timerJ1 >= 2.0f)
        {
            canRegenJ1 = true;
            timerJ1 = 0.0f;
        }
        
        if (timerJ2 >= 2.0f)
        {
            canRegenJ2 = true;
            timerJ2 = 0.0f;
        }

        if (stamJ1 < 100.0f  && canRegenJ1)
        {
            if (stamJ1 + regenRate > 100.0f)
                stamJ1 = 100.0f;
            else
                updateStamina(Player.Joueur.P1, regenRate);
        }
        if (stamJ2 < 100.0f  && canRegenJ2)
        {
            if (stamJ2 + regenRate > 100.0f)
                stamJ2 = 100.0f;
            else
                updateStamina(Player.Joueur.P2, regenRate);
        }
        
        //print(stamJ1);
        
    }
}
