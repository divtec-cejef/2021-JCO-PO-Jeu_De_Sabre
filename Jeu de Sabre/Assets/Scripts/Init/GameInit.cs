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
        
        public static bool isGamePaused;
        
        public static bool isDebugMenuOn;

        private bool isWarningActive;
        
        private bool isTimerInit;
     
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
                                        player2EndScore);
            
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
            bool flag = _round.StopRound();
            CollisionPlayers.timerEnd = true;
            if(flag)
                StartCoroutine(FadeToBlack(true));
            else
                StartCoroutine(PrepareNextRound());
        }

        IEnumerator AddBonusPoint(bool startNext)
        {
            int currentTime = _round.GetCurrentTimer();
            int timer = currentTime;
            Player.PLAYER winner = _round.GetRoundWinner();

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
            if(startNext)
                _round.StartNextRound();
        }
        
        IEnumerator PrepareNextRound()
        {
            //yield return new WaitForSeconds(1.5f);
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
    }
}