using System;
using System.Collections;
using System.Collections.Generic;
using Init;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static int scoreJ1 = 0;
    private static int scoreJ2 = 0;

    /// <summary>
    /// Permet de mettre à jour le score de chaque joueur
    /// </summary>
    /// <param name="j">Le joueur auquel on veut attribuer les points</param>
    /// <param name="score">Le nombre de point à ajouter à son score</param>
    public static void updateScore(Player.Joueur player, int score)
    {
        if (player == Player.Joueur.P1)
        {
            scoreJ1 += score;
            GameInit.getUiUpdater().onScoreUpdate(player);
        }
        else
        {
            scoreJ2 += score;
            GameInit.getUiUpdater().onScoreUpdate(player);
        }
    }
    
    /// <summary>
    /// Permet de récupéer le score actuel du joueur
    /// </summary>
    /// <param name="j">Le joueur auquel on veut récupérer les points</param>
    /// <returns>Le score du joueur</returns>
    public static int getScore(Player.Joueur j)
    {
        return j == Player.Joueur.P1 ? scoreJ1 : scoreJ2;
    }

    /// <summary>
    /// Réinitialise le score du joueur passé en paramètre
    /// </summary>
    /// <param name="j">Le joueur auquel on veut réinitialiser les points</param>
    public static void reinitScore(Player.Joueur j)
    {
        if (j == Player.Joueur.P1)
            scoreJ1 = 0;
        else
            scoreJ2 = 0;
    }
}
