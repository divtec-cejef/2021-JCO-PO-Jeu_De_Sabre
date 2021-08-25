using System;

namespace Init
{
    public class ControllerHandler
    {
        private MoveAPI player1Controller;
        
        private MoveAPI player2Controller;
    
        public ControllerHandler(MoveAPI player1Controller, MoveAPI player2Controller)
        {
            this.player1Controller = player1Controller;
            this.player2Controller = player2Controller;
        }
    
        /// <summary>
        /// Permet de récupérer la manette 1
        /// </summary>
        /// <returns>La manette 1</returns>
        public MoveAPI GetPlayer1Controller()
        {
            return player1Controller;
        }
    
        /// <summary>
        /// Permet de récupérer la manette 2
        /// </summary>
        /// <returns>La manette 2</returns>
        public MoveAPI GetPlayer2Controller()
        {
            return player2Controller;
        }
    }
}
