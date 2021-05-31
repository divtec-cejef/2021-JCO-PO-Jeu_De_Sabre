using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMoveSabre2 : MonoBehaviour
{
    // Permet de récupérer l'appui d'une touche du PSMove
    private PSMoveActions actions;
    
    // Manette PSMove
    private static System.IntPtr move;
    private static System.IntPtr camera;
    
    // Variables utilisées pour gérer l'orientation du sabre
    private float ow = 0;
    private float axeX;
    private float axeY;
    private float axeZ;


    public float value;
    
    /* Effet affiché au moment de la parade */
    public GameObject FXParade_1;
    public GameObject FXParade_2;
    /* Emplacement de l'effet de parade */
    public GameObject FXParadePos;

    
    // Quaternion permettant d'affecter l'orientation du PSMove au sabre
    Quaternion quaternion;

    private Parade parade;
    
    /**
     * Fonction qui se lance juste après le test de la connexion des PSMove
     */
    public static void init()
    {
        move = TestConnection.manette_2;
        PSMoveAPI.psmove_reset_orientation(move);
        PSMoveAPI.psmove_enable_orientation(move, PSMove_Bool.PSMove_True);
        PSMoveUtils.setLED(move, Color.green);
    }

    /**
     * Fonction de base d'Unity s'exécutant au démarage du scripts
     */
    void Awake(){
        actions = new PSMoveActions();
        actions.Buttons.Move.performed += ctx => defaultCalibration();
        parade = new Parade(3.0f, 5.0f, FXParade_1, FXParade_2, FXParadePos, gameObject, move);

    }

    /**
     * Fonction permettant de recalibrer le sabre et le PSMove
     */
    void defaultCalibration()
    {
        PSMoveAPI.psmove_reset_orientation(move);
    }

    public Parade getParade()
    {
        return parade;
    }
    
    private void Update() {
        /* Vérifie si l'initialisation est terminé avant d'agir sur le PSMove */
        if (TestConnection.initDone)
        {
            PSMoveAPI.psmove_update_leds(move);
            //PSMove_Battery_Level batteryLvl = PSMoveAPI.psmove_get_battery(move);
            //LedColorBattery(batteryLvl);

            parade.updateParadeCooldown();
            
            PSMoveAPI.psmove_poll(move);
            
            // Récupération de l'état du Trigger 'T'
            char trigger = PSMoveAPI.psmove_get_trigger(move);

            /* Si le Trigger est enfoncé, activation de la parade */
            if (trigger == 'ÿ')
            {
                parade.onParadeEnabled(ref quaternion, axeX, axeZ, -axeY, ow, Color.red);
            }

            if (trigger != 'ÿ' || parade.getCanceled() || !parade.getParade())
            {
                parade.onParadeDisabled();
                
                /* Récupère l'orientation du PSMove */
                PSMoveAPI.psmove_poll(move);
                PSMoveAPI.psmove_get_orientation(move, ref ow, ref axeX, ref axeY, ref axeZ);


                // CA FAIT CRASHER LE JEU QUAND ON L'ARRETE AVEC CE PRINT, PK PAS
                //print("OW : " + ow + ". OX : " + axeX/**763.0f*/ + ". OY : " + axeY/**26*/ + ". OZ : " + axeZ/**3.19f*/);
                /*
                float owConp = 0.0007f;
                float axeXConp = 0.01f;
                float axeYConp =0.003f;
                float axeZConp =0.009f;
                */
                ow += 0.0f;
                axeX -= 0.0f;
                axeY -= 0.0f;
                axeZ += 0.0009f;

                /* Affectation de l'orientation à l'objet en cours */
                quaternion = new Quaternion(axeX, axeZ, -axeY, ow);
                transform.rotation = quaternion;
            }
        }
    }

    /**
     * Permet d'activer les contrôles des boutons
     */
    void OnEnable(){
        actions.Buttons.Enable();
    }

    /**
     * Permet de désactiver les contrôles des boutons
     */
    void OnDisable(){
        actions.Buttons.Disable();
    }
}
