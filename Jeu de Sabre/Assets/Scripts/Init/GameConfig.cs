using System;

namespace Init
{
    [Serializable]
    public class GameConfig
    {
        // Stockage de toutes les valeurs récupérées dans le fichier de configuration
        public int game_time;
        
        public int run_out_of_time;
        
        public float parade_duration;
        
        public int parade_multiplier;
        
        public float parade_stamina_decrease_rate;
        
        public float stamina_amount;
        
        public float stamina_regeneration_rate;
        
        public float stamina_regeneration_time;
        
        public int attack_score_amount;
        
        public float attack_stamina_decrease;
        
        public int stun_multiplier;
        
        public float katana_lerp_duration;

        public int player_health_amount;

        public int player_health_decrease;
    }
}
