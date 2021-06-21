using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class CollisionPlayers : MonoBehaviour
{
    
    public GameObject Player1Axis;
    
    public GameObject Player2Axis;
    
    public GameObject Player1Char;
    public GameObject Player1Trans;
    
    public GameObject Player2Char;
    public GameObject Player2Trans;

    public GameObject katana;
    
    private float timer = 0;
   

    private Attaque attaque;
    
    private void Awake()
    {
        attaque = new Attaque(Player1Axis, Player2Axis, Player1Char, Player1Trans, Player2Char, Player2Trans);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player.Joueur player = Player.Joueur.Other;
        
        if (other.CompareTag("Katana1"))
        {
            player = Player.Joueur.P1;
        }
        else if (other.CompareTag("Katana2"))
        {
            player = Player.Joueur.P2;
        }

        if (player == Player.Joueur.Other) 
            return;
        
        if (Player.decreaseStamina(player, 20))
        {
            Player.updatePlayerScore(player, 70);
            attaque.onAttack(player);

        }
        else
        {
            //Debug.Log("Pas assez de stamina, attends un peu");
        }

        var position = new Vector3(11.9f, 11.0f, 15.6f);
        var rotation = new Quaternion(0, 0, 0, 0);
        Destroy(Instantiate(GameInit.getSoundHandler().getDamangeSound(), position, rotation), 2.0f);
    }
}
