using System;
using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;

public class CollisionArene : MonoBehaviour
{
    [SerializeField] private Transform playerAxis;
    public static bool isTrigger = false;

    private void OnTriggerExit(Collider other)
    {
        if (!isTrigger)
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {

                isTrigger = true;
                Debug.Log("isTrigger : " + isTrigger);

            }
        }
    }

    private void Update()
    {
        if (isTrigger)
        {
            //Teste si il est toujour dans l'arène    
            if (playerAxis.localPosition.x < 0.25 && playerAxis.localPosition.x > -0.25f &&
                playerAxis.localPosition.z < 0.25f && playerAxis.localPosition.z > -0.25f)
                isTrigger = false;
            else
                playerAxis.localPosition = Vector3.Lerp(playerAxis.localPosition, Vector3.zero, Time.deltaTime * 10f);
        }
    }
}