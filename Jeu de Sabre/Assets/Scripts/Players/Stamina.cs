using System.Runtime.CompilerServices;
using Collisions;
using Init;
using UnityEngine;

namespace Players
{
    public class Stamina : MonoBehaviour
    {
        private static float _player1Stamina;
        private static float _player2Stamina;

        private static bool _canPlayer1Regen;
        private static bool _canPlayer2Regen;
        
        //Effet de fatigue
        private static GameObject _player1ExhaustedFx1;
        private static GameObject _player2ExhaustedFx1;
        private static bool _isPlayer1Exausted;
        private static bool _isPlayer2Exausted;

        public static void Init(GameObject player1ExhaustedFx1, GameObject player2ExhaustedFx1)
        {
            _player1ExhaustedFx1 = player1ExhaustedFx1;
            _player2ExhaustedFx1 = player2ExhaustedFx1;
            _player1ExhaustedFx1.SetActive(false);
            _player2ExhaustedFx1.SetActive(false);
            _isPlayer1Exausted = false;
            _isPlayer2Exausted = false;
        }

        private void Awake()
        {
            print("\tLancement de la mise à jour de la stamina...");
            
            _player1Stamina = GameInit.GetGameConfig().stamina_amount;
            _player2Stamina = GameInit.GetGameConfig().stamina_amount;
    
            _canPlayer1Regen = true;
            _canPlayer2Regen = true;
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
                _player1Stamina += value * Time.deltaTime;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
            }
            else
            {
                _player2Stamina += value * Time.deltaTime;
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
                _player1Stamina = value;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
            }
            else
            {
                _player2Stamina = value;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
            }
        }
    
        /// <summary>
        /// Renvoie le score actuel
        /// </summary>
        /// <param name="player">Le joueur auquel on veut récupérer les points</param>
        /// <returns></returns>
        public static float GetStamina(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? _player1Stamina : _player2Stamina;
        }

