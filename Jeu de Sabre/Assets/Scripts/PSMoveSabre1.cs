using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.VirtualTexturing;

public class PSMoveSabre1 : MonoBehaviour
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
    
    // Compteur permettant de modifier la couleur
    private int ColorCount;
    ArrayList colorList = new ArrayList();

    // Quaternion permettant d'affecter l'orientation du PSMove au sabre
    Quaternion quaternion;

    /**
     * Fonction qui se lance juste après le test de la connexion des PSMove
     */
    public static void init()
    {
        move = TestConnection.manette_1;
        PSMoveAPI.psmove_reset_orientation(move);
        PSMoveAPI.psmove_enable_orientation(move, PSMove_Bool.PSMove_True);
    }

    /**
     * Fonction de base d'Unity s'exécutant au démarage du scripts
     */
    void Awake(){
        actions = new PSMoveActions();
        actions.Buttons.Trigger.performed += ctx => ChangeColor();
        actions.Buttons.Move.performed += ctx => defaultCalibration();
        //actions.Buttons.Move.performed += ctx => LedColorBattery(battery:);
        // Génération de la liste de couleur
        setColorList();
    }

    /**
     * Fonction permettant de recalibrer le sabre et le PSMove
     */
    void defaultCalibration()
    {
        PSMoveAPI.psmove_reset_orientation(move);
    }

    void setColorList()
    {
        colorList.Add(Color.red);
        colorList.Add(Color.blue);
        colorList.Add(Color.green);
        colorList.Add(Color.yellow);
        colorList.Add(Color.magenta);
        colorList.Add(Color.white);
    }
    
    /**
     * Permet de changer la couleur de la LED
     */
    private void ChangeColor()
    {
        Color BasicColor = Color.yellow; 
        // switch (ColorCount){
        //     case 1: BasicColor = cRed; break;
        //     case 2:BasicColor = cBlue; break;
        //     case 3:BasicColor = cGreen; break;
        //     case 4:BasicColor = cYellow; break;
        //     case 5: BasicColor = cMagenta;
        //             ColorCount = 0; break;
        //     default: BasicColor = cWhite; break;
        // }
        SetLED(BasicColor);
        //gameObject.GetComponent<Renderer>().material.color = BasicColor;
        ColorCount++;
    }
    private void Update() {
        /* Vérifie si l'initialisation est terminé avant d'agir sur le PSMove */
        if (TestConnection.initDone)
        {
            PSMoveAPI.psmove_update_leds(move);
            //PSMove_Battery_Level batteryLvl = PSMoveAPI.psmove_get_battery(move);
            //LedColorBattery(batteryLvl);
            
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
            axeX -= 0.2f;
            axeY -= 0.0009f;
            axeZ += 0.0009f;


            if (PSMoveAPI.psmove_get_trigger(move) == 'ÿ')
            {
                PSMoveAPI.psmove_set_rumble(move, 255);
            }
            else
            {
                PSMoveAPI.psmove_set_rumble(move, 0);

            }
            
            /* Affectation de l'orientation à l'objet en cours */
            quaternion = new Quaternion (-axeX, axeZ, axeY, ow);
            transform.rotation = quaternion;
        }
    }

    /**
     * Modifie la couleur de la LED du PSMove en fonction du niveau de batterie passé en paramètre
     */
    void LedColorBattery(PSMove_Battery_Level battery){
        switch (battery)
        {
            case PSMove_Battery_Level.Batt_MIN: SetLED(Color.red);
                break;
            case PSMove_Battery_Level.Batt_20Percent: SetLED(new Color(240,80,0));
                break;
            case PSMove_Battery_Level.Batt_40Percent: SetLED(new Color(210, 150, 0));
                break;
            case PSMove_Battery_Level.Batt_60Percent: SetLED(new Color(150, 210, 0));
                break;
            case PSMove_Battery_Level.Batt_80Percent: SetLED(new Color(80, 240, 0));
                break;
            case PSMove_Battery_Level.Batt_MAX: SetLED(Color.green);
                break;
            case PSMove_Battery_Level.Batt_CHARGING: SetLED(Color.blue);
                break;
            case PSMove_Battery_Level.Batt_CHARGING_DONE: SetLED(Color.cyan);
                break;
        }
    }
    
    /**
     * Permet de traduire la couleur passéE en paramètre au format demandé par la fonction psmove_set_leds()
     */
    public void SetLED(Color color) {
        PSMoveAPI.psmove_set_leds(move, (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
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
