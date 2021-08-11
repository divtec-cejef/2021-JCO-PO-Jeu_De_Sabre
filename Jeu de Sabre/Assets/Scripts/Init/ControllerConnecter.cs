using System;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Init
{
    public class ControllerConnecter {

        private IntPtr controller_1;
        private IntPtr controller_2;
        // Variable utilsée pour afficher les erreurs
        private int errors = -1;
        private ControllerHandler handler;
    
        public bool Init()
        {
        
            /* Initialisation de l'API PSMove */
            PSMove_Bool init = PSMoveAPI.psmove_init(PSMoveAPI.PSMove_Version.PSMOVE_CURRENT_VERSION);
        
            if(init == PSMove_Bool.PSMove_True) {
                /* Récupération des manettes PSMove */
                controller_1 = PSMoveAPI.psmove_connect_by_id(0);
                controller_2 = PSMoveAPI.psmove_connect_by_id(1);
                //tracker_1 = PSMoveAPI.psmove_tracker_new();

                /* Vérification de la validité de la manette 1 */
                if(controller_1 == IntPtr.Zero || PSMoveAPI.psmove_update_leds(controller_1) == 0)
                    errors = 0;

                /* Vérification de la validité de la manette 2 */
                if (controller_2 == IntPtr.Zero || PSMoveAPI.psmove_update_leds(controller_2) == 0)
                {
                    if (errors == 0)
                        errors = 2;
                    else
                        errors = 1;
                }

                // Si il y'a une erreur
                if (errors != -1) 
                    return false;
            
                // Création d'un ControllerHandler permettant de stocker les manettes durant le jeu
                Debug.Log("\tGénération du gestionnaire des manettes...");
                handler = new ControllerHandler(controller_1, controller_2);
                return true;

            } 
            /* Si l'API PSMove n'a pas pu être initialisé */
            errors = 3;
            return false;
        }

        /// <summary>
        /// Permet de récupérer le handler des manettes pour les réutiliser ailleurs
        /// </summary>
        /// <returns>Le handler des manettes</returns>
        public ControllerHandler getHandler()
        {
            return handler;
        }

        /// <summary>
        /// Permet de récupérer les erreurs relatives à la connection des manettes
        /// </summary>
        /// <returns>L'erreur de la connection</returns>
        public String getError()
        {
            String error = null;
            switch (errors)
            {
                /* Si la manette 1 ne fonctionne pas */
                case 0:
                    error = "\tImpossible d'établir une connexion avec la Manette 1";
                    break;
                /* Si la manette 2 ne fonctionne pas */
                case 1:
                    error = "\tImpossible d'établir une connexion avec la Manette 2";
                    break;
                /*Si aucune manette de fonctionne */
                case 2:
                    error = "\tImpossible d'établir une connexion avec les Manettes";
                    break;
                /* Si l'api de fonctionne pas */
                case 3:
                    error = "\tImpossible d'initialiser l'API PSMove";
                    break;
            }
            return error;
        }
    }
}
