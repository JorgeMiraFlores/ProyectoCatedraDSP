using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
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

        string cadenaConexion = "server="+servidor+";"+"port="+port + ";" +"user id="+ usuario + ";" +"password="+password+";"+"database="+db+";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                cnx.ConnectionString = cadenaConexion;

                cnx.Open();

                MessageBox.Show("Conexion con exito");

             
            }
            catch (Exception ex) {
                MessageBox.Show("Error al conectar: " + ex);
            }

            return cnx;
        }



    }
}
