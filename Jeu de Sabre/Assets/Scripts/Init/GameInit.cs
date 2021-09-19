using System;
using System.Collections;
using Camera;
using Cinemachine;
using Collisions;
using Mouvements.Orientation;
using MySql.Data.MySqlClient;
using Players;
using Players.UI;
using Sounds;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Color = UnityEngine.Color;


namespace Init
{
    public class GameInit : MonoBehaviour
    {
        private static UiUpdater _updater;
        
        private static ControllerConnecter _connecter;
        
        private static ControllerHandler _controllerHandler;
        
        private static Timer _timer;
        
        private static SoundHandler _soundHandler;
        
        private static GameConfig _config;
        
        private static KatanaOrientation _katana1;
        
        private static KatanaOrientation _katana2;
        
        private static CameraShaking _cameraShaking;

        private static EmoteHandler _player1EmoteHandler;
        
        private static EmoteHandler _player2EmoteHandler;

        private static Round _round;

        private static Players.Color _color;
        
        private MultiDisplay multiDisplay;
        
        
        [SerializeField] private GameObject player1ParadeFx1;
        
        [SerializeField] private GameObject player1ParadeFx2;
        
        [SerializeField] private GameObject player1ParadeFxPos;
        
        [SerializeField] private GameObject player1KatanaAxis;
        

        [SerializeField] private GameObject player2ParadeFx1;
        
        [SerializeField] private GameObject player2ParadeFx2;
        
        [SerializeField] private GameObject player2ParadeFxPos;
        
        [SerializeField] private GameObject player2KatanaAxis;

        
        [SerializeField] private CinemachineVirtualCamera player1VirtualCamera;
        
        [SerializeField] private CinemachineVirtualCamera player2VirtualCamera;
        
        
        [SerializeField] private TextMeshProUGUI player1ScoreText;
        
        [SerializeField] private TextMeshProUGUI player2ScoreText;
        
        
        [FormerlySerializedAs("player1TimerText")] [SerializeField] private TextMeshProUGUI timerText;

        [SerializeField] private TextMeshProUGUI countdownTimer;
        
        [SerializeField] private Slider player1StaminaSlider;
        
        [SerializeField] private Slider player2StaminaSlider;

        
        [SerializeField] private Slider player1ParadeSlider;
        
        [SerializeField] private Slider player2ParadeSlider;
        
        [SerializeField] private Slider player1HealthBar;
        
        [SerializeField] private Slider player2HealthBar;
        
        //Effets de fatigues des joueurs
        [SerializeField] private GameObject player1ExhaustedFx1;
        
        [SerializeField] private GameObject player2ExhaustedFx1;

        [SerializeField] private Image blackPannel;

        [SerializeField] private TextMeshProUGUI player1WarningText;
        
        [SerializeField] private TextMeshProUGUI player1WarningTextM;
        
        [SerializeField] private TextMeshProUGUI player1Name;
        
        [SerializeField] private TextMeshProUGUI player2Name;
        
        [SerializeField] private TextMeshProUGUI player1EndName;
        
        [SerializeField] private TextMeshProUGUI player2EndName;
        
        [SerializeField] private TextMeshProUGUI player1EndScore;
        
        [SerializeField] private TextMeshProUGUI player2EndScore;
        
        [SerializeField] private GameObject player1KatanaObject;
        
        [SerializeField] private GameObject player2KatanaObject;

        
        [SerializeField] private GameObject soundTimer;
        
        [SerializeField] private GameObject soundDamage;

        
        [SerializeField] private GameObject player1PauseMenuPanel;
        
        [SerializeField] private GameObject player2PauseMenuPanel;
        
        [FormerlySerializedAs("player1HudPanel")] [SerializeField] private GameObject playerHudPanel;

        [SerializeField] private GameObject endScreen;

        [SerializeField] private UnityEngine.Camera cameraTravelling;

        [SerializeField] private GameObject player1Hat;
        
        [SerializeField] private GameObject player1Body;
        
