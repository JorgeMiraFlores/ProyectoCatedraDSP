using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmaciaDonBosco.FormsGestion
{
    public partial class Fabricantes : Form
    {
        public Fabricantes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Fabricantes_Load(object sender, EventArgs e)
        {

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

       
    }
}
