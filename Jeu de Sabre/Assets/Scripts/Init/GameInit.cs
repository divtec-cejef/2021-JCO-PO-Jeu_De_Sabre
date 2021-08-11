using System;
using Camera;
using Cinemachine;
using Mouvements.Orientation;
using Players;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Init
{
    public class GameInit : MonoBehaviour
    {
        private static UiUpdater updater;
        private static ControllerConnecter connecter;
        private static ControllerHandler controllerHandler;
        private static Timer timer;
        private static SoundHandler soundHandler;
        private static GameConfig config;
        private static KatanaOrientation katana_1;
        private static KatanaOrientation katana_2;
        private static CameraShaking cameraShaking;
        private MultiDisplay multiDisplay;
        
        [SerializeField] private GameObject player1ParadeFx1;
        [SerializeField] private GameObject FXParade2_P1;
        [SerializeField] private GameObject FXParadePos_P1;
        [SerializeField] private GameObject KatanaAxis_P1;
    
        [SerializeField] private GameObject player2ParadeFx1;
        [SerializeField] private GameObject FXParade2_P2;
        [SerializeField] private GameObject FXParadePos_P2;
        [SerializeField] private GameObject KatanaAxis_P2;

        [SerializeField] private CinemachineVirtualCamera vCameraJ1;
        [SerializeField] private CinemachineVirtualCamera vCameraJ2;
        
        [SerializeField] private TextMeshProUGUI Score_j1;
        [SerializeField] private TextMeshProUGUI Score_j2;

        [SerializeField] private Slider Stamina_j1;
        [SerializeField] private Slider Stamina_j2;

        [SerializeField] private TextMeshProUGUI timer_j1;
        [SerializeField] private TextMeshProUGUI timer_j2;
        
        [SerializeField] private GameObject katana1;
        [SerializeField] private GameObject katana2;

        [SerializeField] private Slider Parade_j1;
        [SerializeField] private Slider Parade_j2;
        
        [SerializeField] private GameObject timerSound;
        [SerializeField] private GameObject damageSound;

        [SerializeField] private GameObject pauseMenuUi;
        [SerializeField] private GameObject pauseMenuUi2;
        [SerializeField] private GameObject player1Ui;
        [SerializeField] private GameObject player2Ui;

        public static bool isGamePaused = false;
        public static bool isDebugMenuOn = false;
        private bool isTimerInit = false;
    
        private void Awake()
        {
            // Initialisation de l'affichage sur plusieurs écrans
            print("Intitialisation de l'affichage multiple...");
            gameObject.AddComponent<MultiDisplay>();
        
            // Récupération du chemin utilisateur de l'ordinateur
            print("Récupération du dossier utilisation...");
            String userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        
            // Initialisation de la connexion des manettes
            print("Initialisation des manettes...");
            connecter = new ControllerConnecter();
        
            // Si l'initialisation est passée
            if (connecter.Init())
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
                config = JsonUtility.FromJson<GameConfig>(json);

                // Initialisation de l'endurance
                print("Initialisation du système d'endurance...");
                gameObject.AddComponent<Stamina>();
            
                // Récupération des manettes
                print("Récupération des manettes...");
                controllerHandler = connecter.getHandler();
            
                // Initialisation de l'orientation de la manette 1
                print("Initialisation de la rotation du joueur 1...");
                katana_1 = new KatanaOrientation(Player.Joueur.P1, controllerHandler.getController1(), player1ParadeFx1,
                    FXParade2_P1, FXParadePos_P1, KatanaAxis_P1, katana1);
                Katana1.Init();
            
                print("Initialisation de la rotation du joueur 2...");
                // Initialisation de l'orientation de la mentte 2
                katana_2 = new KatanaOrientation(Player.Joueur.P2, controllerHandler.getController2(), player2ParadeFx1,
                    FXParade2_P2, FXParadePos_P2, KatanaAxis_P2, katana2);
                Katana2.Init();

                // Initialisation de la classe chargée de mettre à jour le HUD
                print("Initialisation de la mise à jour de l'affichage");
                updater = new UiUpdater(Score_j1, Score_j2, Stamina_j1, Stamina_j2, timer_j1, timer_j2, Parade_j1, Parade_j2);
            
                // Initialisation du timer
                print("Initialisation du timer...");
                timer = new Timer(config.game_time, timerSound);
                isTimerInit = true;
            
                // Initialisaion du gestionnaire de son
                print("Initialisation de gestionnaire de son...");
                soundHandler = new SoundHandler(timerSound, damageSound);

                // Initialisation du tremblement de caméra
                print("Configuration du tremblement des cameras...");
                gameObject.AddComponent<CameraShaking>().Init(vCameraJ1, vCameraJ2);
                cameraShaking = gameObject.GetComponent<CameraShaking>();
            }
            else
            {
                print(connecter.getError());
            }
        }
    
        /// <summary>
        /// Permet de récupérer la connexion des manettes
        /// </summary>
        /// <returns>Le ControllerConnecter des manettes</returns>
        public static ControllerConnecter getControllerConnecter()
        {
            return connecter;
        }
    
        /// <summary>
        /// Permet de récupérer les manettes
        /// </summary>
        /// <returns>Le ControllerHandler des manettes</returns>
        public static ControllerHandler getControllerHandler()
        {
            return controllerHandler;
        }
    
        /// <summary>
        /// Permet de récupérer la gestion de l'orientation de la manette 1
        /// </summary>
        /// <returns>Le KatanaOrientation de la manette 1</returns>
        public static KatanaOrientation getKatanaPlayer1()
        {
            return katana_1;
        }
    
        /// <summary>
        /// Permet de récupérer la gestion de l'orientation de la manette 2
        /// </summary>
        /// <returns>Le KatanaOrientation de la manette 2</returns>
        public static KatanaOrientation getKatanaPlayer2()
        {
            return katana_2;
        }
    
        /// <summary>
        /// Permet de récupérer l'objet chargé de mettre à jour le HUD
        /// </summary>
        /// <returns>Le UiUpdater permettant de mettre à jour le HUD</returns>
        public static UiUpdater getUiUpdater()
        {
            return updater;
        }

        /// <summary>
        /// Permet de récupérer l'objet chargé de mettre à jour le timer
        /// </summary>
        /// <returns>Le Timer permettant de mettre à jour le timer</returns>
        public static Timer getTimer()
        {
            return timer;
        }

        /// <summary>
        /// Permet de récupérer la configuration chargée depuis le fichier Json
        /// </summary>
        /// <returns>Le GameConfig contenant toutes les configuration du jeu</returns>
        public static GameConfig getGameConfig()
        {
            return config;
        }

        /// <summary>
        /// Permet de récupérer la classe contenant les sons du jeu
        /// </summary>
        /// <returns>Le SoundHandler contenant les sons du jeu</returns>
        public static SoundHandler getSoundHandler()
        {
            return soundHandler;
        }

        public static CameraShaking getCameraShaking()
        {
            return cameraShaking;
        }
    
        private void Update()
        {
            // Dès que le timer est initialisé, mise à jour de celui-ci
            if(isTimerInit)
                getTimer().onUpdate();
        
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
                KatanaOrientation.defaultCalibration(Player.Joueur.P1);
        
            // Recalibration du sabre 2 lors de l'appui sur la touche 2
            if (Input.GetKeyDown(KeyCode.Alpha2))
                KatanaOrientation.defaultCalibration(Player.Joueur.P2);
        }

        /// <summary>
        /// Fonction appelé lors de la fermeture du menu pause
        /// </summary>
        public void Resume()
        {
            // Activation du HUD des joueurs
            player1Ui.SetActive(true);
            player2Ui.SetActive(true);
        
            // Désactivation du menu pause des joueurs
            pauseMenuUi.SetActive(false);
            pauseMenuUi2.SetActive(false);
        
            // Relancement du temps en jeu
            Time.timeScale = 1f;
        
            // Recalibration des sabres des joueurs
            KatanaOrientation.defaultCalibration(Player.Joueur.P1);
            KatanaOrientation.defaultCalibration(Player.Joueur.P2);
        
            isGamePaused = false;
        }

        /// <summary>
        /// Fonction appelé lors de l'ouverture du menu pause
        /// </summary>
        private void Pause()
        {
            // Désactivation du HUD des joueurs
            player1Ui.SetActive(false);
            player2Ui.SetActive(false);
        
            // Activation du menu pause des joueurs
            pauseMenuUi.SetActive(true);
            pauseMenuUi2.SetActive(true);
        
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
            PSMoveAPI.psmove_disconnect(controllerHandler.getController1());
            PSMoveAPI.psmove_disconnect(controllerHandler.getController2());
        }
    }
}
