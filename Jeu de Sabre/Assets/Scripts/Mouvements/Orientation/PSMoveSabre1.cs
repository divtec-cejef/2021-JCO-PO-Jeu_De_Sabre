// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Runtime.CompilerServices;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.InputSystem;
// using UnityEngine.Rendering.VirtualTexturing;
// using Random = UnityEngine.Random;
//
// public class PSMoveSabre1 : MonoBehaviour
// {
//     /* Permet de récupérer l'appui d'une touche du PSMove */ // Bientôt obsolète
//     private PSMoveActions actions;
//
//     /* Manette PSMove */
//     private static System.IntPtr move;
//
//     /* Effet affiché au moment de la parade */
//     public GameObject FXParade;
//     public GameObject FXParade2;
//     /* Emplacement de l'effet de parade */
//     public GameObject FXParadePos;
//
//     public static bool isColliding = false;
//     
//     // Variables utilisées pour gérer l'orientation du sabre
//     private float ow = 0;
//     private float axeX;
//     private float axeY;
//     private float axeZ;
//
//     private int frame = 0;
//
//     /* Quaternion permettant d'affecter l'orientation du PSMove au sabre */
//     Quaternion quaternion;
//
//     public static Quaternion lastQuaternion;
//
//     private Parade parade;
//     /**
//      * Fonction qui se lance juste après le test de la connexion des PSMove
//      */
//     public static void init()
//     {
//         // Récupération de la manette après l'initialisation de l'API
//         move = TestConnection.manette_1;
//         // Activation et réinitialisation de l'orientation de la manette
//         PSMoveAPI.psmove_enable_orientation(move, PSMove_Bool.PSMove_True);
//         PSMoveAPI.psmove_reset_orientation(move);
//         PSMoveUtils.setLED(PSMoveUtils.PSMoveID.Manette_1, Color.green);
//     }
//
//     /**
//      * Fonction de base d'Unity s'exécutant au démarage du scripts
//      * TODO Supprimer la fonction et tout ce qui est en rapport avec les inputs dès qu'on pourra les utiliser avec l'api
//      */
//     void Awake(){
//         actions = new PSMoveActions();
//         actions.Buttons.Move.performed += ctx => defaultCalibration();
//         parade = new Parade(3.0f, 5.0f, FXParade, FXParade2, FXParadePos, gameObject, PSMoveUtils.PSMoveID.Manette_1);
//         //actions.Buttons.Move.performed += ctx => LedColorBattery(battery:);
//     }
//
//     /**
//      * Fonction permettant de recalibrer le sabre et le PSMove
//      */
//     void defaultCalibration()
//     {
//         PSMoveAPI.psmove_reset_orientation(move);
//     }
//
//
//     public Parade getParade()
//     {
//         return parade;
//     }
//     
//     private void Update() {
//         /* Vérifie si l'initialisation est terminé avant d'agir sur le PSMove */
//         if (TestConnection.initDone)
//         {
//             PSMoveAPI.psmove_update_leds(move);
//             //PSMove_Battery_Level batteryLvl = PSMoveAPI.psmove_get_battery(move);
//             //LedColorBattery(batteryLvl);
//
//             //print("Parade : " + isParade + ", Canceled : " + isCanceled + ", Ready : " + isReady);
//
//             parade.updateParadeCooldown();
//
//             if (!isColliding)
//             {
//
//                 // Fonction permettant d'avertir le PSMove qu'on va agir sur ses capteurs
//                 PSMoveAPI.psmove_poll(move);
//
//                 // Récupération de l'état du Trigger 'T'
//                 char trigger = PSMoveAPI.psmove_get_trigger(move);
//
//                 /* Si le Trigger est enfoncé, activation de la parade */
//                 if (trigger == 'ÿ')
//                 {
//                     parade.onParadeEnabled(ref quaternion, -axeX, axeZ, axeY, ow, Color.blue);
//                 }
//
//                 // Si le Trigger n'est pas enfoncé ou que l'ancienne parade à été annulée
//                 // Réactivation de l'orientation du sabre
//                 if (trigger != 'ÿ' || parade.getCanceled() || !parade.getParade())
//                 {
//                     // Désactivation de la parade
//                     parade.onParadeDisabled();
//
//                     // Récupération de l'orientation du PSMove
//                     PSMoveAPI.psmove_poll(move);
//                     PSMoveAPI.psmove_get_orientation(move, ref ow, ref axeX, ref axeY, ref axeZ);
//
//                     // CA FAIT CRASHER LE JEU QUAND ON L'ARRETE AVEC CE PRINT, PK PAS
//                     //print("OW : " + ow + ". OX : " + axeX/**763.0f*/ + ". OY : " + axeY/**26*/ + ". OZ : " + axeZ/**3.19f*/);
//
//                     // TODO Modification de la valeur retournée par le PSMove qui se désaxe au fur et a mesure
//                     ow += 0.0f;
//                     axeX -= 0.0f;
//                     axeY -= 0.0f;
//                     axeZ += 0.0009f;
//
//                     // Affectation de l'orientation du PSMove à l'objet en cours 
//                     // if (frame > 50)
//                     // {
//                     //     frame = 0;
//                     //     lastQuaternion = transform.rotation;
//                     // }
//                     // else
//                     // {
//                         frame++;
//                         quaternion = new Quaternion(-axeX, axeZ, axeY, ow);
//                         transform.rotation = quaternion;
//                     // }
//                     
//                 }
//             }
//         }
//     }
//     
//     /**
//      * Permet d'activer les contrôles des boutons
//      */
//     void OnEnable(){
//         actions.Buttons.Enable();
//     }
//
//     /**
//      * Permet de désactiver les contrôles des boutons
//      */
//     void OnDisable(){
//         actions.Buttons.Disable();
//     }
// }
