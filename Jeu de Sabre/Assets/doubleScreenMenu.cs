using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleScreenMenu : MonoBehaviour
{
    private void Awake()
    {
        //Affiche le nbr d'écran connecté dans les logs
        Debug.Log ("écran(s) connecté : " + Display.displays.Length);

        //Vérifie si d'autre écran sont disponible à l'affichage du jeu         
        for (int i = 1; i < Display.displays.Length; i++)
            Display.displays[i].Activate();
    }
}
