using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    
    // public void init()
    // {
    //     
    //
    // }

    private void Awake()
    {
        // Affichage du nombre d'écran connecté
        Debug.Log ("\tNombre d'écran : " + Display.displays.Length);
    
        //Vérifie si d'autre écran sont disponible à l'affichage du jeu         
        for (int i = 1; i < Display.displays.Length; i++)
            Display.displays[i].Activate();
    }
}
