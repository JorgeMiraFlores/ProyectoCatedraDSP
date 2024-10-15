using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmaciaDonBosco
{
    public static class Usuario
    {
        // Propiedades para almacenar los datos del usuario
        public static string UsuarioID { get; set; }
        public static string Nombre { get; set; }
        public static string Rol { get; set; }

        // Método opcional para limpiar los datos de la sesión
        public static void CerrarSesion()
        {
            Nombre = null;
            UsuarioID = null;
            Rol = null;
        }
    }
}