        [SerializeField] private GameObject player1Legs;
        
        [SerializeField] private GameObject player2Hat;
        
        [SerializeField] private GameObject player2Body;
        
        [SerializeField] private GameObject player2Legs;

        [SerializeField] private GameObject playerAxis;
        
        [SerializeField] private GameObject player1TransHat;
        
        [SerializeField] private GameObject player1TransBody;
        
        [SerializeField] private GameObject player1TransLegs;
        
        [SerializeField] private GameObject player2TransHat;
        
        [SerializeField] private GameObject player2TransBody;
        
        [SerializeField] private GameObject player2TransLegs;
        
        [SerializeField] private GameObject main1G;
        
        [SerializeField] private GameObject main1D;
        
        [SerializeField] private GameObject main2G;
        
        [SerializeField] private GameObject main2D;

        [SerializeField] private GameObject player1Round1Win;
        [SerializeField] private GameObject player1Round1Lose;
        [SerializeField] private GameObject player1Round1Draw;
        [SerializeField] private GameObject player1Round2Win;
        [SerializeField] private GameObject player1Round2Lose;
        [SerializeField] private GameObject player1Round2Draw;
        [SerializeField] private GameObject player1Round3Win;
        [SerializeField] private GameObject player1Round3Lose;
        [SerializeField] private GameObject player1Round3Draw;
        
        [SerializeField] private GameObject player2Round1Win;
        [SerializeField] private GameObject player2Round1Lose;
        [SerializeField] private GameObject player2Round1Draw;
        [SerializeField] private GameObject player2Round2Win;
        [SerializeField] private GameObject player2Round2Lose;
        [SerializeField] private GameObject player2Round2Draw;
        [SerializeField] private GameObject player2Round3Win;
        [SerializeField] private GameObject player2Round3Lose;
        [SerializeField] private GameObject player2Round3Draw;
        
        [SerializeField] private Image player1StaminaIcon;
        [SerializeField] private Image player1NoStam;
        [SerializeField] private Image player1StaminaSliderFill;
        [SerializeField] private Image player1StaminaSliderFrame;
        
        [SerializeField] private Image player2StaminaIcon;
        [SerializeField] private Image player2NoStam;
        [SerializeField] private Image player2StaminaSliderFill;
        [SerializeField] private Image player2StaminaSliderFrame;

        [SerializeField] private Image player1DamageOverlay;
        [SerializeField] private Image player2DamageOverlay;

        [SerializeField] private Image player1HealthDamage;
        [SerializeField] private Image player2HealthDamage;
        
        [SerializeField] private GameObject player1Round1WinEnd;
        [SerializeField] private GameObject player1Round1LoseEnd;
        [SerializeField] private GameObject player1Round1DrawEnd;
        [SerializeField] private GameObject player1Round2WinEnd;
        [SerializeField] private GameObject player1Round2LoseEnd;
        [SerializeField] private GameObject player1Round2DrawEnd;
        [SerializeField] private GameObject player1Round3WinEnd;
        [SerializeField] private GameObject player1Round3LoseEnd;
        [SerializeField] private GameObject player1Round3DrawEnd;
        
        [SerializeField] private GameObject player2Round1WinEnd;
        [SerializeField] private GameObject player2Round1LoseEnd;
        [SerializeField] private GameObject player2Round1DrawEnd;
        [SerializeField] private GameObject player2Round2WinEnd;
        [SerializeField] private GameObject player2Round2LoseEnd;
        [SerializeField] private GameObject player2Round2DrawEnd;
        [SerializeField] private GameObject player2Round3WinEnd;
        [SerializeField] private GameObject player2Round3LoseEnd;
        [SerializeField] private GameObject player2Round3DrawEnd;

        [SerializeField] private GameObject player1RoundEnd;
        [SerializeField] private GameObject player2RoundEnd;

        [SerializeField] private GameObject finDuRound;
        [SerializeField] private Image roundTransition;
        
        public static bool isGamePaused;
        
