using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EmoteHandler
{
    public enum EMOTE_TYPE
    {
        SAD,
        ANGRY,
        HURT,
        HAPPY
    }
    
    private List<Material> sad;
    private List<Material> angry;
    private List<Material> hurt;
    private List<Material> happy;

    public EmoteHandler()
    {
        sad = EmotePlayer.GetSadEmote();
        angry = EmotePlayer.GetAngryEmote();
        hurt = EmotePlayer.GetHurtEmote();
        happy = EmotePlayer.GetHappyEmote();
    }

    public Material GetRandomEmote(EMOTE_TYPE type)
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
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        return currentEmote;
    }
    
}
