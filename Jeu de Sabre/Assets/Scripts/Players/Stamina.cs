using System;
using System.Collections;
using System.Runtime.CompilerServices;
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
        //
        // public static bool canRegenJ1 = true;
        // public static bool canRegenJ2 = true;
        //
        // public static float timerJ1 = 0;
        // public static float timerJ2 = 0;

        private void Awake()
        {
            print("\tLancement de la mise à jour de la stamina...");
            //StartCoroutine(UpdateStamina());
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

        // private static IEnumerator UpdateStamina()
        // {
        //     while (true)
        //     {
        //         yield return new WaitForSecondsRealtime(GameInit.GetGameConfig().stamina_regeneration_time);
        //     
        //         if(canPlayer1Regen)
        //         {
        //             if (player1Stamina < GameInit.GetGameConfig().stamina_amount /* || !GameInit.getKatanaPlayer1().getParade().getParade()*/)
        //             {
        //                 if (player1Stamina + GameInit.GetGameConfig().stamina_regeneration_rate >
        //                     GameInit.GetGameConfig().stamina_amount)
        //                     player1Stamina = GameInit.GetGameConfig().stamina_amount;
        //                 else
        //                     UpdateStamina(Player.PLAYER.P1, GameInit.GetGameConfig().stamina_regeneration_rate);
        //             }
        //         }
        //
        //         if (!canPlayer2Regen) 
        //             continue;
        //
        //         if (!(player2Stamina < GameInit.GetGameConfig().stamina_amount)) 
        //             continue;
        //         
        //         if (player2Stamina + GameInit.GetGameConfig().stamina_regeneration_rate >
        //             GameInit.GetGameConfig().stamina_amount)
        //
        //             player2Stamina = GameInit.GetGameConfig().stamina_amount;
        //         else
        //             UpdateStamina(Player.PLAYER.P2, GameInit.GetGameConfig().stamina_regeneration_rate);
        //     }
        // }

        public static void CanPlayer1Regen(bool canPlayer1Regen)
        {
            Stamina.canPlayer1Regen = canPlayer1Regen;
        }
        
        public static bool CanPlayer1Regen()
        {
            return canPlayer1Regen;
        }
        
        public static void CanPlayer2Regen(bool canPlayer2Regen)
        {
            Stamina.canPlayer2Regen = canPlayer2Regen;
        }
        
        public static bool CanPlayer2Regen()
        {
            return canPlayer2Regen;
        }
    }
}
