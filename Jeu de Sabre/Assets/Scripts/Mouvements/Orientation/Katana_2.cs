using UnityEngine;

public class Katana_2 : MonoBehaviour
{
    private static KatanaOrientation KOrientation;
    private static bool isInitDone = false;
    public AnimationCurve plot = new AnimationCurve();

    public static void init()
    {
        KOrientation = GameInit.getKatanaPlayer2();
        isInitDone = true;
    }
    
    private void Update()
    {
        if (isInitDone)
        {
            KOrientation.onUpdate();

            plot.AddKey(Time.realtimeSinceStartup, KOrientation.getY());

            print(KOrientation.getParade().getParade());
        }
            
    }
}
