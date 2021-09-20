using System;
using System.Collections;
using Init;
using Mouvements.Parade;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.PlayerLoop;
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

        private TextMeshProUGUI timerText;
        
        public TextMeshProUGUI countdownText;

        private Slider player1ParadeSlider;
        
        private Slider player2ParadeSlider;

        private Slider player1HealthBar;
        
        private Slider player2HealthBar;

        private TextMeshProUGUI player1EndName;
        
        private TextMeshProUGUI player2EndName;
        
        private TextMeshProUGUI player1EndScore;
        
        private TextMeshProUGUI player2EndScore;
        
        private bool m_IsSoundPlaying;
        
        private GameObject player1Round1Win;
        private GameObject player1Round1Lose;
        private GameObject player1Round1Draw;
        private GameObject player1Round2Win;
        private GameObject player1Round2Lose;
        private GameObject player1Round2Draw;
        private GameObject player1Round3Win;
        private GameObject player1Round3Lose;
        private GameObject player1Round3Draw;
        
        private GameObject player2Round1Win;
        private GameObject player2Round1Lose;
        private GameObject player2Round1Draw;
        private GameObject player2Round2Win;
        private GameObject player2Round2Lose;
        private GameObject player2Round2Draw;
        private GameObject player2Round3Win;
        private GameObject player2Round3Lose;
        private GameObject player2Round3Draw;
        
        private Image player1StaminaIcon;
        private Image player1NoStam;
        private Image player1StaminaSliderFill;
        private Image player1StaminaSliderFrame;
        
        private Image player2StaminaIcon;
        private Image player2NoStam;
        private Image player2StaminaSliderFill;
        private Image player2StaminaSliderFrame;
        
        
        private Image player1DamageOverlay;
        private Image player2DamageOverlay;
        
        private Image player1HealthDamage;
        private Image player2HealthDamage;
        
        
        private TextMeshProUGUI player1ScorePlusPrefab;
        private TextMeshProUGUI player2ScorePlusPrefab;
        
        private GameObject player1RoundEnd;
        private GameObject player2RoundEnd;

        private GameObject gameInit;

        private GameObject finDuRound;

        public bool canP1Blink = true;
        public bool canP2Blink = true;

        public bool canP1HealBlink = true;
        public bool canP2HealBlink = true;
        

        /// <summary>
        /// Constructeur de UiUpdater
        /// </summary>
        public UiUpdater(TextMeshProUGUI player1ScoreText, 
                        TextMeshProUGUI player2ScoreText,
                        Slider player1StaminaSlider,
                        Slider player2StaminaSlider, 
                        TextMeshProUGUI timerText, 
                        Slider player1ParadeSlider,
                        Slider player2ParadeSlider,
                        Slider player1HealthBar, 
                        Slider player2HealthBar, 
                        TextMeshProUGUI countdownText,
                        TextMeshProUGUI player1EndName, 
                        TextMeshProUGUI player2EndName,
                        TextMeshProUGUI player1EndScore, 
                        TextMeshProUGUI player2EndScore,
                        GameObject player1Round1Win,
                        GameObject player1Round1Lose,
                        GameObject player1Round1Draw,
                        GameObject player1Round2Win,
                        GameObject player1Round2Lose,
                        GameObject player1Round2Draw,
                        GameObject player1Round3Win,
                        GameObject player1Round3Lose,
                        GameObject player1Round3Draw,
                        GameObject player2Round1Win,
                        GameObject player2Round1Lose,
                        GameObject player2Round1Draw,
                        GameObject player2Round2Win,
                        GameObject player2Round2Lose,
                        GameObject player2Round2Draw,
                        GameObject player2Round3Win,
                        GameObject player2Round3Lose,
                        GameObject player2Round3Draw,
                        Image player1StaminaIcon,
                        Image player1NoStam,
                        Image player1StaminaSliderFill,
                        Image player1StaminaSliderFrame,
                        Image player2StaminaIcon,
                        Image player2NoStam,
                        Image player2StaminaSliderFill,
                        Image player2StaminaSliderFrame,
                        Image player1DamageOverlay,
                        Image player2DamageOverlay,
                        Image player1HealthDamage,
                        Image player2HealthDamage,
                        GameObject player1RoundEnd,
                        GameObject player2RoundEnd,
                        GameObject finDuRound,
                        GameObject gameInit/*,
                        TextMeshProUGUI player1ScorePlusPrefab,
                        TextMeshProUGUI player2ScorePlusPrefab*/)
        {
            m_IsSoundPlaying = false;
            Debug.Log("\tRécupération des composants graphiques...");
            this.player1ScoreText = player1ScoreText;
            this.player2ScoreText = player2ScoreText;

            this.player1StaminaSlider = player1StaminaSlider;
            this.player2StaminaSlider = player2StaminaSlider;

            this.timerText = timerText;
            this.countdownText = countdownText;

            //this.player1ScorePlusPrefab = player1ScorePlusPrefab;
            //this.player2ScorePlusPrefab = player2ScorePlusPrefab;
            
            this.player1ParadeSlider = player1ParadeSlider;
            this.player2ParadeSlider = player2ParadeSlider;

            this.player1HealthBar = player1HealthBar;
            this.player2HealthBar = player2HealthBar;

            this.player1EndName = player1EndName;
            this.player2EndName = player2EndName;
            
            this.player1EndScore = player1EndScore;
            this.player2EndScore = player2EndScore;

            this.player1Round1Win = player1Round1Win;
            this.player1Round1Lose = player1Round1Lose;
            this.player1Round1Draw = player1Round1Draw;
            this.player1Round2Win = player1Round2Win;
            this.player1Round2Lose = player1Round2Lose;
            this.player1Round2Draw = player1Round2Draw;
            this.player1Round3Win = player1Round3Win;
            this.player1Round3Lose = player1Round3Lose;
            this.player1Round3Draw = player1Round3Draw;
            
            this.player2Round1Win = player2Round1Win;
            this.player2Round1Lose = player2Round1Lose;
            this.player2Round1Draw = player2Round1Draw;
            this.player2Round2Win = player2Round2Win;
            this.player2Round2Lose = player2Round2Lose;
            this.player2Round2Draw = player2Round2Draw;
            this.player2Round3Win = player2Round3Win;
            this.player2Round3Lose = player2Round3Lose;
            this.player2Round3Draw = player2Round3Draw;

            this.player1StaminaIcon = player1StaminaIcon;
            this.player1NoStam = player1NoStam;
            this.player1StaminaSliderFill = player1StaminaSliderFill;
            this.player1StaminaSliderFrame = player1StaminaSliderFrame;
            
            this.player2StaminaIcon = player2StaminaIcon;
            this.player2NoStam = player2NoStam;
            this.player2StaminaSliderFill = player2StaminaSliderFill;
            this.player2StaminaSliderFrame = player2StaminaSliderFrame;

            this.player1DamageOverlay = player1DamageOverlay;
            this.player2DamageOverlay = player2DamageOverlay;

            this.player1HealthDamage = player1HealthDamage;
            this.player2HealthDamage = player2HealthDamage;

            this.player1RoundEnd = player1RoundEnd;
            this.player2RoundEnd = player2RoundEnd;

            this.finDuRound = finDuRound;
            this.gameInit = gameInit;
            this.player1StaminaSlider.maxValue = GameInit.GetGameConfig().stamina_amount;
            this.player2StaminaSlider.maxValue = GameInit.GetGameConfig().stamina_amount;
        
            this.player1ParadeSlider.maxValue = GameInit.GetGameConfig().parade_duration;
            this.player2ParadeSlider.maxValue = GameInit.GetGameConfig().parade_duration;
        }

        public void SetCountdownText(String text)
        {
            // if (!IntroAnim.startGame)
            // {
            //     IntroAnim.startGame = true;
            //     countdownText.gameObject.GetComponent<IntroAnim>().StartEffect();  
            // }
            
            countdownText.text = text;
        }

        public IEnumerator DispalayLowStamina(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1) canP1Blink = false;
            else canP2Blink = false;
            Image noStam = player == Player.PLAYER.P1 ? player1NoStam : player2NoStam;
            
            UnityEngine.Color color = noStam.color;
            int counter = 0;
            while (counter < 2)
            {
                while (noStam.color.a < 1)
                {
                    float fadeAmount = color.a + (8f * Time.deltaTime);

                    color = new UnityEngine.Color(color.r, color.g, color.b, fadeAmount);
                    noStam.color = color;
                    yield return null;
                }

                while (noStam.color.a > 0)
                {
                    float fadeAmount = color.a - (8f * Time.deltaTime);

                    color = new UnityEngine.Color(color.r, color.g, color.b, fadeAmount);
                    noStam.color = color;
                    yield return null;
                }

                yield return new WaitForSeconds(0.1f);
                counter++;
            }
            if (player == Player.PLAYER.P1) canP1Blink = true;
            else canP2Blink = true;
        }
        public IEnumerator DispalayLowStaminaFill(Player.PLAYER player)
        {
            Image sliderFill = player == Player.PLAYER.P1 ? player1StaminaSliderFill : player2StaminaSliderFill;
            UnityEngine.Color color = sliderFill.color;
            int counter = 0;
            while (counter < 2)
            {
                while (sliderFill.color.b > 0)
                {
                    float fadeAmount = color.b - (8f * Time.deltaTime);

                    color = new UnityEngine.Color(color.r, fadeAmount, fadeAmount, 1);
                    sliderFill.color = color;
                    yield return null;
                }
                while (sliderFill.color.b < 1)
                {
                    float fadeAmount = color.b + (8f * Time.deltaTime);

                    color = new UnityEngine.Color(color.r, fadeAmount, fadeAmount, 1);
                    sliderFill.color = color;
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
                counter++;
            }
        }
        public IEnumerator DispalayLowStaminaIcon(Player.PLAYER player)
        {
            Image staminaIcon = player == Player.PLAYER.P1 ? player1StaminaIcon : player2StaminaIcon;
            UnityEngine.Color color = staminaIcon.color;
            int counter = 0;
            while (counter < 2)
            {
                while (staminaIcon.color.b > 0)
                {
                    float fadeAmount = color.b - (8f * Time.deltaTime);

                    color = new UnityEngine.Color(color.r, fadeAmount, fadeAmount, 1);
                    staminaIcon.color = color;
                    yield return null;
                }
                while (staminaIcon.color.b < 1)
                {
                    float fadeAmount = color.b + (8f * Time.deltaTime);

                    color = new UnityEngine.Color(color.r, fadeAmount, fadeAmount, 1);
                    staminaIcon.color = color;
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
                counter++;
            }
        }

        public bool canBlink(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? canP1Blink : canP2Blink;
        }
        
        public bool canHealthBlink(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? canP1HealBlink : canP2HealBlink;
        }

        public void PlayerScorePlusAnimation(Player.PLAYER player, string text)
        {
            gameInit.GetComponent<GameInit>().PlayScorePlusAnimation(player, text);
        }
        
        /// <summary>
        /// Permet de mettre à jour le score
        /// </summary>
        /// <param name="player">Le joueur auquel on veut mettre à jour le score</param>
        public void OnScoreUpdate(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
                player1ScoreText.text = FormatScore(Player.GetScore(player), true);
            else
                player2ScoreText.text = FormatScore(Player.GetScore(player), true);
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
        private String FormatScore(int score, bool addScoreText)
        {
            String scoreString;
        
            if (score >= 1000)
                scoreString =  score.ToString();
            else
            {
                scoreString = "0" + score;

                if (score >= 100) 
                    return addScoreText ? "Score : " + scoreString : scoreString;
            
                scoreString = "0" + scoreString;
            
                if (score < 10)
                    scoreString = "0" + scoreString;
            }
        
            return addScoreText ? "Score : " + scoreString : scoreString;
        }
    
        /// <summary>
        /// Permet de mettre à jour le timer
        /// </summary>
        public void OnTimerUpdate(int timer)
        {
            timerText.text = timer.ToString(); ///*FormatTime(*/GameInit.GetTimer().GetTimer().ToString()/*)*/;
        }


        public void OnHealthUpdate()
        {
            player1HealthBar.value = Player.GetPlayerHealth(Player.PLAYER.P1);
            player2HealthBar.value = Player.GetPlayerHealth(Player.PLAYER.P2);
            
            UpdateDamageOverlay();
        }

        public void UpdateDamageOverlay()
        {
            player1DamageOverlay.color = new UnityEngine.Color(
                                        player1DamageOverlay.color.r, 
                                        player1DamageOverlay.color.g,
                                        player1DamageOverlay.color.b, 
                                        1f - (Player.GetPlayerHealth(Player.PLAYER.P1) / (float)GameInit.GetGameConfig().player_health_amount));
            
            player2DamageOverlay.color = new UnityEngine.Color(
                                        player2DamageOverlay.color.r, 
                                        player2DamageOverlay.color.g,
                                        player2DamageOverlay.color.b, 
                                        1f - (Player.GetPlayerHealth(Player.PLAYER.P2) / (float)GameInit.GetGameConfig().player_health_amount));

        }

        public IEnumerator DisplayHealthWarning(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1) canP1HealBlink = false;
            else canP2HealBlink = false;
            Image noStam = player == Player.PLAYER.P1 ? player1HealthDamage : player2HealthDamage;
            
            UnityEngine.Color color = noStam.color;
            int counter = 0;
            
            while (noStam.color.a < 1)
            {
                float fadeAmount = color.a + (8f * Time.deltaTime);

                color = new UnityEngine.Color(color.r, color.g, color.b, fadeAmount);
                noStam.color = color;
                yield return null;
            }

            while (noStam.color.a > 0)
            {
                float fadeAmount = color.a - (8f * Time.deltaTime);

                color = new UnityEngine.Color(color.r, color.g, color.b, fadeAmount);
                noStam.color = color;
                yield return null;
            }
            if (player == Player.PLAYER.P1) canP1HealBlink = true;
            else canP2HealBlink = true;
        }
        
        // /// <summary>
        // /// Permet de formatter le timer au format 00:00
        // /// </summary>
        // /// <param name="time">Le timer a formatter</param>
        // /// <returns>Le timer formatté</returns>
        // private String FormatTime(int time)
        // {
        //     String format = "";
        //
        //     if (time <= 20 && !m_IsSoundPlaying)
        //     {
        //         var position = new Vector3(11.9f, 11.0f, 15.6f);
        //         var rotation = new Quaternion(0, 0, 0, 0);
        //         Object.Instantiate(GameInit.GetSoundHandler().GetTimerSound(), position, rotation);
        //         m_IsSoundPlaying = true;
        //     }
        //
        //
        //     if (time / 60 < 10)
        //     {
        //         format += "0";
        //     }
        //
        //     format += time / 60 + ":";
        //
        //     if (time % 60 < 10)
        //     {
        //         format += "0";
        //     }
        //
        //     format += time % 60;
        //
        //     return format;
        // }

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
        
        
        
        public void OnEndScreenDisplayed()
        {
            // TODO  je faisais que les round gagnées et perdu s'affiche dans le score final
        
            string first = Player.GetPlayerName(Player.PLAYER.P1);
            string second = Player.GetPlayerName(Player.PLAYER.P2);
            string firstScore = FormatScore(Player.GetScore(Player.PLAYER.P1), false);
            string secondScore = FormatScore(Player.GetScore(Player.PLAYER.P2), false);

            if (Player.GetScore(Player.PLAYER.P1) < Player.GetScore(Player.PLAYER.P2))
            {
                Vector3 pos1 = player1RoundEnd.GetComponent<RectTransform>().localPosition;
                Vector3 pos2 = player2RoundEnd.GetComponent<RectTransform>().localPosition;

                player1RoundEnd.GetComponent<RectTransform>().localPosition = pos2;
                player2RoundEnd.GetComponent<RectTransform>().localPosition = pos1;
                
                first = Player.GetPlayerName(Player.PLAYER.P2);
                second = Player.GetPlayerName(Player.PLAYER.P1);
                firstScore = FormatScore(Player.GetScore(Player.PLAYER.P2), false);
                secondScore = FormatScore(Player.GetScore(Player.PLAYER.P1), false);
            }
                            
            player1EndName.text = first;
            player2EndName.text = second;

            player1EndScore.text = firstScore;
            player2EndScore.text = secondScore;
        }

        public void UpdateRoundHUD(Player.PLAYER winner, int roundId)
        {

            if (winner == Player.PLAYER.P1)
            {
                if (roundId == 1)
                {
                    player1Round1Win.SetActive(true);
                    player2Round1Lose.SetActive(true);
                }
                else if (roundId == 2)
                {
                    player1Round2Win.SetActive(true);
                    player2Round2Lose.SetActive(true);
                }
                else if (roundId == 3)
                {
                    player1Round3Win.SetActive(true);
                    player2Round3Lose.SetActive(true);
                }
            }
            else if (winner == Player.PLAYER.P2)
            {
                if (roundId == 1)
                {
                    player1Round1Lose.SetActive(true);
                    player2Round1Win.SetActive(true);
                }
                else if (roundId == 2)
                {
                    player1Round2Lose.SetActive(true);
                    player2Round2Win.SetActive(true);
                }
                else if (roundId == 3)
                {
                    player1Round3Lose.SetActive(true);
                    player2Round3Win.SetActive(true);
                }
            }
            else
            {
                if (roundId == 1)
                {
                    player1Round1Draw.SetActive(true);
                    player2Round1Draw.SetActive(true);
                }
                else if (roundId == 2)
                {
                    player1Round2Draw.SetActive(true);
                    player2Round2Draw.SetActive(true);
                }
                else if (roundId == 3)
                {
                    player1Round3Draw.SetActive(true);
                    player2Round3Draw.SetActive(true);
                }
            }
        }
        
        public void RefreshHUD()
        {
            OnHealthUpdate();
            OnStaminaUpdate(Player.PLAYER.P1);
            OnStaminaUpdate(Player.PLAYER.P2);
        }
    }
}
