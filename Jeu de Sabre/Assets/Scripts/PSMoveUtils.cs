using Init;
using Players;
using UnityEngine;

public class PSMoveUtils
{
    public static void SetLed(Player.PLAYER player, Color color)
    {
        if (player == Player.PLAYER.P1)
        {
            PSMoveAPI.psmove_set_leds(GameInit.GetControllerHandler().GetPlayer1Controller(), (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
        else
        {
            PSMoveAPI.psmove_set_leds(GameInit.GetControllerHandler().GetPlayer2Controller(), (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
        
    }

    public static void SetVibration(Player.PLAYER player, System.Byte level)
    {
        if (player == Player.PLAYER.P1)
        {
            PSMoveAPI.psmove_set_rumble(GameInit.GetControllerHandler().GetPlayer1Controller(), level);
        }
        else
        {
            PSMoveAPI.psmove_set_rumble(GameInit.GetControllerHandler().GetPlayer2Controller(), level);
        }
    }
}
