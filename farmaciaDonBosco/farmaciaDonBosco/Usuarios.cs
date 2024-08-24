using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using farmaciaDonBosco.FormsGestion;
using System.Collections;

namespace farmaciaDonBosco
{
    public partial class Usuarios : Form
    {
        Conexion conexion = new Conexion();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
            txtBoxContra.PasswordChar = '*';
        }

        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            DataTable dt = conexion.ObtenerUsuarios();
            dataGVTipo.DataSource = dt;

            DataTable dtRoles = conexion.ObtenerDatos("roles");
            cBoxRoles.Items.Clear();
            foreach (DataRow row in dtRoles.Rows)
            {
                cBoxRoles.Items.Add(row[1].ToString());
            }
        }
        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            string name = "";
            Dashboard dashboard = new Dashboard(name);

            dashboard.Show();

            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtBoxContra.PasswordChar = '\0';
            }
            else
            {
                txtBoxContra.PasswordChar = '*';
            }

        }

        private void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            if (txtBoxNombre.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Por favor, añada un nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cBoxRoles.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Por favor, añada un rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtBoxUsuario.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Por favor, añada un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtBoxContra.Text.Length > 0) { }
            else
            {
                MessageBox.Show("Por favor, añada una contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rolSeleccionado = cBoxRoles.SelectedItem.ToString();

            int idUsuario = 0;
            if (!string.IsNullOrEmpty(txtBoxID.Text))
            {
                if (int.TryParse(txtBoxID.Text, out idUsuario))
                {
                    // La conversión fue exitosa, `idProductos` tiene un valor entero válido.
                }
                else
                {
                    // Manejar el caso donde la conversión falla.
                    MessageBox.Show("El ID del producto no es válido. Por favor, introduce un número entero.");
                }
            }

            string nombre = txtBoxNombre.Text;
            int idRol = conexion.ObtenerIdObjeto(rolSeleccionado, "idRoles", "roles");
            string usuario = txtBoxUsuario.Text;
            string contra = txtBoxContra.Text;

            if (idRol != -1) { }
            else
            {
                MessageBox.Show("No se encontró el ID del rol seleccionad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnAgregarTipo.Text == "Actualizar")
            {
                conexion.ActualizarUsuarios(idUsuario, nombre, idRol, usuario, contra);

                VaciarGrillas();
                ocultarId();
                btnAgregarTipo.Text = "Agregar";

                CargarDatos();
            }
            else if (btnAgregarTipo.Text == "Agregar")
            {
                bool exito = conexion.AgregarUsuario(nombre, idRol, usuario, contra);
                if (exito)
                {
                    VaciarGrillas();
                    CargarDatos();
                }
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (ComprobarGrillasLlenas() && txtBoxID.Visible == false)
            {
                VaciarGrillas();
                MessageBox.Show("Los campos de texto de insersión han sido vaciados");
            }
            else if (ComprobarGrillasLlenas() && txtBoxID.Visible == true)
            {
                VaciarGrillas();
                MessageBox.Show("Los campos de texto de actualización han sido vaciados");
                txtBoxID.Visible = false;
                label9.Visible = false;
                btnAgregarTipo.Text = "Agregar";
            }
            else if (!ComprobarGrillasLlenas() || txtBoxID.Visible == false)
            {
                MessageBox.Show("Los campos de texto ya están vacios");

            }
        }
        private bool ComprobarGrillasLlenas()
        {
            if (!string.IsNullOrWhiteSpace(txtBoxID.Text) ||
                !string.IsNullOrWhiteSpace(txtBoxNombre.Text) ||
                cBoxRoles.SelectedIndex != -1 ||
                !string.IsNullOrWhiteSpace(txtBoxContra.Text) ||
                !string.IsNullOrWhiteSpace(txtBoxUsuario.Text))
            {
                return true;
            }

            return false;
        }

        private void VaciarGrillas()
        {
            txtBoxID.Text = string.Empty;
            txtBoxNombre.Text = string.Empty;
            txtBoxUsuario.Text = string.Empty;
            txtBoxContra.Text = string.Empty;
            cBoxRoles.Text = string.Empty; 
        }

        private void ocultarId()
        {
            label9.Visible = false;
            txtBoxID.Visible = false;
        }
        private void mostrarId()
        {
            label9.Visible = true;
            txtBoxID.Visible = true;
        }

        private void dataGVTipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGVTipo.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGVTipo.SelectedRows[0];

                // Cargar los datos de la fila en los controles
                txtBoxID.Text = filaSeleccionada.Cells["idUsuarios"].Value.ToString();
                txtBoxUsuario.Text = filaSeleccionada.Cells["usuario"].Value.ToString();
                cBoxRoles.SelectedItem = filaSeleccionada.Cells["nombreRol"].Value.ToString();
                txtBoxNombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();
                txtBoxContra.Text = filaSeleccionada.Cells["password"].Value.ToString();

                string usuarioSeleccionado = filaSeleccionada.Cells["usuario"].Value.ToString();

                btnAgregarTipo.Text = "Actualizar";

                btnEliminar.Enabled = true;
                mostrarId();

                MessageBox.Show("Datos de usuario " + usuarioSeleccionado + " añadidos campos, listos para ser actualizados.", "Usuario Listo para Actualizar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGVTipo.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idUsuarios = Convert.ToInt32(dataGVTipo.SelectedRows[0].Cells["idUsuarios"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    bool exito = conexion.EliminarObjeto(idUsuarios, "usuarios", "idUsuarios");

                    if (exito)
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Recargar los datos
                        VaciarGrillas();
                        ocultarId();    
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este usuario.", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.", "Eliminar usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
