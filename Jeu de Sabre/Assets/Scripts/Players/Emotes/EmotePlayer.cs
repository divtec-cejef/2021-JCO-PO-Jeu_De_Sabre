using System.Collections.Generic;
using UnityEngine;

public class EmotePlayer : MonoBehaviour
{
    [SerializeField] private Material sad_1;
    [SerializeField] private Material sad_2;
    [SerializeField] private Material sad_3;
    [SerializeField] private Material angry_1;
    [SerializeField] private Material angry_2;
    [SerializeField] private Material angry_3;
    [SerializeField] private Material hurt_1;
    [SerializeField] private Material hurt_2;
    [SerializeField] private Material hurt_3;
    [SerializeField] private Material happy_1;
    [SerializeField] private Material happy_2;
    [SerializeField] private Material happy_3;
    
    private static Material _sad_1;
    private static Material _sad_2;
    private static Material _sad_3;
    private static Material _angry_1;
    private static Material _angry_2;
    private static Material _angry_3;
    private static Material _hurt_1;
    private static Material _hurt_2;
    private static Material _hurt_3;
    private static Material _happy_1;
    private static Material _happy_2;
    private static Material _happy_3;

    private void Awake()
    {
        _sad_1 = sad_1;
        _sad_2 = sad_2;
        _sad_3 = sad_3;

        _angry_1 = angry_1;
        _angry_2 = angry_2;
        _angry_3 = angry_3;

        _hurt_1 = hurt_1;
        _hurt_2 = hurt_2;
        _hurt_3 = hurt_3;

        _happy_1 = happy_1;
        _happy_2 = happy_2;
        _happy_3 = happy_3;
    }

    public static List<Material> GetSadEmote()
    {
        List<Material> sad = new List<Material>();
        sad.Add(_sad_1);
        sad.Add(_sad_2);
        sad.Add(_sad_3);

        return sad;
    }
    
    public static List<Material> GetAngryEmote()
    {
        List<Material> sad = new List<Material>();
        sad.Add(_angry_1);
        sad.Add(_angry_2);
        sad.Add(_angry_3);

        return sad;
    }
    
    public static List<Material> GetHurtEmote()
    {
        List<Material> sad = new List<Material>();
        sad.Add(_hurt_1);
        sad.Add(_hurt_2);
        sad.Add(_hurt_3);

        return sad;
    }
    
    public static List<Material> GetHappyEmote()
    {
        List<Material> sad = new List<Material>();
        sad.Add(_happy_1);
        sad.Add(_happy_2);
        sad.Add(_happy_3);

        return sad;
    }
    
}
