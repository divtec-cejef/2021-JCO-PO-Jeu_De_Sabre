using System.Collections;
using System.Collections.Generic;
using Collisions;
using Players;
using Players.UI;
using UnityEngine;

namespace Init
{
    public class Round : MonoBehaviour
    {
        private int roundNumber;
        private float currentRoundTimer;
        private bool isRoundFinished;
        public bool isRoundAborted;

        private List<Player.PLAYER> winners;

        public Round()
        {
            winners = new List<Player.PLAYER>();
            currentRoundTimer = GameInit.GetGameConfig().game_time;
            isRoundAborted = false;
            isRoundFinished = false;
            roundNumber = 1;
        }
        
        public int GetRoundNumber()
        {
            return roundNumber;
        }

        public bool StopRound()
        {
            CollisionPlayers.attack.disableAttack();
            GameInit.GetUiUpdater().UpdateRoundHUD(GetRoundWinner(false), roundNumber);
            GameInit.GetUiUpdater().SetCountdownText("-");
            CollisionPlayers.canAttack = false;
            ResetRound();
            if (roundNumber == 3)
                return true;
            roundNumber++;
            return false;
        }

        public void StartNextRound()
        {
            currentRoundTimer = GameInit.GetGameConfig().game_time;
            isRoundAborted = false;
            isRoundFinished = false;
            StartCoroutine(CountdownTimer());
        }
        
        IEnumerator RoundTimer()
        {
            while (!isRoundAborted && !isRoundFinished)
            {
                if (currentRoundTimer > 0)
                {
                    currentRoundTimer -= Time.deltaTime;
                    GameInit.GetUiUpdater().OnTimerUpdate((int)currentRoundTimer);
                }
                else
                {
                    isRoundFinished = true;
                }

                yield return new WaitForEndOfFrame();
            }
            GetComponent<GameInit>().OnTimerEnd();
        }
        
        IEnumerator CountdownTimer()
        {
            yield return new WaitForSeconds(1.5f);
            IntroAnim.startGame = true;
            UiUpdater updater = GameInit.GetUiUpdater();
            StartCoroutine(GameInit.GetUiUpdater().countdownText.GetComponent<IntroAnim>().PulseEffect());
            updater.SetCountdownText("3");
            yield return new WaitForSeconds(1f);
            updater.SetCountdownText("2");
            yield return new WaitForSeconds(1f);
            updater.SetCountdownText("1");
            yield return new WaitForSeconds(1f);
            updater.SetCountdownText("GO ! ");
            yield return new WaitForSeconds(.5f);
            IntroAnim.startGame = false;
            CollisionPlayers.canAttack = true;

            StartCoroutine(RoundTimer());
        }

        public Player.PLAYER GetRoundWinner(bool insertPlayer)
        {
            int heal1 = Player.GetPlayerHealth(Player.PLAYER.P1);
            int heal2 = Player.GetPlayerHealth(Player.PLAYER.P2);

            Player.PLAYER winner = Player.PLAYER.Other;
            
            if (heal1 > heal2)
                winner = Player.PLAYER.P1;
            if (heal2 > heal1)
                winner = Player.PLAYER.P2;
            
            // Egalité au niveau de la vie
            if(insertPlayer) winners.Add(winner);
            return winner;
        }
        
        public void ResetRound()
        {
            Stamina.Reset();
            GameInit.GetEmoteHandler(Player.PLAYER.P1).Reset();
            GameInit.GetUiUpdater().RefreshHUD();
            GameInit.GetPlayer1KatanaOrientation().CanMove(false);
            GameInit.GetPlayer2KatanaOrientation().CanMove(false);
        }

        public int GetCurrentTimer()
        {
            return (int)currentRoundTimer;
        }
    }
}