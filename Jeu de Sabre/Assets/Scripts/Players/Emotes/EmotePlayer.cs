using System.Collections.Generic;
using Players;
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
    [SerializeField] private Material exhausted_1;
    [SerializeField] private Material death_1;
    [SerializeField] private  ParticleSystem player1Menacing;
    [SerializeField] private  ParticleSystem player2Menacing;
    
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
    private static Material _exhausted_1;
    private static Material _death_1;
    private static ParticleSystem _player1Menacing;
    private static ParticleSystem _player2Menacing;

    private void Awake()
    {
        //print("AWAKE");
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

        _exhausted_1 = exhausted_1;

        _death_1 = death_1;
        
        _player1Menacing = player1Menacing;
        _player2Menacing = player2Menacing;
        
        _player1Menacing.Stop();
        _player2Menacing.Stop();
    }

    /// <summary>
    /// Permet de récupérer les emotes SAD
    /// </summary>
    /// <returns>Une liste d'emote SAD</returns>
    public static List<Material> GetSadEmote()
    {
        List<Material> sad = new List<Material>();
        sad.Add(_sad_1);
        sad.Add(_sad_2);
        sad.Add(_sad_3);

        return sad;
    }
    
    /// <summary>
    /// Permet de récupérer les emotes ANGRY
    /// </summary>
    /// <returns>Une liste d'emote ANGRY</returns>
    public static List<Material> GetAngryEmote()
    {
        List<Material> angry = new List<Material>();
        angry.Add(_angry_1);
        angry.Add(_angry_2);
        angry.Add(_angry_3);

        print(angry);
        
        return angry;
    }
    
    /// <summary>
    /// Permet de récupérer les emotes HURT
    /// </summary>
    /// <returns>Une liste d'emote HURT</returns>
    public static List<Material> GetHurtEmote()
    {
        List<Material> hurt = new List<Material>();
        hurt.Add(_hurt_1);
        hurt.Add(_hurt_2);
        hurt.Add(_hurt_3);

        return hurt;
    }
    
    /// <summary>
    /// Permet de récupérer les emotes HAPPY
    /// </summary>
    /// <returns>Une liste d'emote HAPPY</returns>
    public static List<Material> GetHappyEmote()
    {
        List<Material> happy = new List<Material>();
        happy.Add(_happy_1);
        happy.Add(_happy_2);
        happy.Add(_happy_3);

        return happy;
    }
    
    /// <summary>
    /// Permet de récupérer le emote EXHAUSTED
    /// </summary>
    /// <returns>Une liste d'emote EXHAUSTED</returns>
    public static List<Material> GetExhaustedEmote()
    {
        List<Material> exhausted = new List<Material>();
        exhausted.Add(_exhausted_1);
        return exhausted;
    }

    /// <summary>
    /// Permet de récupérer le emote DEATH
    /// </summary>
    /// <returns>Une liste d'emote DEATH</returns>
    public static List<Material> GetDeathEmote()
    {
        List<Material> death = new List<Material>();
        death.Add(_death_1);
        return death;
    }
    
    /// <summary>
    /// Permet d'appliquer l'effet de menage
    /// </summary>
    /// <param name="player">Le joueur auquel on souhaite ajouter l'effet</param>
    public static void SetMenacingEffect(Player.PLAYER player)
    {
        if(player == Player.PLAYER.P1)
        {
            _player1Menacing.Play(); 
        }else if (player == Player.PLAYER.P2)
        {
            _player2Menacing.Play();
        }

    }
}