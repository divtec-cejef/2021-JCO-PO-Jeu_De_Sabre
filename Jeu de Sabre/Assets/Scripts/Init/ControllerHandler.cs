using System;

namespace Init
{
    public class ControllerHandler
    {
        private IntPtr controller_1;
        private IntPtr controller_2;
    
        public ControllerHandler(IntPtr controller_1, IntPtr controller_2)
        {
            this.controller_1 = controller_1;
            this.controller_2 = controller_2;
        }
    
        /// <summary>
        /// Permet de récupérer la manette 1
        /// </summary>
        /// <returns>La manette 1</returns>
        public IntPtr getController1()
        {
            return controller_1;
        }
    
        /// <summary>
        /// Permet de récupérer la manette 2
        /// </summary>
        /// <returns>La manette 2</returns>
        public IntPtr getController2()
        {
            return controller_2;
        }
    }
}
