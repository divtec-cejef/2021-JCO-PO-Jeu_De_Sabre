using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Tracker_2 : MonoBehaviour
{
    [SerializeField] private float xAmplitude;
    [SerializeField] private float xOffset;
    
    [SerializeField] private float yOffset;
    
    [SerializeField] private float zAmplitude;

    [SerializeField] private float zOffset;

    private static bool canTrack;
    
    private String X;
    private String Y;
    private String radius;
    private String userDir;
    private Data data;
    private CamOffset offset;
    
    private void Awake()
    {
        canTrack = false;
        data = new Data();
        offset = new CamOffset();
        userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        userDir += "\\Documents\\data1.json";

        //StartCoroutine(Tracker());
    }

    IEnumerator Tracker()
    {
        while (true)
        {
            if (!canTrack) 
                continue;
            
            String json = "";
            String[] lines = null;
            bool isReadable = true;
            try
            {
                lines = System.IO.File.ReadAllLines(@userDir);
            }
            catch (Exception e)
            {
                isReadable = false;
                print("Erreur de lecture");
            }
    
            if (isReadable)
            {
                foreach (String line in lines)
                {
                    json += line;
                }
    
                data = JsonUtility.FromJson<Data>(json);
            }
    
            X = data.x;
            Y = data.y;
            radius = data.z;
    
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                new Vector3((xOffset + float.Parse(X) / xAmplitude) + offset.xOffset,
                    (5 + float.Parse(Y) / yOffset) + offset.yOffset,
                    (zOffset + zAmplitude * float.Parse(radius) + offset.zOffset)),
                0.3f);
    
            yield return new WaitForSeconds(0.03f);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ProcessCameraOffset();
        }
    }

    private void ProcessCameraOffset()
    {
        offset.xOffset = 0 + (xOffset + float.Parse(X) / xAmplitude);
        offset.yOffset = 4.5f + (5 + float.Parse(Y) / yOffset);
        offset.zOffset = 0.7f + (zOffset + zAmplitude * float.Parse(radius));
    }

    private class CamOffset
    {
        public float xOffset = 0;
        
        public float yOffset = 0;
        
        public float zOffset = 0;
    }

    [Serializable]
    private class Data
    {
        public String x;
        
        public String y;
        
        public String z;
    }
}