using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Tracker_1 : MonoBehaviour
{
    [SerializeField] private float xOffset;
    
    [SerializeField] private float yOffset;
    
    [SerializeField] private float zAmplitude;

    [SerializeField] private float zOffset;
    
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
        
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(float.Parse(X) / xOffset, 5 + float.Parse(Y) / yOffset, zOffset + zAmplitude * float.Parse(radius)), 1f);
    }
    
    [Serializable]
    public class Data
    {
        public String x;
        
        public String y;
        
        public String z;
    }
}