        public static bool isDebugMenuOn;

        private bool isWarningActive;
        
        private bool isTimerInit;
        private bool isGameEnd;
     
        // TODO Faut faire une petite transition la, faut faire le stun, faut faire qu'on puisse relancer le jeu a la fin, faut balancer la camera, faut que léo regle ses animation et des déplacements
        
        
        private void Awake()
        {
            player1Name.text = Player.GetPlayerName(Player.PLAYER.P1);
            player2Name.text = Player.GetPlayerName(Player.PLAYER.P2);
            
            isWarningActive = false;
            isGamePaused = false;
            isDebugMenuOn = false;
            isTimerInit = false;
            // // Initialisation de l'affichage sur plusieurs écrans7
            // print("Intitialisation de l'affichage multiple...");
            // gameObject.AddComponent<MultiDisplay>();
        
            // Récupération du chemin utilisateur de l'ordinateur
            print("Récupération du dossier utilisation...");
            String userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        
            // Initialisation de la connexion des manettes
            print("Initialisation des manettes...");
            _connecter = new ControllerConnecter();
        
            // Si l'initialisation est passée
            if (_connecter.Init())
            {
                // Récupération et lecture du fichier de configuration
                print("Récupération de la configuration du jeu...");
                userDir += "\\Documents\\katana_no_tatakai_properties.json";
                String json = "";
                String[] lines= System.IO.File.ReadAllLines(@userDir);
                foreach (String line in lines)
                {
                    json += line;
                }
                
                _config = JsonUtility.FromJson<GameConfig>(json);

                // Initialisation de l'endurance
                print("Initialisation du système d'endurance...");
                gameObject.AddComponent<Stamina>();
                Stamina.Init(player1ExhaustedFx1, player2ExhaustedFx1);

                // Initialisation de la vie
                print("Initialisation du système de vie...");
                gameObject.AddComponent<Health>();
                
                // Récupération des manettes
                print("Récupération des manettes...");
                _controllerHandler = _connecter.GetHandler();
            
                // Initialisation de l'orientation de la manette 1
                print("Initialisation de la rotation du joueur 1...");
                _katana1 = new KatanaOrientation(Player.PLAYER.P1, _controllerHandler.GetPlayer1Controller(), player1ParadeFx1,
                    player1ParadeFx2, player1ParadeFxPos, player1KatanaAxis, player1KatanaObject, player1ParadeSlider);
                Katana1.Init();
                _katana1.CanMove(false);
                print("Initialisation de la rotation du joueur 2...");
                // Initialisation de l'orientation de la manette 2
                _katana2 = new KatanaOrientation(Player.PLAYER.P2, _controllerHandler.GetPlayer2Controller(), player2ParadeFx1,
                    player2ParadeFx2, player2ParadeFxPos, player2KatanaAxis, player2KatanaObject, player2ParadeSlider);
                Katana2.Init();
                _katana2.CanMove(false);

                _color = gameObject.GetComponent<Players.Color>();
                _color.ApplyPlayerColor(player1Hat, player1Body, player1Legs, Player.GetPlayerColor(Player.PLAYER.P1),
                                        player2Hat, player2Body, player2Legs, Player.GetPlayerColor(Player.PLAYER.P2),
                                        player1TransHat, player1TransBody, player1TransLegs,
                                        player2TransHat, player2TransBody, player2TransLegs,
                                        main1G, main1D, main2G, main2D);
                
                // Initialisation de la classe chargée de mettre à jour le HUD
                print("Initialisation de la mise à jour de l'affichage");
                _updater = new UiUpdater(player1ScoreText, 
                                        player2ScoreText, 
                                        player1StaminaSlider, 
                                        player2StaminaSlider, 
                                        timerText, 
                                        player1ParadeSlider, 
                                        player2ParadeSlider, 
                                        player1HealthBar, 
                                        player2HealthBar, 
                                        countdownTimer, 
                                        player1EndName, 
                                        player2EndName, 
                                        player1EndScore, 
                                        player2EndScore,
                                        player1Round1Win,
                                        player1Round1Lose,
                                        player1Round1Draw,
                                        player1Round2Win,
                                        player1Round2Lose,
                                        player1Round2Draw,
                                        player1Round3Win,
                                        player1Round3Lose,
                                        player1Round3Draw,
                                        player2Round1Win,
                                        player2Round1Lose,
                                        player2Round1Draw,
                                        player2Round2Win,
                                        player2Round2Lose,
                                        player2Round2Draw,
                                        player2Round3Win,
                                        player2Round3Lose,
                                        player2Round3Draw,
                                        player1StaminaIcon,
                                        player1NoStam,
                                        player1StaminaSliderFill,
                                        player1StaminaSliderFrame,
                                        player2StaminaIcon,
                                        player2NoStam,
                                        player2StaminaSliderFill,
                                        player2StaminaSliderFrame,
                                        player1DamageOverlay,
                                        player2DamageOverlay,
                                        player1HealthDamage,
                                        player2HealthDamage,
                                        player1RoundEnd,
                                        player2RoundEnd,
                                        finDuRound);
            
                // Initialisation du timer
                // print("Initialisation du timer...");
                // _timer = new Timer(_config.game_time, soundTimer, gameObject);
                // isTimerInit = true;
            
                // Initialisaion du gestionnaire de son
                print("Initialisation de gestionnaire de son...");
                _soundHandler = new SoundHandler(soundTimer, soundDamage);

                // Initialisation du tremblement de caméra
                print("Configuration du tremblement des cameras...");
                gameObject.AddComponent<CameraShaking>().Init(player1VirtualCamera, player2VirtualCamera);
                _cameraShaking = gameObject.GetComponent<CameraShaking>();

                // Initialisation des emotes
                print("Initialisation des emotes...");
                gameObject.AddComponent<EmoteHandler>();
                
                _player1EmoteHandler = new EmoteHandler();
                _player2EmoteHandler = new EmoteHandler();
                
                
                // Activation de la Led des manettes
                //PSMoveUtils.SetLed(Player.PLAYER.P1, Color.yellow);
                //PSMoveUtils.SetLed(Player.PLAYER.P2, Color.yellow);

                _round = gameObject.AddComponent<Round>();
                _round.StartNextRound();
            }
            else
            {
                print(_connecter.GetError());
                DisplayWarningMessage(_connecter.GetError(), player1WarningText, player1WarningTextM);
            }
        }
    
