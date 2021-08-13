using System;
using Init;
using Mouvements.Parade;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Players.UI
{
    public class UiUpdater
    {
        private TextMeshProUGUI player1ScoreText;
        
        private TextMeshProUGUI player2ScoreText;

        private Slider player1StaminaSlider;
        
        private Slider player2StaminaSlider;

        private TextMeshProUGUI player1TimerText;
        
        private TextMeshProUGUI player2TimerText;
    
        private Slider player1ParadeSlider;
        
        private Slider player2ParadeSlider;

        private bool m_IsSoundPlaying;
    
        
        /// <summary>
        /// Constructeur du UiUpdater
        /// </summary>
        /// <param name="player1ScoreText">Le texte correspondant au score du joueur 1</param>
        /// <param name="player2ScoreText">Le texte correspondant au score du joueur 2</param>
        /// <param name="player1StaminaSlider">Le slider correspondant a la stamina du joueur 1</param>
        /// <param name="player2StaminaSlider">Le slider correspondant a la stamina du joueur 2</param>
        /// <param name="player1TimerText">Le texte correspondant au timer du joueur 1</param>
        /// <param name="player2TimerText">Le texte correspondant au timer du joueur 2</param>
        /// <param name="player1ParadeSlider">Le slider correspondant a la slider du joueur 1</param>
        /// <param name="player2ParadeSlider">Le slider correspondant a la slider du joueur 2</param>
        public UiUpdater(TextMeshProUGUI player1ScoreText, TextMeshProUGUI player2ScoreText, Slider player1StaminaSlider, Slider player2StaminaSlider, TextMeshProUGUI player1TimerText, TextMeshProUGUI player2TimerText, Slider player1ParadeSlider, Slider player2ParadeSlider)
        {
            m_IsSoundPlaying = false;
            Debug.Log("\tRécupération des composants graphiques...");
            this.player1ScoreText = player1ScoreText;
            this.player2ScoreText = player2ScoreText;

            this.player1StaminaSlider = player1StaminaSlider;
            this.player2StaminaSlider = player2StaminaSlider;

            this.player1TimerText = player1TimerText;
            this.player2TimerText = player2TimerText;

            this.player1ParadeSlider = player1ParadeSlider;
            this.player2ParadeSlider = player2ParadeSlider;

            this.player1StaminaSlider.maxValue = GameInit.GetGameConfig().stamina_amount;
            this.player2StaminaSlider.maxValue = GameInit.GetGameConfig().stamina_amount;
        
            this.player1ParadeSlider.maxValue = GameInit.GetGameConfig().parade_duration;
            this.player2ParadeSlider.maxValue = GameInit.GetGameConfig().parade_duration;
        }

        /// <summary>
        /// Permet de mettre à jour le score
        /// </summary>
        /// <param name="player">Le joueur auquel on veut mettre à jour le score</param>
        public void OnScoreUpdate(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
                player1ScoreText.text = FormatScore(Player.GetScore(player));
            else
                player2ScoreText.text = FormatScore(Player.GetScore(player));
        }

        /// <summary>
        /// Permet de mettre à jour la stamina
        /// </summary>
        /// <param name="player">Le joueur auquel on veut mettre à jour la stamina</param>
        public void OnStaminaUpdate(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
                player1StaminaSlider.value = Player.GetStamina(player);
            
            else
                player2StaminaSlider.value = Player.GetStamina(player);
        }

        /// <summary>
        /// Permet de formater le score au format 0000
        /// </summary>
        /// <param name="score">Le score a formater</param>
        /// <returns>Le score formaté</returns>
        private String FormatScore(int score)
        {
            String scoreString;
        
            if (score >= 1000)
                scoreString =  score.ToString();
            else
            {
                scoreString = "0" + score;

                if (score >= 100) 
                    return "Score : " + scoreString;
            
                scoreString = "0" + scoreString;
            
                if (score < 10)
                    scoreString = "0" + scoreString;
            }
        
            return "Score : " + scoreString;
        }
    
        /// <summary>
        /// Permet de mettre à jour le timer
        /// </summary>
        public void OnTimerUpdate()
        {
            player1TimerText.text = player2TimerText.text = FormatTime(GameInit.GetTimer().GetTimer());
        }
    
        /// <summary>
        /// Permet de formatter le timer au format 00:00
        /// </summary>
        /// <param name="time">Le timer a formatter</param>
        /// <returns>Le timer formatté</returns>
        private String FormatTime(int time)
        {
            String format = "";

            if (time <= 20 && !m_IsSoundPlaying)
            {
                var position = new Vector3(11.9f, 11.0f, 15.6f);
                var rotation = new Quaternion(0, 0, 0, 0);
                Object.Instantiate(GameInit.GetSoundHandler().GetTimerSound(), position, rotation);
                m_IsSoundPlaying = true;
            }
        
        
            if (time / 60 < 10)
            {
                format += "0";
            }

            format += time / 60 + ":";

            if (time % 60 < 10)
            {
                format += "0";
            }

            format += time % 60;

            return format;
        }

        /// <summary>
        /// Permet de mettre à jour l'affichage au déclenchement de la parade
        /// </summary>
        /// <param name="player">Le joueur auquel on veut mettre à jour la parade</param>
        public void OnParadeEnabled(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
            {
                Stamina.CanPlayer1Regen(false);
                player1ParadeSlider.gameObject.SetActive(true);
            }
            else
            {
                Stamina.CanPlayer2Regen(false);
                player2ParadeSlider.gameObject.SetActive(true);
            }
        }
        
        /// <summary>
        /// Permet de mettre à jour l'affichage de la parade
        /// </summary>
        /// <param name="player">Le joueur auquel on veut mettre à jour la parade</param>
        public void OnParadeUpdate(Player.PLAYER player)
        {
            switch (player)
            {
                case Player.PLAYER.P1:
                    player1ParadeSlider.value = GameInit.GetPlayer1KatanaOrientation().GetPlayerParade().GetParadeTimer();
                    break;
                case Player.PLAYER.P2:
                    player2ParadeSlider.value = GameInit.GetPlayer2KatanaOrientation().GetPlayerParade().GetParadeTimer();
                    break;
                default:
                    Debug.LogError("Impossible d'identifier le joueur");
                    break;
            }
        }

        /// <summary>
        /// Permet de mettre à jour l'affichage à l'arrêt de la parade
        /// </summary>
        /// <param name="player">Le joueur auquel on veut mettre à jour la parade</param>
        public void OnParadeDisabled(Player.PLAYER player)
        {
            switch (player)
            {
                case Player.PLAYER.P1:
                {
                    Stamina.CanPlayer1Regen(true);
                
                    Parade parade = GameInit.GetPlayer1KatanaOrientation().GetPlayerParade();
                    float timer = parade.GetParadeTimer();
                    if (timer < GameInit.GetGameConfig().parade_duration)
                    {
                        timer += 1f * Time.deltaTime;
                    }
                    else
                    {
                        timer = GameInit.GetGameConfig().parade_duration;
                        parade.SetReady(true);
                        player1ParadeSlider.gameObject.SetActive(false);
                    }
                    parade.SetParadeTimer(timer);
                    player1ParadeSlider.value = timer;
                    break;
                }
                case Player.PLAYER.P2:
                {
                    Stamina.CanPlayer2Regen(true);
                
                    Parade parade = GameInit.GetPlayer2KatanaOrientation().GetPlayerParade();
                    float timer = parade.GetParadeTimer();
                    if (timer < GameInit.GetGameConfig().parade_duration)
                    {
                        timer += 1f * Time.deltaTime;
                    }
                    else
                    {
                        timer = GameInit.GetGameConfig().parade_duration;
                        parade.SetReady(true);
                        player2ParadeSlider.gameObject.SetActive(false);
                    }
                    parade.SetParadeTimer(timer);
                    player2ParadeSlider.value = timer;
                    break;
                }
            }
        }
    }
}
