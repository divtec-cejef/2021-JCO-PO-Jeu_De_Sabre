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
        EXHAUSTED,
        STUN
    }
    
    private List<Material> sad;
    private List<Material> angry;
    private List<Material> hurt;
    private List<Material> happy;
    private List<Material> exhausted;
    private List<Material> stun;
    
    private bool resetFace = false;
    private float timer;
    private GameObject playerFace;

    private void Awake()
    {
        timer = 0;
        sad = EmotePlayer.GetSadEmote();
        angry = EmotePlayer.GetAngryEmote();
        hurt = EmotePlayer.GetHurtEmote();
        happy = EmotePlayer.GetHappyEmote();
        exhausted = EmotePlayer.GetExhaustedEmote();
    }

    public Material GetRandomEmote(EMOTE_TYPE type, GameObject playerFace, float resetTime, bool resetFace)
    {
        int rand;
        Material currentEmote;
        switch (type)
        {
            case EMOTE_TYPE.SAD:
                rand = Random.Range(0, sad.Count - 1);
                currentEmote =  sad[rand];
                break;
            case EMOTE_TYPE.ANGRY:
                rand = Random.Range(0, angry.Count - 1);
                currentEmote = angry[rand];
                break;
            case EMOTE_TYPE.HURT:
                rand = Random.Range(0, hurt.Count - 1);
                currentEmote = hurt[rand];
                break;
            case EMOTE_TYPE.HAPPY:
                rand = Random.Range(0, happy.Count - 1);
                currentEmote = happy[rand];
                break;
            case EMOTE_TYPE.EXHAUSTED:
                rand = Random.Range(0, exhausted.Count - 1);
                currentEmote = exhausted[rand];
                break;
            case EMOTE_TYPE.STUN:
                rand = Random.Range(0, stun.Count - 1);
                currentEmote = stun[rand];
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        if (resetFace) StartCoroutine(ResetFace(playerFace, resetTime));
                 
        return currentEmote;
    }
    
    public Material GetRandomEmote(EMOTE_TYPE type, GameObject playerFace, bool resetFace)
    {
        return GetRandomEmote(type, playerFace, 1f, resetFace);
    }

    IEnumerator ResetFace(GameObject playerFace, float timer)
    {
        yield return new WaitForSeconds(timer);
        if (0 == Random.Range(0, 1))
        {
            playerFace.GetComponent<Renderer>().material =
                GetRandomEmote(EMOTE_TYPE.HAPPY, playerFace, 0, false); 
        }
        else
        {
            playerFace.GetComponent<Renderer>().material =
                GetRandomEmote(EMOTE_TYPE.ANGRY, playerFace, 0, false); 
        }
    }
}
