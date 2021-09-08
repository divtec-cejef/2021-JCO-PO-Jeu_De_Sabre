using Init;
using UnityEngine;

namespace Players
{
    public class Health : MonoBehaviour
    {
        private static int _player1Health;
        private static int _player2Health;

        private void Awake()
        {
            _player1Health = GameInit.GetGameConfig().player_health_amount;
            _player2Health = GameInit.GetGameConfig().player_health_amount;
        }

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

        public static int GetPlayerHealth(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? _player1Health : _player2Health;
        }

        public static void Reset()
        {
            _player1Health = GameInit.GetGameConfig().player_health_amount;
            _player2Health = GameInit.GetGameConfig().player_health_amount;
        }
    }
}