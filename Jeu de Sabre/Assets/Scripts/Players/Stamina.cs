using Init;
using UnityEngine;

namespace Players
{
    public class Stamina : MonoBehaviour
    {
        private static float player1Stamina;
        private static float player2Stamina;

        private static bool canPlayer1Regen;
        private static bool canPlayer2Regen;

        private void Awake()
        {
            print("\tLancement de la mise à jour de la stamina...");
            
            player1Stamina = GameInit.GetGameConfig().stamina_amount;
            player2Stamina = GameInit.GetGameConfig().stamina_amount;

            canPlayer1Regen = true;
            canPlayer2Regen = true;
        }

        /// <summary>
        /// Permet de mettre à jour le score de chaque joueur
        /// </summary>
        /// <param name="player">Le joueur auquel on veut attribuer les points</param>
        /// <param name="value">Le nombre de point à ajouter à son score</param>
        private static void UpdateStamina(Player.PLAYER player, float value)
        {
            if (player == Player.PLAYER.P1)
            {
                player1Stamina += value * Time.deltaTime;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
            }
            else
            {
                player2Stamina += value * Time.deltaTime;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
            }
        }

        /// <summary>
        /// Permet d'appliquer une valeur à l'endurance du joueur
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite modifier l'endurance</param>
        /// <param name="value">La nouvelle valeur</param>
        public static void SetStamina(Player.PLAYER player, float value)
        {
            if (player == Player.PLAYER.P1)
            {
                player1Stamina = value;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
            }
            else
            {
                player2Stamina = value;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
            }
        }
    
        /// <summary>
        /// Renvoie le score actuel
        /// </summary>
        /// <param name="j">Le joueur auquel on veut récupérer les points</param>
        /// <returns></returns>
        public static float GetStamina(Player.PLAYER j)
        {
            return j == Player.PLAYER.P1 ? player1Stamina : player2Stamina;
        }

        /// <summary>
        /// Réinitialise le score du joueur passé en paramètre
        /// </summary>
        /// <param name="j">Le joueur auquel on veut réinitialiser les points</param>
        public static void ReinitStamina(Player.PLAYER j)
        {
            if (j == Player.PLAYER.P1)
                player1Stamina = 0;
            else
                player2Stamina = 0;
        }
    
        /// <summary>
        /// Permet de baisser l'endurance du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite baisser l'endurance</param>
        /// <param name="amount">La valeur à retirer</param>
        /// <returns>Est-ce que l'endurance à pu être baissée</returns>
        public static bool DecreaseStamina(Player.PLAYER player, float amount)
        {

            if (player == Player.PLAYER.P1)
            {
                if (player1Stamina < amount)
                {
                    return false;
                }
            
                player1Stamina -= amount;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
                //canRegenJ1 = false;
                return true;
            }
            else
            {
                if (player2Stamina < amount)
                {
                    return false;
                }
                player2Stamina -= amount;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
                //canRegenJ2 = false;
                return true;
            }
        }

        private void Update()
        {
            if(canPlayer1Regen)
            {
                if (player1Stamina < GameInit.GetGameConfig().stamina_amount /* || !GameInit.getKatanaPlayer1().getParade().getParade()*/)
                {
                    if (player1Stamina + GameInit.GetGameConfig().stamina_regeneration_rate >
                        GameInit.GetGameConfig().stamina_amount)
                        player1Stamina = GameInit.GetGameConfig().stamina_amount;
                    else
                        UpdateStamina(Player.PLAYER.P1, GameInit.GetGameConfig().stamina_regeneration_rate);
                }
            }

            if (!canPlayer2Regen)
                return;

            if (!(player2Stamina < GameInit.GetGameConfig().stamina_amount)) 
                return;
                
            if (player2Stamina + GameInit.GetGameConfig().stamina_regeneration_rate >
                GameInit.GetGameConfig().stamina_amount)

                player2Stamina = GameInit.GetGameConfig().stamina_amount;
            else
                UpdateStamina(Player.PLAYER.P2, GameInit.GetGameConfig().stamina_regeneration_rate);
        }

        /// <summary>
        /// Permet de modifier si le joueur 1 peut régénérer
        /// </summary>
        /// <param name="canPlayer1Regen">Est-ce que le joueur 1 peut régénérer</param>
        public static void CanPlayer1Regen(bool canPlayer1Regen)
        {
            Stamina.canPlayer1Regen = canPlayer1Regen;
        }
        
        /// <summary>
        /// Permet de récupérer si le joueur 1 peut régénérer
        /// </summary>
        /// <returns>Est-ce que le joueur 1 peut régénérer</returns>
        public static bool CanPlayer1Regen()
        {
            return canPlayer1Regen;
        }
        
        /// <summary>
        /// Permet de modifier si le joueur 2 peut régénérer
        /// </summary>
        /// <param name="canPlayer1Regen">Est-ce que le joueur 2 peut régénérer</param>
        public static void CanPlayer2Regen(bool canPlayer2Regen)
        {
            Stamina.canPlayer2Regen = canPlayer2Regen;
        }
        
        /// <summary>
        /// Permet de récupérer si le joueur 2 peut régénérer
        /// </summary>
        /// <returns>Est-ce que le joueur 2 peut régénérer</returns>
        public static bool CanPlayer2Regen()
        {
            return canPlayer2Regen;
        }
    }
}
