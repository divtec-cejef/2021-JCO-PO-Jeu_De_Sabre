using System;
using UnityEngine;

public class TestConnection : MonoBehaviour {

    public static IntPtr manette_1;
    public static IntPtr manette_2;
    public static bool initDone = false;

	private void Start () {
        /* Initialisation de l'API PSMove */
        PSMove_Bool init = PSMoveAPI.psmove_init(PSMoveAPI.PSMove_Version.PSMOVE_CURRENT_VERSION);
        
        if(init == PSMove_Bool.PSMove_True) {
            /* Récupération des manettes PSMove */
            manette_1 = PSMoveAPI.psmove_connect_by_id(0);
            //manette_2 = PSMoveAPI.psmove_connect_by_id(1);

            // Variable utilsée pour afficher les erreurs
            int errorNbr = -1;
            
            /* Vérification de la validité de la manette 1 */
            if(manette_1 == IntPtr.Zero || PSMoveAPI.psmove_update_leds(manette_1) == 0)
                errorNbr = 0;
            
            /* Vérification de la validité de la manette 2 */
            // if (manette_2 == IntPtr.Zero || PSMoveAPI.psmove_update_leds(manette_2) == 0)
            // {
            //     if (errorNbr == 0)
            //         errorNbr = 2;
            //     else
            //         errorNbr = 1;
            // }
            
            /* Affichage des potentielles erreurs */
            switch (errorNbr)
            {
                /* Si la manette 1 ne fonctionne pas */
                case 0:
                    Debug.LogError("Impossible d'établir une connexion avec la Manette 1");
                    break;
                /* Si la manette 2 ne fonctionne pas */
                case 1:
                    Debug.LogError("Impossible d'établir une connexion avec la Manette 2");
                    break;
                /*Si aucune manette de fonctionne */
                case 2:
                    Debug.LogError("Impossible d'établir une connexion avec les Manettes");
                    break;
                /* Si toute les manettes fonctionnent */
                default:
                    Debug.Log("Connexion établie avec les Manettes");
                    // Initialisation terminée
                    initDone = true;
                    
                    // Initialisation des mouvements de la manette
                    PSMoveSabre1.init();
                    //PSMoveSabre2.init();
                    break;
            }
        } 
        /* Si l'API PSMove n'a pas pu être initialisé */
        else {
            Debug.LogError("Impossible d'initialiser l'API PSMove");
        }
    }

    /**
     * Déconnection des manettes lors de la fermeture de l'application
     */
    private void OnApplicationQuit() {
        PSMoveAPI.psmove_disconnect(manette_1);
        //PSMoveAPI.psmove_disconnect(manette_2);
    }
}
