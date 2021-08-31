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
        if (isTrigger)
        {
            //Teste si il est toujours dans l'arène
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