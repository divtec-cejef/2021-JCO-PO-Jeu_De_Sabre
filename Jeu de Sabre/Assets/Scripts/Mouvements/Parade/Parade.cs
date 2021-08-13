using System;
using System.Collections;
using System.Security.Cryptography;
using Init;
using Mouvements.Orientation;
using Players;
using UnityEngine;
using UnityEngine.UI;

namespace Mouvements.Parade
{
    public class Parade : MonoBehaviour
    {
        private Player.PLAYER player;
        
        private float paradeTimer;
        
        private GameObject paradeFx1;
        
        private GameObject paradeFx2;
        
        private GameObject paradeFx1Object;
        
        private GameObject paradeFx2Object;
        
        private GameObject paradeFxPos;
        
        private GameObject katanaAxis;
        
        private KatanaOrientation katanaOrientation;
        
        private Slider paradeSlider;
        
        private bool isParade;
        
        private bool isReady;
        
        private bool isCanceled;

        public void Init(float paradeTimer, GameObject paradeFx1, GameObject paradeFx2, GameObject paradeFxPos, GameObject katanaAxis,
            Player.PLAYER player, KatanaOrientation katanaOrientation, Slider paradeSlider)
        {
            SetParade(false);
            SetReady(true);
            SetCanceled(false);
            this.player = player;
            this.paradeTimer = paradeTimer;
            this.paradeFx1 = paradeFx1;
            this.paradeFx2 = paradeFx2;
            this.paradeFxPos = paradeFxPos;
            this.katanaAxis = katanaAxis;
            this.katanaOrientation = katanaOrientation;
            this.paradeSlider = paradeSlider;
        }


        /// <summary>
        /// Fonction appelé lors de la première frame de la parade
        /// </summary>
        public void OnParadeEnabled()
        {
            
            PSMoveUtils.SetVibration(player, 255);

            var rotation = paradeFxPos.transform.rotation;
            var position = paradeFxPos.transform.position;
            paradeFx1Object = Instantiate(paradeFx1, position, rotation);
            paradeFx2Object = Instantiate(paradeFx2, position, rotation);
            
            katanaOrientation.CanMove(false);
            SetParade(true);
            SetReady(false);

            GameInit.GetUiUpdater().OnParadeEnabled(player);
            
            //StartCoroutine(UpdateParade());
        }
        
        // /// <summary>
        // /// Fonction appelé juste après l'activation de la parade
        // /// Stoppe la boucle lorsque la parade s'arrete
        // /// </summary>
        // /// <returns></returns>
        // IEnumerator UpdateParade()
        // {
        //     while (isParade)
        //     {
        //         yield return new WaitForSeconds(.25f);
        //         if (player == Player.PLAYER.P1)
        //         {
        //             if (Input.GetKey(KeyCode.Q))
        //             {
        //                 GameInit.GetUiUpdater().OnParadeUpdate(player);
        //             }
        //             else
        //             {
        //                 isParade = false;
        //             }
        //         }
        //     }
        //     OnParadeDisabled();
        // }

        /// <summary>
        /// Fonction appelé chaque frame du jeu
        /// </summary>
        private void Update()
        {
            if (!GetParade() || GetCanceled())
            {
                Destroy(paradeFx1Object);
                Destroy(paradeFx2Object);
                OnParadeDisabled();
                SetCanceled(false);
                return;
            }
            
            // Décrémentation du timer tant que la parade est active
            float timer = GetParadeTimer();
            if (timer > 0.0f)
            {
                timer -= 1f * Time.deltaTime;
                if (!Player.DecreaseStamina(player, GameInit.GetGameConfig().parade_stamina_decrease_rate * Time.deltaTime))
                {
                    SetParade(false);
                }
            }
            else
            {
                timer = 0.0f;
                    
                SetParade(false);
                SetCanceled(true);
            }
            SetParadeTimer(timer);
            
            // Mise à jour de l'affichage
            GameInit.GetUiUpdater().OnParadeUpdate(player);
            
            var position = paradeFxPos.transform.position;
            paradeFx1Object.transform.position = position;
            paradeFx2Object.transform.position = position;
        }

