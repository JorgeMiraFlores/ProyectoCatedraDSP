using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmaciaDonBosco
{
    public partial class Marcas : Form
    {
        public Marcas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Marcas_Load(object sender, EventArgs e)
        {
            CargarDatos();


            //this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            //this.WindowState = FormWindowState.Maximized;
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            string name = "";
            Dashboard dashboard = new Dashboard(name);

            dashboard.Show();

            this.Hide();
        }


        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            DataTable dt = conexion.ObtenerDatos("marcas");
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
