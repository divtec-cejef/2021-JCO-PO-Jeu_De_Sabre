using UnityEngine;

namespace Sounds
{
    public class SoundHandler
    {

        private GameObject timerSound;
        private GameObject damageSound;
    
        public SoundHandler(GameObject timerSound, GameObject damageSound)
        {
            this.timerSound = timerSound;
            this.damageSound = damageSound;
        }

        public GameObject GetTimerSound()
        {
            return timerSound;
        }

        public GameObject GetDamageSound()
        {
            return damageSound;
        }
    }
}
