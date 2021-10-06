using System;
using System.Collections;
using Cinemachine;
using Players;
using UnityEngine;

namespace Mouvements
{
    public class CameraController : MonoBehaviour
    {
        // Caméra virtuelle des joueurs
        public CinemachineVirtualCamera player1;
        public CinemachineVirtualCamera player2;

        // Variables uilisées lors de la mort d'un joueur afin de déplacer la caméra
        private float yAim;
        private float yBody;
        private float xBodyBase1;
        private float yBodyBase1;
        private float zBodyBase1;
        private float xBodyBase2;
        private float yBodyBase2;
        private float zBodyBase2;
        
        private void Awake()
        {
            // Récupération des valeurs du joueur 1
            Vector3 offset1 = player1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
            xBodyBase1 = offset1.x;
            yBodyBase1 = offset1.y;
            zBodyBase1 = offset1.z;
            
            // Récupération des valeurs du joueur 2
            Vector3 offset2 = player2.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
            xBodyBase2 = offset2.x;
            yBodyBase2 = offset2.y;
            zBodyBase2 = offset2.z;
            
            // Valeur de base
            yAim = -6f;
            yBody = 3f;
        }

        /// <summary>
        /// Permet de changer le point de vue de la caméra du joueur passé en paramètre
        /// </summary>
        /// <param name="player">Le joueur auquel on souhaite changer le point de vu</param>
        public void ChangeCameraPOV(Player.PLAYER player)
        {
            if (player == Player.PLAYER.P1)
            {
                StartCoroutine(ChangePOVAim(player1));
                StartCoroutine(ChangePOVBody(player1));
            }
            else if (player2)
            {
                StartCoroutine(ChangePOVAim(player2));
                StartCoroutine(ChangePOVBody(player2));
            }
        }

        /// <summary>
        /// Modifie la valeur Aim de la caméra 
        /// </summary>
        /// <param name="vCam">La caméra à modifier</param>
        private IEnumerator ChangePOVAim(CinemachineVirtualCamera vCam)
        {
            // La valeur y du tracking de la caméra
            float currentY = vCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y;
            
            // Modification de la valeur tant que la caméra n'est pas arrivé à destination
            while (currentY > yAim)
            {
                currentY -= 8f * Time.deltaTime;
                vCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y = currentY;
                yield return null;
            }
        }
        
        /// <summary>
        /// Modifie la valeur Body de la caméra 
        /// </summary>
        /// <param name="vCam">La caméra à modifier</param>
        private IEnumerator ChangePOVBody(CinemachineVirtualCamera vCam)
        {
            // La valeur y du offset de la caméra
            float currentY = vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y;
            
            // Modification de la valeur tant que la caméra n'est pas arrivé à destination
            while (currentY < yBody)
            {
                currentY += 3.8f * Time.deltaTime;
                vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = currentY;
                yield return null;
            }
        }

        /// <summary>
        /// Replace la caméra
        /// </summary>
        public void ResetCamera()
        {
            // Replace le Body de la caméra 1
            player1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
                new Vector3(xBodyBase1, yBodyBase1, zBodyBase1);
            
            // Replace le Aim de la caméra 1
            player1.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset =
                new Vector3(0f, 0f, 0f);
            
            // Replace le Body de la caméra 2
            player2.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
                new Vector3(xBodyBase2, yBodyBase2, zBodyBase2);
            
            // Replace le Aim de la caméra 2
            player2.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset =
                new Vector3(0f, 0f, 0f);
        }
        
    }
}