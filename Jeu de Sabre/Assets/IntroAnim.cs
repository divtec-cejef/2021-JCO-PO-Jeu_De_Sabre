using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroAnim : MonoBehaviour
{
    public float Strength;
    public static bool startGame;
    private Vector3 basicSize;


    public IEnumerator PulseEffect()
    {
        basicSize = transform.localScale;
        /*while (true)
        {*/
            // Loops forever
            transform.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            while (startGame)
            {
                transform.localScale = basicSize;
                float timer = 0f;
                // Zoom in
                while (timer < 1f)
                {
                    yield return new WaitForEndOfFrame();
                    timer += Time.deltaTime;

                    transform.localScale = new Vector3
                    (
                        transform.localScale.x + (Time.deltaTime * Strength * 4),
                        transform.localScale.y + (Time.deltaTime * Strength * 4)
                    );
                }
            }
            transform.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
            
            
            transform.localScale = basicSize;
            yield return null;
        //}
    }
}
