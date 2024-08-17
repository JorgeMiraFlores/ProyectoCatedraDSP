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
    public partial class Tipos : Form
    {
        Conexion conexion = new Conexion();
        public Tipos()
        {
            InitializeComponent();
        }

        private void Tipos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            DataTable dt = conexion.ObtenerDatos("tipo");
            dataGridView1.DataSource = dt;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            string name = "";
            Dashboard dashboard = new Dashboard(name);

            dashboard.Show();

            this.Hide();
        }

        private void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            if (txtBoxTipoNombre.Text.Length > 0)
            {
                string nombreTipo = txtBoxTipoNombre.Text;
                conexion.AgregarTipos(nombreTipo);

                CargarDatos();

            }
            else
            {
                MessageBox.Show("Ingrese el nombre la nueva marca");
                return;
            }
        }
    }
}
