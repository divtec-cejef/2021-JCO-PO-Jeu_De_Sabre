using System;
using UnityEngine;

public class PSMove : MonoBehaviour
{
    private IntPtr psMoveController;
    private bool isInitDone;
    
    private void Awake()
    {
        isInitDone = false;

        // Initialisation de l'API PSMove
        PSMove_Bool init = PSMoveAPI.psmove_init(PSMoveAPI.PSMove_Version.PSMOVE_CURRENT_VERSION);
        
        if(init == PSMove_Bool.PSMove_True) {
            
            // Récupération de la manette
            psMoveController = PSMoveAPI.psmove_connect();
                
            // Vérification de la validité de la manette
            if (psMoveController == IntPtr.Zero || PSMoveAPI.psmove_update_leds(psMoveController) == 0)
            {
                Debug.LogError("Erreur lors de la récupération de la manette");
            }
            else
            {
                // Activation de l'orientation de la manette
                PSMoveAPI.psmove_enable_orientation(psMoveController, PSMove_Bool.PSMove_True);
                PSMoveAPI.psmove_reset_orientation(psMoveController);
                isInitDone = true;
            }
        }
        else
        {
            Debug.LogError("Erreur lors de l'initialisation de l'API");
        }
    }

    private void Update()
    {
        if (!isInitDone) return;

        // Réinitialisation de l'orientation lors de l'appui sur la touche R
        if (Input.GetKeyDown(KeyCode.R)) PSMoveAPI.psmove_reset_orientation(psMoveController);
        
        // Récupération de l'orientation
        float x = 0, y = 0, z = 0, w = 0;
        PSMoveAPI.psmove_poll(psMoveController);
        PSMoveAPI.psmove_get_orientation(psMoveController, ref w, ref x, ref y, ref z);

        // Application de l'orientation
        Quaternion orientation = new Quaternion(-x, z, y, w);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, orientation, 1f);
    }
}
