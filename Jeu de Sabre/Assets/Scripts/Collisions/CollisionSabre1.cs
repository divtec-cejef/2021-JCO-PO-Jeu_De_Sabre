using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CollisionSabre1 : MonoBehaviour
{
    
    public GameObject Player1Axis;
    
    public GameObject Player2Axis;
    
    public GameObject Player1Char;
    public GameObject Player1Trans;
    
    public GameObject Player2Char;
    public GameObject Player2Trans;

    public GameObject sabre;
    public Text text_J1;

    private float timer = 0;
    
    //Récuperer la vitesse du sabre et definir les damages en consequences
    public int OnDamage(float speed)
    {
        return 1;
    }

    private Attaque attaque;
    
    private void Awake()
    {

        attaque = new Attaque(Player1Axis, Player2Axis, Player1Char, Player1Trans, Player2Char, Player2Trans);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SM_Wep_Odachi_01")
        {
            //PSMoveSabre1.isColliding = true;
            //sabre.transform.rotation = Quaternion.Lerp(sabre.transform.rotation, PSMoveSabre1.lastQuaternion, 0.5f);

        }
        else if (other.gameObject.name == "Characters_J2")
        {
            if (Player.decreaseStamina(Player.Joueur.P1, 20))
            {
                Player.updatePlayerScore(Player.Joueur.P1, 10, text_J1);
                attaque.onAttack(Player.Joueur.P1);
            }
            else
            {
                Debug.Log("Pas assez de stamina, attends un peu");
            }
        }
    }

    private void Update()
    {
       /* if (!PSMoveSabre1.isColliding) return;
        
        if (timer > 3.0f)
        {
            timer = 0;
            PSMoveSabre1.isColliding = false;
            
        }
        else
        {
            timer += Time.deltaTime;
        }*/
    }
}
