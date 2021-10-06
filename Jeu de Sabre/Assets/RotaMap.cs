using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaMap : MonoBehaviour
{
    [Range(0.0f, 10.0f)] public float rotation;

    private void Update()
    {
        Quaternion rot = new Quaternion(transform.rotation.x, rotation, transform.rotation.z, transform.rotation.w);

        transform.rotation = rot;
    }
}
