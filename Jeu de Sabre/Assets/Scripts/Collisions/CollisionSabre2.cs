using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSabre2 : MonoBehaviour
{
    //Récuperer la vitesse du sabre et definir les damages en consequences
    public int OnDamage(float speed)
    {
        return 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SM_Wep_Odachi_01")
        {
            //PSMoveSabre2.isColliding = true;
        }
        else if (other.gameObject.name == "Characters_J1")
        {
            //Player.updatePlayerScore(Player.Joueur.P2, 10);
        }
    }
}
