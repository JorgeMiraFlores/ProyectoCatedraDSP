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

            this.StartPosition = FormStartPosition.CenterScreen;

            //Picture box con imagen de la farmacia
            pictureBox1.ImageLocation = @"C:\repositories\ProyectoCatedraDSP\farmaciaDonBosco\farmaciaDonBosco\resources\iconLogin.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Declarando el texto de los textbox: usuario y password
            string user = textBox1.Text;
            string pasword = textBox2.Text;

            Conexion conexion = new Conexion();

            if (conexion.EvaluarLogin(user, pasword))
            {
                string usuario = conexion.ObtenerUsuario(user);
                MessageBox.Show("Login exitoso, bienvenid@ "+usuario);

                
                Dashboard dashboard = new Dashboard(usuario);
               
                dashboard.Show();

                this.Hide();

            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else {
                textBox2.PasswordChar = '*';
            }

        }


    }
}
