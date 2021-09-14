using Init;
using UnityEngine;

namespace Players
{
    public class Color : MonoBehaviour
    {
        
        [SerializeField] private Material playerRedHat;
        [SerializeField] private Material playerBlueHat;
        [SerializeField] private Material playerGreenHat;
        [SerializeField] private Material playerPinkHat;
        [SerializeField] private Material playerOrangeHat;
        [SerializeField] private Material playerYellowHat;
        [SerializeField] private Material playerBlackHat;
        [SerializeField] private Material playerWhiteHat;
        [SerializeField] private Material playerMagentaHat;
        [SerializeField] private Material playerBrownHat;
        [SerializeField] private Material playerCyanHat;
        [SerializeField] private Material playerLimeHat;
        
        [SerializeField] private Material playerRedClothes;
        [SerializeField] private Material playerBlueClothes;
        [SerializeField] private Material playerGreenClothes;
        [SerializeField] private Material playerPinkClothes;
        [SerializeField] private Material playerOrangeClothes;
        [SerializeField] private Material playerYellowClothes;
        [SerializeField] private Material playerBlackClothes;
        [SerializeField] private Material playerWhiteClothes;
        [SerializeField] private Material playerMagentaClothes;
        [SerializeField] private Material playerBrownClothes;
        [SerializeField] private Material playerCyanClothes;
        [SerializeField] private Material playerLimeClothes;
        
        

        public void ApplyPlayerColor(GameObject hat1, GameObject body1, GameObject leg1, int color1, GameObject hat2, GameObject body2, GameObject leg2, int color2,
        GameObject hatTrans1, GameObject bodyTrans1, GameObject legTrans1, GameObject hatTrans2, GameObject bodyTrans2, GameObject legTrans2,
        GameObject main1G, GameObject main1D, GameObject main2G, GameObject main2D)
        {
            Material player1Clothes = color1 switch
            {
                1 => playerRedClothes,
                2 => playerBlueClothes,
                3 => playerGreenClothes,
                4 => playerPinkClothes,
                5 => playerOrangeClothes,
                6 => playerYellowClothes,
                7 => playerBlackClothes,
                8 => playerWhiteClothes,
                9 => playerMagentaClothes,
                10 => playerBrownClothes,
                11 => playerCyanClothes,
                12 => playerLimeClothes,
                _ => playerRedClothes
            };
            Material player1Hat = color1 switch
            {
                1 => playerRedHat,
                2 => playerBlueHat,
                3 => playerGreenHat,
                4 => playerPinkHat,
                5 => playerOrangeHat,
                6 => playerYellowHat,
                7 => playerBlackHat,
                8 => playerWhiteHat,
                9 => playerMagentaHat,
                10 => playerBrownHat,
                11 => playerCyanHat,
                12 => playerLimeHat,
                _ => playerRedHat
            };
            
            UnityEngine.Color player1TransColor = color1 switch
            {
                1 => new UnityEngine.Color(255, 0, 0, .03f),
                2 => new UnityEngine.Color(0, 50, 200, .03f),
                3 => new UnityEngine.Color(0, 200, 0, .03f),
                4 => new UnityEngine.Color(255, 0, 220, .03f),
                5 => new UnityEngine.Color(255, 150, 0, .03f),
                6 => new UnityEngine.Color(255, 255, 0, .03f),
                7 => new UnityEngine.Color(0, 0, 0, .03f),
                8 => new UnityEngine.Color(255, 255, 255, .03f),
                9 => new UnityEngine.Color(180, 0, 255, .03f),
                10 => new UnityEngine.Color(70, 30, 0, .03f),
                11 => new UnityEngine.Color(0, 255, 255, .03f),
                12 => new UnityEngine.Color(0, 255, 0, .03f),
                _ => new UnityEngine.Color(255, 0, 0, .03f)
            };
            //
            // hatTrans1.GetComponent<Renderer>().material.color = player1TransColor;
            // bodyTrans1.GetComponent<Renderer>().material.color = player1TransColor;
            // legTrans1.GetComponent<Renderer>().material.color = player1TransColor;
            // legTrans1.GetComponent<Renderer>().sha;
            main1D.GetComponent<Renderer>().material.color = player1TransColor;
            main1G.GetComponent<Renderer>().material.color = player1TransColor;
            
            hat1.GetComponent<Renderer>().material = player1Hat;
            body1.GetComponent<Renderer>().material = player1Clothes;
            leg1.GetComponent<Renderer>().material = player1Clothes;

            
            
            Material player2Clothes = color2 switch
            {
                1 => playerRedClothes,
                2 => playerBlueClothes,
                3 => playerGreenClothes,
                4 => playerPinkClothes,
                5 => playerOrangeClothes,
                6 => playerYellowClothes,
                7 => playerBlackClothes,
                8 => playerWhiteClothes,
                9 => playerMagentaClothes,
                10 => playerBrownClothes,
                11 => playerCyanClothes,
                12 => playerLimeClothes,
                _ => playerRedClothes
            };
            Material player2Hat = color2 switch
            {
                1 => playerRedHat,
                2 => playerBlueHat,
                3 => playerGreenHat,
                4 => playerPinkHat,
                5 => playerOrangeHat,
                6 => playerYellowHat,
                7 => playerBlackHat,
                8 => playerWhiteHat,
                9 => playerMagentaHat,
                10 => playerBrownHat,
                11 => playerCyanHat,
                12 => playerLimeHat,
                _ => playerRedHat
            };
            
            UnityEngine.Color player2TransColor = color2 switch
            {
                1 => new UnityEngine.Color(255, 0, 0, .03f),
                2 => new UnityEngine.Color(0, 50, 200, .03f),
                3 => new UnityEngine.Color(0, 200, 0, .03f),
                4 => new UnityEngine.Color(255, 0, 220, .03f),
                5 => new UnityEngine.Color(255, 150, 0, .03f),
                6 => new UnityEngine.Color(255, 255, 0, .03f),
                7 => new UnityEngine.Color(0, 0, 0, .03f),
                8 => new UnityEngine.Color(255, 255, 255, .03f),
                9 => new UnityEngine.Color(180, 0, 255, .03f),
                10 => new UnityEngine.Color(70, 30, 0, .03f),
                11 => new UnityEngine.Color(0, 255, 255, .03f),
                12 => new UnityEngine.Color(0, 255, 0, .03f),
                _ => new UnityEngine.Color(255, 0, 0, .03f)
            };
            //
            // hatTrans2.GetComponent<Renderer>().material.color = player2TransColor;
            // bodyTrans2.GetComponent<Renderer>().material.color = player2TransColor;
            // legTrans2.GetComponent<Renderer>().material.color = player2TransColor;
            main2D.GetComponent<Renderer>().material.color = player2TransColor;
            main2G.GetComponent<Renderer>().material.color = player2TransColor;
            
            hat2.GetComponent<Renderer>().material = player2Hat;
            body2.GetComponent<Renderer>().material = player2Clothes;
            leg2.GetComponent<Renderer>().material = player2Clothes;
        }
    }
}