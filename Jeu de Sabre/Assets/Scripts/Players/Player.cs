using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Enum utiliser pour effectuer une action sur un joueur précis
    public enum Joueur
    {
        P1,
        P2,
        Other
    }

    /// <summary>
    /// Permet de mettre à jour le score du joueur
    /// </summary>
    /// <param name="j">Le joueur auquel on veut attribuer les points</param>
    /// <param name="score">Le nombre de point à ajouter à son score</param>
    public static void updatePlayerScore(Joueur j, int score)
    {
        Score.updateScore(j, score);
    }

    /// <summary>
    /// Permet de récupérer le score du joueur
    /// </summary>
    /// <param name="j">Le joueur auquel on veut récupérer le score</param>
    /// <returns>Le score du joueur</returns>
    public static int getScore(Joueur j)
    {
        return Score.getScore(j);
    }

    /// <summary>
    /// Réinitialise le score du joueur passé en paramètre
    /// </summary>
    /// <param name="j">Le joueur auquel on veut réinitialiser les points</param>
    public static void reinitScore(Joueur j)
    {
        Score.reinitScore(j);
    }

    /// <summary>
    /// Permet de baisser l'endurance du joueur passé en paramètre
    /// </summary>
    /// <param name="j">Le joueur auquel on veut baisser l'endurance</param>
    /// <param name="amount">Le nombre de point d'endurance que l'on souhaite retirer</param>
    /// <returns></returns>
    public static bool decreaseStamina(Joueur j, float amount)
    {
        return Stamina.DecreaseStamina(j, amount);
    }

    /// <summary>
    /// Permet d'appliquer une valeur à la stamina du joueur passé en paramètre
    /// </summary>
    /// <param name="j">Le joueur auquel on souhaite appliquer la valeur</param>
    /// <param name="stamina">La nouvelle valeur d'endurance</param>
    public static void setStamina(Joueur j, float stamina)
    {
        Stamina.SetStamina(j, stamina);
    }
    
    /// <summary>
    /// Permet de récupérer la valeur de l'endurance du joueur passé en paramètre
    /// </summary>
    /// <param name="j">Le joueur auquel on souhaite récupérer l'endurance</param>
    /// <returns>L'endurance du joueur</returns>
    public static float getStamina(Joueur j)
    {
        return Stamina.GetStamina(j);
    }
    
}
