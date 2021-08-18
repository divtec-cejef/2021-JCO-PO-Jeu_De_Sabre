using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EmoteHandler : MonoBehaviour
{
    public enum EMOTE_TYPE
    {
        SAD,
        ANGRY,
        HURT,
        HAPPY,
        EXHAUSTED
    }
    
    private List<Material> sad;
    private List<Material> angry;
    private List<Material> hurt;
    private List<Material> happy;
    private List<Material> exhausted;
    
    private bool resetFace = false;
    private float timer;
    private GameObject playerFace;

    private void Awake()
    {
        //print("Awake!");
        timer = 0;
    }

    public void SetEmote(EMOTE_TYPE type, GameObject playerFace, float resetTime, bool resetFace)
    {
        playerFace.GetComponent<Renderer>().material = GetRandomEmote(type, playerFace, resetTime, resetFace);
    }
    
    public void SetEmote(EMOTE_TYPE type, GameObject playerFace, bool resetFace)
    {
        playerFace.GetComponent<Renderer>().material = GetRandomEmote(type, playerFace, 1f, resetFace);
    }
    
    
    public Material GetRandomEmote(EMOTE_TYPE type, GameObject playerFace, float resetTime, bool resetFace)
    {
        int rand;
        int counter;
        Material currentEmote;

        sad = EmotePlayer.GetSadEmote();
        angry = EmotePlayer.GetAngryEmote();
        hurt = EmotePlayer.GetHurtEmote();
        happy = EmotePlayer.GetHappyEmote();
        exhausted = EmotePlayer.GetExhaustedEmote();

        switch (type)
        {
            case EMOTE_TYPE.SAD:
                //List<Material> sad = EmotePlayer.GetSadEmote();
                counter = sad.Count;
                rand = Random.Range(0, counter);
                currentEmote =  sad[rand];
                break;
            case EMOTE_TYPE.ANGRY:
                counter = angry.Count;
                rand = Random.Range(0, counter);
                currentEmote = angry[rand];
                break;
            case EMOTE_TYPE.HURT:
                counter = hurt.Count;
                rand = Random.Range(0, counter);
                currentEmote = hurt[rand];
                break;
            case EMOTE_TYPE.HAPPY:
                counter = happy.Count;
                rand = Random.Range(0, counter);
                currentEmote = happy[rand];
                break;
            case EMOTE_TYPE.EXHAUSTED:
                // int counter = exhausted.Count - 1;
                //
                // if (counter > 0) rand = Random.Range(0, exhausted.Count - 1);
                // else rand = 0;
                currentEmote = exhausted[0];
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        //if (resetFace) StartCoroutine(ResetFace(playerFace, resetTime));
                 
        return currentEmote;
    }
    
    public Material GetRandomEmote(EMOTE_TYPE type, GameObject playerFace, bool resetFace)
    {
        return GetRandomEmote(type, playerFace, 1f, resetFace);
    }

    public void ResetFace(GameObject playerFace)
    {
        if (0 == Random.Range(0, 2))
            playerFace.GetComponent<Renderer>().material = GetRandomEmote(EMOTE_TYPE.HAPPY, playerFace, 0, false);
        else
            playerFace.GetComponent<Renderer>().material = GetRandomEmote(EMOTE_TYPE.ANGRY, playerFace, 0, false);
    }
}
