using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CollisionSabre1 : MonoBehaviour
{
    
    public GameObject Player1Axis;
    
    public GameObject Player2Axis;
    
    public GameObject Player1Char;
    public GameObject Player1Trans;
    
    public GameObject Player2Char;
    public GameObject Player2Trans;
    
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
        }
        else if (other.gameObject.name == "Characters_J2")
        {
            if (Player.decreaseStamina(Player.Joueur.P1, 20))
            {
                Player.updatePlayerScore(Player.Joueur.P1, 10);
                attaque.onAttack(Player.Joueur.P1);
            }
            else
            {
                Debug.Log("Pas assez de stamina, attends un peu");
            }
        }
    }
}
