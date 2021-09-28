using Init;
using Players;
using UnityEngine;

namespace Mouvements.Orientation
{
    public class Katana1 : MonoBehaviour
    {
        private static KatanaOrientation player1KatanaOrientation;
        private static bool isInitDone = false;
    
        /// <summary>
        /// Initialisation de l'orientation du sabre 1
        /// </summary>
        public static void Init()
        {
            player1KatanaOrientation = GameInit.GetPlayer1KatanaOrientation();
            isInitDone = true;
        }
    
        private void Update()
        {
            // Ne rien faire tant que l'initialisation n'est pas terminé
            if (!isInitDone) 
                return;
        
            if (player1KatanaOrientation.GetPlayerParade().GetReady())
            {
                // A l'activation de la parade
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (!player1KatanaOrientation.GetPlayerParade().GetParade())
                    {
                        player1KatanaOrientation.GetPlayerParade().OnParadeEnabled();
                    }
                }
            }
            
            // Au relachement de la parade
            if (Input.GetKeyUp(KeyCode.Q) && player1KatanaOrientation.GetPlayerParade().GetParade())
            {
                Stamina.CanPlayer1Regen(true);
                player1KatanaOrientation.GetPlayerParade().SetParade(false);
            } 
        
            player1KatanaOrientation.onUpdate();
            //plot.AddKey(Time.realtimeSinceStartup, KOrientation.getY());
        }
    }
}
