using Init;
using Players;
using UnityEngine;

namespace Collisions
{
    public class CollisionSabres : MonoBehaviour
    {
        [SerializeField] private GameObject collisionFx;
        
        private GameObject collision;
    
        private void OnCollisionEnter(Collision other)
        {
            // Si la collision du sabre 1 n'est pas le sabre 2
            if (!other.collider.CompareTag("Katana2")) 
                return;

            // TODO mettre ca dans la parade et pas dans la gestio des collision
            if (!GameInit.GetPlayer1KatanaOrientation().GetPlayerParade().GetParade() &&
                !GameInit.GetPlayer2KatanaOrientation().GetPlayerParade().GetParade())
            {
                //Physics.IgnoreCollision(other.collider, katana_1.GetComponent<Collider>(), true);
                return;
            }
            
            // Si le joueur 1 est en parade, baisse de la stamina du joueur 2
            if (GameInit.GetPlayer1KatanaOrientation().GetPlayerParade().GetParade())
            {
                Player.SetStamina(Player.PLAYER.P2, 0);
            }
        
            // Si le joueur 2 est en parade, baisse de la stamina du joueur 1
            else if (GameInit.GetPlayer2KatanaOrientation().GetPlayerParade().GetParade())
            {
                Player.SetStamina(Player.PLAYER.P1, 0);
            }
        
            print("1 : " + GameInit.GetPlayer1KatanaOrientation().GetPlayerParade().GetParade() + ". 2 : " +
                  GameInit.GetPlayer2KatanaOrientation().GetPlayerParade().GetParade() + ".");
        
        
            // Affichage de l'effet de collision sur le point de contact
            var contact = other.contacts[0];
            var rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            var pos = contact.point;
            collision = Instantiate(collisionFx, pos, rot);
        
            // Vibration des manettes
            PSMoveUtils.SetVibration(Player.PLAYER.P1, 255);
            PSMoveUtils.SetVibration(Player.PLAYER.P2, 255);
            
            GameInit.GetSoundHandler().GetSoundCollision().Play();
        }

        private void OnCollisionExit(Collision other)
        {
            // Stoppe la vibration des manettes
            PSMoveUtils.SetVibration(Player.PLAYER.P1, 0); 
            PSMoveUtils.SetVibration(Player.PLAYER.P2, 0); 
            // Physics.IgnoreCollision(other.collider, katana_1.GetComponent<Collider>(), false);
        
            // Detruit l'effet de collision
            Destroy(collision, 0.2f);
        }
    }
}
