using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CollisionSabre1 : MonoBehaviour
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
            //PSMoveSabre1.isColliding = true;
        }
        else if (other.gameObject.name == "Characters_J2")
        {
            if (Player.decreaseStamina(Player.Joueur.P1, 20))
            {
                Player.updatePlayerScore(Player.Joueur.P1, 10); 
            }
            else
            {
                Debug.Log("Pas assez de stamina, attends un peu");
            }
        }
    }
}
