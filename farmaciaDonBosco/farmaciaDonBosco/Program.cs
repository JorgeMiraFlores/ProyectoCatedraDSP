using farmaciaDonBosco;
using farmaciaDonBosco.FormsGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmaciaDonBosco
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tipos());
            //Application.Run(new Login());
            //Application.Run(new Dashboard());
        }
    }
}
