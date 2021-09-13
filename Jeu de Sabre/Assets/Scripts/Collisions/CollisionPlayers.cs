using System;
using Init;
using Mouvements.Orientation;
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

        
        private bool isPlayer1Left = false;
        private bool isPlayer1Center = false;
        private bool isPlayer1Right = false;
        private bool isFirstCollisionOfP1 = false;
        
        private bool isPlayer2Left = false;
        private bool isPlayer2Center = false;
        private bool isPlayer2Right = false;
        private bool isFirstCollisionOfP2 = false;
    
    
        public static bool timerEnd = false;


        public static bool canAttack;
        
        public enum TYPE_ATTACK
        {
            RIGHT,
            LEFT,
            CENTER
        }

        private TYPE_ATTACK currentAttack = TYPE_ATTACK.CENTER;
        
        private void Awake()
        {
            canAttack = false;
            _player1Face = player1Face;
            _player2Face = player2Face;
            
            // Initialisaiton de la classe chargée d'effectuer les mouvements des joueurs lors d'une attaque
            attack = new AttackMouvements(player1Axis, player2Axis, player1Character, player1CharacterTransparent, player2Character, player2CharacterTransparent);
        }


        private void Update()
        {
            if (!updateRotation) return;
            //if (!canAttack) return;

            //Valeur aléatoire
            float rotationTime  = Random.Range(.05f, .25f);;
            float rotationAngle  = Random.Range(100, 200);
            bool backwardMouvement = Random.Range(0, 2) == 0;
            float backwardTime  = Random.Range(.02f, .1f);
            float backwardDistance  = Random.Range(1, 10);

            //Joueur 1 côté gauche
            var positionP1Left = player1LeftCollisionCheck.position;
            Vector3 player1StartLeft = new Vector3(positionP1Left.x, positionP1Left.y - 1.1f, positionP1Left.z);
            Vector3 player1EndLeft = new Vector3(positionP1Left.x, positionP1Left.y + 1.1f, positionP1Left.z);
            isPlayer1Left = Physics.CheckCapsule(player1StartLeft, player1EndLeft, 0.1f, sabre2);

            //Joueur 1 côté droit
            var positionP1Right = player1RightCollisionCheck.position;
            Vector3 player1StatRight = new Vector3(positionP1Right.x, positionP1Right.y - 1.1f, positionP1Right.z);
            Vector3 player1EndRight = new Vector3(positionP1Right.x, positionP1Right.y + 1.1f, positionP1Right.z);
            isPlayer1Right = Physics.CheckCapsule(player1StatRight, player1EndRight, 0.1f, sabre2);

            if (isPlayer1Left && roteTimer == 0 && !isPlayer1Right && isFirstCollisionOfP1)
            {
                Travelling.anglesToRotate = new Vector3(0, -rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, -backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
                isPlayer1Left = false;
                isFirstCollisionOfP1 = false;
                currentAttack = TYPE_ATTACK.LEFT;
                attack.onAttack(Player.PLAYER.P2,Player.PLAYER.P1,currentAttack);
                //Debug.Log(("C la gaUche isFirstCollisionP1 :"+ isFirstCollisionOfP1));
            }else if (isPlayer1Right && roteTimer == 0 && !isPlayer1Left && isFirstCollisionOfP1)
            {
                Travelling.anglesToRotate = new Vector3(0, +rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, -backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
                isPlayer1Right = false;
                isFirstCollisionOfP1 = false;
                currentAttack = TYPE_ATTACK.RIGHT;
                attack.onAttack(Player.PLAYER.P2,Player.PLAYER.P1,currentAttack);
                //Debug.Log(("C la droite isFirstCollisionP1 :"+ isFirstCollisionOfP1));
            }else if ( backTimer == 0 && !isPlayer1Left && !isPlayer1Right && isFirstCollisionOfP1)
            {
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, -backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = 0f;
                isPlayer1Center = false;
                isFirstCollisionOfP1 = false;
                currentAttack = TYPE_ATTACK.CENTER;
                attack.onAttack(Player.PLAYER.P2,Player.PLAYER.P1,currentAttack);
                //Debug.Log(("C le center isFirstCollisionP1 :"+ isFirstCollisionOfP1));
            }

            var position2 = player2LeftCollisionCheck.position;
            Vector3 player2StartLeft = new Vector3(position2.x, position2.y - 1.1f, position2.z);
            Vector3 player2EndLeft = new Vector3(position2.x, position2.y + 1.1f, position2.z);
            isPlayer2Left = Physics.CheckCapsule(player2StartLeft, player2EndLeft, 0.1f, sabre1);

            var position3 = player2RightCollisionCheck.position;
            Vector3 player2StartRight = new Vector3(position3.x, position3.y - 1.1f, position3.z);
            Vector3 player2EndRight = new Vector3(position3.x, position3.y + 1.1f, position3.z);
            isPlayer2Right = Physics.CheckCapsule(player2StartRight, player2EndRight, 0.1f, sabre1);
            
            if (isPlayer2Left && roteTimer == 0 && !isPlayer2Right && isFirstCollisionOfP2)
            {
                Travelling.anglesToRotate = new Vector3(0, -rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
                isPlayer2Left = false;
                isFirstCollisionOfP2 = false;
                currentAttack = TYPE_ATTACK.LEFT;
                attack.onAttack(Player.PLAYER.P1,Player.PLAYER.P2,currentAttack);
                //Debug.Log(("C LA GOCHE isFirstCollisionPlayer2 :"+ isFirstCollisionOfP2));
            }else if (isPlayer2Right && roteTimer == 0 && !isPlayer2Left && isFirstCollisionOfP2)
            {
                Travelling.anglesToRotate = new Vector3(0, +rotationAngle, 0);
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, backwardDistance);
                    backTimer = .01f;
                } 
                roteTimer = .01f;
                isPlayer2Right = false;
                isFirstCollisionOfP2 = false;
                currentAttack = TYPE_ATTACK.RIGHT;
                attack.onAttack(Player.PLAYER.P1,Player.PLAYER.P2,currentAttack);
                //Debug.Log(("C LA DROUATE isFirstCollisionPlayer2 :"+ isFirstCollisionOfP2));
            }else if ( backTimer == 0 && !isPlayer2Left && !isPlayer2Right && isFirstCollisionOfP2)
            {
                if (backwardMouvement)
                {
                    Travelling.distanceToMove = new Vector3(0, 0, backwardDistance);
                    backTimer = .01f;
                }
                Debug.Log(("C le center isFirstCollisionP2 :"+ isFirstCollisionOfP2));
                roteTimer = 0f;
                isPlayer2Center = false;
                isFirstCollisionOfP2 = false;
                currentAttack = TYPE_ATTACK.CENTER;
                attack.onAttack(Player.PLAYER.P1,Player.PLAYER.P2,currentAttack);
            }
            
            
            if (roteTimer != 0f)
            {
               
                roteTimer += Time.deltaTime;
                if (roteTimer > rotationTime)
                {
                    roteTimer = 0f;
                    Travelling.anglesToRotate = Vector3.zero;
                    timerEnd = true;
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

            attack.disableAttack();
        }

        private void OnTriggerStay(Collider other)
        {
            if (timerEnd)
            {
                if (isFirstCollisionOfP1)
                {
                    isFirstCollisionOfP1 = false;
                    //Debug.Log("Stay isFirstCollisionPlayer1 : "+ isFirstCollisionOfP1);
                } else if (isFirstCollisionOfP2)
                {
                    isFirstCollisionOfP2 = false;
                    //Debug.Log("Stay isFirstCollisionPlayer2 : "+ isFirstCollisionOfP2);
                } 
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            // Vérifie si le jeu autorise l'attaque à ce moment là
            if (!canAttack) 
                return;
            
            // Initialisation du joueur qui a effectuer l'attaque
            Player.PLAYER player = Player.PLAYER.Other;

            // Si le sabre du joueur 1 entre en collision avec autre chose que son propre joueur
            if (other.CompareTag("Katana1") && !gameObject.CompareTag("Player1"))
            {
                player = Player.PLAYER.P1;
                //isFirstCollisionOfP2 = true;
                //timerEnd = false;
                //Debug.Log( "isFirstCollisionOfP2 : "+isFirstCollisionOfP2 );
            }

            // Si le sabre du joueur 2 entre en collision avec autre chose que son propre joueur
            else if (other.CompareTag("Katana2") && !gameObject.CompareTag("Player2"))
            {
                player = Player.PLAYER.P2;
                //isFirstCollisionOfP1 = true;
                //timerEnd = false;
                //Debug.Log( "isFirstCollisionOfP1: "+isFirstCollisionOfP1 );
            }

            // Si aucune condition n'est respectée et que player n'a pas été modifié, la collision n'est pas valable
            if (player == Player.PLAYER.Other)
                return;
            
            KatanaOrientation ko;
            ko = player == Player.PLAYER.P1
                ? GameInit.GetPlayer1KatanaOrientation()
                : GameInit.GetPlayer2KatanaOrientation();
            
            if (!ko.GetPlayerParade().GetParade())
            {
                // Si le joueur à assez d'endurance pour porter le coup
                if (Player.DecreaseStamina(player, GameInit.GetGameConfig().attack_stamina_decrease))
                {
                    if (player == Player.PLAYER.P1)
                        isFirstCollisionOfP2 = true;
                    else
                        isFirstCollisionOfP1 = true;
                    
                    timerEnd = false;

                    // Mise à jour de la vie du joueur
                    bool playerStatus = Player.DecreasePlayerHealth(player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1, GameInit.GetGameConfig().player_health_decrease);

                    // Animations et mouvements de l'attaque
                    //attack.onAttack(player, player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1);

                    if (updateEmote)
                    {
                        if (player == Player.PLAYER.P2)
                        {
                            if (!Stamina.GetExthausted(Player.PLAYER.P2))
                                GameInit.GetEmoteHandler(Player.PLAYER.P2).SetEmote(EmoteHandler.EMOTE_TYPE.HURT,
                                    player1Face, 1f, true);
                        }
                        else
                        {
                            if (!Stamina.GetExthausted(Player.PLAYER.P1))
                                GameInit.GetEmoteHandler(Player.PLAYER.P1).SetEmote(EmoteHandler.EMOTE_TYPE.HURT,
                                    player2Face, 1f, true);
                        }
                    }

                    if (!playerStatus)
                    {
                        Player.UpdatePlayerScore(player, (int)(GameInit.GetGameConfig().attack_score_amount * 1.5f));
                        GameInit.GetRound().isRoundAborted = true;
                    }
                    else
                    {
                        Player.UpdatePlayerScore(player, GameInit.GetGameConfig().attack_score_amount);
                    }
                    
                    
                    // Le son TODO changer ca plus tard
                    var position = new Vector3(11.9f, 11.0f, 15.6f);
                    var rotation = new Quaternion(0, 0, 0, 0);
                    Destroy(Instantiate(GameInit.GetSoundHandler().GetDamageSound(), position, rotation), 2.0f);
                }
                else
                {
                    timerEnd = true;
                    // Si un joueur n'a pas assez de stamina
                }
            }
            else
            {
                // Si un joueur attaque en parade
                //Debug.Log("parade.. arrete... maintenant.. s'il te plait...");
            }
        }

        public bool getIsFirstCollisionOfP1()
        {
            return isFirstCollisionOfP1;
        }
        
        public bool getIsFirstCollisionOfP2()
        {
            return isFirstCollisionOfP2;
        }
    }
}
