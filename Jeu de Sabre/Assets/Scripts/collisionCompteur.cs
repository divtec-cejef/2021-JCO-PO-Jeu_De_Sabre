using System;
using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class collisionCompteur : MonoBehaviour
{
    private int compteur;
    public Rigidbody rb;
    public float vitesseCoup;
    Vector3 vitesseVector;

    void FixedUpdate()
    {
        vitesseCoup = rb.velocity.magnitude;
        Debug.Log("c'est la vitesse " + vitesseCoup);
        
        //Debug.Log("C'est le vecteur " + vitesseVector.ToString());
        //Debug.Log("c'est la vitesse " + vitesseCoup);
    }
    
    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, 100, 20), "Points " + compteur.ToString());
    }
   
    //Récuperer la vitesse du sabre et definir les damages en consequences
    public int OnDamage(float speed)
    {
        //le multiplicateur sert a rendre la vitesse lisible
        speed *= 10000000;
        
        int degat = 0;
        if (speed >= 0 && speed < 2)
        {
            degat += 1;
        }
        else if (speed >= 2 && speed < 3)
        {
            degat += 5;
        }
        else if (speed >= 3 && speed < 4)
        {
            degat += 10;
        }
        else if (speed >= 3 && speed < 5)
        {
            degat += 15;
        }
        else if (speed >= 5 && speed < 7)
        {
            degat += 20;
        }
        else if (speed >= 7 && speed < 10)
        {
            degat += 25;
        }
        else if (speed >= 10)
        {
            degat += 35;
        }

        
        Debug.Log("c'est les damage " + degat);
        
        return degat;
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {

        compteur += OnDamage(vitesseCoup);;

    }

}