using System;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Init
{
    public class ControllerConnecter {

        private IntPtr player1Controller;
        
        private IntPtr player2Controller;
        
        // Variable utilsée pour afficher les erreurs
        private int errors = -1;
        
        private ControllerHandler handler;
    
        public bool Init()
        {
        
            /* Initialisation de l'API PSMove */
            PSMove_Bool init = PSMoveAPI.psmove_init(PSMoveAPI.PSMove_Version.PSMOVE_CURRENT_VERSION);
        
            if(init == PSMove_Bool.PSMove_True) {
                /* Récupération des manettes PSMove */
                player1Controller = PSMoveAPI.psmove_connect_by_id(0);
                player2Controller = PSMoveAPI.psmove_connect_by_id(1);
                //tracker_1 = PSMoveAPI.psmove_tracker_new();

                /* Vérification de la validité de la manette 1 */
                if(player1Controller == IntPtr.Zero || PSMoveAPI.psmove_update_leds(player1Controller) == 0)
                    errors = 0;

                /* Vérification de la validité de la manette 2 */
                if (player2Controller == IntPtr.Zero || PSMoveAPI.psmove_update_leds(player2Controller) == 0)
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
                handler = new ControllerHandler(player1Controller, player2Controller);
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
        public ControllerHandler GetHandler()
        {
            return handler;
        }

        /// <summary>
        /// Permet de récupérer les erreurs relatives à la connection des manettes
        /// </summary>
        /// <returns>L'erreur de la connection</returns>
        public String GetError()
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
