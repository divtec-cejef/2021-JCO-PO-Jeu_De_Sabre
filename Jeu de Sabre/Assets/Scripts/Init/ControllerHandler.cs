using System;

namespace Init
{
    public class ControllerHandler
    {
        private IntPtr player1Controller;

        private IntPtr player2Controller;

        /// <summary>
        /// Constructeur de ControllerHandler
        /// </summary>
        /// <param name="player1Controller">La manette du joueur 1</param>
        /// <param name="player2Controller">La manette du joueur 2</param>
        public ControllerHandler(IntPtr player1Controller, IntPtr player2Controller)
        {
            this.player1Controller = player1Controller;
            this.player2Controller = player2Controller;
        }

        /// <summary>
        /// Permet de récupérer la manette 1
        /// </summary>
        /// <returns>La manette 1</returns>
        public IntPtr GetPlayer1Controller()
        {
            return player1Controller;
        }

        /// <summary>
        /// Permet de récupérer la manette 2
        /// </summary>
        /// <returns>La manette 2</returns>
        public IntPtr GetPlayer2Controller()
        {
            return player2Controller;
        }
    }
}