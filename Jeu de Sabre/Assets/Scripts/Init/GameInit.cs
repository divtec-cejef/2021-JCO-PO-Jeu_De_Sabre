using System;
using Camera;
using Cinemachine;
using Mouvements.Orientation;
using Players;
using Players.UI;
using Sounds;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Init
{
    public class GameInit : MonoBehaviour
    {
        private static UiUpdater _updater;
        
        private static ControllerConnecter _connecter;

        private static TrackerConnecter _tracker;
        
        private static ControllerHandler _controllerHandler;
        
        private static Timer _timer;
        
        private static SoundHandler _soundHandler;
        
        private static GameConfig _config;
        
        private static KatanaOrientation _katana1;
        
        private static KatanaOrientation _katana2;
        
        private static CameraShaking _cameraShaking;

        private static EmoteHandler _player1EmoteHandler;
        
        private static EmoteHandler _player2EmoteHandler;
        
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
        
        
        [SerializeField] private TextMeshProUGUI player1TimerText;
        
        [SerializeField] private TextMeshProUGUI player2TimerText;
        
        
        [SerializeField] private Slider player1StaminaSlider;
        
        [SerializeField] private Slider player2StaminaSlider;

        
        [SerializeField] private Slider player1ParadeSlider;
        
        [SerializeField] private Slider player2ParadeSlider;
        
        
        [SerializeField] private GameObject player1KatanaObject;
        
        [SerializeField] private GameObject player2KatanaObject;

        
        [SerializeField] private GameObject soundTimer;
        
        [SerializeField] private GameObject soundDamage;

        
        [SerializeField] private GameObject player1PauseMenuPanel;
        
        [SerializeField] private GameObject player2PauseMenuPanel;
        
        [SerializeField] private GameObject player1HudPanel;
        
        [SerializeField] private GameObject player2HudPanel;

        public static bool isGamePaused;
        
        public static bool isDebugMenuOn;
        
        private bool isTimerInit;
    
        private void Awake()
        {
            isGamePaused = false;
            isDebugMenuOn = false;
            isTimerInit = false;
            // Initialisation de l'affichage sur plusieurs écrans
            print("Intitialisation de l'affichage multiple...");
            gameObject.AddComponent<MultiDisplay>();
        
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
            
                // Récupération des manettes
                print("Récupération des manettes...");
                _controllerHandler = _connecter.GetHandler();
            
                // Initialisation des trackers
                // print("Initialisation des trackers...");
                // gameObject.AddComponent<TrackerConnecter>();
                // _tracker = gameObject.GetComponent<TrackerConnecter>();
                // _tracker = new TrackerConnecter();
                // _tracker.Init();

                // Initialisation de l'orientation de la manette 1
                print("Initialisation de la rotation du joueur 1...");
                _katana1 = new KatanaOrientation(Player.PLAYER.P1, _controllerHandler.GetPlayer1Controller(), player1ParadeFx1,
                    player1ParadeFx2, player1ParadeFxPos, player1KatanaAxis, player1KatanaObject, player1ParadeSlider);
                Katana1.Init();
            
                print("Initialisation de la rotation du joueur 2...");
                // Initialisation de l'orientation de la manette 2
                _katana2 = new KatanaOrientation(Player.PLAYER.P2, _controllerHandler.GetPlayer2Controller(), player2ParadeFx1,
                    player2ParadeFx2, player2ParadeFxPos, player2KatanaAxis, player2KatanaObject, player2ParadeSlider);
                Katana2.Init();

                // Initialisation de la classe chargée de mettre à jour le HUD
                print("Initialisation de la mise à jour de l'affichage");
                _updater = new UiUpdater(player1ScoreText, player2ScoreText, player1StaminaSlider, player2StaminaSlider, player1TimerText, player2TimerText, player1ParadeSlider, player2ParadeSlider);
            
                // Initialisation du timer
                print("Initialisation du timer...");
                _timer = new Timer(_config.game_time, soundTimer);
                isTimerInit = true;
            
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
                PSMoveUtils.SetLed(Player.PLAYER.P1, Color.magenta);
                PSMoveUtils.SetLed(Player.PLAYER.P2, Color.magenta);
            }
            else
            {
                print(_connecter.GetError());
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
            player1HudPanel.SetActive(true);
            player2HudPanel.SetActive(true);
        
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
            player1HudPanel.SetActive(false);
            player2HudPanel.SetActive(false);
        
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
            Debug.Log("Quitting game...");
            Application.Quit();
        }

        private void OnApplicationQuit()
        {
            // Déconnexion des manettes à la fermeture du jeu
            PSMoveAPI.psmove_disconnect(_controllerHandler.GetPlayer1Controller());
            PSMoveAPI.psmove_disconnect(_controllerHandler.GetPlayer2Controller());
            PSMoveAPI.psmove_tracker_free(TrackerConnecter.player1Tracker);
            PSMoveAPI.psmove_tracker_free(TrackerConnecter.player2Tracker);
        }
    }
}