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
    
    public static void setLED(PSMoveID move_id, Color color)
    {
        if (move_id == PSMoveID.Manette_1)
        {
            PSMoveAPI.psmove_set_leds(TestConnection.manette_1, (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
        else
        {
            PSMoveAPI.psmove_set_leds(TestConnection.manette_2, (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
        
    }

    public static void setVibration(PSMoveID move_id, System.Byte level)
    {
        if (move_id == PSMoveID.Manette_1)
        {
            PSMoveAPI.psmove_set_rumble(TestConnection.manette_1, level);
        }
        else
        {
            PSMoveAPI.psmove_set_rumble(TestConnection.manette_2, level);
        }
    }
}
