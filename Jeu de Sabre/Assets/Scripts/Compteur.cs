using System;
using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class Compteur : MonoBehaviour
{
    private int compteur;
    private collisionCompteur vitesse = new collisionCompteur();
        
    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, 30, 20), compteur.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        compteur+= vitesse.OnDamage(vitesseVariables.vitesse);;

    }

}