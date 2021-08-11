using Init;
using UnityEngine;

namespace Mouvements.Orientation
{
    public class Katana2 : MonoBehaviour
    {
        private static KatanaOrientation KOrientation;
        private static bool isInitDone = false;
        public AnimationCurve plot = new AnimationCurve();

        /// <summary>
        /// Initialisation de l'orientation du sabre 2
        /// </summary>
        public static void Init()
        {
            KOrientation = GameInit.getKatanaPlayer2();
            isInitDone = true;
        }
    
        private void Update()
        {
            // Lorsque l'initialisation est terminée, mise à jour de l'orientation du sabre
            if (!isInitDone)
                return;
        
            KOrientation.onUpdate();

            //plot.AddKey(Time.realtimeSinceStartup, KOrientation.getY());
        }
    }
}
