namespace Players
{
    public class Player
    {
        // Enum utiliser pour effectuer une action sur un joueur précis
        public enum PLAYER
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
