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
    
    [SerializeField] private float yOffset;
    
    [SerializeField] private float zAmplitude;

    [SerializeField] private float zOffset;

    private static Thread _tracking1;
    
    private String X;
    private String Y;
    private String radius;
    private String userDir;
    private Data data;
    
    private void Awake()
    {
        data = new Data();
        userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        userDir += "\\Documents\\data.json";

        StartCoroutine(Tracker());
    }

    IEnumerator Tracker()
    {
        while (true)
        {
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
                new Vector3(xOffset +float.Parse(X) / xAmplitude, 5 + float.Parse(Y) / yOffset,
                    zOffset + zAmplitude * float.Parse(radius)), 0.3f);
    
            yield return new WaitForSeconds(0.03f);
        }
    }

    // private void Update()
    // {
    //     /*while (true)
    //     {*/
    //     String json = "";
    //     String[] lines = null;
    //     bool isReadable = true;
    //     try
    //     {
    //         lines = System.IO.File.ReadAllLines(@userDir);
    //     }
    //     catch (Exception e)
    //     {
    //         isReadable = false;
    //         print("Erreur de lecture");
    //     }
    //
    //     if (isReadable)
    //     {
    //         foreach (String line in lines)
    //         {
    //             json += line;
    //         }
    //
    //         data = JsonUtility.FromJson<Data>(json);
    //     }
    //
    //     X = data.x;
    //     Y = data.y;
    //     radius = data.z;
    //
    //     transform.localPosition = Vector3.Lerp(transform.localPosition,
    //         new Vector3(xOffset +float.Parse(X) / xAmplitude, 5 + float.Parse(Y) / yOffset,
    //             zOffset + zAmplitude * float.Parse(radius)), 0.3f);
    //
    //     //yield return new WaitForSeconds(0.05f);
    //     //}
    // }

    [Serializable]
    private class Data
    {
        public String x;
        
        public String y;
        
        public String z;
    }
}