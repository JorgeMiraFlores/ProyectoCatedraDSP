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
        public Dashboard(string usuario)
        {
            
            InitializeComponent();

            lblWelcome.Text = "Bienvenid@ "+ usuario;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
           //this.WindowState = FormWindowState.Maximized;
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

       
    }
}
