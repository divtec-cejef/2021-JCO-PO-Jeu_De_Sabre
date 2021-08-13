using System;
using Cinemachine;
using Players;
using UnityEngine;

namespace Camera
{
    public class CameraShaking : MonoBehaviour
    {

        private CinemachineVirtualCamera player1VirtualCamera;
        
        private CinemachineVirtualCamera player2VirtualCamera;
        
        private float player1ShakeTimer;
        
        private float player2ShakeTimer;
        
        private float player1Intensity;
        
        private float player2Intensity;

        public void Init(CinemachineVirtualCamera vCam1, CinemachineVirtualCamera vCam2)
        {
            print("\tRécupération des caméras virtuelles...");
            this.player1VirtualCamera = vCam1;
            this.player2VirtualCamera = vCam2;
        }

        public void ShakeCamera(Player.PLAYER player, float intensity, float duration)
        {
            switch (player)
            {
                case Player.PLAYER.P1:
                    player1Intensity = intensity;
                    player1ShakeTimer = duration;
                    Shake(player1VirtualCamera, intensity);
                    break;
                case Player.PLAYER.P2:
                    player2Intensity = intensity;
                    player2ShakeTimer = duration;
                    Shake(player2VirtualCamera, intensity);
                    break;
                case Player.PLAYER.Other:
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
            if (player1ShakeTimer > 0f)
            {
                player1ShakeTimer -= Time.deltaTime;
                if (player1ShakeTimer <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin perlin =
                        player1VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                    perlin.m_AmplitudeGain = 0f;
                }
            }
            if (player2ShakeTimer > 0f)
            {
                player2ShakeTimer -= Time.deltaTime;
                if (player2ShakeTimer <= 0f)
                {
                    CinemachineBasicMultiChannelPerlin perlin =
                        player2VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                    perlin.m_AmplitudeGain = 0f;
                }
            }
        }
    }
}
