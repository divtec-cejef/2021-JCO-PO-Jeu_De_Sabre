using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    
    public void init()
    {
        //Affiche le nbr d'écran connecté dans les logs
        Debug.Log ("écran(s) connecté : " + Display.displays.Length);
    
        //Vérifie si d'autre écran sont disponible à l'affichage du jeu         
        for (int i = 1; i < Display.displays.Length; i++)
            Display.displays[i].Activate();

        // Display.displays[1].Activate();
        // Display.displays[2].Activate();

    }
}
