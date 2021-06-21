using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSabres : MonoBehaviour
{
    public GameObject collisionFx;
    private GameObject collision;
    public GameObject katana_1;
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Katana2")) 
            return;

        if (!GameInit.getKatanaPlayer1().getParade().getParade() &&
            !GameInit.getKatanaPlayer2().getParade().getParade())
        {
            Physics.IgnoreCollision(other.collider, katana_1.GetComponent<Collider>(), true);
            return;
        }
        
        if (GameInit.getKatanaPlayer1().getParade().getParade())
        {
            Player.setStamina(Player.Joueur.P2, 0);
        }
        else if (GameInit.getKatanaPlayer2().getParade().getParade())
        {
            Player.setStamina(Player.Joueur.P1, 0);
        }

        print("1 : " + GameInit.getKatanaPlayer1().getParade().getParade() + ". 2 : " +
              GameInit.getKatanaPlayer2().getParade().getParade() + ".");
        
        
        
        
        var contact = other.contacts[0];
        var rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        var pos = contact.point;
        collision = Instantiate(collisionFx, pos, rot);
        
        PSMoveUtils.setVibration(Player.Joueur.P1, 255);
        PSMoveUtils.setVibration(Player.Joueur.P2, 255);
    }

    private void OnCollisionExit(Collision other)
    {
        PSMoveUtils.setVibration(Player.Joueur.P1, 0);
        PSMoveUtils.setVibration(Player.Joueur.P2, 0);
       // Physics.IgnoreCollision(other.collider, katana_1.GetComponent<Collider>(), false);

        Destroy(collision, 0.2f);
    }
}
