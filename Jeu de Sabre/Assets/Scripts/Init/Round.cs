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

        // List des gagnants 
        public List<Player.PLAYER> winners;

        /// <summary>
        /// Constructeur du Round
        /// </summary>
        public Round()
        {
            // Initialisation des valeurs du round
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

        /// <summary>
        /// Permet de stopper le round et de le réinitialiser
        /// </summary>
        /// <returns>Est-ce que le round était le dernier</returns>
        public bool StopRound()
        {
            // Réinitialisation de toute les valeurs unique à un round
            CollisionPlayers.attack.DisableAnimation();
            GameInit.GetUiUpdater().UpdateRoundHUD(GetRoundWinner(false), roundNumber);
            GameInit.GetUiUpdater().SetCountdownText("-");
            CollisionPlayers.canAttack = false;
            ResetRound();
            
            // Mise à jour du round et vérification du dernier
            if (roundNumber == 3)
                return true;
            roundNumber++;
            return false;
        }

        /// <summary>
        /// Lancement du prochain round
        /// </summary>
        public void StartNextRound()
        {
            // Activation de l'effet de menace sur un des deux joueur
            if(Random.Range(0,2) == 0)
                GameInit.GetEmoteHandler(Player.PLAYER.P1).MenacingEffect(Player.PLAYER.P1);
            else
                GameInit.GetEmoteHandler(Player.PLAYER.P2).MenacingEffect(Player.PLAYER.P2);
            
            // Réinitialisation de certaine valeur
            currentRoundTimer = GameInit.GetGameConfig().game_time;
            isRoundAborted = false;
            isRoundFinished = false;
            
            // Lancement du timer
            StartCoroutine(CountdownTimer());
        }
        
        /// <summary>
        /// Permet de lancer le timer du round tant qu'il n'est pas terminé ou que le round n'est pas arrêté prématurément
        /// </summary>
        IEnumerator RoundTimer()
        {
            // Boucle infinie tant que le round est en cours
            while (!isRoundAborted && !isRoundFinished)
            {
                // Baisse du timer et mise à jour de l'affichage
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
            // Appel de la fonction appelé la fin du timer
            GetComponent<GameInit>().OnTimerEnd();
        }
        
        /// <summary>
        /// Permet d'afficher le décompte au début du round
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Permet de récupérer le gagnant du round qui vient d'être joué
        /// </summary>
        /// <param name="insertPlayer">Est-ce que le gagnant doit-être inscrit dans la liste</param>
        /// <returns></returns>
        public Player.PLAYER GetRoundWinner(bool insertPlayer)
        {
            // Récupération de la vie des deux joueurs
            int heal1 = Player.GetPlayerHealth(Player.PLAYER.P1);
            int heal2 = Player.GetPlayerHealth(Player.PLAYER.P2);

            // Détermination du gagnant
            Player.PLAYER winner = Player.PLAYER.Other;
            
            if (heal1 > heal2)
                winner = Player.PLAYER.P1;
            if (heal2 > heal1)
                winner = Player.PLAYER.P2;
            
            // Si il faut inscrire le joueur, ajout dans la liste
            if(insertPlayer) winners.Add(winner);
            return winner;
        }
        
        /// <summary>
        /// Permet de réinitialiser le round
        /// </summary>
        public void ResetRound()
        {
            Stamina.Reset();
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