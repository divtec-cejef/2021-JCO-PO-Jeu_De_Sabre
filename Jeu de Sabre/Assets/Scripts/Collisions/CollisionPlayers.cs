using Init;
using UnityEngine;

namespace Collisions
{
    public class CollisionPlayers : MonoBehaviour
    {
        public GameObject Player1Axis;
        public GameObject Player2Axis;
    
        public GameObject Player1Char;
        public GameObject Player1Trans;
    
        public GameObject Player2Char;
        public GameObject Player2Trans;

        public GameObject katana;
    
        private float timer = 0;
    
        private AttackMouvements attack;
    
        private void Awake()
        {
            // Initialisaiton de la classe chargée d'effectuer les mouvements des joueurs lors d'une attaque
            attack = new AttackMouvements(Player1Axis, Player2Axis, Player1Char, Player1Trans, Player2Char, Player2Trans);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Initialisation du joueur qui a effectuer l'attaque
            Player.Joueur player = Player.Joueur.Other;
        
            // Si le sabre du joueur 1 entre en collision avec autre chose que son propre joueur
            if (other.CompareTag("Katana1") && !gameObject.CompareTag("Player1"))
                player = Player.Joueur.P1;
        
            // Si le sabre du joueur 2 entre en collision avec autre chose que son propre joueur
            else if (other.CompareTag("Katana2") && !gameObject.CompareTag("Player2"))
                player = Player.Joueur.P2;
        
            // Si aucune condition n'est respectée et que player n'a pas été modifié, la collision n'est pas valable
            if (player == Player.Joueur.Other) 
                return;
        
            // Si le joueur à assez d'endurance pour porter le coup
            if (Player.decreaseStamina(player, GameInit.getGameConfig().attack_stamina_decrease))
            {
                // Mise à jour du score du joueur
                Player.updatePlayerScore(player, GameInit.getGameConfig().attack_score_amount);
            
                // Animations et mouvements de l'attaque
                attack.onAttack(player, player == Player.Joueur.P1 ? Player.Joueur.P2 : Player.Joueur.P1);
            
                // Le son TODO changer ca plus tard
                var position = new Vector3(11.9f, 11.0f, 15.6f);
                var rotation = new Quaternion(0, 0, 0, 0);
                Destroy(Instantiate(GameInit.getSoundHandler().getDamangeSound(), position, rotation), 2.0f);
            }
            else
            {
                //Debug.Log("Pas assez de stamina, attends un peu");
            }

        
        }
    }
}
