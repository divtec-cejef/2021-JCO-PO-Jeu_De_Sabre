using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    private static float stamJ1;
    private static float stamJ2;

    public static bool canRegenJ1 = true;
    public static bool canRegenJ2 = true;

    public static float timerJ1 = 0;
    public static float timerJ2 = 0;

    public static void initStamina()
    {
        stamJ1 = GameInit.getGameConfig().stamina_amount;
        stamJ2 = GameInit.getGameConfig().stamina_amount;
    }
    
    /// <summary>
    /// Permet de mettre à jour le score de chaque joueur
    /// </summary>
    /// <param name="j">Le joueur auquel on veut attribuer les points</param>
    /// <param name="score">Le nombre de point à ajouter à son score</param>
    private static void updateStamina(Player.Joueur player, float stamina)
    {
        if (player == Player.Joueur.P1)
        {
            stamJ1 += stamina;
            GameInit.getUiUpdater().onStaminaUpdate(player);
        }
        else
        {
            stamJ2 += stamina;
            GameInit.getUiUpdater().onStaminaUpdate(player);
        }
    }

    public static void setStamina(Player.Joueur player, float value)
    {
        if (player == Player.Joueur.P1)
        {
            stamJ1 = value;
            GameInit.getUiUpdater().onStaminaUpdate(player);
        }
        else
        {
            stamJ2 = value;
            GameInit.getUiUpdater().onStaminaUpdate(player);
        }
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
    
    public static bool decreaseStamina(Player.Joueur player, float amount)
    {

        if (player == Player.Joueur.P1)
        {
            if (stamJ1 < amount)
            {
                return false;
            }
            
            stamJ1 -= amount;
            GameInit.getUiUpdater().onStaminaUpdate(player);
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
            GameInit.getUiUpdater().onStaminaUpdate(player);
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

        if (stamJ1 < GameInit.getGameConfig().stamina_amount  && canRegenJ1)
        {
            if (stamJ1 + GameInit.getGameConfig().stamina_regeneration_rate > GameInit.getGameConfig().stamina_amount)
                stamJ1 = GameInit.getGameConfig().stamina_amount;
            else
                updateStamina(Player.Joueur.P1, GameInit.getGameConfig().stamina_regeneration_rate);
        }
        if (stamJ2 < GameInit.getGameConfig().stamina_amount  && canRegenJ2)
        {
            if (stamJ2 + GameInit.getGameConfig().stamina_regeneration_rate > GameInit.getGameConfig().stamina_amount)
                stamJ2 = GameInit.getGameConfig().stamina_amount;
            else
                updateStamina(Player.Joueur.P2, GameInit.getGameConfig().stamina_regeneration_rate);
        }
    }
}
