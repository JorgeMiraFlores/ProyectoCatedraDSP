using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace farmaciaDonBosco
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
            Conexion c = new Conexion();

            pictureBox1.ImageLocation = @"C:\repositories\ProyectoCatedraDSP\farmaciaDonBosco\farmaciaDonBosco\resources\iconLogin.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        

        }
    }
}
