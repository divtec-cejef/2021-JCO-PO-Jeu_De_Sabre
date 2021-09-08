using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroAnim : MonoBehaviour
{
    public float Strength;
    public static bool startGame;

    private void Awake()
    {
        StartCoroutine(PulseEffect());
    }

    IEnumerator PulseEffect()
    {
        Vector3 resetSize = transform.localScale;
        /*while (true)
        {*/
            // Loops forever
            while (true)
            {

                if (!startGame)
                {
                    transform.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
                }
                else{
                    
                    transform.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
                    transform.localScale = resetSize;
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
                yield return null;
            }
        //}
    }
}
