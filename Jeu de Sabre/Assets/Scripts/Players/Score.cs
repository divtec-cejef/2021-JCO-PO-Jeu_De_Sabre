using Init;

namespace Players
{
    public class Score
    {
        private static int joueur1Score = 0;
        private static int joueur2Score = 0;

        /// <summary>
        /// Permet de mettre à jour le score de chaque joueur
        /// </summary>
        /// <param name="player">Le joueur auquel on veut attribuer les points</param>
        /// <param name="score">Le nombre de point à ajouter à son score</param>
        public static void UpdateScore(Player.PLAYER player, int score)
        {
            if (player == Player.PLAYER.P1)
            {
                joueur1Score += score;
                GameInit.GetUiUpdater().OnScoreUpdate(player);
            }
            else
            {
                joueur2Score += score;
                GameInit.GetUiUpdater().OnScoreUpdate(player);
            }
        }
    
        /// <summary>
        /// Permet de récupéer le score actuel du joueur
        /// </summary>
        /// <param name="player">Le joueur auquel on veut récupérer les points</param>
        /// <returns>Le score du joueur</returns>
        public static int GetScore(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? joueur1Score : joueur2Score;
        }

        /// <summary>
        /// Réinitialise le score du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on veut réinitialiser les points</param>
        public static void ReinitScore(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
                joueur1Score = 0;
            else
                joueur2Score = 0;
        }
    }
}
