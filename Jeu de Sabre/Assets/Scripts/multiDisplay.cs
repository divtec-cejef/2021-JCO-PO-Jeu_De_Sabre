using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          //Affiche le nbr d'écran connecté dans les logs
          Debug.Log ("écran(s) connecté : " + Display.displays.Length);
        
                //Vérifie si d'autre écran sont disponible à l'affichage du jeu         
                for (int i = 1; i < Display.displays.Length; i++)
                    {
                        Display.displays[i].Activate();
                    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
