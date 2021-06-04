using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Collision : MonoBehaviour
{
    public GameObject FX_Player;
    public GameObject FX_Katana;
    


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "SM_Wep_Odachi_01")
        {
            invokeParticleEffect(FX_Katana);
        }
        else if (collision.gameObject.name == "Characters_J2")
        {
            invokeParticleEffect(FX_Player);
        } else if (collision.gameObject.name != "Characters_J1")
        {
            PSMoveAPI.psmove_set_rumble(TestConnection.manette_1, 250);
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        PSMoveAPI.psmove_set_rumble(TestConnection.manette_1, 0);
        PSMoveAPI.psmove_set_rumble(TestConnection.manette_2, 0);
    }

    void invokeParticleEffect(GameObject Arc_En_Ciel)
    {
        GameObject effect =  (GameObject) Instantiate(Arc_En_Ciel, transform.position, Arc_En_Ciel.transform.rotation);
        Destroy(effect, 2f);
    }
}
