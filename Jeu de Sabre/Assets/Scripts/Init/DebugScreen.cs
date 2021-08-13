using Mouvements.Orientation;
using Players;
using TMPro;
using UnityEngine;

namespace Init
{
    public class DebugScreen : MonoBehaviour
    {
        public GameObject debugMenuUi;
    
        public TextMeshProUGUI frameRate;
    
        public TextMeshProUGUI stamina1;
    
        public TextMeshProUGUI stamina2;
    
        public TextMeshProUGUI isParade1;
    
        public TextMeshProUGUI isParade2;
    
        public TextMeshProUGUI isReady1;
    
        public TextMeshProUGUI isReady2;
    
        public TextMeshProUGUI paradeTimer1;
    
        public TextMeshProUGUI paradeTimer2;
    
        public TextMeshProUGUI cooldownTimer1;
    
        public TextMeshProUGUI cooldownTimer2;
    
        public TextMeshProUGUI psMoveOrientation1;
    
        public TextMeshProUGUI psMoveOrientation2;
    
        public TextMeshProUGUI katanaOrientation1;
    
        public TextMeshProUGUI katanaOrientation2;
    
        public TextMeshProUGUI screenCountText;
    
        public static int screenCount;

        private float time = 0.0f;
        private int frame;
        private int fps;
        private bool isDebugMenuOn = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F3))
            {
                if (!isDebugMenuOn)
                    LoadDebugMenu();
                else
                    UnloadDebugMenu();
            }

            if (!isDebugMenuOn) return;
        
            KatanaOrientation orientation1 = GameInit.GetPlayer1KatanaOrientation();
            KatanaOrientation orientation2 = GameInit.GetPlayer2KatanaOrientation();
        
            stamina1.text = Player.GetStamina(Player.PLAYER.P1).ToString();
            stamina2.text = Player.GetStamina(Player.PLAYER.P2).ToString();
        
            isParade1.text = orientation1.GetPlayerParade().GetParade().ToString();
            isParade2.text = orientation2.GetPlayerParade().GetParade().ToString();
        
            isReady1.text = orientation1.GetPlayerParade().GetReady().ToString();
            isReady2.text = orientation2.GetPlayerParade().GetReady().ToString();
        
            paradeTimer1.text = orientation1.GetPlayerParade().GetParadeTimer().ToString();
            paradeTimer2.text = orientation2.GetPlayerParade().GetParadeTimer().ToString();
        
            katanaOrientation1.text = orientation1.getCurrentQuaternion().ToString();
            katanaOrientation2.text = orientation2.getCurrentQuaternion().ToString();
        
            frameRate.text = fps.ToString();
        
            if (time > 1.0f)
            {
                fps = frame;
                frame = 0;
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
                frame++;
            }
        }

        private void Awake()
        {
            screenCountText.text = Display.displays.Length.ToString();
        }

        private void LoadDebugMenu()
        {
            debugMenuUi.SetActive(true);
            isDebugMenuOn = true;
        }

        private void UnloadDebugMenu()
        {
            debugMenuUi.SetActive(false);
            isDebugMenuOn = false;
        }
    }
}
