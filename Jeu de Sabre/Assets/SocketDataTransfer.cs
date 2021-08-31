using System;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using Init;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[Obsolete]
public class SocketDataTransfer : MonoBehaviour
{
    public String X;
    public String Y;
    public String radius;
    private String userDir;
    private Data data;
    
    private void Awake()
    {
        data = new Data();
        userDir = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        userDir += "\\Documents\\data.json";

        //StartCoroutine(UpdatePos());
    }

    private void Update()
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
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(float.Parse(X) / 5, float.Parse(Y) / 10, -10f * float.Parse(radius)), 1f);
    }
    
    [Serializable]
    public class Data
    {
        public String x;
        
        public String y;
        
        public String z;
    }
}
