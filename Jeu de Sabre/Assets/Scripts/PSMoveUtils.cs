using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PSMoveUtils
{

    public enum PSMoveID
    {
        Manette_1 = 0,
        Manette_2 = 1,
    }
    
    public static void setLED(Player.Joueur player, Color color)
    {
        if (player == Player.Joueur.P1)
        {
            PSMoveAPI.psmove_set_leds(GameInit.getControllerHandler().getController1(), (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
        else
        {
            PSMoveAPI.psmove_set_leds(GameInit.getControllerHandler().getController2(), (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
        
    }

    public static void setVibration(Player.Joueur player, System.Byte level)
    {
        if (player == Player.Joueur.P1)
        {
            PSMoveAPI.psmove_set_rumble(GameInit.getControllerHandler().getController1(), level);
        }
        else
        {
            PSMoveAPI.psmove_set_rumble(GameInit.getControllerHandler().getController2(), level);
        }
    }
}
