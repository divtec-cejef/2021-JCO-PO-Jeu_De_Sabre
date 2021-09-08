using System;
using Init;
using Players;
using UnityEngine;
using Color = UnityEngine.Color;

public class PSMoveUtils
{
    /// <summary>
    /// Permet de modifier la couleur des leds de la manette
    /// </summary>
    /// <param name="player">Le joueur auquel on souhaite changer la couleur</param>
    /// <param name="color">La nouvelle couleur</param>
    [Obsolete("Veuillez utiliser MoveAPI.SetLED")]
    public static void SetLed(Player.PLAYER player, Color color)
    {
        if (player == Player.PLAYER.P1)
        {
            //PSMoveAPI.psmove_set_leds(GameInit.GetControllerHandler().GetPlayer1Controller(), (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
            //PSMoveAPI.psmove_set_leds(GameInit.GetControllerHandler().GetPlayer1Controller(), (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
        else
        {
            //PSMoveAPI.psmove_set_leds(GameInit.GetControllerHandler().GetPlayer2Controller(), (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255));
        }
    }

    /// <summary>
    /// Permet de faire vibrer la manette
    /// </summary>
    /// <param name="player">Le joueur auquel on souhaite faire vibrer la manette</param>
    /// <param name="level">Le niveau de vibration</param>
    [Obsolete("Veuillez utiliser MoveAPI.SetRumble")]
    public static void SetVibration(Player.PLAYER player, System.Byte level)
    {
        if (player == Player.PLAYER.P1)
        {
            //PSMoveAPI.psmove_set_rumble(GameInit.GetControllerHandler().GetPlayer1Controller(), level);
        }
        else
        {
            //PSMoveAPI.psmove_set_rumble(GameInit.GetControllerHandler().GetPlayer2Controller(), level);
        }
    }
}
