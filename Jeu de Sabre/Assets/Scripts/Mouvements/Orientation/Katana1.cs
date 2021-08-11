using Init;
using UnityEngine;

namespace Mouvements.Orientation
{
    public class Katana1 : MonoBehaviour
    {
        private static KatanaOrientation KOrientation;
        private static bool isInitDone = false;
        public AnimationCurve plot = new AnimationCurve();
    
        /// <summary>
        /// Initialisation de l'orientation du sabre 1
        /// </summary>
        public static void Init()
        {
            KOrientation = GameInit.getKatanaPlayer1();
            isInitDone = true;
        }
    
        private void Update()
        {
            // Ne rien faire tant que l'initialisation n'est pas terminé
            if (!isInitDone) 
                return;
            
            // A l'activation de la parade
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!KOrientation.getParade().getParade())
                {
                    KOrientation.getParade().OnParadeEnabled();
                } 
            }

            // Au maintient de la parade
            // if (Input.GetKey(KeyCode.Q))
            // {
            //     print("PARADE");
            // }
            
            
            // Au relachement de la parade
            if (Input.GetKeyUp(KeyCode.Q))
            {
                KOrientation.getParade().setParade(false);
            }
            
            KOrientation.onUpdate();
            //plot.AddKey(Time.realtimeSinceStartup, KOrientation.getY());
        }

        // TODO ca c'est pour les déplacements au clavier mais ca va dégager
        private void FixedUpdate()
        {
            if (isInitDone)
            {
                KOrientation.onFixedUpdate();
            }
        }
    }
}
