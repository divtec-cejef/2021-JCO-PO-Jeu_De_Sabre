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

        public static String GetPlayerName(PLAYER player)
        {
            return player == PLAYER.P1 ? player1Name : player2Name;
        }

        public static void SetPlayerNames(String name1, String name2)
        {
            player1Name = name1;
            player2Name = name2;
        }

        public static int GetPlayerColor(PLAYER player)
        {
            return player == PLAYER.P1 ? player1Color : player2Color;
        }
        
        public static void SetPlayerColors(int color1, int color2)
        {
            player1Color = color1;
            player2Color = color2;
        }

        // public static void ApplyPlayerColor(GameObject hat1, GameObject body1, GameObject leg1, int color1, GameObject hat2, GameObject body2, GameObject leg2, int color2)
        // {
        //     ApplyPlayerColor(hat1, body1, leg1, color1, hat2, body2, leg2, color2);
        // }
        
        public static bool DecreasePlayerHealth(PLAYER player, int amount)
        {
            return Health.DecreaseHealth(player, amount);
        }

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
