using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private int width = 150;
    
    private void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, width, 20), "Score 1 : " + Player.getScore(Player.Joueur.P1));
        GUI.TextArea(new Rect(Screen.width / 2, 0, width, 20), "Score 2 : " + Player.getScore(Player.Joueur.P2));
    }
}
