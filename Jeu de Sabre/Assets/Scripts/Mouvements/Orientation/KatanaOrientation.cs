using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

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

    private Rigidbody rbKatana;

    public static bool canMove;
    
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
    
    public KatanaOrientation(Player.Joueur player, IntPtr controller, GameObject FXParade, GameObject FXParade2, GameObject FXParadePos, GameObject katanaAxis, GameObject katana)
    {
        this.player = player;
        this.controller = controller;
        this.FXParade = FXParade;
        this.FXParade2 = FXParade2;
        this.FXParadePos = FXParadePos;
        this.katanaAxis = katanaAxis;
        rbKatana = katanaAxis.GetComponent<Rigidbody>();
    
        // Activation et réinitialisation de l'orientation de la manette
        PSMoveAPI.psmove_enable_orientation(controller, PSMove_Bool.PSMove_True);
        PSMoveAPI.psmove_reset_orientation(controller);
        
        //parade = new Parade(GameInit.getGameConfig().parade_duration, GameInit.getGameConfig().parade_duration, FXParade, FXParade2, FXParadePos, katanaAxis, player);
        katanaAxis.AddComponent<Parade>().init(GameInit.getGameConfig().parade_duration, GameInit.getGameConfig().parade_duration, FXParade, FXParade2, FXParadePos, katanaAxis, player);
        parade = katanaAxis.GetComponent<Parade>();
    }

    public void onUpdate()
    {
        canMove = !GameInit.isGamePaused;
        
        if (canMove)
        {
            dirX = Input.GetAxis("Horizontal") * 5;
            dirY = Input.GetAxis("Vertical") * 5;

            //Debug.Log(dirX + " " + dirY);
            bool a = Input.GetMouseButtonDown(1);
            if (a)
                defaultCalibration(Player.Joueur.P2);
            bool b = Input.GetMouseButtonDown(0);
            if (b)
                defaultCalibration(Player.Joueur.P1);
            bool c = Input.GetMouseButtonDown(2);
            if (c)
            {
                defaultCalibration(Player.Joueur.P1);
                defaultCalibration(Player.Joueur.P2);
            }



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
                
                prevAxeX = axeX;
                prevAxeZ = axeZ;
                prevAxeY = axeY;
                prevOw = ow;

                currentOrientation = player == Player.Joueur.P1
                    ? new Quaternion(-axeX, axeZ, axeY, ow)
                    : new Quaternion(axeX, axeZ, -axeY, ow);

                //var v = new Vector3(-axeX, axeZ, axeY);
                katanaAxis.transform.rotation =
                    Quaternion.Lerp(katanaAxis.transform.rotation, currentOrientation, GameInit.getGameConfig().katana_lerp_duration);

                //katanaAxis.transform.rotation = currentOrientation;
            }
        }
    }

    public void onFixedUpdate()
    {
        var c = new Vector3(dirX, dirY, rbKatana.velocity.z);
        // Debug.Log(c);
        rbKatana.velocity = c;
    }

    public Parade getParade()
    {
        return parade;
    }
    
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
