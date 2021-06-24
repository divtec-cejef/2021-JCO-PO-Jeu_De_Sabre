using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    private static UiUpdater updater;
    private static ControllerConnecter connecter;
    private static ControllerHandler controllerHandler;
    private static KatanaOrientation katana_1;
    private static Timer timer;
    private static SoundHandler soundHandler;
    private static GameConfig config;
    private MultiDisplay multi;
    
    public GameObject FXParade_P1;
    public GameObject FXParade2_P1;
    public GameObject FXParadePos_P1;
    public GameObject KatanaAxis_P1;
    
    private static KatanaOrientation katana_2;
    
    public GameObject FXParade_P2;
    public GameObject FXParade2_P2;
    public GameObject FXParadePos_P2;
    public GameObject KatanaAxis_P2;
    
    public TextMeshProUGUI Score_j1;
    public TextMeshProUGUI Score_j2;

    public Slider Stamina_j1;
    public Slider Stamina_j2;

    public TextMeshProUGUI timer_j1;
    public TextMeshProUGUI timer_j2;
    
    public TextMeshProUGUI classement_j1;
    public TextMeshProUGUI classement_j2;

    public GameObject katana1;
    public GameObject katana2;

    public Slider Parade_j1;
    public Slider Parade_j2;
    public GameObject timerSound;

    public GameObject damageSound;

    public GameObject pauseMenuUi;
    public GameObject pauseMenuUi2;
    public GameObject player1Ui;
    public GameObject player2Ui;
    
    public static bool isGamePaused = false;
    
    private bool isTimerInit = false;
    
    private void Awake()
    {
        multi = new MultiDisplay();
        multi.init();String userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        
        connecter = new ControllerConnecter();
        if (connecter.init())
        {
            userDir += "\\Documents\\katana_no_tatakai_properties.json";
            String json = "";
            String[] lines= System.IO.File.ReadAllLines(@userDir);
            foreach (String line in lines)
            {
                json += line;
            }
            config = JsonUtility.FromJson<GameConfig>(json);
            //print(config.getValue());
            
            Stamina.initStamina();
            
            controllerHandler = connecter.getHandler();
            
            katana_1 = new KatanaOrientation(Player.Joueur.P1, controllerHandler.getController1(), FXParade_P1,
                FXParade2_P1, FXParadePos_P1, KatanaAxis_P1, katana1);
            
            katana_2 = new KatanaOrientation(Player.Joueur.P2, controllerHandler.getController2(), FXParade_P2,
                FXParade2_P2, FXParadePos_P2, KatanaAxis_P2, katana2);

            Katana_1.init();
            Katana_2.init();

            updater = new UiUpdater(Score_j1, Score_j2, Stamina_j1, Stamina_j2, timer_j1, timer_j2, Parade_j1, Parade_j2, classement_j1, classement_j2);
            
            timer = new Timer(config.game_time, timerSound);
            isTimerInit = true;
            soundHandler = new SoundHandler(timerSound, damageSound);
        }
        else
        {
            print(connecter.getError());
        }
    }
    
    public static ControllerConnecter getControllerConnecter()
    {
        return connecter;
    }
    
    public static ControllerHandler getControllerHandler()
    {
        return controllerHandler;
    }
    
    public static KatanaOrientation getKatanaPlayer1()
    {
        return katana_1;
    }
    
    public static KatanaOrientation getKatanaPlayer2()
    {
        return katana_2;
    }
    
    public static UiUpdater getUiUpdater()
    {
        return updater;
    }

    public static Timer getTimer()
    {
        return timer;
    }

    public static GameConfig getGameConfig()
    {
        return config;
    }

    public static SoundHandler getSoundHandler()
    {
        return soundHandler;
    }
    
    private void Update()
    {
        if(isTimerInit)
            getTimer().onUpdate();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Resume();
            else
                Pause();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            KatanaOrientation.defaultCalibration(Player.Joueur.P1);
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            KatanaOrientation.defaultCalibration(Player.Joueur.P2);
        
    }

    public void Resume()
    {
        player1Ui.SetActive(true);
        player2Ui.SetActive(true);
        pauseMenuUi.SetActive(false);
        pauseMenuUi2.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        KatanaOrientation.defaultCalibration(Player.Joueur.P1);
        KatanaOrientation.defaultCalibration(Player.Joueur.P2);
    }

    private void Pause()
    {
        player1Ui.SetActive(false);
        player2Ui.SetActive(false);
        pauseMenuUi.SetActive(true);
        pauseMenuUi2.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene("MainMenu");
    }
    
    

    /**
     * Déconnection des manettes lors de la fermeture de l'application
     */
    private void OnApplicationQuit()
    {
        PSMoveAPI.psmove_disconnect(controllerHandler.getController1());
        PSMoveAPI.psmove_disconnect(controllerHandler.getController2());
    }
}
