using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingObj : MonoBehaviour
{
    
    [SerializeField] private GameObject shakeObject;
    private Vector3 tremblement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shakeObject.transform.localPosition = tremblement;
        
        if (tremblement.magnitude <= shakeObject.transform.localPosition.magnitude + 0.1 &&
            tremblement.magnitude >= shakeObject.transform.localPosition.magnitude - 0.1)
        { shakeObject.transform.localPosition = Random.insideUnitSphere * 0.025f;
        }
        
         tremblement.x = Mathf.SmoothStep(tremblement.x, shakeObject.transform.localPosition.x, Time.deltaTime * 200.0f);
         tremblement.y = Mathf.SmoothStep(tremblement.y, shakeObject.transform.localPosition.y, Time.deltaTime * 200.0f);
         tremblement.z = Mathf.SmoothStep(tremblement.z, shakeObject.transform.localPosition.z, Time.deltaTime * 200.0f);
        
    }
}
