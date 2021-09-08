using System.Collections;
using Players;
using UnityEngine;

namespace Init
{
    public class Round : MonoBehaviour
    {
        private int roundNumber;

        public Round()
        {
            roundNumber = 1;
        }
        
        public int GetRoundNumber()
        {
            return roundNumber;
        }

        public bool StopRound()
        {
            if (roundNumber == 3)
                return true;
            roundNumber++;
            return false;
        }

        public void StartNextRound()
        {
            StartCoroutine(CountdownTimer());
        }

        public void ResetRound()
        {
            Health.Reset();
            Stamina.Reset();
            GameInit.GetEmoteHandler(Player.PLAYER.P1).Reset();
            GameInit.GetPlayer1KatanaOrientation().CanMove(false);
            GameInit.GetPlayer2KatanaOrientation().CanMove(false);
        }

        IEnumerator CountdownTimer()
        {
            IntroAnim.startGame = true;
            GameInit.GetUiUpdater().SetCountdownText("3");
            yield return new WaitForSeconds(1f);
            GameInit.GetUiUpdater().SetCountdownText("2");
            yield return new WaitForSeconds(1f);
            GameInit.GetUiUpdater().SetCountdownText("1");
            yield return new WaitForSeconds(1f);
            GameInit.GetUiUpdater().SetCountdownText("GO ! ");
            yield return new WaitForSeconds(1f);
            IntroAnim.startGame = false;
            
            GameInit.GetPlayer1KatanaOrientation().CanMove(true);
            GameInit.GetPlayer2KatanaOrientation().CanMove(true);
        }
    }
}