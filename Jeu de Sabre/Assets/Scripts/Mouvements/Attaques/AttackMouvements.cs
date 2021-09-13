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

    public void onAttack(Player.PLAYER attacker, Player.PLAYER defender, CollisionPlayers.TYPE_ATTACK attack)
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

        // if (attacker == Player.Joueur.P1)
        // {
        //     anime1 = Player1Char.GetComponent<Animator>();
        //     anime1Trans = Player1Trans.GetComponent<Animator>();
        //     anime1.SetTrigger("isAttacking");
        //     anime1Trans.SetTrigger("isAttacking");
        //     
        //     anime2 = Player2Char.GetComponent<Animator>();
        //     anime2Trans = Player2Trans.GetComponent<Animator>();
        //     anime2.SetTrigger("isHit");
        //     anime2Trans.SetTrigger("isHit");
        // }
        // else
        // {
        //     
        // }
    }

    public void disableAttack()
    {
        Animator animeP1 = Player1Char.GetComponent<Animator>();
        Animator animeP1Trans = Player1Trans.GetComponent<Animator>();
        Animator animeP2 = Player2Char.GetComponent<Animator>();
        Animator animeP2Trans = Player2Trans.GetComponent<Animator>();;
        
        animeP1.SetBool("isSlideWalkRight", false);
        animeP1Trans.SetBool("isSlideWalkRight", true);
        animeP2.SetBool("isSlideWalkRight", false);
        animeP2Trans.SetBool("isSlideWalkRight", false);
      
        animeP1.SetBool("isSlideWalkLeft", false);
        animeP1Trans.SetBool("isSlideWalkLeft", false);
        animeP2.SetBool("isSlideWalkLeft", false);
        animeP2Trans.SetBool("isSlideWalkLeft", false);
     
        animeP1.SetBool("isMoveBack", false);
        animeP1Trans.SetBool("isMoveBack", false);
        animeP1.SetBool("isMoveBack", false);
        animeP1Trans.SetBool("isMoveBack", false);
        
        animeP1.SetBool("isNormalWalk", false);
        animeP1Trans.SetBool("isNormalWalk", false);
        animeP2.SetBool("isNormalWalk", false);
        animeP2Trans.SetBool("isNormalWalk", false);
    }

    private void typeAttack(CollisionPlayers.TYPE_ATTACK attack, Animator animeDefender, Animator animeDefenderTrans,
        Animator animeAttacker, Animator animeAttackerTrans)
    {
        switch (attack)
            {
                case CollisionPlayers.TYPE_ATTACK.RIGHT:
                    animeDefender.SetBool("isSlideWalkRight", true);
                    animeDefenderTrans.SetBool("isSlideWalkRight", true);

                    animeAttacker.SetBool("isSlideWalkRight", true);
                    animeAttackerTrans.SetBool("isSlideWalkRight", true);
                    break;
                
                case CollisionPlayers.TYPE_ATTACK.LEFT:
                    animeDefender.SetBool("isSlideWalkLeft", true);
                    animeDefenderTrans.SetBool("isSlideWalkLeft", true);

                    animeAttacker.SetBool("isSlideWalkLeft", true);
                    animeAttackerTrans.SetBool("isSlideWalkLeft", true);
                    break;
                
                case CollisionPlayers.TYPE_ATTACK.CENTER:
                    animeDefender.SetBool("isMoveBack", true);
                    animeDefenderTrans.SetBool("isMoveBack", true);

                    animeAttacker.SetBool("isNormalWalk", true);
                    animeAttackerTrans.SetBool("isNormalWalk", true);
                    break;
            }
        }

        //private void Update()
        //{
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
        //}
    }
