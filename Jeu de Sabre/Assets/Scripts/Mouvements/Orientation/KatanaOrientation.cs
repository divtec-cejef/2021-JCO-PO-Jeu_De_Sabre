using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private Parade parade;

    private GameObject katanaAxis;
    
    // Variables utilisées pour gérer l'orientation du sabre
    private float ow;
    private float axeX;
    private float axeY;
    private float axeZ;
    
    public KatanaOrientation(Player.Joueur player, IntPtr controller, GameObject FXParade, GameObject FXParade2, GameObject FXParadePos, GameObject katanaAxis)
    {
        this.player = player;
        this.controller = controller;
        this.FXParade = FXParade;
        this.FXParade2 = FXParade2;
        this.FXParadePos = FXParadePos;
        this.katanaAxis = katanaAxis;
    
        // Activation et réinitialisation de l'orientation de la manette
        PSMoveAPI.psmove_enable_orientation(controller, PSMove_Bool.PSMove_True);
        PSMoveAPI.psmove_reset_orientation(controller);
        
        parade = new Parade(3.0f, 5.0f, FXParade, FXParade2, FXParadePos, katanaAxis, player);
    }

    public void onUpdate()
    {
        // Met à jour la led de la manette
        PSMoveAPI.psmove_update_leds(controller);
        // Met à jour le cooldown de la parade
        parade.updateParadeCooldown();
        
        
        //Is Colliding

        PSMoveAPI.psmove_poll(controller);
        char trigger = PSMoveAPI.psmove_get_trigger(controller);

        
        if (trigger == 'ÿ')
        {
            if (player == Player.Joueur.P1)
                parade.onParadeEnabled(ref currentOrientation, -axeX, axeZ, axeY, ow, Color.blue);
            else
                parade.onParadeEnabled(ref currentOrientation, axeX, axeZ, -axeY, ow, Color.red);
        }

        if (trigger != 'ÿ' || parade.getCanceled() || !parade.getParade())
        {
            parade.onParadeDisabled();

            PSMoveAPI.psmove_poll(controller);
            PSMoveAPI.psmove_get_orientation(controller, ref ow, ref axeX, ref axeY, ref axeZ);

            currentOrientation = player == Player.Joueur.P1 ? new Quaternion(-axeX, axeZ, axeY, ow) : new Quaternion(axeX, axeZ, -axeY, ow);

            katanaAxis.transform.rotation = currentOrientation;
        }
    }
    
    
    public void defaultCalibration()
    {
        PSMoveAPI.psmove_reset_orientation(controller);
    }

    
}