        /// <summary>
        /// Fonction appelé lorsque la parade s'arrète
        /// </summary>
        public void OnParadeDisabled()
        {
            
            GameInit.GetUiUpdater().OnParadeDisabled(player);
            SetParade(false);
            katanaOrientation.CanMove(true);
            PSMoveUtils.SetVibration(player, 0);
        }
        
        /// <summary>
        /// Permet de récupérer l'état actuel de la parade
        /// </summary>
        /// <returns>L'état de la parade</returns>
        public bool GetParade()
        {
            return isParade;
        }

        /// <summary>
        /// Permet de modifier l'état de la parade
        /// </summary>
        /// <param name="isParade">Le nouvel état de la parade</param>
        public void SetParade(bool isParade)
        {
            this.isParade = isParade;
        }
        
        public bool GetReady()
        {
            return isReady;
        }

        public void SetReady(bool isReady)
        {
            this.isReady = isReady;
        }
        
        public bool GetCanceled()
        {
            return isCanceled;
        }

        public void SetCanceled(bool isCanceled)
        {
            this.isCanceled = isCanceled;
        }

        public float GetParadeTimer()
        {
            return paradeTimer;
        }

        public void SetParadeTimer(float paradeTimer)
        {
            this.paradeTimer = paradeTimer;
        }





















    }
    
    
    // public class Parade : MonoBehaviour
    // {
    //     private Player.Joueur player;
    //
    //     /* Si le joueur est en parade */
    //     private bool isParade;
    //     /* Si sa parade à été annulé */
    //     private bool isCanceled;
    //     /* Si le joueur est prêt pour une nouvelle parade */
    //     private bool isReady = true;
    //
    //     private GameObject FXParade_1;
    //     private GameObject FXParade_2;
    //     private GameObject FXParadePos;
    //
    //     private GameObject katanaAxis;
    //
    //     private Vector3 defaultPos;
    //     private Vector3 tremblement;
    //
    //     private float timerParade;
    //     private float cooldownParade;
    //
    //     private GameObject fxEffect1;
    //     private GameObject fxEffect2;
    //
    //
    //     // public Parade(float timerParade, float cooldownParade, GameObject fx1, GameObject fx2, GameObject fxPos, GameObject katanaAxis, Player.Joueur player)
    //     // {
    //     //     this.timerParade = timerParade;
    //     //     this.cooldownParade = 1.0f;
    //     //     FXParade_1 = fx1;
    //     //     FXParade_2 = fx2;
    //     //     FXParadePos = fxPos;
    //     //     this.katanaAxis = katanaAxis;
    //     //     this.player = player;
    //     // }
    //
    //     public void init(float timerParade, float cooldownParade, GameObject fx1, GameObject fx2, GameObject fxPos,
    //         GameObject katanaAxis, Player.Joueur player)
    //     {
    //         this.timerParade = timerParade;
    //         this.cooldownParade = timerParade;
    //         FXParade_1 = fx1;
    //         FXParade_2 = fx2;
    //         FXParadePos = fxPos;
    //         this.katanaAxis = katanaAxis;
    //         this.player = player;
    //     }
    //
    //     /// <summary>
    //     /// Vérification et activation de la parade, active aussi tout les effets secondaires liés à la parade
    //     /// </summary>
    //     /// <param name="quaternion">Quaternion représentant l'orientation du sabre</param>
    //     /// <param name="axeX">AxeX de l'orientation du PSMove</param>
    //     /// <param name="axeZ">AxeZ de l'orientation du PSMove</param>
    //     /// <param name="axeY">AxeZ de l'orientation du PSMove</param>
    //     /// <param name="ow">Orientation W du PSMove</param>
    //     public void onParadeEnabled(ref Quaternion quaternion, float axeX, float axeZ, float axeY, float ow, Color parryColor)
    //     {
    //         if (!isCanceled && isReady)
    //         {
    //             if (!isParade)
    //             { 
    //                 PSMoveUtils.setLED(player, parryColor);
    //                 var rotation = FXParadePos.transform.rotation;
    //                 var position = FXParadePos.transform.position;
    //                 fxEffect1 = MonoBehaviour.Instantiate(FXParade_1, position, rotation);
    //                 fxEffect2 = MonoBehaviour.Instantiate(FXParade_2, position, rotation);
    //
    //                 quaternion = new Quaternion(axeX, axeZ, axeY, ow);
    //                 katanaAxis.transform.rotation = quaternion;
    //            
    //                 PSMoveUtils.setVibration(player, 255);
    //                 defaultPos = katanaAxis.transform.position;
    //
    //                 StartCoroutine(DecreaseStaminaOverTime());
    //             }
    //
    //             //MonoBehaviour.print("Parade " + quaternion);
    //         
    //             // katanaAxis.transform.position = tremblement;
    //             //
    //             // if (tremblement.magnitude <= katanaAxis.transform.position.magnitude + 0.1 &&
    //             //     tremblement.magnitude >= katanaAxis.transform.position.magnitude - 0.1)
    //             // {
    //             //     katanaAxis.transform.position = Random.insideUnitSphere * 0.025f;
    //             // }
    //             //
    //             // tremblement.x = Mathf.SmoothStep(tremblement.x, katanaAxis.transform.position.x, Time.deltaTime * 200.0f);
    //             // tremblement.y = Mathf.SmoothStep(tremblement.y, katanaAxis.transform.position.y, Time.deltaTime * 200.0f);
    //             // tremblement.z = Mathf.SmoothStep(tremblement.z, katanaAxis.transform.position.z, Time.deltaTime * 200.0f);
    //             //
    //             
    //             print("LALALAL");
    //             
    //             updateParadeTimer();
    //             isParade = true;
    //         }
    //     }
    //
    //     /// <summary>
    //     /// Met à jour le timer
    //     /// </summary>
    //     private void updateParadeTimer()
    //     {
    //         /* Si le timer n'est pas terminé, décompte du timer */
    //         if (timerParade > 1.0f)
    //         {
    //             timerParade -= Time.deltaTime;
    //         }
    //         /* Si le timer est terminé, annulation de la parade et réinitialisation du timer */
    //         else
    //         {
    //             isCanceled = true;
    //             timerParade = GameInit.getGameConfig().parade_duration;
    //             isReady = false;
    //         }
    //     }
    //
    //     public IEnumerator DecreaseStaminaOverTime()
    //     {
    //         while (!Player.decreaseStamina(player, GameInit.getGameConfig().parade_stamina_decrease_rate) || !isParade)
    //         {
    //             yield return new WaitForSecondsRealtime(.25f);
    //         }
    //         timerParade = 1.0f;
    //     }
    //
    //     public void onParadeDisabled()
    //     {
    //         if (isParade)
    //         {
    //             PSMoveUtils.setLED(player, Color.green);
    //             timerParade = GameInit.getGameConfig().parade_duration;
    //             cooldownParade = timerParade;
    //             isCanceled = false;
    //             PSMoveUtils.setVibration(player, 0);
    //             Destroy(fxEffect1);
    //             Destroy(fxEffect2);
    //             isReady = false;
    //             katanaAxis.transform.position = defaultPos;
    //         }
    //         isParade = false;
    //     }
    //
    //     public void UpdateParadeCooldown()
    //     {
    //         /* Si le joueur n'est pas prêt à executer une parade et qu'il n'est pas déjà en parade */
    //         if (!isReady && !isParade)
    //         {
    //             /* Si le timer n'est pas terminé, décompte du timer */
    //             if (cooldownParade < GameInit.getGameConfig().parade_duration)
    //             {
    //                 cooldownParade += Time.deltaTime;
    //             }
    //             /* Si le timer est terminé, réactivation de la parade et réinitialisation du cooldown*/
    //             else
    //             {
    //                 isReady = true;
    //                 cooldownParade = GameInit.getGameConfig().parade_duration;
    //             }
    //         }
    //     }
    //
    //     public bool getParade()
    //     {
    //         return isParade;
    //     }
    //
    //     public bool getCanceled()
    //     {
    //         return isCanceled;
    //     }
    //     public bool getReady()
    //     {
    //         return isReady;
    //     }
    //
    //     public float getParadeTimer()
    //     {
    //         return timerParade;
    //     }
    //
    //     public float getCooldownTimer()
    //     {
    //         return cooldownParade;
    //     }
    // }
}