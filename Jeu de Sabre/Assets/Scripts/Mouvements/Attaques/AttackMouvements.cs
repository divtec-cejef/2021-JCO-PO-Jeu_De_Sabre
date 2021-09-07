using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Collisions;
using Init;
using Players;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class AttackMouvements
{

    private GameObject Player1Axis;
    
    private GameObject Player2Axis;


    private GameObject Player1Char;
    private GameObject Player1Trans;
    private GameObject Player2Char;
    private GameObject Player2Trans;
    

    private Animator animeP1;
    private Animator animeP1Trans;
    private Animator animeP2;
    private Animator animeP2Trans;


    public AttackMouvements(GameObject P1A, GameObject P2A, GameObject P1C, GameObject P1T, GameObject P2C, GameObject P2T)
    {
        Player1Axis = P1A;
        Player2Axis = P2A;
        Player1Char = P1C;
        Player1Trans = P1T;
        Player2Char = P2C;
        Player2Trans = P2T;
    }

    public void onAttack(Player.PLAYER defender, Player.PLAYER attacker,CollisionPlayers.TYPE_ATTACK attack)
    {
        GameInit.GetCameraShaking().ShakeCamera(attacker, 1.0f, .1f);
        GameInit.GetCameraShaking().ShakeCamera(defender, 1.0f, .3f);
        
        animeP1 = Player1Char.GetComponent<Animator>();
        animeP1Trans = Player1Trans.GetComponent<Animator>();
        animeP2 = Player2Char.GetComponent<Animator>();
       animeP2Trans = Player2Trans.GetComponent<Animator>();

        if (defender == Player.PLAYER.P1) 
            typeAttack(attack, animeP1, animeP1Trans,animeP2, animeP2Trans);
        
        else if(defender == Player.PLAYER.P2) 
            typeAttack(attack, animeP2, animeP2Trans,animeP1, animeP1Trans);

    }

    private void typeAttack(CollisionPlayers.TYPE_ATTACK attack, Animator animeDefender,Animator animeDefenderTrans ,
        Animator animeAttacker, Animator animeAttackerTrans)
    {
        switch (attack)
        {
            case CollisionPlayers.TYPE_ATTACK.RIGHT:
                animeDefender.SetTrigger("isSlideWalkRight");
                animeDefenderTrans.SetTrigger("isSlideWalkRight");
                
                animeAttacker.SetTrigger("isSlideWalkRight");
                animeAttackerTrans.SetTrigger("isSlideWalkRight");
                break;
            case CollisionPlayers.TYPE_ATTACK.LEFT:
                animeDefender.SetTrigger("isSlideWalkLeft");
                animeDefenderTrans.SetTrigger("isSlideWalkLeft");
                    
                animeAttacker.SetTrigger("isSlideWalkLeft");
                animeAttackerTrans.SetTrigger("isSlideWalkLeft");
                break;
            case CollisionPlayers.TYPE_ATTACK.CENTER:
                animeDefender.SetTrigger("isNormalWalk");
                animeDefenderTrans.SetTrigger("isNormalWalk");
                    
                animeAttacker.SetTrigger("isMoveBack");
                animeAttackerTrans.SetTrigger("isMoveBack");
                break;
        }
    }
    

    private void Update()
    {
        //Player1.transform.position = Vector3.Lerp(Player1.transform.position, new Vector3(Player1.transform.position.x, Player1.transform.position.y, Player1.transform.position.z + move * 1.5f), 0.5f*Time.deltaTime);
        //Player1.transform.position = Vector3.Lerp(Player1.transform.position, new Vector3(Player1.transform.position.x, Player1.transform.position.y, Player1.transform.position.z - move2 * 1.5f), 0.5f*Time.deltaTime);
        
    
        
        //anim.SetBool("isRunning", move != 0);


        // Quaternion.Lerp( )
        
    // if (isAttacking)
    // {
    //
    //     if (timer1 < 0.2f && !isDefending)
    //     {
    //         isDefending = true;
    //     }
    //     else if (timer1 > 0)
    //     {
    //         Player1.transform.Translate(new Vector3(0,0,0.05f));
    //         timer1 -= Time.deltaTime;
    //     }
    //     else
    //     {
    //         isAttacking = false;
    //     }
    // }
    //
    // if (isDefending)
    // {
    //     if (timer2 > 0)
    //     {
    //         Player2.transform.Translate(new Vector3(0,0,0.05f));
    //         timer2 -= Time.deltaTime;
    //     }
    // }
    }
}
