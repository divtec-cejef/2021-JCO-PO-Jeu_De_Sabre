using System;
using Init;
using Players;
using UnityEngine;
using UnityEngine.UI;

namespace Mouvements.Orientation
{
    public class KatanaOrientation
    { 
        private Player.PLAYER player;
    
        private IntPtr playerController;
        
        /* Effet affiché au moment de la parade */ 
        private GameObject playerParadeFx1;
        
        private GameObject playerParadeFx2;
        
        /* Emplacement de l'effet de parade */
        private GameObject playerParadeFxPos;
        
        /* Quaternion permettant d'affecter l'orientation du PSMove au sabre */
        private Quaternion currentOrientation;
        
        private Parade.Parade playerParade;

        private GameObject playerKatanaAxis;

        //private Rigidbody rbKatana;

        public static bool isPaused;
        
        private bool canMove;
    
        // Variables utilisées pour gérer l'orientation du sabre
        private float ow, axeX, axeY, axeZ;
        
        private float prevOw, prevAxeX, prevAxeY, prevAxeZ = 0;
        // private float dirX, dirY;
    
        /// <summary>
        /// Constructeur de l'orientation du katana
        /// </summary>
        /// <param name="player">Le joueur associé au sabre</param>
        /// <param name="playerController">La manette associé au sabre</param>
        /// <param name="playerParadeFx1">Le premier effet visuel appliqué lors d'une parade</param>
        /// <param name="playerParadeFx2">Le deuxième effet visuel appliqué lors d'une parade</param>
        /// <param name="playerParadeFxPos">La position de l'effet visuel lors de son apparition</param>
        /// <param name="playerKatanaAxis">L'axe de rotation du sabre</param>
        /// <param name="katana">Le sabre lui-même</param>
        public KatanaOrientation(Player.PLAYER player, IntPtr playerController, GameObject playerParadeFx1, GameObject playerParadeFx2, GameObject playerParadeFxPos, GameObject playerKatanaAxis, GameObject katana, Slider paradeSlider)
        {
            this.player = player;
            this.playerController = playerController;
            this.playerParadeFx1 = playerParadeFx1;
            this.playerParadeFx2 = playerParadeFx2;
            this.playerParadeFxPos = playerParadeFxPos;
            this.playerKatanaAxis = playerKatanaAxis;
    
            // Activation et réinitialisation de l'orientation de la manette
            Debug.Log("\tActivation et réinitialisation de l'orientation de la manette...");
            PSMoveAPI.psmove_enable_orientation(playerController, PSMove_Bool.PSMove_True);
            PSMoveAPI.psmove_reset_orientation(playerController);
        
            // Initialisation de la parade
            Debug.Log("\tConfiguration de la parade...");
            playerKatanaAxis.AddComponent<Parade.Parade>().Init(GameInit.GetGameConfig().parade_duration, playerParadeFx1, playerParadeFx2, playerParadeFxPos, playerKatanaAxis, player, this, paradeSlider);
            playerParade = playerKatanaAxis.GetComponent<Parade.Parade>();

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

            // Met à jour la led de la manette
            PSMoveAPI.psmove_update_leds(playerController);
        
            // Récupération de l'orientation
            PSMoveAPI.psmove_poll(playerController);
            PSMoveAPI.psmove_get_orientation(playerController, ref ow, ref axeX, ref axeY, ref axeZ);

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
            currentOrientation = new Quaternion(-axeX, axeZ, axeY, ow);

            // Application de la rotation de la manette à l'objet en jeu
            playerKatanaAxis.transform.localRotation =
                Quaternion.Lerp(playerKatanaAxis.transform.localRotation, currentOrientation, GameInit.GetGameConfig().katana_lerp_duration);
        }

        /// <summary>
        /// Permet de récupérer la parade du joueur
        /// </summary>
        /// <returns>La Parade liée au joueur</returns>
        public Parade.Parade GetPlayerParade()
        {
            return playerParade;
        }
    
        /// <summary>
        /// Permet de remettre les valeurs des manettes à zéro
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite réinitialiser la manette</param>
        public static void SetDefaultCalibration(Player.PLAYER player)
        {
            PSMoveAPI.psmove_reset_orientation(player == Player.PLAYER.P1 ? GameInit.GetControllerHandler().GetPlayer1Controller() : GameInit.GetControllerHandler().GetPlayer2Controller());
        }

        /// <summary>
        /// Permet de savoir si le katana peut bouger
        /// </summary>
        /// <returns>Est-ce que le katana peut bouger</returns>
        public bool CanMove()
        {
            return canMove;
        }
        
        /// <summary>
        /// Permet de modifier si le katana peut bouger
        /// </summary>
        /// <param name="canMove">Est-ce que le katana peut bouger</param>
        public void CanMove(bool canMove)
        {
            this.canMove = canMove;
        }

        /// <summary>
        /// Permet de récupérer l'orientation actuel du katana
        /// </summary>
        /// <returns>L'orientation actuel du katana</returns>
        public Quaternion getCurrentQuaternion()
        {
            return currentOrientation;
        }
    }
}
