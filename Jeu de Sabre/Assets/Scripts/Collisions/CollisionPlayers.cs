using System;
using System.Collections;
using System.Collections.Generic;
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
    
        public static AttackMouvements attack;

        
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
        
        // Enum utilisé pour communiquer à AttackMouvements quelle animation jouer
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
            // Transformation des variables passé depuis Unity en variable Static
            _player1Face = player1Face;
            _player2Face = player2Face;
            
            // Initialisaiton de la classe chargée d'effectuer les mouvements et les animations des joueurs lors d'une attaque
            attack = new AttackMouvements(player1Axis, player2Axis, player1Character, player1CharacterTransparent, player2Character, player2CharacterTransparent);
        }


        private void Update()
        {
            if (!updateRotation) return;
            //if (!canAttack) return;

            // Récupération de valeur depuis le fichier de configuration
            // Le temps de rotation lors d'une attaque latérale
            float rotationTime  = Random.Range(GameInit.GetGameConfig().rotation_time_min, GameInit.GetGameConfig().rotation_time_max);;
           
            // La force de rotation
            float rotationAngle  = Random.Range(GameInit.GetGameConfig().rotation_angle_min, GameInit.GetGameConfig().rotation_angle_max);
            
            // Les chances d'effectuer un mouvement arrière lors d'une attaque latérale
            bool backwardMouvement = Random.Range(0, (GameInit.GetGameConfig().backward_mouvement_chance - 1)) == 0;
            //float backwardTime  = Random.Range(.02f, .1f);
            
            // La distance de recul lors d'une attaque frontale
            float backwardDistance  = Random.Range(GameInit.GetGameConfig().backward_distance_min, GameInit.GetGameConfig().backward_distance_max);

            
            
            // Latérale 1 Gauche
            var positionP1Left = player1LeftCollisionCheck.position;
            Vector3 player1StartLeft = new Vector3(positionP1Left.x, positionP1Left.y - 1.1f, positionP1Left.z);
            Vector3 player1EndLeft = new Vector3(positionP1Left.x, positionP1Left.y + 1.1f, positionP1Left.z);
            isPlayer1Left = Physics.CheckCapsule(player1StartLeft, player1EndLeft, 0.1f, sabre2);

            // Latérale 1 Droit
            var positionP1Right = player1RightCollisionCheck.position;
            Vector3 player1StatRight = new Vector3(positionP1Right.x, positionP1Right.y - 1.1f, positionP1Right.z);
            Vector3 player1EndRight = new Vector3(positionP1Right.x, positionP1Right.y + 1.1f, positionP1Right.z);
            isPlayer1Right = Physics.CheckCapsule(player1StatRight, player1EndRight, 0.1f, sabre2);

            ///////////////////////////////////
            ///  COLLISION PLAYER 1 GAUCHE  ///
            ///////////////////////////////////
            
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
            }

            ///////////////////////////////////
            ///  COLLISION PLAYER 1 DROITE  ///
            ///////////////////////////////////
            
            else if (isPlayer1Right && roteTimer == 0 && !isPlayer1Left && isFirstCollisionOfP1)
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
            }
            
            ///////////////////////////////////
            ///  COLLISION PLAYER 1 CENTRE  ///
            ///////////////////////////////////
            
            else if ( backTimer == 0 && !isPlayer1Left && !isPlayer1Right && isFirstCollisionOfP1)
            {
                Travelling.distanceToMove = new Vector3(0, 0, -backwardDistance);
                backTimer = .01f;
                roteTimer = 0f;
                isPlayer1Center = false;
                isFirstCollisionOfP1 = false;
                currentAttack = TYPE_ATTACK.CENTER;
                attack.onAttack(Player.PLAYER.P2,Player.PLAYER.P1,currentAttack);
            }
            
            // Latérale 2 Gauche
            var position2 = player2LeftCollisionCheck.position;
            Vector3 player2StartLeft = new Vector3(position2.x, position2.y - 1.1f, position2.z);
            Vector3 player2EndLeft = new Vector3(position2.x, position2.y + 1.1f, position2.z);
            isPlayer2Left = Physics.CheckCapsule(player2StartLeft, player2EndLeft, 0.1f, sabre1);

            // Latérale 2 Droite
            var position3 = player2RightCollisionCheck.position;
            Vector3 player2StartRight = new Vector3(position3.x, position3.y - 1.1f, position3.z);
            Vector3 player2EndRight = new Vector3(position3.x, position3.y + 1.1f, position3.z);
            isPlayer2Right = Physics.CheckCapsule(player2StartRight, player2EndRight, 0.1f, sabre1);
            
            ///////////////////////////////////
            ///  COLLISION PLAYER 2 GAUCHE  ///
            ///////////////////////////////////
            
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
            }
            
            ///////////////////////////////////
            ///  COLLISION PLAYER 2 DROITE  ///
            ///////////////////////////////////
            
            else if (isPlayer2Right && roteTimer == 0 && !isPlayer2Left && isFirstCollisionOfP2)
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
            }
            
            ///////////////////////////////////
            ///  COLLISION PLAYER 2 CENTRE  ///
            ///////////////////////////////////
            
            else if ( backTimer == 0 && !isPlayer2Left && !isPlayer2Right && isFirstCollisionOfP2)
            {
                Travelling.distanceToMove = new Vector3(0, 0, backwardDistance);
                backTimer = .01f;
                roteTimer = 0f;
                isPlayer2Center = false;
                isFirstCollisionOfP2 = false;
                currentAttack = TYPE_ATTACK.CENTER;
                attack.onAttack(Player.PLAYER.P1,Player.PLAYER.P2,currentAttack);
            }
            
            // Timer de rotation, effectue le mouvement pendant un certain temps
            if (roteTimer != 0f)
            {
                roteTimer += Time.deltaTime;
                if (roteTimer > rotationTime)
                {
                    roteTimer = 0f;
                    Travelling.anglesToRotate = Vector3.zero;
                    timerEnd = true;
                    attack.DisableAnimation();
                }
            }
            
            // Timer de recul, effectue le mouvement pendant un certain temps
            if (backTimer != 0f)
            {
                backTimer += Time.deltaTime;
                if (backTimer > rotationTime)
                {
                    backTimer = 0f;
                    Travelling.distanceToMove = Vector3.zero;
                    timerEnd = true;
                    attack.DisableAnimation();
                }
            }
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
            
            // Récupération du KatanaOrientation de l'attaquant
            KatanaOrientation ko;
            ko = player == Player.PLAYER.P1
                ? GameInit.GetPlayer1KatanaOrientation()
                : GameInit.GetPlayer2KatanaOrientation();
            
            // Si l'attaquant est en parade, l'attaque est invalide
            if (!ko.GetPlayerParade().GetParade())
            {
                // Si le n'as pas assez d'endurance, l'attaque est invalide
                if (Player.DecreaseStamina(player, GameInit.GetGameConfig().attack_stamina_decrease))
                {
                    PSMoveUtils.SetVibration(player, 255);
                    PSMoveUtils.SetVibration(player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1, 100);

                    StartCoroutine(StopRumble());

                    GameInit.GetSoundHandler().GetSoundSlash().Play();
                    
                    if (player == Player.PLAYER.P1)
                        isFirstCollisionOfP2 = true;
                    else
                        isFirstCollisionOfP1 = true;
                    
                    timerEnd = false;

                    // Mise à jour de la vie du joueur et récupération de son état
                    bool playerStatus = Player.DecreasePlayerHealth(player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1, (int)(GameInit.GetGameConfig().player_health_decrease * GameInit.GetGameConfig().stun_multiplier));
                    
                    // Clignotement de la barre de vie du joueur qui vient de se prendre un coup
                    if(GameInit.GetUiUpdater().canHealthBlink(player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1))
                        StartCoroutine(GameInit.GetUiUpdater().DisplayHealthWarning(player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1));
                    // Animations et mouvements de l'attaque
                    //attack.onAttack(player, player == Player.PLAYER.P1 ? Player.PLAYER.P2 : Player.PLAYER.P1);

                    // Mise à jour du visage des joueurs
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

                    float scorePlus;
                    
                    // Si le joueur est mort, fin du round et point bonus
                    if (!playerStatus)
                    {
                        scorePlus = (int)(GameInit.GetGameConfig().attack_score_amount * 1.3f);
                        GameInit.GetRound().isRoundAborted = true;
                    }
                    else
                    {
                        scorePlus = GameInit.GetGameConfig().attack_score_amount;
                    }

                    if (player == Player.PLAYER.P1)
                    {
                        if (CollisionSabres._isPlayer2Stun)
                            scorePlus *= GameInit.GetGameConfig().stun_multiplier;
                    }
                    
                    if (player == Player.PLAYER.P2)
                    {
                        if (CollisionSabres._isPlayer1Stun)
                            scorePlus *= GameInit.GetGameConfig().stun_multiplier;
                    }
                    
                    // Mise à jour du score du joueur 
                    Player.UpdatePlayerScore(player, (int)scorePlus);
                    
                    // Lancement de l'animation de gain de points
                    GameInit.GetUiUpdater().PlayerScorePlusAnimation(player, scorePlus.ToString());
                }
                else
                {
                    timerEnd = true;
                    if (GameInit.GetUiUpdater().canBlink(player))
                    {
                        StartCoroutine(GameInit.GetUiUpdater().DispalayLowStamina(player));
                        StartCoroutine(GameInit.GetUiUpdater().DispalayLowStaminaFill(player));
                        StartCoroutine(GameInit.GetUiUpdater().DispalayLowStaminaIcon(player));
                    }
                    // Si un joueur n'a pas assez de stamina
                }
            }
            else
            {
                // Si un joueur attaque en parade
                //Debug.Log("parade.. arrete... maintenant.. s'il te plait...");
            }
        }

        IEnumerator StopRumble()
        {
            yield return new WaitForSeconds(.2f);
            PSMoveUtils.SetVibration(Player.PLAYER.P1, 0);
            PSMoveUtils.SetVibration(Player.PLAYER.P2, 0);
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
