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

        public float parade_recovery;
        
        public int parade_stun;
        
        public float parade_stamina_decrease_rate;
        
        public float stamina_amount;
        
        public float stamina_regeneration_rate;
        
        public float stamina_regeneration_time;
        
        public int attack_score_amount;
        
        public float attack_stamina_decrease;
        
        public float stun_multiplier;
        
        public float katana_lerp_duration;

        public int player_health_amount;

        public int player_health_decrease;

        public int player_bonus_point;

        public float player_bonus_point_speed;

        public float rotation_time_min;
        
        public float rotation_time_max;

        public float rotation_angle_min;

        public float rotation_angle_max;

        public float backward_mouvement_chance;

        public float backward_distance_min;

        public float backward_distance_max;

        public float camera_shaking_force_attacker;

        public float camera_shaking_duration_attacker;
        
        public float camera_shaking_force_defender;

        public float camera_shaking_duration_defender;
    }
}
