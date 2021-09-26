using System;
using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;

public class CollisionArene : MonoBehaviour
{
    [SerializeField] private Transform playerAxis;
    public static bool isTrigger = false;
    private const float limitationArena = 0.25f;
    
    private void OnTriggerExit(Collider other)
    {
        // Lors de la collision avec un des deux jouers
        if (!isTrigger)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                isTrigger = true;
            }
        }
    }

    private void Update()
    {
        // Lorsqu'une collisiion survient
        if (isTrigger)
        {
            // Replacement du joueur, déplacement jusqu'au centre
            if (playerAxis.localPosition.x < limitationArena && playerAxis.localPosition.x > -limitationArena &&
                playerAxis.localPosition.z < limitationArena && playerAxis.localPosition.z > -limitationArena)
            {
                isTrigger = false; 
            }
            else
                playerAxis.localPosition = Vector3.Lerp(playerAxis.localPosition, Vector3.zero, Time.deltaTime * 2f);
        }
    }
}