using UnityEngine;

public class Katana_1 : MonoBehaviour
{
    
    private static KatanaOrientation KOrientation;
    private static bool isInitDone = false;

    public static void init()
    {
        KOrientation = GameInit.getKatanaPlayer1();
        isInitDone = true;
    }
    
    private void Update()
    {
        if(isInitDone)
            KOrientation.onUpdate();
    }

    private void FixedUpdate()
    {
        if (isInitDone)
            KOrientation.onFixedUpdate();
    }
}
