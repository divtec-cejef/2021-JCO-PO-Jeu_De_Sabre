using Init;
using Players;
using UnityEngine;

namespace Mouvements.Orientation
{
    public class Katana2 : MonoBehaviour
    {
        private static KatanaOrientation player2KatanaOrientation;
        private static bool isInitDone = false;

        /// <summary>
        /// Initialisation de l'orientation du sabre 2
        /// </summary>
        public static void Init()
        {
            player2KatanaOrientation = GameInit.GetPlayer2KatanaOrientation();
            isInitDone = true;
        }
    
        private void Update()
        {
            // Ne rien faire tant que l'initialisation n'est pas terminé
            if (!isInitDone) 
                return;
            
            if (player2KatanaOrientation.GetPlayerParade().GetReady())
            {
                // A l'activation de la parade
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (!player2KatanaOrientation.GetPlayerParade().GetParade())
                    {
                        player2KatanaOrientation.GetPlayerParade().OnParadeEnabled();
                    }
                }
            }
            
            // Au relachement de la parade
            if (Input.GetKeyUp(KeyCode.W) && player2KatanaOrientation.GetPlayerParade().GetParade())
            {
                Stamina.CanPlayer2Regen(true);
                player2KatanaOrientation.GetPlayerParade().SetParade(false);
            } 
            
            player2KatanaOrientation.onUpdate();
            //plot.AddKey(Time.realtimeSinceStartup, KOrientation.getY());
        }
    }
}
