using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSMoveUtils
{
    public static void setLED(System.IntPtr move, Color color)
    {
        PSMoveAPI.psmove_set_leds(move, (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
    }

    public static void setVibration(System.IntPtr move, System.Byte level)
    {
        PSMoveAPI.psmove_set_rumble(move, level);
    }
}