        private void DisplayWarningMessage(String errors, TextMeshProUGUI player1, TextMeshProUGUI player1M)
        {
            player1.text = errors;
            player1.alignment = TextAlignmentOptions.Center;
            player1M.gameObject.SetActive(true);
            StartCoroutine(WarningFlash(player1));
        }

        private IEnumerator WarningFlash(TextMeshProUGUI player1)
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                if (isWarningActive)
                {
                    player1.gameObject.SetActive(false);
                    isWarningActive = false;
                }
                else
                {
                    player1.gameObject.SetActive(true);
                    isWarningActive = true;
                }
            }
        }
        
        /// <summary>
        /// Permet de récupérer la connexion des manettes
        /// </summary>
        /// <returns>Le ControllerConnecter des manettes</returns>
        public static ControllerConnecter GetControllerConnecter()
        {
            return _connecter;
        }
    
        /// <summary>
        /// Permet de récupérer les manettes
        /// </summary>
        /// <returns>Le ControllerHandler des manettes</returns>
        public static ControllerHandler GetControllerHandler()
        {
            return _controllerHandler;
        }
    
        /// <summary>
        /// Permet de récupérer la gestion de l'orientation de la manette 1
        /// </summary>
        /// <returns>Le KatanaOrientation de la manette 1</returns>
        public static KatanaOrientation GetPlayer1KatanaOrientation()
        {
            return _katana1;
        }
    
        /// <summary>
        /// Permet de récupérer la gestion de l'orientation de la manette 2
        /// </summary>
        /// <returns>Le KatanaOrientation de la manette 2</returns>
        public static KatanaOrientation GetPlayer2KatanaOrientation()
        {
            return _katana2;
        }
    
        /// <summary>
        /// Permet de récupérer l'objet chargé de mettre à jour le HUD
        /// </summary>
        /// <returns>Le UiUpdater permettant de mettre à jour le HUD</returns>
        public static UiUpdater GetUiUpdater()
        {
            return _updater;
        }

        /// <summary>
        /// Permet de récupérer l'objet chargé de mettre à jour le timer
        /// </summary>
        /// <returns>Le Timer permettant de mettre à jour le timer</returns>
        public static Timer GetTimer()
        {
            return _timer;
        }

        /// <summary>
        /// Permet de récupérer la configuration chargée depuis le fichier Json
        /// </summary>
        /// <returns>Le GameConfig contenant toutes les configuration du jeu</returns>
        public static GameConfig GetGameConfig()
        {
            return _config;
        }

        /// <summary>
        /// Permet de récupérer la classe contenant les sons du jeu
        /// </summary>
        /// <returns>Le SoundHandler contenant les sons du jeu</returns>
        public static SoundHandler GetSoundHandler()
        {
            return _soundHandler;
        }

        /// <summary>
        /// Permet de récupérer la classe gérant les tremblements de caméra
        /// </summary>
        /// <returns></returns>
        public static CameraShaking GetCameraShaking()
        {
            return _cameraShaking;
        }

        public static Round GetRound()
        {
            return _round;
        }
        
        public static EmoteHandler GetEmoteHandler(Player.PLAYER player)
        {
            return player == Player.PLAYER.P1 ? _player1EmoteHandler : _player2EmoteHandler;
        }
    
        private void Update()
        {
            // Dès que le timer est initialisé, mise à jour de celui-ci
            if(isTimerInit)
                GetTimer().OnUpdate();
        
            // Affichage ou désactivation du menu pause lors de l'appui sur la touche Echape
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isGamePaused)
                    Resume();
                else
                    Pause();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_updater.canP1Blink)
                {
                    StartCoroutine(_updater.DispalayLowStamina(Player.PLAYER.P1));
                    StartCoroutine(_updater.DispalayLowStaminaFill(Player.PLAYER.P1));
                    StartCoroutine(_updater.DispalayLowStaminaIcon(Player.PLAYER.P1));
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_updater.canP2Blink)
                {
                    StartCoroutine(_updater.DispalayLowStamina(Player.PLAYER.P2));
                    StartCoroutine(_updater.DispalayLowStaminaFill(Player.PLAYER.P2));
                    StartCoroutine(_updater.DispalayLowStaminaIcon(Player.PLAYER.P2));
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGameEnd)
                {
                    isGameEnd = false;
                    SceneManager.LoadScene("Scenes/MainMenu");
                }
            }

            // Recalibration du sabre 1 lors de l'appui sur la touche 1
            if (Input.GetKeyDown(KeyCode.Alpha1))
                KatanaOrientation.SetDefaultCalibration(Player.PLAYER.P1);
        
            // Recalibration du sabre 2 lors de l'appui sur la touche 2
            if (Input.GetKeyDown(KeyCode.Alpha2))
                KatanaOrientation.SetDefaultCalibration(Player.PLAYER.P2);
        }

        /// <summary>
        /// Fonction appelé lors de la fermeture du menu pause
        /// </summary>
        public void Resume()
        {
            // Activation du HUD des joueurs
            playerHudPanel.SetActive(true);
        
            // Désactivation du menu pause des joueurs
            player1PauseMenuPanel.SetActive(false);
            player2PauseMenuPanel.SetActive(false);
        
            // Relancement du temps en jeu
            Time.timeScale = 1f;
        
            // Recalibration des sabres des joueurs
            KatanaOrientation.SetDefaultCalibration(Player.PLAYER.P1);
            KatanaOrientation.SetDefaultCalibration(Player.PLAYER.P2);
        
            isGamePaused = false;
        }

        /// <summary>
        /// Fonction appelé lors de l'ouverture du menu pause
        /// </summary>
        private void Pause()
        {
            // Désactivation du HUD des joueurs
            playerHudPanel.SetActive(false);
        
            // Activation du menu pause des joueurs
            player1PauseMenuPanel.SetActive(true);
            player2PauseMenuPanel.SetActive(true);
        
            // Mise en pause du temps en jeu
            Time.timeScale = 0f;
        
            isGamePaused = true;
        }

        /// <summary>
        /// Fonction appelé lors de l'appui sur le bouton Quitter
        /// </summary>
        public void QuitGame()
        {
            // Mise en pause du temps en jeu
            Time.timeScale = 1f;
        
            isGamePaused = false;
        
            Debug.Log("Quitting game...");
            SceneManager.LoadScene("MainMenu");
        }

        public void OnTimerEnd()
        {
            CollisionPlayers.timerEnd = true;
            StartCoroutine(DisplayRoundEnd());
        }
        
        private IEnumerator DisplayRoundEnd()
        {
            finDuRound.SetActive(true);
            bool flag = _round.StopRound();

            Color color = finDuRound.GetComponent<TextMeshProUGUI>().color;
            
            while (finDuRound.GetComponent<TextMeshProUGUI>().color.a < 1)
            {
                float fadeAmount = color.a + (0.8f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                roundTransition.color = new Color(roundTransition.color.r, roundTransition.color.g, roundTransition.color.b, fadeAmount);

                finDuRound.GetComponent<TextMeshProUGUI>().color = color;
                yield return null;
            }
            
            
            if(flag)
                StartCoroutine(FadeToBlack(true));
            else
                StartCoroutine(PrepareNextRound());
        }

        private IEnumerator DisableRoundEnd(bool restart)
        {
            Color color = finDuRound.GetComponent<TextMeshProUGUI>().color;

            while (finDuRound.GetComponent<TextMeshProUGUI>().color.a > 0)
            {
                float fadeAmount = color.a - (0.8f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                finDuRound.GetComponent<TextMeshProUGUI>().color = color;
                roundTransition.color = new Color(roundTransition.color.r, roundTransition.color.g, roundTransition.color.b, fadeAmount);
                yield return null;
            }
            finDuRound.SetActive(false);
            yield return new WaitForSeconds(0.8f);

            if (restart)
            {
                _round.StartNextRound();
            }
        }


        IEnumerator AddBonusPoint(bool startNext)
        {
            int currentTime = _round.GetCurrentTimer();
            int timer = currentTime;
            Player.PLAYER winner = _round.GetRoundWinner(true);


            
            if (winner == Player.PLAYER.Other)
            {
                
            }
            else
            {
                for (int i = 0; i < currentTime; i++)
                {
                    timer--;
                    _updater.OnTimerUpdate(timer);
                    Player.UpdatePlayerScore(winner, _config.player_bonus_point);
                    yield return new WaitForSeconds(_config.player_bonus_point_speed);
                }
                Health.Reset();
                _updater.RefreshHUD();
            }

            if (startNext)
            {
                StartCoroutine(DisableRoundEnd(true));
            }
        }
        
        IEnumerator PrepareNextRound()
        {
            yield return new WaitForSeconds(1.5f);
            playerAxis.transform.localPosition = Vector3.zero;
            playerAxis.transform.localRotation = new Quaternion(0,0,0,0);
            
            StartCoroutine(AddBonusPoint(true));
            
            //FadeToBlack(false, true);
            yield return null;
        }
        
        IEnumerator FadeToBlack(bool displayEndScreen)
        {
            StartCoroutine(AddBonusPoint(false));

            yield return new WaitForSeconds(1.5f);
            
            Color color = blackPannel.GetComponent<Image>().color;

            while (blackPannel.GetComponent<Image>().color.a < 1)
            {
                float fadeAmount = color.a + (1f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                blackPannel.GetComponent<Image>().color = color;
                yield return null;
            }
            
            if(displayEndScreen)
            {
                EditData();
                _updater.OnEndScreenDisplayed();
                playerHudPanel.SetActive(false);
                endScreen.SetActive(true);
                cameraTravelling.gameObject.SetActive(true);
                _katana1.CanMove(false); //
                _katana2.CanMove(false);
                isGameEnd = true;
                StartCoroutine(DisableRoundEnd(false));
                yield return new WaitForSeconds(0.8f);

                for (int i = 0; i < 3; i++)
                {
                    UpdateRoundHUD(_round.winners[i], i+1);
                }
            }

            while (blackPannel.GetComponent<Image>().color.a > 0)
            {
                float fadeAmount = color.a - (1f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                blackPannel.GetComponent<Image>().color = color;
                yield return null;
            }
                
        }
        
        public void EditData()
        {
            string connStr =
                "Database=lacourseauxtrophees;Server=127.0.0.1;Uid=root;Password=Admlocal1;pooling=false;CharSet=utf8;port=3306";
            MySqlConnection conn = new MySqlConnection(connStr);
            
            try
            {
                conn.Open();
                MySqlCommand CMD_addScore = conn.CreateCommand();
                CMD_addScore.CommandText = "UPDATE tb_player SET score_knt_player = " + Player.GetScore(Player.PLAYER.P1) + " WHERE identifiant_player  = " + MenuActions.id1 + ";";
                CMD_addScore.ExecuteScalar();
                MySqlCommand CMD_addScore2 = conn.CreateCommand();
                CMD_addScore2.CommandText = "UPDATE tb_player SET score_knt_player = " + Player.GetScore(Player.PLAYER.P2) + " WHERE identifiant_player  = " + MenuActions.id2 + ";";
                CMD_addScore2.ExecuteScalar();
            }
            catch (Exception ex)
            {
                print("Ca marche po - " + ex);
            }
            conn.Close();
            print("Done.");
        }


        private void OnApplicationQuit()
        {
            // Déconnexion des manettes à la fermeture du jeu
            PSMoveAPI.psmove_disconnect(_controllerHandler.GetPlayer1Controller());
            PSMoveAPI.psmove_disconnect(_controllerHandler.GetPlayer2Controller());
        }
        
        public void UpdateRoundHUD(Player.PLAYER winner, int roundId)
        {

            if (winner == Player.PLAYER.P1)
            {
                if (roundId == 1)
                {
                    player1Round1WinEnd.SetActive(true);
                    player2Round1LoseEnd.SetActive(true);
                }
                else if (roundId == 2)
                {
                    player1Round2WinEnd.SetActive(true);
                    player2Round2LoseEnd.SetActive(true);
                }
                else if (roundId == 3)
                {
                    player1Round3WinEnd.SetActive(true);
                    player2Round3LoseEnd.SetActive(true);
                }
            }
            else if (winner == Player.PLAYER.P2)
            {
                if (roundId == 1)
                {
                    player1Round1LoseEnd.SetActive(true);
                    player2Round1WinEnd.SetActive(true);
                }
                else if (roundId == 2)
                {
                    player1Round2LoseEnd.SetActive(true);
                    player2Round2WinEnd.SetActive(true);
                }
                else if (roundId == 3)
                {
                    player1Round3LoseEnd.SetActive(true);
                    player2Round3WinEnd.SetActive(true);
                }
            }
            else
            {
                if (roundId == 1)
                {
                    player1Round1DrawEnd.SetActive(true);
                    player2Round1DrawEnd.SetActive(true);
                }
                else if (roundId == 2)
                {
                    player1Round2DrawEnd.SetActive(true);
                    player2Round2DrawEnd.SetActive(true);
                }
                else if (roundId == 3)
                {
                    player1Round3DrawEnd.SetActive(true);
                    player2Round3DrawEnd.SetActive(true);
                }
            }
        }
    }
}