using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = UnityEngine.Vector3;

public class Tracker_1 : MonoBehaviour
{
    [SerializeField] private float xAmplitude;
    
    [SerializeField] private float xOffset;
    
    [SerializeField] private float yAmplitude;

    [SerializeField] private float yOffset;
    
    [SerializeField] private float zAmplitude;

    [SerializeField] private float zOffset;

    private static bool canTrack;
    
    private String X;
    private String Y;
    private String radius;
    private String userDir;
    private Data data;
    //private CamOffset offset;
    
    private void Awake()
    {
        canTrack = false;
        data = new Data();
        //offset = new CamOffset();
        userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        userDir += "\\Documents\\data.json";
        canTrack = true;
        //StartCoroutine(Tracker());
    }

    // IEnumerator Tracker()
    // {
    //     while (true)
    //     {
    //         if (!canTrack) 
    //             continue;
    //         
    //         String json = "";
    //         String[] lines = null;
    //         bool isReadable = true;
    //         try
    //         {
    //             lines = System.IO.File.ReadAllLines(@userDir);
    //         }
    //         catch (Exception e)
    //         {
    //             isReadable = false;
    //             print("Erreur de lecture");
    //         }
    //
    //         if (isReadable)
    //         {
    //             foreach (String line in lines)
    //             {
    //                 json += line;
    //             }
    //
    //             data = JsonUtility.FromJson<Data>(json);
    //         }
    //
    //         X = data.x;
    //         Y = data.y;
    //         radius = data.z;
    //
    //         float y = (float.Parse(Y) / yAmplitude);
    //         print(y.ToString());
    //         
    //         transform.localPosition = Vector3.Lerp(transform.localPosition,
    //             new Vector3((float.Parse(X) / xAmplitude)+ xOffset/* - offset.xOffset*/,
    //                 y,
    //                 (zOffset + zAmplitude * float.Parse(radius) + 0.7f/* - offset.zOffset*/)),
    //             0.04f);
    //
    //         
    //         yield return new WaitForSeconds(0.05f);
    //     }
    // }

    private void Update()
    {
        if (!canTrack) 
            return;
        
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
            new Vector3((xOffset + float.Parse(X) / xAmplitude),
                (4.5f + float.Parse(Y) / yAmplitude),
                (zOffset + zAmplitude * float.Parse(radius) + 0.7f)),
            0.3f);
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Alpha1))
    //     {
    //         ProcessCameraOffset();
    //     }
    // }
    //
    // private void ProcessCameraOffset()
    // {
    //     offset.xOffset = 0 - float.Parse(data.x);
    //     offset.yOffset = 4.5f - float.Parse(data.y);
    //     offset.zOffset = 0.7f - float.Parse(data.z);
    // }
    //
    // private class CamOffset
    // {
    //     public float xOffset = 0;
    //     
    //     public float yOffset = 0;
    //     
    //     public float zOffset = 0;
    // }

    [Serializable]
    private class Data
    {
        public String x;
        
        public String y;
        
        public String z;
    }
}