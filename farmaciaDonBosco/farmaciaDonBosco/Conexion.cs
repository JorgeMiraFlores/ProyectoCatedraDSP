using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmaciaDonBosco
{
    internal class Conexion
    {
        private SqlConnection cnx;

        public Conexion()
        {
            try
            {
                string connectionString = "Server=root@localhost:3306;Database=farmacia_don_bosco;";
                cnx = new SqlConnection(connectionString);
                cnx.Open();

                MessageBox.Show("Conexion exitosa");
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("ERROR conexion: " + ex.Message);
                }
            }

        }
    }
}
