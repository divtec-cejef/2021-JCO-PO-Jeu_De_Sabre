using Init;
using UnityEngine;

namespace Collisions
{
    public class CollisionSabres : MonoBehaviour
    {
        public GameObject collisionFx;
        private GameObject collision;
        //public GameObject katana_1;
    
        private void OnCollisionEnter(Collision other)
        {
            // Si la collision du sabre 1 n'est pas le sabre 2
            if (!other.collider.CompareTag("Katana2")) 
                return;

            // TODO mettre ca dans la parade et pas dans la gestio des collision
            if (!GameInit.getKatanaPlayer1().getParade().getParade() &&
                !GameInit.getKatanaPlayer2().getParade().getParade())
            {
                //Physics.IgnoreCollision(other.collider, katana_1.GetComponent<Collider>(), true);
                return;
            }
        
        
            // Si le joueur 1 est en parade, baisse de la stamina du joueur 2
            if (GameInit.getKatanaPlayer1().getParade().getParade())
            {
                Player.setStamina(Player.Joueur.P2, 0);
            }
        
            // Si le joueur 2 est en parade, baisse de la stamina du joueur 1
            else if (GameInit.getKatanaPlayer2().getParade().getParade())
            {
                Player.setStamina(Player.Joueur.P1, 0);
            }
        
            // TODO si ils sont les deux en parade bah c'est celui qui y est depuis le moins de temps qui gagne je pense

            print("1 : " + GameInit.getKatanaPlayer1().getParade().getParade() + ". 2 : " +
                  GameInit.getKatanaPlayer2().getParade().getParade() + ".");
        
        
            // Affichage de l'effet de collision sur le point de contact
            var contact = other.contacts[0];
            var rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            var pos = contact.point;
            collision = Instantiate(collisionFx, pos, rot);
        
            // Vibration des manettes
            PSMoveUtils.setVibration(Player.Joueur.P1, 255);
            PSMoveUtils.setVibration(Player.Joueur.P2, 255);
        }

        private void OnCollisionExit(Collision other)
        {
            // Stoppe la vibration des manettes
            PSMoveUtils.setVibration(Player.Joueur.P1, 0); PSMoveUtils.setVibration(Player.Joueur.P2, 0); 
            // Physics.IgnoreCollision(other.collider, katana_1.GetComponent<Collider>(), false);
        
            // Detruit l'effet de collision
            Destroy(collision, 0.2f);
        }
    }
}
