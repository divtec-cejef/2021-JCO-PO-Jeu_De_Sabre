using System;
using Init;
using Players;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Collisions
{
    public class CollisionPlayers : MonoBehaviour
    {
        [SerializeField] private GameObject player1Axis;
        
        [SerializeField] private GameObject player2Axis;

        [SerializeField] private GameObject player1Character;
        
        [SerializeField] private GameObject player1CharacterTransparent;
        
        [SerializeField] private Transform player1LeftCollisionCheck;
        
        [SerializeField] private Transform player2LeftCollisionCheck;
        
        [SerializeField] private Transform player1RightCollisionCheck;
        
        [SerializeField] private Transform player2RightCollisionCheck;

        [SerializeField] private LayerMask sabre1;
        
        [SerializeField] private LayerMask sabre2;
        
        [SerializeField] private GameObject player2Character;
        
        [SerializeField] private GameObject player2CharacterTransparent;

        [SerializeField] private GameObject player1Face;
        
        [SerializeField] private GameObject player2Face;

        public static GameObject _player1Face;
        public static GameObject _player2Face;

        [SerializeField] private bool updateRotation;
        
        [SerializeField] private bool updateEmote;

        // Le sabre du joueur 2 (Le sabre du joueur 1 est l'objet associé à ce script)
        [SerializeField] private GameObject player2KatanaObject;
        
        private static float roteTimer = 0f;
        private static float backTimer = 0f;
        private static bool isColliding;
    
        //private float timer = 0;
    
        private AttackMouvements attack;
    
        private void Awake()
        {
            _player1Face = player1Face;
            _player2Face = player2Face;
            
            // Initialisaiton de la classe chargée d'effectuer les mouvements des joueurs lors d'une attaque
            attack = new AttackMouvements(player1Axis, player2Axis, player1Character, player1CharacterTransparent, player2Character, player2CharacterTransparent);
        }


        private void Update()
        {
            if (!updateRotation) return;

            float rotationTime = Random.Range(.05f, .25f);
            float rotationAngle = Random.Range(100, 200);
            bool backwardMouvement = Random.Range(0, 2) == 0;
            float backwardTime = Random.Range(.02f, .1f);
            float backwardDistance = Random.Range(1, 10);
            
            var position = player1LeftCollisionCheck.position;
            Vector3 player1StartLeft = new Vector3(position.x, position.y - 1.1f, position.z);
            Vector3 player1EndLeft = new Vector3(position.x, position.y + 1.1f, position.z);
            bool isPlayer1Left = Physics.CheckCapsule(player1StartLeft, player1EndLeft, 0.1f, sabre2);

            if (isPlayer1Left && roteTimer == 0 && !isColliding)
            {
                Travelling.anglesToRotate = new Vector3(0, -rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, -backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
            }

            var position1 = player1RightCollisionCheck.position;
            Vector3 player1StatRight = new Vector3(position1.x, position1.y - 1.1f, position1.z);
            Vector3 player1EndRight = new Vector3(position1.x, position1.y + 1.1f, position1.z);
            bool isPlayer1Right = Physics.CheckCapsule(player1StatRight, player1EndRight, 0.1f, sabre2);

            if (isPlayer1Right && roteTimer == 0 && !isColliding)
            {
                Travelling.anglesToRotate = new Vector3(0, +rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, -backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
            }

            var position2 = player2LeftCollisionCheck.position;
            Vector3 player2StartLeft = new Vector3(position2.x, position2.y - 1.1f, position2.z);
            Vector3 player2EndLeft = new Vector3(position2.x, position2.y + 1.1f, position2.z);
            bool isPlayer2Left = Physics.CheckCapsule(player2StartLeft, player2EndLeft, 0.1f, sabre1);

            if (isPlayer2Left && roteTimer == 0 && !isColliding)
            {
                Travelling.anglesToRotate = new Vector3(0, -rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
            }

            var position3 = player2RightCollisionCheck.position;
            Vector3 player2StartRight = new Vector3(position3.x, position3.y - 1.1f, position3.z);
            Vector3 player2EndRight = new Vector3(position3.x, position3.y + 1.1f, position3.z);
            bool isPlayer2Right = Physics.CheckCapsule(player2StartRight, player2EndRight, 0.1f, sabre1);

            if (isPlayer2Right && roteTimer == 0 && !isColliding)
            {
                Travelling.anglesToRotate = new Vector3(0, +rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
            }
            
            if (roteTimer != 0f)
            {
                isColliding = true;
                roteTimer += Time.deltaTime;
                if (roteTimer > rotationTime)
                {
                    isColliding = false;
                    roteTimer = 0f;
                    Travelling.anglesToRotate = Vector3.zero;
                }
            }
            if (backTimer != 0f)
            {
                backTimer += Time.deltaTime;
                if (backTimer > rotationTime)
                {
                    backTimer = 0f;
                    Travelling.distanceToMove = Vector3.zero;
                }
            }
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

                if(updateEmote){
                    if (player == Player.PLAYER.P1)
                    {
                        player1Face.GetComponent<Renderer>().material =
                            GameInit.GetEmoteHandler(Player.PLAYER.P1).GetRandomEmote(EmoteHandler.EMOTE_TYPE.HURT, player1Face, 1f,true);
                    }
                    else
                    {
                        player2Face.GetComponent<Renderer>().material =
                            GameInit.GetEmoteHandler(Player.PLAYER.P2).GetRandomEmote(EmoteHandler.EMOTE_TYPE.HURT, player2Face, 1f,true);
                    }
                }
                
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
