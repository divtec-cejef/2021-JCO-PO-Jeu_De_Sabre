using System;
using Init;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Mouvements.Orientation
{
    public class KatanaOrientation
    { 
        private Player.Joueur player;
    
        private IntPtr controller;
        /* Effet affiché au moment de la parade */ 
        private GameObject FXParade;
        private GameObject FXParade2;
        /* Emplacement de l'effet de parade */
        private GameObject FXParadePos;
        /* Quaternion permettant d'affecter l'orientation du PSMove au sabre */
        private Quaternion currentOrientation;
        private Parade.Parade parade;

        private GameObject katanaAxis;

        private Rigidbody rbKatana;

        public static bool isPaused;
        private bool canMove;
    
        // Variables utilisées pour gérer l'orientation du sabre
        private float ow;
        private float axeX;
        private float axeY;
        private float axeZ;
    
        private float prevOw = 0;
        private float prevAxeX = 0;
        private float prevAxeY = 0;
        private float prevAxeZ = 0;
    

        private float dirX, dirY;
    
        /// <summary>
        /// Constructeur de l'orientation du katana
        /// </summary>
        /// <param name="player">Le joueur associé au sabre</param>
        /// <param name="controller">La manette associé au sabre</param>
        /// <param name="FXParade">Le premier effet visuel appliqué lors d'une parade</param>
        /// <param name="FXParade2">Le deuxième effet visuel appliqué lors d'une parade</param>
        /// <param name="FXParadePos">La position de l'effet visuel lors de son apparition</param>
        /// <param name="katanaAxis">L'axe de rotation du sabre</param>
        /// <param name="katana">Le sabre lui-même</param>
        public KatanaOrientation(Player.Joueur player, IntPtr controller, GameObject FXParade, GameObject FXParade2, GameObject FXParadePos, GameObject katanaAxis, GameObject katana)
        {
            this.player = player;
            this.controller = controller;
            this.FXParade = FXParade;
            this.FXParade2 = FXParade2;
            this.FXParadePos = FXParadePos;
            this.katanaAxis = katanaAxis;
            // TODO ca aussi c'est pour les déplacements clavier 
            rbKatana = katanaAxis.GetComponent<Rigidbody>();
    
            // Activation et réinitialisation de l'orientation de la manette
            Debug.Log("\tActivation et réinitialisation de l'orientation de la manette...");
            PSMoveAPI.psmove_enable_orientation(controller, PSMove_Bool.PSMove_True);
            PSMoveAPI.psmove_reset_orientation(controller);
        
            //parade = new Parade(GameInit.getGameConfig().parade_duration, GameInit.getGameConfig().parade_duration, FXParade, FXParade2, FXParadePos, katanaAxis, player);
        
            // Initialisation de la parade
            Debug.Log("\tConfiguration de la parade...");
            katanaAxis.AddComponent<Parade.Parade>().Init(GameInit.getGameConfig().parade_duration, FXParade, FXParade2, FXParadePos, katanaAxis, player, this);
            parade = katanaAxis.GetComponent<Parade.Parade>();

            canMove = true;
        }

        public void onUpdate()
        {
            // Si le jeu est en pause, le sabre de peut plus bouger
            isPaused = !GameInit.isGamePaused;

            if (!isPaused) 
                return;

            if (!canMove)
                return;
        
        
            // TODO c'est pour le clavier
            dirX = Input.GetAxis("Horizontal") * 5;
            dirY = Input.GetAxis("Vertical") * 5;

            // Met à jour la led de la manette
            PSMoveAPI.psmove_update_leds(controller);
        
            // Met à jour le cooldown de la parade
            // parade.UpdateParadeCooldown();

            // Récupération de la valeur de la gachette de la manette
            PSMoveAPI.psmove_poll(controller);
            char trigger = PSMoveAPI.psmove_get_trigger(controller);

            // Si le joueur est en parade, mise à jour de la parade
            // [mise à jour]
            
            // Si la gachette est enfoncé
            // ('ÿ' est la valeur retourné par l'API PSMove lorsque la gachette est enfoncée au maximum)
            // if (trigger == 'ÿ')
            // {
            //     // Activation de la parade chez le joueur correspondant
            //     if (player == Player.Joueur.P1)
            //         parade.OnParadeEnabled(ref currentOrientation, -axeX, axeZ, axeY, ow, Color.blue);
            //     else
            //         parade.OnParadeEnabled(ref currentOrientation, axeX, axeZ, -axeY, ow, Color.red);
            // }

            // Si le joueur n'est pas en parade, réactivation des controles du sabre
            
            // Si la gachette est relaché ou que la parade a été annulée ou que le joueur n'est plus en parade
            // if (trigger != 'ÿ' || /*parade.getCanceled() ||*/ !parade.getParade())
            // {
            // Désactivation de la parade
            //parade.OnParadeDisabled();

            // Récupération de l'orientation
            PSMoveAPI.psmove_poll(controller);
            PSMoveAPI.psmove_get_orientation(controller, ref ow, ref axeX, ref axeY, ref axeZ);

            // La c'est des trucs pour modifier tenter de recalibrer le sabre tout seul
            // C'est pas encore parfait
            {
                float Xmin = prevAxeX - 0.05f;
                float Xmax = prevAxeX + 0.05f;
                if (axeX >= Xmin && axeX <= Xmax)
                {

                }

                float Zmin = prevAxeZ - 0.05f;
                float Zmax = prevAxeZ + 0.05f;
                if (axeZ >= Zmin && axeZ <= Zmax)
                {
                    axeZ = prevAxeZ;
                }

                float Ymin = prevAxeY - 0.05f;
                float Ymax = prevAxeY + 0.05f;
                if (axeY >= Ymin && axeY <= Ymax)
                {
                    axeY = prevAxeY;
                }

                float Wmin = prevOw - 0.005f;
                float Wmax = prevOw + 0.005f;
                if (ow >= Wmin && ow <= Wmax)
                {
                    ow = prevOw;
                }
            }
            
            prevAxeX = axeX;
            prevAxeZ = axeZ;
            prevAxeY = axeY;
            prevOw = ow;

        
            // Sauvegarde de la rotation
            currentOrientation = player == Player.Joueur.P1
                ? new Quaternion(-axeX, axeZ, axeY, ow)
                : new Quaternion(axeX, axeZ, -axeY, ow);

            //Debug.Log(currentOrientation);
            
            // Application de la rotation de la manette à l'objet en jeu
            katanaAxis.transform.rotation =
                Quaternion.Lerp(katanaAxis.transform.rotation, currentOrientation, GameInit.getGameConfig().katana_lerp_duration);
            //}
        }

        public void onFixedUpdate()
        {
            //TODO les déplacements au clavier
            var c = new Vector3(dirX, dirY, rbKatana.velocity.z);
            // Debug.Log(c);
            rbKatana.velocity = c;
        }

        /// <summary>
        /// Permet de récupérer la parade du joueur
        /// </summary>
        /// <returns>La Parade liée au joueur</returns>
        public Parade.Parade getParade()
        {
            return parade;
        }
    
        /// <summary>
        /// Permet de remettre les valeurs des manettes à zéro
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite réinitialiser la manette</param>
        public static void defaultCalibration(Player.Joueur player)
        {
            if (player == Player.Joueur.P1)
            {
                PSMoveAPI.psmove_reset_orientation(GameInit.getControllerHandler().getController1());
            }
            else
            {
                PSMoveAPI.psmove_reset_orientation(GameInit.getControllerHandler().getController2());
            }
        
        }


        public bool CanMove()
        {
            return canMove;
        }
        
        public void CanMove(bool canMove)
        {
            this.canMove = canMove;
        }

        public Quaternion getCurrentQuaternion()
        {
            return currentOrientation;
        }
        
        public float getX()
        {
            return axeX;
        }
    
        public float getY()
        {
            return axeY;
        }
    
        public float getZ()
        {
            return axeZ;
        }
    
        public float getW()
        {
            return ow;
        }
    }
}
