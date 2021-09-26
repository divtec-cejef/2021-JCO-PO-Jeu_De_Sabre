using System;
using System.Collections;
using Cinemachine;
using Players;
using UnityEngine;

namespace Mouvements
{
    public class CameraController : MonoBehaviour
    {
        public CinemachineVirtualCamera player1;
        public CinemachineVirtualCamera player2;

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
            xBodyBase1 = player1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x;
            yBodyBase1 = player1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y;
            zBodyBase1 = player1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z;
            
            xBodyBase2 = player2.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x;
            yBodyBase2 = player2.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y;
            zBodyBase2 = player2.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z;
            yAim = -6f;
            yBody = 3f;
        }


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

        private IEnumerator ChangePOVAim(CinemachineVirtualCamera vCam)
        {
            float currentY = vCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y;
            
            while (currentY > yAim)
            {
                currentY -= 8f * Time.deltaTime;
                vCam.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y = currentY;
                yield return null;
            }
        }
        
        private IEnumerator ChangePOVBody(CinemachineVirtualCamera vCam)
        {
            float currentY = vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y;
            
            while (currentY < yBody)
            {
                currentY += 3.8f * Time.deltaTime;
                vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = currentY;
                yield return null;
            }
        }
        
        
        public void ResetCamera()
        {
            player1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
                new Vector3(xBodyBase1, yBodyBase1, zBodyBase1);
            
            player1.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset =
                new Vector3(0f, 0f, 0f);
            
            player2.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
                new Vector3(xBodyBase2, yBodyBase2, zBodyBase2);
            
            player2.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset =
                new Vector3(0f, 0f, 0f);
        }
        
    }
}