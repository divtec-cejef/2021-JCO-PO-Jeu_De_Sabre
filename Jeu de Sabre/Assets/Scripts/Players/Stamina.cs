using System.Collections;
using Init;
using UnityEngine;

namespace Players
{
    public class Stamina : MonoBehaviour
    {
        private static float stamJ1;
        private static float stamJ2;

        public static bool canPlayer1Regen;
        public static bool canPlayer2Regen;
        //
        // public static bool canRegenJ1 = true;
        // public static bool canRegenJ2 = true;
        //
        // public static float timerJ1 = 0;
        // public static float timerJ2 = 0;

        private void Awake()
        {
            print("\tLancement de la mise à jour de la stamina...");
            StartCoroutine(UpdateStamina());
            stamJ1 = GameInit.getGameConfig().stamina_amount;
            stamJ2 = GameInit.getGameConfig().stamina_amount;

            canPlayer1Regen = true;
            canPlayer2Regen = true;
        }

        /// <summary>
        /// Permet de mettre à jour le score de chaque joueur
        /// </summary>
        /// <param name="player">Le joueur auquel on veut attribuer les points</param>
        /// <param name="value">Le nombre de point à ajouter à son score</param>
        private static void UpdateStamina(Player.Joueur player, float value)
        {
            if (player == Player.Joueur.P1)
            {
                stamJ1 += value;
                GameInit.getUiUpdater().onStaminaUpdate(player);
            }
            else
            {
                stamJ2 += value;
                GameInit.getUiUpdater().onStaminaUpdate(player);
            }
        }

        /// <summary>
        /// Permet d'appliquer une valeur à l'endurance du joueur
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite modifier l'endurance</param>
        /// <param name="value">La nouvelle valeur</param>
        public static void SetStamina(Player.Joueur player, float value)
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
        public static float GetStamina(Player.Joueur j)
        {
            return j == Player.Joueur.P1 ? stamJ1 : stamJ2;
        }

        /// <summary>
        /// Réinitialise le score du joueur passé en paramètre
        /// </summary>
        /// <param name="j">Le joueur auquel on veut réinitialiser les points</param>
        public static void ReinitStamina(Player.Joueur j)
        {
            if (j == Player.Joueur.P1)
                stamJ1 = 0;
            else
                stamJ2 = 0;
        }
    
        /// <summary>
        /// Permet de baisser l'endurance du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite baisser l'endurance</param>
        /// <param name="amount">La valeur à retirer</param>
        /// <returns>Est-ce que l'endurance à pu être baissée</returns>
        public static bool DecreaseStamina(Player.Joueur player, float amount)
        {

            if (player == Player.Joueur.P1)
            {
                if (stamJ1 < amount)
                {
                    return false;
                }
            
                stamJ1 -= amount;
                GameInit.getUiUpdater().onStaminaUpdate(player);
                //canRegenJ1 = false;
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
                //canRegenJ2 = false;
                return true;
            }
        }


        // public static void resetTimer(Player.Joueur j)
        // {
        //     if (j == Player.Joueur.P1)
        //         timerJ1 = 0.0f;
        //     else
        //         timerJ2 = 0.0f;
        // }
    
        // private void Update()
        // {
        //     
        //     if (!canRegenJ1)
        //         timerJ1 += Time.deltaTime;
        //
        //     if (!canRegenJ2)
        //         timerJ2 += Time.deltaTime;
        //
        //     if (timerJ1 >= 2.0f)
        //     {
        //         canRegenJ1 = true;
        //         timerJ1 = 0.0f;
        //     }
        //
        //     if (timerJ2 >= 2.0f)
        //     {
        //         canRegenJ2 = true;
        //         timerJ2 = 0.0f;
        //     }
        //
        //     if (stamJ1 < GameInit.getGameConfig().stamina_amount && canRegenJ1)
        //     {
        //         if (stamJ1 + GameInit.getGameConfig().stamina_regeneration_rate >
        //             GameInit.getGameConfig().stamina_amount)
        //             stamJ1 = GameInit.getGameConfig().stamina_amount;
        //         else
        //             updateStamina(Player.Joueur.P1, GameInit.getGameConfig().stamina_regeneration_rate);
        //     }
        //
        //     if (stamJ2 < GameInit.getGameConfig().stamina_amount && canRegenJ2)
        //     {
        //         if (stamJ2 + GameInit.getGameConfig().stamina_regeneration_rate >
        //             GameInit.getGameConfig().stamina_amount)
        //             stamJ2 = GameInit.getGameConfig().stamina_amount;
        //         else
        //             updateStamina(Player.Joueur.P2, GameInit.getGameConfig().stamina_regeneration_rate);
        //     }
        //     //print(stamJ1);
        // }
        // }

        private static IEnumerator UpdateStamina()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(GameInit.getGameConfig().stamina_regeneration_time);
            
                if(canPlayer1Regen)
                {
                    if (stamJ1 < GameInit.getGameConfig().stamina_amount /* || !GameInit.getKatanaPlayer1().getParade().getParade()*/)
                    {
                        if (stamJ1 + GameInit.getGameConfig().stamina_regeneration_rate >
                            GameInit.getGameConfig().stamina_amount)
                            stamJ1 = GameInit.getGameConfig().stamina_amount;
                        else
                            UpdateStamina(Player.Joueur.P1, GameInit.getGameConfig().stamina_regeneration_rate);
                    }
                }

                if (!canPlayer2Regen) 
                    continue;

                if (!(stamJ2 < GameInit.getGameConfig().stamina_amount)) 
                    continue;
                
                if (stamJ2 + GameInit.getGameConfig().stamina_regeneration_rate >
                    GameInit.getGameConfig().stamina_amount)

                    stamJ2 = GameInit.getGameConfig().stamina_amount;
                else
                    UpdateStamina(Player.Joueur.P2, GameInit.getGameConfig().stamina_regeneration_rate);
            }

        }
    }
}
