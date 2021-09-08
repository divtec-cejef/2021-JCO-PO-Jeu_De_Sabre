using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenTravelling : MonoBehaviour
{
    // Update is called once per frame
    public Vector3 anglesToRotate;

    void Update()
    {
        transform.Rotate(new Vector3 (1f,0f,0f), anglesToRotate.x * Time.deltaTime,Space.Self);
        transform.Rotate(new Vector3 (0f,1f,0f), anglesToRotate.y * Time.deltaTime,Space.Self);
        transform.Rotate(new Vector3 (0f,0f,1f), anglesToRotate.z * Time.deltaTime,Space.Self);
    }
}
