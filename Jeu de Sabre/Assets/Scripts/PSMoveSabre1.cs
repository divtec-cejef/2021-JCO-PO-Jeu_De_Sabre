using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.VirtualTexturing;

public class PSMoveSabre1 : MonoBehaviour
{
    /* Permet de récupérer l'appui d'une touche du PSMove */ // Bientôt obsolète
    private PSMoveActions actions;
    
    /* Manette PSMove */
    private static System.IntPtr move;
    /* Camera PSEye */
    private static System.IntPtr camera;

    /* Si le joueur est en parade */
    public static bool isParade = false;
    /* Si sa parade à été annulé */
    private bool isCanceled = false;
    /* Si le joueur est prêt pour une nouvelle parade */
    private bool isReady = true;

    /* Délai avant que la parade ne se désactive */
    private float timerParade = 5.0f; // Secondes
    /* Délai avant la nouvelle parade */
    private float cooldownParade = 5.0f; // Secondes
    
    /* Effet affiché au moment de la parade */
    public GameObject FXParade;
    /* Emplacement de l'effet de parade */
    public GameObject FXParadePos;
    private GameObject effect;
    
    // Variables utilisées pour gérer l'orientation du sabre
    private float ow = 0;
    private float axeX;
    private float axeY;
    private float axeZ;
    
    /* Compteur permettant de modifier la couleur */ /* TODO A Supprimer */
    private int ColorCount;
    ArrayList colorList = new ArrayList();

    /* Quaternion permettant d'affecter l'orientation du PSMove au sabre */
    Quaternion quaternion;

    /**
     * Fonction qui se lance juste après le test de la connexion des PSMove
     */
    public static void init()
    {
        // Récupération de la manette après l'initialisation de l'API
        move = TestConnection.manette_1;
        // Activation et réinitialisation de l'orientation de la manette
        PSMoveAPI.psmove_enable_orientation(move, PSMove_Bool.PSMove_True);
        PSMoveAPI.psmove_reset_orientation(move);
    }

    /**
     * Fonction de base d'Unity s'exécutant au démarage du scripts
     * TODO Supprimer la fonction et tout ce qui est en rapport avec les inputs dès qu'on pourra les utiliser avec l'api
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

    /* TODO A supprimer ou deplacer */
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
     * TODO A Supprimer ou déplacer
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

            // Fonction permettant d'avertir le PSMove qu'on va agir sur ses capteurs
            PSMoveAPI.psmove_poll(move);
            
            // Récupération de l'état du Trigger 'T'
            char trigger = PSMoveAPI.psmove_get_trigger(move);

            /* Si le Trigger est enfoncé, activation de la parade */
            if (trigger == 'ÿ')
            {
                activerParade();
            }
            
            // Si le Trigger n'est pas enfoncé ou que l'ancienne parade à été annulée
            // Réactivation de l'orientation du sabre
            if (trigger != 'ÿ' || isCanceled)
            {
                // Désactivation de la parade
                desactiverParade();
                
                // Récupération de l'orientation du PSMove
                PSMoveAPI.psmove_poll(move);
                PSMoveAPI.psmove_get_orientation(move, ref ow, ref axeX, ref axeY, ref axeZ);
            
                // CA FAIT CRASHER LE JEU QUAND ON L'ARRETE AVEC CE PRINT, PK PAS
                //print("OW : " + ow + ". OX : " + axeX/**763.0f*/ + ". OY : " + axeY/**26*/ + ". OZ : " + axeZ/**3.19f*/);
                
                // TODO Modification de la valeur retournée par le PSMove qui se désaxe au fur et a mesure
                ow += 0.0f;
                axeX -= 0.2f;
                axeY -= 0.0009f;
                axeZ += 0.0009f;
            
                // Affectation de l'orientation du PSMove à l'objet en cours 
                quaternion = new Quaternion(-axeX, axeZ, axeY, ow);
                transform.rotation = quaternion;
            }

            /* Si le joueur n'est pas prêt à executé une parade et qu'un n'est pas déjà en parade */
            if (!isReady && !isParade)
            {
                // TODO, Utiliser la variable CoolDownParade comme TimerParade
            }
        }
    }

    /* Réinitialisation du timer de la parade */
    private void reinitTimer()
    {
        timerParade = 5.0f;
    }

    /* Vérification et activation de la parade */
    private void activerParade()
    {
        /* Si la parade n'est pas annulé et que le joueur est prêt à parer */
        if (!isCanceled && isReady)
        {
            /* Si le joueur n'est pas déjà en parade */
            if (!isParade)
            {
                // Création de l'effet visuel
                effect = (GameObject) Instantiate(FXParade, FXParadePos.transform.position, FXParadePos.transform.rotation);
                quaternion = new Quaternion(-axeX, axeZ, axeY, ow);
                transform.rotation = quaternion;
                // Vibration de la manette
                PSMoveAPI.psmove_set_rumble(move, 255);
            }
            // Mise à jour du timer de la parade
            ParadeTimer();
            isParade = true;
        }
    }

    /* Gère le timer de la parade en cours */
    private void  ParadeTimer()
    {
        /* Si le timer n'est pas terminé, décompte du timer */
        if (timerParade > 0)
        {
            timerParade -= Time.deltaTime;
        }
        /* Si le timer est terminé, annulation de la parade et réinitialisation du timer */
        else
        {
            isCanceled = true;
            timerParade = 4.0f;
        }
            
    }

    private void desactiverParade()
    {
        if (isParade)
        {
            timerParade = 4.0f;
            isCanceled = false;
            PSMoveAPI.psmove_set_rumble(move, 0);
            Destroy(effect);
        }
        isParade = false;
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
