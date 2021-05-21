using System;
using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class FX_Collision : MonoBehaviour
{
    
    public GameObject FX;
   
    
    private void OnCollisionEnter(Collision collision)
    {
        PSMoveAPI.psmove_set_rumble(TestConnection.handle, 250);
        invokeParticleEffect();
    }

    private void OnCollisionExit(Collision other)
    {
        PSMoveAPI.psmove_set_rumble(TestConnection.handle, 0);
    }

    void invokeParticleEffect()
    {
        GameObject effect =  (GameObject) Instantiate(FX, transform.position, FX.transform.rotation);
        Destroy(effect, 2f);
    }
    

}