using System;
using Init;
using UnityEngine;

namespace Players
{
    public class Player
    {
        private static int player1Color = 2;
        private static int player2Color = 1;
        private static String player1Name = "Player 1";
        private static String player2Name = "Player 2";
        
        // Enum utiliser pour effectuer une action sur un joueur précis
        public enum PLAYER
        {
            P1,
            P2,
            Other
        }

        /// <summary>
        /// Permet de récupérer le nom du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite connaitre le nom</param>
        /// <returns>Le nom du joueur</returns>
        public static String GetPlayerName(PLAYER player)
        {
            return player == PLAYER.P1 ? player1Name : player2Name;
        }

        /// <summary>
        /// Permet de modifier le nom des joueurs
        /// </summary>
        /// <param name="name1">Nom du joueur 1</param>
        /// <param name="name2">Nom du joueur 2</param>
        public static void SetPlayerNames(String name1, String name2)
        {
            player1Name = name1;
            player2Name = name2;
        }

        /// <summary>
        /// Permet de connaitre la couleur du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite connaitre la couleur</param>
        /// <returns>La couleur du joueur</returns>
        public static int GetPlayerColor(PLAYER player)
        {
            return player == PLAYER.P1 ? player1Color : player2Color;
        }
        
        /// <summary>
        /// Permet de changer la couleur des joueurs
        /// </summary>
        /// <param name="color1">La couleur du joueur 1</param>
        /// <param name="color2">La couleur du joueur 2</param>
        public static void SetPlayerColors(int color1, int color2)
        {
            player1Color = color1;
            player2Color = color2;
        }

        /// <summary>
        /// Permet de faire descendre la vie du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite faire baisser la vie</param>
        /// <param name="amount">La valeur de vie à baisser</param>
        /// <returns>Est-ce que la vie a pu etre baissé</returns>
        public static bool DecreasePlayerHealth(PLAYER player, int amount)
        {
            return Health.DecreaseHealth(player, amount);
        }

        /// <summary>
        /// Permet de récupérer la vie du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite récupérer la vie</param>
        /// <returns>La vie du joueur</returns>
        public static int GetPlayerHealth(PLAYER player)
        {
            return Health.GetPlayerHealth(player);
        }

        /// <summary>
        /// Permet de mettre à jour le score du joueur
        /// </summary>
        /// <param name="j">Le joueur auquel on veut attribuer les points</param>
        /// <param name="score">Le nombre de point à ajouter à son score</param>
        public static void UpdatePlayerScore(PLAYER j, int score)
        {
            Score.UpdateScore(j, score);
        }

        /// <summary>
        /// Permet de récupérer le score du joueur
        /// </summary>
        /// <param name="j">Le joueur auquel on veut récupérer le score</param>
        /// <returns>Le score du joueur</returns>
        public static int GetScore(PLAYER j)
        {
            return Score.GetScore(j);
        }

        /// <summary>
        /// Réinitialise le score du joueur passé en paramètre
        /// </summary>
        /// <param name="j">Le joueur auquel on veut réinitialiser les points</param>
        public static void ReinitScore(PLAYER j)
        {
            Score.ReinitScore(j);
        }

        /// <summary>
        /// Permet de baisser l'endurance du joueur passé en paramètre
        /// </summary>
        /// <param name="j">Le joueur auquel on veut baisser l'endurance</param>
        /// <param name="amount">Le nombre de point d'endurance que l'on souhaite retirer</param>
        /// <returns></returns>
        public static bool DecreaseStamina(PLAYER j, float amount)
        {
            return Stamina.DecreaseStamina(j, amount);
        }

        /// <summary>
        /// Permet d'appliquer une valeur à la stamina du joueur passé en paramètre
        /// </summary>
        /// <param name="j">Le joueur auquel on souhaite appliquer la valeur</param>
        /// <param name="stamina">La nouvelle valeur d'endurance</param>
        public static void SetStamina(PLAYER j, float stamina)
        {
            Stamina.SetStamina(j, stamina);
        }
    
        /// <summary>
        /// Permet de récupérer la valeur de l'endurance du joueur passé en paramètre
        /// </summary>
        /// <param name="j">Le joueur auquel on souhaite récupérer l'endurance</param>
        /// <returns>L'endurance du joueur</returns>
        public static float GetStamina(PLAYER j)
        {
            return Stamina.GetStamina(j);
        }
    }
}
