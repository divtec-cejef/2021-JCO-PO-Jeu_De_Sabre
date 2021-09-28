using System;
using System.Collections;
using Camera;
using Cinemachine;
using Collisions;
using Mouvements;
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

        private static CameraController _cameraController;

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

        [SerializeField] private GameObject player1ScorePlusPrefab;
        [SerializeField] private TextMeshProUGUI player1ScorePlusPrefabText;
        [SerializeField] private GameObject player2ScorePlusPrefab;
        [SerializeField] private TextMeshProUGUI player2ScorePlusPrefabText;
        [SerializeField] private GameObject playerScorePlusParent;
        
        [SerializeField] private GameObject finDuRound;
        [SerializeField] private GameObject player1Win;
        [SerializeField] private GameObject player1Lose;
        [SerializeField] private GameObject player2Win;
        [SerializeField] private GameObject player2Lose;
        [SerializeField] private GameObject player1Draw;
        [SerializeField] private GameObject player2Draw;
        [SerializeField] private Image roundTransition;

        [SerializeField] private GameObject player1LightSaber;
        [SerializeField] private GameObject player2LightSaber;

        [SerializeField] private GameObject player1Character;
        [SerializeField] private GameObject player1CharacterTrans;
        
        [SerializeField] private GameObject player2Character;
        [SerializeField] private GameObject player2CharacterTrans;

        [SerializeField] private GameObject player1Face;
        [SerializeField] private GameObject player2Face;
        
        


        [SerializeField] private ParticleSystem player1Dust;
        [SerializeField] private ParticleSystem player2Dust;

        [SerializeField] private AudioSource soundGong1;
        [SerializeField] private AudioSource soundGong2;
        [SerializeField] private AudioSource soundGong3;
        
        [SerializeField] private AudioSource soundSlash1;
        [SerializeField] private AudioSource soundSlash2;
        [SerializeField] private AudioSource soundSlash3;
        
        [SerializeField] private AudioSource soundCollision1;
        [SerializeField] private AudioSource soundCollision2;
        
        [SerializeField] private AudioSource soundDeath1;
        [SerializeField] private AudioSource soundDeath2;
        [SerializeField] private AudioSource soundDeath3;
        [SerializeField] private AudioSource soundDeath4;
        
        [SerializeField] private AudioSource soundHurt1;
        [SerializeField] private AudioSource soundHurt2;
        [SerializeField] private AudioSource soundHurt3;
        [SerializeField] private AudioSource soundHurt4;
        [SerializeField] private AudioSource soundHurt5;
        [SerializeField] private AudioSource soundHurt6;
        [SerializeField] private AudioSource soundHurt7;
        [SerializeField] private AudioSource soundHurt8;

        [SerializeField] private ParticleSystem player1StunEffect;
        [SerializeField] private ParticleSystem player2StunEffect;

        public static GameObject _player1Character;
        public static GameObject _player2Character;

        public static ParticleSystem _player1StunEffect;
        public static ParticleSystem _player2StunEffect;
        
        public static bool isGamePaused;
        
        public static bool isDebugMenuOn;

        private bool isWarningActive;
        
        private bool isTimerInit;
        private bool isGameEnd;
        
         private void Awake()
         {
             _player1Character = player1Character;
             _player2Character = player2Character;
             
             _player1StunEffect = player1StunEffect;
             _player2StunEffect = player2StunEffect;
             
             // Réinitiation des scores afin d'éviter de récupérer ceux des anciens joueurs
             Player.ReinitScore(Player.PLAYER.P1);
             Player.ReinitScore(Player.PLAYER.P2);
             
             // Affichage des noms des joueurs
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
                 // C'est le pire constructeur que j'ai vu de ma vie,
                 // mais c'était ca ou tout mettre en public
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
                                         finDuRound,
                                         gameObject/*,
                                         player1ScorePlusPrefab,
                                         player2ScorePlusPrefab*/);
            
                // Initialisation du timer
                // print("Initialisation du timer...");
                // _timer = new Timer(_config.game_time, soundTimer, gameObject);
                // isTimerInit = true;
            
                // Initialisaion du gestionnaire de son
                print("Initialisation de gestionnaire de son...");
                _soundHandler = new SoundHandler();
                _soundHandler.soundGong1 = soundGong1;
                _soundHandler.soundGong2 = soundGong2;
                _soundHandler.soundGong3 = soundGong3;
                _soundHandler.soundSlash1 = soundSlash1;
                _soundHandler.soundSlash2 = soundSlash2;
                _soundHandler.soundSlash3 = soundSlash3;
                _soundHandler.soundCollision1 = soundCollision1;
                _soundHandler.soundCollision2 = soundCollision2;
                _soundHandler.soundDeath1 = soundDeath1;
                _soundHandler.soundDeath2 = soundDeath2;
                _soundHandler.soundDeath3 =soundDeath3;
                _soundHandler.soundDeath4 =soundDeath4;
                _soundHandler.soundHurt1 =soundHurt1;
                _soundHandler.soundHurt2 =soundHurt2;
                _soundHandler.soundHurt3 =soundHurt3;
                _soundHandler.soundHurt4 =soundHurt4;
                _soundHandler.soundHurt5 =soundHurt5;
                _soundHandler.soundHurt6 =soundHurt6;
                _soundHandler.soundHurt7 =soundHurt7;
                _soundHandler.soundHurt8 = soundHurt8;

                // Initialisation du tremblement de caméra
                print("Configuration du tremblement des cameras...");
                gameObject.AddComponent<CameraShaking>().Init(player1VirtualCamera, player2VirtualCamera);
                _cameraShaking = gameObject.GetComponent<CameraShaking>();

                // Initialisation du déplacement de caméra
                print("Configuration du déplacement des caméras");
                _cameraController = GetComponent<CameraController>();
                
                // Initialisation des emotes
                print("Initialisation des emotes...");
                gameObject.AddComponent<EmoteHandler>();
                
                _player1EmoteHandler = new EmoteHandler(player1Face);
                _player2EmoteHandler = new EmoteHandler(player2Face);
                
                
                // Activation de la Led des manettes
                //PSMoveUtils.SetLed(Player.PLAYER.P1, Color.yellow);
                //PSMoveUtils.SetLed(Player.PLAYER.P2, Color.yellow);

                _round = gameObject.AddComponent<Round>();
                _round.StartNextRound();
            }
            else
            {
                // Affichage d'un message d'erreur lorsque la connexion avec les manettes s'est mal effectué
                print(_connecter.GetError());
                DisplayWarningMessage(_connecter.GetError(), player1WarningText, player1WarningTextM);
            }
        }
    
        /// <summary>
        /// Permet d'afficher un message d'erreur lorsque les manettes ne fonctionne pas
        /// </summary>
        private void DisplayWarningMessage(String errors, TextMeshProUGUI player1, TextMeshProUGUI player1M)
        {
            player1.text = errors;
            player1.alignment = TextAlignmentOptions.Center;
            player1M.gameObject.SetActive(true);
            StartCoroutine(WarningFlash(player1));
        }

        /// <summary>
        /// Permet de faire clignoter le message passé en paramètre
        /// </summary>
        /// <param name="message">Le message à faire clignoter</param>
        /// <returns></returns>
        private IEnumerator WarningFlash(TextMeshProUGUI message)
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                if (isWarningActive)
                {
                    message.gameObject.SetActive(false);
                    isWarningActive = false;
                }
                else
                {
                    message.gameObject.SetActive(true);
                    isWarningActive = true;
                }

                yield return null;
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
        /// <returns>Le CameraShaking permettant les tremblements</returns>
        public static CameraShaking GetCameraShaking()
        {
            return _cameraShaking;
        }

        public static CameraController GetCameraController()
        {
            return _cameraController;
        }

        /// <summary>
        /// Permet de récupéer la classe gerant les rounds
        /// </summary>
        /// <returns>Le Round gérant les rounds</returns>
        public static Round GetRound()
        {
            return _round;
        }

        /// <summary>
        /// Permet de récupérer l'EmoteHandler du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite récupérer l'EmoteHandler</param>
        /// <returns>L'EmoteHandler du joueur</returns>
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

            // Lors de l'appui sur E, échange du katana par un sabre laser pour le joueur 1
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player1LightSaber.activeInHierarchy)
                {
                    player1LightSaber.SetActive(false);
                    player1KatanaObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    player1LightSaber.SetActive(true);
                    player1KatanaObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            
            // Lors de l'appui sur R, échange du katana par un sabre laser pour le joueur 2
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (player2LightSaber.activeInHierarchy)
                {
                    player2LightSaber.SetActive(false);
                    player2KatanaObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    player2LightSaber.SetActive(true);
                    player2KatanaObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                //PlayScorePlusAnimation(Player.PLAYER.P1);

                //_cameraController.ChangeCameraPOV(Player.PLAYER.P1);
                
                // if (_updater.canP1Blink)
                // {
                //     StartCoroutine(_updater.DispalayLowStamina(Player.PLAYER.P1));
                //     StartCoroutine(_updater.DispalayLowStaminaFill(Player.PLAYER.P1));
                //     StartCoroutine(_updater.DispalayLowStaminaIcon(Player.PLAYER.P1));
                // }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //_cameraController.ResetCamera();
                // if (_updater.canP2Blink)
                // {
                //     StartCoroutine(_updater.DispalayLowStamina(Player.PLAYER.P2));
                //     StartCoroutine(_updater.DispalayLowStaminaFill(Player.PLAYER.P2));
                //     StartCoroutine(_updater.DispalayLowStaminaIcon(Player.PLAYER.P2));
                // }
            }

            // Lors de l'appui sur espace sur le menu de fin, retour au menu
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
        
        ////////////////////////////////////////////////////
        /// LA C'EST LE POINT D'ENTREE A LA FIN DU TIMER ///
        ////////////////////////////////////////////////////
        /*
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |
                            |                                                                                  
                           \*/

        public void OnTimerEnd()
        {
            soundGong2.Play();
            
            // Arret de tout les mouvements en cours
            CollisionPlayers.timerEnd = true;
            
            // Inscription du gagnant
            _round.GetRoundWinner(true);
            
            // Reset du timer
            _updater.SetCountdownText("-");
            
            // Desactivation des collisions
            CollisionPlayers.canAttack = false;
            
            // Lancement de l'animation de chute
            StartCoroutine(PlayDeathAnimation());
        }

        
        ////////////////////////////////////////////////////////
        /// LA C'EST JUSTE APRES LA FIN DU TIMER POUR L'ANIM ///
        ////////////////////////////////////////////////////////
        
        private IEnumerator PlayDeathAnimation()
        {
            // Récupération du gagnant
            Player.PLAYER winner = _round.GetRoundWinner(false);
            
            // Arret des animations en cours
            CollisionPlayers.attack.DisableAnimation();
            
            // Déplacement de la caméra
            if (winner == Player.PLAYER.Other)
            {
                _cameraController.ChangeCameraPOV(Player.PLAYER.P1);
                _cameraController.ChangeCameraPOV(Player.PLAYER.P2);
                
                Color col = new Color(1, 1, 1, 1);
                player2TransLegs.GetComponent<Renderer>().material.color = col;
                player2TransBody.GetComponent<Renderer>().material.color = col;
                player2TransHat.GetComponent<Renderer>().material.color = col;
                
                player1TransLegs.GetComponent<Renderer>().material.color = col;
                player1TransBody.GetComponent<Renderer>().material.color = col;
                player1TransHat.GetComponent<Renderer>().material.color = col;
            }
            else
            {
                _cameraController.ChangeCameraPOV(winner == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1);
            }
            
            
            
            if (winner == Player.PLAYER.P1)
            {
                player2StunEffect.gameObject.SetActive(true);
                _soundHandler.GetSoundDeath().Play();
                // Activation de l'animation de chute pour le joueur 2
                AttackMouvements.animeP2.SetBool("isDead", true);
                AttackMouvements.animeP2Trans.SetBool("isDead", true);

                GetEmoteHandler(Player.PLAYER.P2).SetDeathEmote();

                Color col = new Color(1, 1, 1, 1);
                player2TransLegs.GetComponent<Renderer>().material.color = col;
                player2TransBody.GetComponent<Renderer>().material.color = col;
                player2TransHat.GetComponent<Renderer>().material.color = col;
                
                yield return new WaitForSeconds(.5f);
                
                // Replacement du modèle graphique
                var localPosition = player2Character.transform.localPosition;
                localPosition = new Vector3(localPosition.x, 2.7938f, localPosition.z);
                player2Character.transform.localPosition = localPosition;
    
                var position = player2CharacterTrans.transform.localPosition;
                position = new Vector3(position.x, 2.7938f, position.z);
                player2CharacterTrans.transform.localPosition = position;
                
                yield return new WaitForSeconds(.25f);
                player2Dust.Play();
            }
            else if (winner == Player.PLAYER.P2)
            {
                player1StunEffect.gameObject.SetActive(true);
                _soundHandler.GetSoundDeath().Play();
                // Activation de l'animation de chute pour le joueur 1
                AttackMouvements.animeP1.SetBool("isDead", true);
                AttackMouvements.animeP1Trans.SetBool("isDead", true);
                
                GetEmoteHandler(Player.PLAYER.P1).SetDeathEmote();
                
                Color col = new Color(1, 1, 1, 1);
                player1TransLegs.GetComponent<Renderer>().material.color = col;
                player1TransBody.GetComponent<Renderer>().material.color = col;
                player1TransHat.GetComponent<Renderer>().material.color = col;

                yield return new WaitForSeconds(.5f);
 
                // Replacement ud modèle graphique
                var localPosition = player1Character.transform.localPosition;
                localPosition = new Vector3(localPosition.x, 2.7938f, localPosition.z);
                player1Character.transform.localPosition = localPosition;
    
                var position = player1CharacterTrans.transform.localPosition;
                position = new Vector3(position.x, 2.7938f, position.z);
                player1CharacterTrans.transform.localPosition = position;
                
                yield return new WaitForSeconds(.25f);
                player1Dust.Play();
            }
            
            
            yield return new WaitForSeconds(2.5f);
            
            // Lancement de la fin du round
            StartCoroutine(DisplayRoundEnd());
        }
        
        ////////////////////////////////////////////////////////
        ///          LA C'EST JUSTE L'ANIM POUR              ///
        ///       MONTRER QUE LE ROUND EST TERMINE           ///
        ////////////////////////////////////////////////////////
        
        private IEnumerator DisplayRoundEnd()
        {
            // Activation de l'ecran de transition
            finDuRound.SetActive(true);
            Player.PLAYER winner = _round.GetRoundWinner(false);

            GameObject player1;
            GameObject player2;
            
            if (winner == Player.PLAYER.P1)
            {
                player1 = player1Win;
                player2 = player2Lose;
            }
            else if (winner == Player.PLAYER.P2)
            {
                player1 = player1Lose;
                player2 = player2Win;
            }
            else
            {
                player1 = player1Draw;
                player2 = player2Draw;
            }
            player1.SetActive(true);
            player2.SetActive(true);
            // Arret du round, récupère false si c'était le dernier
            bool flag = _round.StopRound();

            // Affichage en fondu de l'écran de transition
            Color color = finDuRound.GetComponent<TextMeshProUGUI>().color;
            
            while (finDuRound.GetComponent<TextMeshProUGUI>().color.a < 1)
            {
                float fadeAmount = color.a + (0.8f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                roundTransition.color = new Color(roundTransition.color.r, roundTransition.color.g, roundTransition.color.b, fadeAmount);

                player1.GetComponent<TextMeshProUGUI>().color = color;
                player2.GetComponent<TextMeshProUGUI>().color = color;
                finDuRound.GetComponent<TextMeshProUGUI>().color = color;
                yield return null;
            }
            
            _cameraController.ResetCamera();
            CollisionPlayers.attack.DisableDeath();
            // Replacement du modèle graphique
            var localPosition = player2Character.transform.localPosition;
            localPosition = new Vector3(localPosition.x, 3.35f, localPosition.z);
            player2Character.transform.localPosition = localPosition;
    
            var position = player2CharacterTrans.transform.localPosition;
            position = new Vector3(position.x, 3.35f, position.z);
            player2CharacterTrans.transform.localPosition = position;
            
            localPosition = player1Character.transform.localPosition;
            localPosition = new Vector3(localPosition.x, 3.35f, localPosition.z);
            player1Character.transform.localPosition = localPosition;
    
            position = player1CharacterTrans.transform.localPosition;
            position = new Vector3(position.x, 3.35f, position.z);
            player1CharacterTrans.transform.localPosition = position;
            
            Color col = new Color(1, 1, 1, 0.1960784f);
            player1TransLegs.GetComponent<Renderer>().material.color = col;
            player1TransBody.GetComponent<Renderer>().material.color = col;
            player1TransHat.GetComponent<Renderer>().material.color = col;
            player2TransLegs.GetComponent<Renderer>().material.color = col;
            player2TransBody.GetComponent<Renderer>().material.color = col;
            player2TransHat.GetComponent<Renderer>().material.color = col;
            
            player1StunEffect.gameObject.SetActive(false);
            player2StunEffect.gameObject.SetActive(false);

            GetEmoteHandler(Player.PLAYER.P1).Reset();

            yield return new WaitForSeconds(.5f);
            
            // Si c'est le dernier round, fondu au noir 
            if(flag)
                StartCoroutine(FadeToBlack(true, player1, player2));
            // Sinon préparation du prochain round
            else
                StartCoroutine(PrepareNextRound(player1, player2));
        }
        
        ////////////////////////////////////////////////////////
        ///        LA C'EST JUSTE APRES LA TRANSITION        ///
        ///     REPLACE LES JOUEURS ET LES SCORES BONUS      ///
        ////////////////////////////////////////////////////////
        IEnumerator PrepareNextRound(GameObject player1, GameObject player2)
        {
            yield return new WaitForSeconds(1.5f);
            
            // Replacement de l'axe des joueurs 
            playerAxis.transform.localPosition = Vector3.zero;
            playerAxis.transform.localRotation = new Quaternion(0,0,0,0);
            
            // Ajout de points bonus au gagnant
            StartCoroutine(AddBonusPoint(true, player1, player2));
        }
        
        /////////////////////////////////////////////////////
        ///     LA C'EST JUSTE APRES LA PREPARATION       ///
        ///     CALCULE LE SCORE BONUS DU VAINQUEUR       ///
        /////////////////////////////////////////////////////
        IEnumerator AddBonusPoint(bool startNext, GameObject player1, GameObject player2)
        {
            // Récupération du temps restant
            int currentTime = _round.GetCurrentTimer();
            int timer = currentTime;
            
            // Récupération du gagnant
            Player.PLAYER winner = _round.GetRoundWinner(false);
            
            // Décompte du temps restant
            for (int i = 0; i < currentTime; i++)
            {
                timer--;
                _updater.OnTimerUpdate(timer);
                
                // En cas d'égalité, aucun ajout de point
                if (winner != Player.PLAYER.Other)
                {
                    _updater.PlayerScorePlusAnimation(winner, _config.player_bonus_point.ToString());
                    Player.UpdatePlayerScore(winner, _config.player_bonus_point);
                }
                yield return new WaitForSeconds(_config.player_bonus_point_speed);
            }
            
            // Reset de la vie et de l'affichage
            Health.Reset();
            _updater.RefreshHUD();

            // Désactivation de la transition si nécessaire
            if (startNext)
            {
                StartCoroutine(DisableRoundEnd(true, player1, player2));
            }
        }

        /////////////////////////////////////////////////////
        ///     LA C'EST JUSTE APRES LES POINTS BONUS     ///
        ///   DESACTIVE L'EFFET DE TRANSITION ET RELANCE  ///
        /////////////////////////////////////////////////////
        
        private IEnumerator DisableRoundEnd(bool restart, GameObject player1, GameObject player2)
        {
            // Désactivation de l'écran de transition en fondu
            Color color = finDuRound.GetComponent<TextMeshProUGUI>().color;
            Player.PLAYER winner = _round.GetRoundWinner(false);
            
            
            while (finDuRound.GetComponent<TextMeshProUGUI>().color.a > 0)
            {
                float fadeAmount = color.a - (0.8f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                player1.GetComponent<TextMeshProUGUI>().color = color;
                player2.GetComponent<TextMeshProUGUI>().color = color;
                finDuRound.GetComponent<TextMeshProUGUI>().color = color;
                roundTransition.color = new Color(roundTransition.color.r, roundTransition.color.g, roundTransition.color.b, fadeAmount);
                yield return null;
            }
            
            // Désactivation de l'écran de transition pour être sur qu'il disparaisse
            finDuRound.SetActive(false);
            player1.SetActive(false);
            player2.SetActive(false);
            yield return new WaitForSeconds(0.8f);

            // Relancement d'un round si nécessaire
            if (restart)
            {
                _round.StartNextRound();
            }
        }
        
        /////////////////////////////////////////////////////
        ///     LA C'EST JUSTE APRES LA FIN DU ROUND      ///
        ///  AJOUTE LES SCORE ET PASSE A L'ECRAN DE FIN   ///
        /////////////////////////////////////////////////////
        IEnumerator FadeToBlack(bool displayEndScreen, GameObject player1, GameObject player2)
        {
            // Ajout de point bonus au vainqueur
            StartCoroutine(AddBonusPoint(false, player1, player2));

            yield return new WaitForSeconds(1.5f);
            
            // Activation du fondu au noir
            Color color = blackPannel.GetComponent<Image>().color;

            while (blackPannel.GetComponent<Image>().color.a < 1)
            {
                float fadeAmount = color.a + (1f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                blackPannel.GetComponent<Image>().color = color;
                yield return null;
            }
            
            // Pendant que l'écran est noir
            if(displayEndScreen)
            {
                // Modification du score des joueurs dans la base de données
                EditData();
                
                // Lancement des scripts de fin
                _updater.OnEndScreenDisplayed();
                
                // Désactivation de l'affichage de jeu
                playerHudPanel.SetActive(false);
                
                // Activation de l'écran de fin
                endScreen.SetActive(true);
                
                // Activation de la caméra de fin
                cameraTravelling.gameObject.SetActive(true);
                
                // Bloquage de la rotation des sabres (ca marche pas :/ )
                _katana1.CanMove(false);
                _katana2.CanMove(false);
                
                // Indication que la partie est terminée
                isGameEnd = true;
                
                // Désactivation de la transition
                StartCoroutine(DisableRoundEnd(false, player1, player2));
                yield return new WaitForSeconds(0.8f);

                // Récupération des gagnants de chaque round et mise à jour de l'écran de fin
                for (int i = 0; i < 3; i++)
                {
                    UpdateRoundHUD(_round.winners[i], i+1);
                }
            }

            // Disparition du fondu au noir
            while (blackPannel.GetComponent<Image>().color.a > 0)
            {
                float fadeAmount = color.a - (1f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                blackPannel.GetComponent<Image>().color = color;
                yield return null;
            }
        }
        
        /// <summary>
        /// Permet de mettre à jour les scores des joueurs dans la base de données
        /// </summary>
        public void EditData()
        {
            // La chaine de connexion
            string connStr =
                "Database=lacourseauxtrophees;Server=127.0.0.1;Uid=root;Password=Admlocal1;pooling=false;CharSet=utf8;port=3306";
            MySqlConnection conn = new MySqlConnection(connStr);
            
            
            try
            {
                // Overture de la connexion 
                conn.Open();
                
                // Envoi des requêtes 
                // Joueur 1
                MySqlCommand CMD_addScore = conn.CreateCommand();
                CMD_addScore.CommandText = "UPDATE tb_player SET score_knt_player = " + Player.GetScore(Player.PLAYER.P1) + " WHERE identifiant_player  = " + MenuActions.id1 + ";";
                CMD_addScore.ExecuteScalar();
                
                //Joueur 2
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
        
        /// <summary>
        /// Permet d'afficher les résultats des rounds sur le menu de fin
        /// </summary>
        /// <param name="winner">Le gagnant du round</param>
        /// <param name="roundId">Quel round modifier</param>
        public void UpdateRoundHUD(Player.PLAYER winner, int roundId)
        {
            // Permet mettre à jour le résultat des rounds 
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
        
        /// <summary>
        /// Permet de joueur l'animation de gain de score
        /// </summary>
        /// <param name="player">Le joueur à qui jouer l'animation</param>
        /// <param name="text">Le nombre de point</param>
        public void PlayScorePlusAnimation(Player.PLAYER player, string text)
        {
            if (player == Player.PLAYER.P1)
            {
                // Instantiation d'un nouvel objet depuis le péfab
                var scorePlus = Instantiate (player1ScorePlusPrefab, Vector3.zero, Quaternion.identity);
                
                // Liaison de cette objet au score parent
                scorePlus.transform.parent = playerScorePlusParent.transform;
                
                // Taille et positionnement de l'objet
                scorePlus.GetComponent<RectTransform>().localPosition = new Vector3(-354, 122.5f, 0f);
                scorePlus.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f,0.8f);
                
                // Modification du text
                scorePlus.GetComponent<TextMeshProUGUI>().text = "+" + text;
                
                // Destruction de l'object dans 0.8 secondes
                Destroy(scorePlus, 0.8f);
            }
            else
            {   // Instantiation d'un nouvel objet depuis le péfab
                var scorePlus = Instantiate (player2ScorePlusPrefab, Vector3.zero, Quaternion.identity);
                
                // Liaison de cette objet au score parent
                scorePlus.transform.parent = playerScorePlusParent.transform;
                
                // Taille et positionnement de l'objet
                scorePlus.GetComponent<RectTransform>().localPosition = new Vector3(404, 122.5f, 0f);
                scorePlus.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f,0.8f);
                
                // Modification du text
                scorePlus.GetComponent<TextMeshProUGUI>().text = "+" + text;
                
                // Destruction de l'object dans 0.8 secondes
                Destroy(scorePlus, 0.8f);
            }
        }
    }
}