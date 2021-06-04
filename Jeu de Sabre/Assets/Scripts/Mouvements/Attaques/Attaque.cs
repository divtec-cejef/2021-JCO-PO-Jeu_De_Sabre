using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Attaque : MonoBehaviour
{

    public GameObject Player1;
    
    public GameObject Player2;
    float move;
    float move2;

    public bool isAttacking;
    private bool isDefending = false;

    private PSMoveActions actions;
    
    private void Awake()
    {
        actions = new PSMoveActions();
        actions.Buttons.attak.performed += ctx => move = ctx.ReadValue<float>();
        actions.Buttons.attak.canceled += crx => move = 0;
        
        actions.Buttons.recul.performed += ctx => move2 = ctx.ReadValue<float>();
        actions.Buttons.recul.canceled += crx => move2 = 0;
    }

    public void onAttaque(Player.Joueur agresseur)
    {

    }
    
    

    private void OnEnable()
    {
        actions.Buttons.Enable();
    }

    private void OnDisable()
    {
        actions.Buttons.Disable();
    }

    private void Update()
    {
        Player1.transform.position = Vector3.Lerp(Player1.transform.position, new Vector3(Player1.transform.position.x, Player1.transform.position.y, Player1.transform.position.z + move * 1.5f), 0.5f*Time.deltaTime);
        Player1.transform.position = Vector3.Lerp(Player1.transform.position, new Vector3(Player1.transform.position.x, Player1.transform.position.y, Player1.transform.position.z - move2 * 1.5f), 0.5f*Time.deltaTime);

        
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
