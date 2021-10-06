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

        /// <summary>
        /// Initialisation du tremblement des caméras
        /// </summary>
        /// <param name="player1VirtualCamera">La caméra virtuelle du joueur 1</param>
        /// <param name="player2VirtualCamera">La caméra virtuelle du joueur 2</param>
        public void Init(CinemachineVirtualCamera player1VirtualCamera, CinemachineVirtualCamera player2VirtualCamera)
        {
            print("\tRécupération des caméras virtuelles...");
            this.player1VirtualCamera = player1VirtualCamera;
            this.player2VirtualCamera = player2VirtualCamera;
        }

        /// <summary>
        /// Permet de faire trembler la caméra du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on veut faire trembler la caméra</param>
        /// <param name="intensity">L'intensité du tremblement</param>
        /// <param name="duration">La durée du tremblement</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        /// Permet de faire tremblé la caméra
        /// </summary>
        /// <param name="vCam">La caméra virtuel du joueur</param>
        /// <param name="intensity">L'intensité du tremblement</param>
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
