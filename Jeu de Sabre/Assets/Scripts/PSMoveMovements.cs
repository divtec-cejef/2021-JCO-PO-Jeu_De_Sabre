using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.VirtualTexturing;

public class PSMoveMovements : MonoBehaviour
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
        move = TestConnection.handle;
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
        Color BasicColor = Color.white; 
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
        gameObject.GetComponent<Renderer>().material.color = BasicColor;
        ColorCount++;
    }
    
    public void SetLED(Color color) {
        PSMoveAPI.psmove_set_leds(move, (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
    }

    private void Update() {
        if (TestConnection.initDone)
        {
            PSMoveAPI.psmove_update_leds(move);

            PSMove_Battery_Level batteryLvl = PSMoveAPI.psmove_get_battery(move);
            //LedColorBattery(b);
            
            PSMoveAPI.psmove_poll(move);

            //print(PSMoveAPI.psmove_get_accelerometer_frame(move,frame ,ref ow, ref ox, ref oy, ref oz));
            PSMoveAPI.psmove_get_orientation(move, ref ow, ref axeX, ref axeY, ref axeZ);
            print("OW : " + ow + ". OX : " + axeX/**763.0f*/ + ". OY : " + axeY/**26*/ + ". OZ : " + axeZ/**3.19f*/);

            quaternion = new Quaternion (-axeX, axeZ, axeY, ow);
            transform.rotation = quaternion;
        }
    }

    private void OnApplicationQuit() {
        PSMoveAPI.psmove_disconnect(move);
    }

    private float getDivValue(float value, float maxValue, float divValue = 360f)
    {
        double div = divValue / maxValue;
        value = (float)(div * value);
        return value;
    }

    private void printOrientationValue(float attitude, float bank, float heading)
    {
        bool flag = false;
        /*if (heading < 0){
            heading *= -1;
        }*/
        double div = 360.0f / 5000.0f;
        //print(heading);
        heading = (float)(div * heading);
        //print(attitude + " " + heading + " " + bank);
    }
    
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

    void OnEnable(){
        actions.Buttons.Enable();
    }

    void OnDisable(){
        actions.Buttons.Disable();
    }
}
