using UnityEngine;

namespace Sounds
{
    public class SoundHandler 
    {
        public AudioSource soundGong1;
        public AudioSource soundGong2;
        public AudioSource soundGong3;
        
        public AudioSource soundSlash1;
        public AudioSource soundSlash2;
        public AudioSource soundSlash3;
        
        public AudioSource soundCollision1;
        public AudioSource soundCollision2;
        
        public AudioSource soundDeath1;
        public AudioSource soundDeath2;
        public AudioSource soundDeath3;
        public AudioSource soundDeath4;
        
        public AudioSource soundHurt1;
        public AudioSource soundHurt2;
        public AudioSource soundHurt3;
        public AudioSource soundHurt4;
        public AudioSource soundHurt5;
        public AudioSource soundHurt6;
        public AudioSource soundHurt7;
        public AudioSource soundHurt8;
        
        /// <summary>
        /// Permet de récupérer un son de collision aléatoire
        /// </summary>
        /// <returns>Le son</returns>
        public AudioSource GetSoundCollision()
        {
            float pitch = Random.Range(0.9f, 1.3f);
            if (Random.Range(0, 2) == 0)
            {
                soundCollision1.pitch = pitch;
                return soundCollision1;
            }

            soundCollision2.pitch = pitch;
            return soundCollision2;
        }
        
        /// <summary>
        /// Permet de récupérer un son de slash aléatoire
        /// </summary>
        /// <returns>Le son</returns>
        public AudioSource GetSoundSlash()
        {
            float pitch = Random.Range(0.9f, 1.3f);
            int rand = Random.Range(0, 3);
            if (rand == 0)
            {
                soundSlash1.pitch = pitch;
                return soundSlash1;
            }
            
            if (rand == 1)
            {
                soundSlash2.pitch = pitch;
                return soundSlash2;
            }
            soundSlash3.pitch = pitch;
            return soundSlash3;
        }

        /// <summary>
        /// Permet de récupérer un son de mort aléatoire
        /// </summary>
        /// <returns>Le son</returns>
        public AudioSource GetSoundDeath()
        {
            float pitch = Random.Range(0.9f, 1.3f);
            int rand = Random.Range(0, 4);

            switch (rand)
            {
                case 0 :soundDeath1.pitch = pitch;
                    return soundDeath1;
                
                case 1 :soundDeath2.pitch = pitch;
                    return soundDeath2;
                
                case 2 :soundDeath3.pitch = pitch;
                    return soundDeath3;
                
                case 3 :soundDeath4.pitch = pitch;
                    return soundDeath4;
                
                default:soundDeath1.pitch = pitch;
                    return soundDeath1;
            }
        }
    }
}