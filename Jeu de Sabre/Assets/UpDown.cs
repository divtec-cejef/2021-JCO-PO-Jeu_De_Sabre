using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    float lerpDuration = 3; 
    public Vector3 startPos; 
    public Vector3 endPos; 
    float valueToLerp = 0;
    private bool estArrive = false;
    private float a;
    
    private void FixedUpdate()
    {
        a = Mathf.Lerp(a, 1.0f, 0.001f);
        transform.position = new Vector3(transform.position.x, a, transform.position.z);
    }
}
