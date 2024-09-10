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

        Conexion conexion = new Conexion();

        public Login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            //Picture box con imagen de la farmacia
            //pictureBox1.ImageLocation = @"C:\iconLogin.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Obtener las credenciales del formulario (asumiendo que tienes dos TextBox: txtUsuario y txtContrasena)
            string nombreUsuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;


            bool esValido = conexion.EvaluarLogin(nombreUsuario, contrasena);

            if (esValido)
            {
                // Si las credenciales son válidas, abrir el formulario Dashboard
                MessageBox.Show("Inicio de sesión exitoso.");
                Dashboard dashboardForm = new Dashboard("xd");
                dashboardForm.Show();

                // Cerrar el formulario de login actual
                this.Hide();
            }
            else
            {
                // Si las credenciales son inválidas, mostrar un mensaje de error
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
