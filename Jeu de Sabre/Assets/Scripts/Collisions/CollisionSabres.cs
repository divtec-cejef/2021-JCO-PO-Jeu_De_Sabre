using System.Collections;
using Init;
using Players;
using UnityEngine;

namespace Collisions
{
    public class CollisionSabres : MonoBehaviour
    {
        [SerializeField] private GameObject collisionFx;
        
        private GameObject collision;

        public static bool _isPlayer1Stun;
        public static bool _isPlayer2Stun;
    
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
                StartCoroutine(StaminaCooldown(Player.PLAYER.P2));
            }
        
            // Si le joueur 2 est en parade, baisse de la stamina du joueur 1
            else if (GameInit.GetPlayer2KatanaOrientation().GetPlayerParade().GetParade())
            {
                Player.SetStamina(Player.PLAYER.P1, 0);
                StartCoroutine(StaminaCooldown(Player.PLAYER.P1));
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

        /// <summary>
        /// Ajoute un cooldown ?? la remont??e de l'endurance
        /// </summary>
        /// <param name="player">Le joueur affect?? par le cooldown</param>
        IEnumerator StaminaCooldown(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
            {
                // Bloque la r??g??n??ration de l'endurance
                Stamina.CanPlayer1Regen(false);
                // Indication que le joueur est paralys??
                _isPlayer1Stun = true;
                // Activation de l'effet d'??toile
                GameInit._player1StunEffect.gameObject.SetActive(true);
                // Attente en fonction des valeurs renseign??es dans le fichier de configuration
                yield return new WaitForSeconds(GameInit.GetGameConfig().parade_stun);
                GameInit._player1StunEffect.gameObject.SetActive(false);
                _isPlayer1Stun = false;
                Stamina.CanPlayer1Regen(true);
            }
            else
            {
                // Bloque la r??g??n??ration de l'endurance
                Stamina.CanPlayer2Regen(false);
                // Indication que le joueur est paralys??
                _isPlayer2Stun = true;
                // Activation de l'effet d'??toile
                GameInit._player2StunEffect.gameObject.SetActive(true);
                // Attente en fonction des valeurs renseign??es dans le fichier de configuration
                yield return new WaitForSeconds(GameInit.GetGameConfig().parade_stun);
                GameInit._player2StunEffect.gameObject.SetActive(false);
                _isPlayer2Stun = false;
                Stamina.CanPlayer2Regen(true);
            }
        }
    }
}
