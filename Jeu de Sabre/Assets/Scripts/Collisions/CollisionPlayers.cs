using Init;
using Players;
using UnityEngine;

namespace Collisions
{
    public class CollisionPlayers : MonoBehaviour
    {
        [SerializeField] private GameObject player1Axis;
        
        [SerializeField] private GameObject player2Axis;

        [SerializeField] private GameObject player1Character;
        
        [SerializeField] private GameObject player1CharacterTransparent;
    
        [SerializeField] private GameObject player2Character;
        
        [SerializeField] private GameObject player2CharacterTransparent;

        // Le sabre du joueur 2 (Le sabre du joueur 1 est l'objet associé à ce script)
        [SerializeField]
        private GameObject player2KatanaObject;
    
        //private float timer = 0;
    
        private AttackMouvements attack;
    
        private void Awake()
        {
            // Initialisaiton de la classe chargée d'effectuer les mouvements des joueurs lors d'une attaque
            attack = new AttackMouvements(player1Axis, player2Axis, player1Character, player1CharacterTransparent, player2Character, player2CharacterTransparent);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Initialisation du joueur qui a effectuer l'attaque
            Player.PLAYER player = Player.PLAYER.Other;
        
            // Si le sabre du joueur 1 entre en collision avec autre chose que son propre joueur
            if (other.CompareTag("Katana1") && !gameObject.CompareTag("Player1"))
                player = Player.PLAYER.P1;
        
            // Si le sabre du joueur 2 entre en collision avec autre chose que son propre joueur
            else if (other.CompareTag("Katana2") && !gameObject.CompareTag("Player2"))
                player = Player.PLAYER.P2;
        
            // Si aucune condition n'est respectée et que player n'a pas été modifié, la collision n'est pas valable
            if (player == Player.PLAYER.Other) 
                return;
        
            // Si le joueur à assez d'endurance pour porter le coup
            if (Player.DecreaseStamina(player, GameInit.GetGameConfig().attack_stamina_decrease))
            {
                // Mise à jour du score du joueur
                Player.UpdatePlayerScore(player, GameInit.GetGameConfig().attack_score_amount);
            
                // Animations et mouvements de l'attaque
                attack.onAttack(player, player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1);
            
                // Le son TODO changer ca plus tard
                var position = new Vector3(11.9f, 11.0f, 15.6f);
                var rotation = new Quaternion(0, 0, 0, 0);
                Destroy(Instantiate(GameInit.GetSoundHandler().GetDamageSound(), position, rotation), 2.0f);
            }
            else
            {
                //Debug.Log("Pas assez de stamina, attends un peu");
            }
        }
    }
}
