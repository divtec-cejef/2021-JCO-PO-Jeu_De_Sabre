using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Camera
{
    public class CameraShaking : MonoBehaviour
    {

        private CinemachineVirtualCamera vCam1;
        private CinemachineVirtualCamera vCam2;
        private float shakeTimer1;
        private float shakeTimer2;
        private float intensity1;
        private float intensity2;

        public void Init(CinemachineVirtualCamera vCam1, CinemachineVirtualCamera vCam2)
        {
            print("\tRécupération des caméras virtuelles...");
            this.vCam1 = vCam1;
            this.vCam2 = vCam2;
        }

        public void ShakeCamera(Player.Joueur player, float intensity, float duration)
        {
            switch (player)
            {
                case Player.Joueur.P1:
                    intensity1 = intensity;
                    shakeTimer1 = duration;
                    Shake(vCam1, intensity);
                    break;
                case Player.Joueur.P2:
                    intensity2 = intensity;
                    shakeTimer2 = duration;
                    Shake(vCam2, intensity);
                    break;
                case Player.Joueur.Other:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(player), player, null);
            }
        }

        private void Shake(CinemachineVirtualCamera vCam, float intensity)
        {
            CinemachineBasicMultiChannelPerlin perlin =
                vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = intensity;
        }

        private void Update()
        {
            if (shakeTimer1 > 0f)
            {
                shakeTimer1 -= Time.deltaTime;
                if (shakeTimer1 <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin perlin =
                        vCam1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                    perlin.m_AmplitudeGain = 0f;
                }
            }
            if (shakeTimer2 > 0f)
            {
                shakeTimer2 -= Time.deltaTime;
                if (shakeTimer2 <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin perlin =
                        vCam2.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                    perlin.m_AmplitudeGain = 0f;
                }
            }
        }
    }
}
