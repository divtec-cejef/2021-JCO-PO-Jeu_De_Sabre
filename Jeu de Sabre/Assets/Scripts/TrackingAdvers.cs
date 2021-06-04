using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingAdvers : MonoBehaviour
{
    [SerializeField] Transform targetJoueur;
    Vector3 offsetCameraJ;
    
    [Range(0.01f, 1.0f)]
    [SerializeField] float smooth;

    void Start () {
        offsetCameraJ = transform.position - targetJoueur.position;
    }
    
    void Update () {
        Vector3 cameraPositionJ1 = targetJoueur.position + offsetCameraJ;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, cameraPositionJ1, smooth);
        transform.position = smoothPosition;
        transform.LookAt(targetJoueur);
    }
}

