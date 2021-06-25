using UnityEngine;

public class Katana_1 : MonoBehaviour
{
    
    private static KatanaOrientation KOrientation;
    private static bool isInitDone = false;
    public AnimationCurve plot = new AnimationCurve();



    public static void init()
    {
        KOrientation = GameInit.getKatanaPlayer1();
        isInitDone = true;
    }
    
    private void Update()
    {
        if (isInitDone)
        {
            KOrientation.onUpdate();
            plot.AddKey(Time.realtimeSinceStartup, KOrientation.getY());
        }
    }

    private void FixedUpdate()
    {
        if (isInitDone)
        {
            KOrientation.onFixedUpdate();
        }
    }
}
