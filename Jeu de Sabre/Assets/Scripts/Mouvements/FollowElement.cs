using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowElement : MonoBehaviour
{
    public Transform targetOffset;
    public Vector3 follower;
// Start is called before the first frame update
    void Start()
    {
        follower = transform.position - targetOffset.transform.position;
    }
// Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetOffset.transform.position + follower;
        transform.position = newPosition;
    }

}
