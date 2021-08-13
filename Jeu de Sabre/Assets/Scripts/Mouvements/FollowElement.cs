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
            Vector3 newPosition = targetOffset.transform.position + follower;
            transform.position = newPosition;
        }
    }
}