        /// <summary>
        /// Réinitialise le score du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on veut réinitialiser les points</param>
        public static void ReinitStamina(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
                _player1Stamina = 0;
            else
                _player2Stamina = 0;
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
                if (_player1Stamina < amount)
                {
                    return false;
                }
            
                _player1Stamina -= amount;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
                //canRegenJ1 = false;
                return true;
            }
            else
            {
                if (_player2Stamina < amount)
                {
                    return false;
                }
                _player2Stamina -= amount;
                GameInit.GetUiUpdater().OnStaminaUpdate(player);
                //canRegenJ2 = false;
                return true;
            }
        }

        /// <summary>
        /// Fonction appelé lors de la première frame de la fatigue
        /// </summary>
        public static void OnExthaustedEnabled(Player.PLAYER player, GameObject playerFace)
        {
            SetExthausted(player, true);

            if (player == Player.PLAYER.P1)
                _player1ExhaustedFx1.SetActive(true);
            else if (player == Player.PLAYER.P2)
                _player2ExhaustedFx1.SetActive(true);

            GameInit.GetEmoteHandler(player).GetRandomEmote(EmoteHandler.EMOTE_TYPE.EXHAUSTED, playerFace,true);
        }
        
        /// <summary>
        /// Fonction appelé lorsque la fatigue s'arrête
        /// </summary> 
        public static void OnExthaustedDisabled(Player.PLAYER player)
        {
            SetExthausted(player, false);
            if (player == Player.PLAYER.P1)
            {
                _player1ExhaustedFx1.SetActive(false);
                GameInit.GetEmoteHandler(Player.PLAYER.P2).SetEmote(EmoteHandler.EMOTE_TYPE.EXHAUSTED, CollisionPlayers._player1Face, 1f,true);
            }
            else if (player == Player.PLAYER.P2)
            {
                _player2ExhaustedFx1.SetActive(false);
                GameInit.GetEmoteHandler(Player.PLAYER.P2).SetEmote(EmoteHandler.EMOTE_TYPE.EXHAUSTED, CollisionPlayers._player1Face, 1f,true);
            }
        }
        
        /// <summary>
        /// Permet de récupérer l'état actuel de fatigue
        /// </summary>
        /// <returns>L'état de fatigue</returns>
        public static bool GetExthausted(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? _isPlayer1Exausted : _isPlayer2Exausted;
        }
        
        /// <summary>
        /// Permet de modifier l'état de fatigue visible du joueur
        /// </summary>
        /// <param name="isExthausted">Le nouvel état de fatigue</param>
        public static void SetExthausted(Player.PLAYER player, bool isExthausted)
        {
            if (player == Player.PLAYER.P1)
                _isPlayer1Exausted = isExthausted;
            else if (player == Player.PLAYER.P2)
                _isPlayer2Exausted = isExthausted;
        }
        
        private void Update()
        {
            //Change L'expression du joueur quand il n'a plus de stamina 
            if (!_isPlayer1Exausted || !_isPlayer2Exausted)
            {
                if (Player.GetStamina(Player.PLAYER.P1) < GameInit.GetGameConfig().attack_stamina_decrease)
                    OnExthaustedEnabled(Player.PLAYER.P1,CollisionPlayers._player1Face);
                
                else if (Player.GetStamina(Player.PLAYER.P2) < GameInit.GetGameConfig().attack_stamina_decrease)
                    OnExthaustedEnabled(Player.PLAYER.P2,CollisionPlayers._player2Face);
            }else {
                if(_isPlayer1Exausted)
                    OnExthaustedDisabled(Player.PLAYER.P1);
                else
                    OnExthaustedDisabled(Player.PLAYER.P2);
            }
            
            if(_canPlayer1Regen)
            {
                if (_player1Stamina < GameInit.GetGameConfig().stamina_amount /* || !GameInit.getKatanaPlayer1().getParade().getParade()*/)
                {
                    if (_player1Stamina + GameInit.GetGameConfig().stamina_regeneration_rate >
                        GameInit.GetGameConfig().stamina_amount)
                        _player1Stamina = GameInit.GetGameConfig().stamina_amount;
                    else
                        UpdateStamina(Player.PLAYER.P1, GameInit.GetGameConfig().stamina_regeneration_rate);
                }
            }

            if (!_canPlayer2Regen)
                return;

            if (!(_player2Stamina < GameInit.GetGameConfig().stamina_amount)) 
                return;

            if (_player2Stamina + GameInit.GetGameConfig().stamina_regeneration_rate >
                GameInit.GetGameConfig().stamina_amount)

                _player2Stamina = GameInit.GetGameConfig().stamina_amount;
            else
                UpdateStamina(Player.PLAYER.P2, GameInit.GetGameConfig().stamina_regeneration_rate);
        }

        /// <summary>
        /// Permet de modifier si le joueur 1 peut régénérer
        /// </summary>
        /// <param name="canPlayer1Regen">Est-ce que le joueur 1 peut régénérer</param>
        public static void CanPlayer1Regen(bool canPlayer1Regen)
        {
            Stamina._canPlayer1Regen = canPlayer1Regen;
        }
        
        /// <summary>
        /// Permet de récupérer si le joueur 1 peut régénérer
        /// </summary>
        /// <returns>Est-ce que le joueur 1 peut régénérer</returns>
        public static bool CanPlayer1Regen()
        {
            return _canPlayer1Regen;
        }
        
        /// <summary>
        /// Permet de modifier si le joueur 2 peut régénérer
        /// </summary>
        /// <param name="canPlayer1Regen">Est-ce que le joueur 2 peut régénérer</param>
        public static void CanPlayer2Regen(bool canPlayer2Regen)
        {
            Stamina._canPlayer2Regen = canPlayer2Regen;
        }
        
        /// <summary>
        /// Permet de récupérer si le joueur 2 peut régénérer
        /// </summary>
        /// <returns>Est-ce que le joueur 2 peut régénérer</returns>
        public static bool CanPlayer2Regen()
        {
            return _canPlayer2Regen;
        }
    }
    
}
