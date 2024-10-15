using farmaciaDonBosco.FormsGestion;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            // Mostrar el nombre del usuario en la barra de título
            lblWelcome.Text = $"Dashboard - Bienvenido {Usuario.Nombre}";

            // Verificar el rol del usuario y habilitar controles
            if (Usuario.Rol == "Administrador")
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
            }
            else if (Usuario.Rol == "Cajero")
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
        }

        private void btnMarcasGo_Click(object sender, EventArgs e)
        {
            //Dirige al formulario de marcas

            Marcas Marcas = new Marcas();

            Marcas.Show();

            this.Hide();
        }

        private void btnFabricGo_Click(object sender, EventArgs e)
        {
            //Dirige al formulario de marcas

            Fabricantes Marcas = new Fabricantes();

            Marcas.Show();

            this.Hide();

        }

        private void btnTiposGo_Click(object sender, EventArgs e)
        {
            //Dirige al formulario de marcas

            Tipos Marcas = new Tipos();

            Marcas.Show();

            this.Hide();
        }

        private void btnProducGo_Click(object sender, EventArgs e)
        {
            //Dirige al formulario de marcas

            Productos Marcas = new Productos();

            Marcas.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario.CerrarSesion();
            Login login = new Login();

            login.Show();

            this.Hide();
        }


        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Detiene la aplicación
            Application.Exit();
        }

        private void btnUsuariosForm_Click(object sender, EventArgs e)
        {
            //Dirige al formulario de marcas

            Usuarios Usuarios = new Usuarios();

            Usuarios.Show();

            this.Hide();
        }

        private void btnFacturaGo_Click(object sender, EventArgs e)
        {

            GenerarFactura GenerarFactura = new GenerarFactura();

            GenerarFactura.Show();

            this.Hide();
        }

        private void btnHistGo_Click(object sender, EventArgs e)
        {
            HistorialFactura HistorialFactura = new HistorialFactura();

            HistorialFactura.Show();

            this.Hide();
        }

        private void btnAgregarRoles_Click(object sender, EventArgs e)
        {
            HistorialFactura HistorialFactura = new HistorialFactura();

            HistorialFactura.Show();

            this.Hide();
        }
    }
}
