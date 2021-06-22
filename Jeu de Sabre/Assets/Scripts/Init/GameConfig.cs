using System;
[Serializable]
public class GameConfig
{
    public int game_time;
    public int run_out_of_time;
    public float parade_duration;
    public int parade_multiplier;
    public float parade_stamina_decrease_rate;
    public float stamina_amount;
    public float stamina_regeneration_rate;
    public int attack_score_amount;
    public float attack_stamina_decrease;
    public int stun_multiplier;
    public float katana_lerp_duration;
    

    // public String getValue()
    // {
    //     return game_time + " " + run_out_of_time + " " + parade_duration + " " + parade_multiplier + " " +
    //            parade_stamina_decrease_rate + " " + stamina_amount + " " + stamina_regeneration_rate + " " +
    //            attack_score_amount + " " +
    //            attack_stamina_decrease + " " + stun_multiplier + " " + katana_lerp_duration;
    // }
}
