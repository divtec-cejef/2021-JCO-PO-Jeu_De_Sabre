using UnityEngine;

namespace Mouvements
{
    public class FollowElement : MonoBehaviour
    {
        public Transform targetOffset;
        public Vector3 follower;
    
        void Start()
        {
            follower = transform.position - targetOffset.transform.position;
        }
    
        void LateUpdate()
        {
            // Mise à jour de la position de l'objet avec l'objet à suivre
            Vector3 newPosition = targetOffset.transform.position + follower;
            transform.position = newPosition;
        }
    }
}
