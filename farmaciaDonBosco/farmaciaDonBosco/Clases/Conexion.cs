using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace farmaciaDonBosco
{
    internal class Conexion
    {
        MySqlConnection cnx = new MySqlConnection();

        static string servidor = "localhost";
        static string db = "farmacia_don_bosco";
        static string usuario = "root";
        static string password = "";
        static string port = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + port + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + db + ";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                cnx.ConnectionString = cadenaConexion;
                cnx.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }

            return cnx;
        }

        public bool EvaluarLogin(string nombreUsuario, string contrasena)
        {
            try
            {
                establecerConexion();

                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @nombreUsuario AND password = @contrasena";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                cnx.Close();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al evaluar login: " + ex.Message);
                return false;
            }
        }
    }
}
