using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    private static UiUpdater updater;
    private static ControllerConnecter connecter;
    private static ControllerHandler controllerHandler;
    private static KatanaOrientation katana_1;
    private static Timer timer;
    private static SoundHandler soundHandler;
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
    
    public Text Score_j1;
    public Text Score_j2;

    public GameObject Stamina_j1;
    public GameObject Stamina_j2;

    public Text timer_j1;
    public Text timer_j2;

    public GameObject katana1;
    public GameObject katana2;

    public int timerDuration;

    public GameObject timerSound;

    public GameObject damageSound;

    private bool isTimerInit = false;
    
    private void Awake()
    {
        multi = new MultiDisplay();
        multi.init();
        
        connecter = new ControllerConnecter();
        if (connecter.init())
        {
            controllerHandler = connecter.getHandler();
            
            katana_1 = new KatanaOrientation(Player.Joueur.P1, controllerHandler.getController1(), FXParade_P1,
                FXParade2_P1, FXParadePos_P1, KatanaAxis_P1, katana1);
            
            katana_2 = new KatanaOrientation(Player.Joueur.P2, controllerHandler.getController2(), FXParade_P2,
                FXParade2_P2, FXParadePos_P2, KatanaAxis_P2, katana2);

            Katana_1.init();
            Katana_2.init();

            updater = new UiUpdater(Score_j1, Score_j2, Stamina_j1, Stamina_j2, timer_j1, timer_j2);
            
            timer = new Timer(timerDuration, timerSound);
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

    public static SoundHandler getSoundHandler()
    {
        return soundHandler;
    }
    
    private void Update()
    {
        if(isTimerInit)
            getTimer().onUpdate();
    }

    /**
     * Déconnection des manettes lors de la fermeture de l'application
     */
    private void OnApplicationQuit()
    {
        PSMoveAPI.psmove_disconnect(controllerHandler.getController1());
        //PSMoveAPI.psmove_disconnect(controllerHandler.getController2());
    }
}
