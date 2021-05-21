using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Collision : MonoBehaviour
{
    public GameObject FX;
   
    
    private void OnCollisionEnter(Collision collision)
    {
        PSMoveAPI.psmove_set_rumble(TestConnection.manette_1, 250);
        PSMoveAPI.psmove_set_rumble(TestConnection.manette_2, 250);
        invokeParticleEffect();
    }

    private void OnCollisionExit(Collision other)
    {
        PSMoveAPI.psmove_set_rumble(TestConnection.manette_1, 0);
        PSMoveAPI.psmove_set_rumble(TestConnection.manette_2, 0);
    }

    void invokeParticleEffect()
    {
        GameObject effect =  (GameObject) Instantiate(FX, transform.position, FX.transform.rotation);
        Destroy(effect, 2f);
    }
}
