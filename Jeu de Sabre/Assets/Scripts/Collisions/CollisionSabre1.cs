using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CollisionSabre1 : MonoBehaviour
{
    private int score;
    public float vitesseCoup = 0;
    Vector3 vitesseVector;
    public GameObject sabreOue;


    private float timer = 0.0f;

    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, 200, 20), "Points " + score.ToString());
    }
   
    //Récuperer la vitesse du sabre et definir les damages en consequences
    public int OnDamage(float speed)
    {
        //le multiplicateur sert a rendre la vitesse lisible
        //speed *= 10000000;
        
        //Debug.Log("c'est les damage " + degat);
        
        return 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SM_Wep_Odachi_01")
        { 
            PSMoveSabre1.isColliding = true;
            sabreOue.transform.rotation = Quaternion.Lerp(transform.rotation, PSMoveSabre1.frameQuaternion, 0.07f);

        }
        else if (other.gameObject.name == "Characters_J2" )
        {
            score += OnDamage(vitesseCoup);
        }
    }

    private void Update()
    {
        if (PSMoveSabre1.isColliding)
        {
            if (timer > 1.0f)
            {
                PSMoveSabre1.isColliding = false;
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
