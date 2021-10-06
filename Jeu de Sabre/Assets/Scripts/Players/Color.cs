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
        
        [SerializeField] private Material playerRedHatTrans;
        [SerializeField] private Material playerBlueHatTrans;
        [SerializeField] private Material playerGreenHatTrans;
        [SerializeField] private Material playerPinkHatTrans;
        [SerializeField] private Material playerOrangeHatTrans;
        [SerializeField] private Material playerYellowHatTrans;
        [SerializeField] private Material playerBlackHatTrans;
        [SerializeField] private Material playerWhiteHatTrans;
        [SerializeField] private Material playerMagentaHatTrans;
        [SerializeField] private Material playerBrownHatTrans;
        [SerializeField] private Material playerCyanHatTrans;
        [SerializeField] private Material playerLimeHatTrans;
        
        [SerializeField] private Material playerRedClothesTrans;
        [SerializeField] private Material playerBlueClothesTrans;
        [SerializeField] private Material playerGreenClothesTrans;
        [SerializeField] private Material playerPinkClothesTrans;
        [SerializeField] private Material playerOrangeClothesTrans;
        [SerializeField] private Material playerYellowClothesTrans;
        [SerializeField] private Material playerBlackClothesTrans;
        [SerializeField] private Material playerWhiteClothesTrans;
        [SerializeField] private Material playerMagentaClothesTrans;
        [SerializeField] private Material playerBrownClothesTrans;
        [SerializeField] private Material playerCyanClothesTrans;
        [SerializeField] private Material playerLimeClothesTrans;
        
        /// <summary>
        /// Permet d'appliquer les bonnes couleurs au joueur
        /// </summary>
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
                1 => new UnityEngine.Color(255, 0, 0),
                2 => new UnityEngine.Color(0, 50, 200),
                3 => new UnityEngine.Color(0, 200, 0),
                4 => new UnityEngine.Color(255, 0, 220),
                5 => new UnityEngine.Color(255, 150, 0),
                6 => new UnityEngine.Color(255, 255, 0),
                7 => new UnityEngine.Color(0, 0, 0),
                8 => new UnityEngine.Color(255, 255, 255),
                9 => new UnityEngine.Color(180, 0, 255),
                10 => new UnityEngine.Color(70, 30, 0),
                11 => new UnityEngine.Color(0, 255, 255),
                12 => new UnityEngine.Color(0, 255, 0),
                _ => new UnityEngine.Color(255, 0, 0)
            };
            
            Material player1ClothesTrans = color1 switch
            {
                1 => playerRedClothesTrans,
                2 => playerBlueClothesTrans,
                3 => playerGreenClothesTrans,
                4 => playerPinkClothesTrans,
                5 => playerOrangeClothesTrans,
                6 => playerYellowClothesTrans,
                7 => playerBlackClothesTrans,
                8 => playerWhiteClothesTrans,
                9 => playerMagentaClothesTrans,
                10 => playerBrownClothesTrans,
                11 => playerCyanClothesTrans,
                12 => playerLimeClothesTrans,
                _ => playerRedClothesTrans
            };
            Material player1HatTrans = color1 switch
            {
                1 => playerRedHatTrans,
                2 => playerBlueHatTrans,
                3 => playerGreenHatTrans,
                4 => playerPinkHatTrans,
                5 => playerOrangeHatTrans,
                6 => playerYellowHatTrans,
                7 => playerBlackHatTrans,
                8 => playerWhiteHatTrans,
                9 => playerMagentaHatTrans,
                10 => playerBrownHatTrans,
                11 => playerCyanHatTrans,
                12 => playerLimeHatTrans,
                _ => playerRedHatTrans
            };
            
            // Application des couleurs et des materiaux au objet
            main1D.GetComponent<Renderer>().material.color = player1TransColor;
            main1G.GetComponent<Renderer>().material.color = player1TransColor;
            
            hat1.GetComponent<Renderer>().material = player1Hat;
            body1.GetComponent<Renderer>().material = player1Clothes;
            leg1.GetComponent<Renderer>().material = player1Clothes;
            
            hatTrans1.GetComponent<Renderer>().material = player1HatTrans;
            bodyTrans1.GetComponent<Renderer>().material = player1ClothesTrans;
            legTrans1.GetComponent<Renderer>().material = player1ClothesTrans;
            
            
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
            Material player2ClothesTrans = color2 switch
            {
                1 => playerRedClothesTrans,
                2 => playerBlueClothesTrans,
                3 => playerGreenClothesTrans,
                4 => playerPinkClothesTrans,
                5 => playerOrangeClothesTrans,
                6 => playerYellowClothesTrans,
                7 => playerBlackClothesTrans,
                8 => playerWhiteClothesTrans,
                9 => playerMagentaClothesTrans,
                10 => playerBrownClothesTrans,
                11 => playerCyanClothesTrans,
                12 => playerLimeClothesTrans,
                _ => playerRedClothesTrans
            };
            Material player2HatTrans = color2 switch
            {
                1 => playerRedHatTrans,
                2 => playerBlueHatTrans,
                3 => playerGreenHatTrans,
                4 => playerPinkHatTrans,
                5 => playerOrangeHatTrans,
                6 => playerYellowHatTrans,
                7 => playerBlackHatTrans,
                8 => playerWhiteHatTrans,
                9 => playerMagentaHatTrans,
                10 => playerBrownHatTrans,
                11 => playerCyanHatTrans,
                12 => playerLimeHatTrans,
                _ => playerRedHatTrans
            };
            // Application des couleurs et des materiaux au objet
            main2D.GetComponent<Renderer>().material.color = player2TransColor;
            main2G.GetComponent<Renderer>().material.color = player2TransColor;
            
            hat2.GetComponent<Renderer>().material = player2Hat;
            body2.GetComponent<Renderer>().material = player2Clothes;
            leg2.GetComponent<Renderer>().material = player2Clothes;

            hatTrans2.GetComponent<Renderer>().material = player2HatTrans;
            bodyTrans2.GetComponent<Renderer>().material = player2ClothesTrans;
            legTrans2.GetComponent<Renderer>().material = player2ClothesTrans;
        }
    }
}