using Init;
using UnityEngine;

namespace Players
{
    public class Health : MonoBehaviour
    {
        // La vie des joueurs
        private static int _player1Health;
        private static int _player2Health;

        private void Awake()
        {
            _player1Health = GameInit.GetGameConfig().player_health_amount;
            _player2Health = GameInit.GetGameConfig().player_health_amount;
        }

        /// <summary>
        /// Permet de faire descendre la vie du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite faire baisser la vie</param>
        /// <param name="amount">La valeur de vie à baisser</param>
        /// <returns>Est-ce que la vie a pu etre baissé</returns>
        public static bool DecreaseHealth(Player.PLAYER player, int amount)
        {
            switch (player)
            {
                case Player.PLAYER.P1:
                {
                    _player1Health -= amount;
                    if (_player1Health <= 0)
                    {
                        _player1Health = 0;
                        GameInit.GetUiUpdater().OnHealthUpdate();
                        return false;
                    }
                    GameInit.GetUiUpdater().OnHealthUpdate();
                    return true;
                }
                case Player.PLAYER.P2:
                {
                    _player2Health -= amount;
                    if (_player2Health <= 0)
                    {
                        _player2Health = 0;
                        GameInit.GetUiUpdater().OnHealthUpdate();
                        return false;
                    }
                    GameInit.GetUiUpdater().OnHealthUpdate();
                    return true;
                }
                default:
                    return false;
            }
        }

        /// <summary>
        /// Permet de récupérer la vie du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite récupérer la vie</param>
        /// <returns>La vie du joueur</returns>
        public static int GetPlayerHealth(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? _player1Health : _player2Health;
        }

        /// <summary>
        /// Permet de réinitialiser la vie
        /// </summary>
        public static void Reset()
        {
            _player1Health = GameInit.GetGameConfig().player_health_amount;
            _player2Health = GameInit.GetGameConfig().player_health_amount;
            GameInit.GetUiUpdater().UpdateDamageOverlay();
        }
    }
}