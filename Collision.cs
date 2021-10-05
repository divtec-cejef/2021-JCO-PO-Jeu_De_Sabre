using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Changement de la couleur de l'objet lors d'une collision
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        // Remise en place de la couleur lors de la sortie d'une collision
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }
}
