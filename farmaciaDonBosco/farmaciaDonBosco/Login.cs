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
            pictureBox1.ImageLocation = @"C:\iconLogin.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Declarando el texto de los textbox: usuario y password
            string user = textBox1.Text;
            string password = textBox2.Text;

            Conexion conexion = new Conexion();

            if (conexion.EvaluarLogin(user, password))
            {
                // Obtener datos del usuario desde la base de datos
                string nombreUsuario = conexion.ObtenerUsuario(user);
                string rolUsuario = conexion.ObtenerRolUsuario(user);

                // Guardar los datos del usuario en la clase Usuario
                Usuario.Nombre = nombreUsuario;
                Usuario.UsuarioID = user;
                Usuario.Rol = rolUsuario;

                MessageBox.Show($"Login exitoso, bienvenid@ {Usuario.Nombre}");

                // Abrir el dashboard sin necesidad de pasar parámetros
                Dashboard dashboard = new Dashboard();
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
