using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana_2 : MonoBehaviour
{
    private static KatanaOrientation KOrientation;
    private static bool isInitDone = false;

    public static void init()
    {
        KOrientation = GameInit.getKatanaPlayer2();
        isInitDone = true;
    }
    
    private void Update()
    {
        if(isInitDone)
            KOrientation.onUpdate();
    }
}
