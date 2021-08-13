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
        }

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
        
        /// <summary>
        /// Permet de savoir si la parade est prête
        /// </summary>
        /// <returns>Est-ce que la parade est prête</returns>
        public bool GetReady()
        {
            return isReady;
        }

        /// <summary>
        /// Permet de modifier si la parade est prête
        /// </summary>
        /// <param name="isReady">Est-ce que la parade est prête</param>
        public void SetReady(bool isReady)
        {
            this.isReady = isReady;
        }
        
        /// <summary>
        /// Permet de savoir si la parade a été annulé
        /// </summary>
        /// <returns>Est-ce que la parade a été annulé</returns>
        public bool GetCanceled()
        {
            return isCanceled;
        }

        /// <summary>
        /// Permet de modifier si la parade a été annulé
        /// </summary>
        /// <param name="isCanceled">Est-ce que la parade a été annulé</param>
        public void SetCanceled(bool isCanceled)
        {
            this.isCanceled = isCanceled;
        }

        /// <summary>
        /// Permet de récupérer le timer de la parade
        /// </summary>
        /// <returns>Le timer de la parade</returns>
        public float GetParadeTimer()
        {
            return paradeTimer;
        }

        /// <summary>
        /// Permet de modifier le timer de la parade
        /// </summary>
        /// <param name="paradeTimer">Le nouveau timer</param>
        public void SetParadeTimer(float paradeTimer)
        {
            this.paradeTimer = paradeTimer;
        }
    }
}