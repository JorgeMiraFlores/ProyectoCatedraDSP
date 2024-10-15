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
            dataGVTipo.DataSource = dt;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();

            dashboard.Show();

            this.Hide();
        }

        private void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            string nombreTipo = txtBoxTipoNombre.Text;
            int idTipo = 0;
            if(txtBoxID.Text == string.Empty)
            {
                txtBoxID.Text = "0";
            }
            else
            {
                txtBoxID.Text = txtBoxID.Text;
            }
            if (int.TryParse(txtBoxID.Text, out idTipo))
            {
                // El valor es un número válido, puedes usar idTipo
            }
            else
            {
                // El valor en txtBoxID no es un número válido
                MessageBox.Show("Por favor, ingrese un número válido en el campo de ID.");
                return; // Salir del método para evitar continuar con un valor inválido
            }
            if (txtBoxTipoNombre.Text.Length > 0)
            {
                if (btnAgregarTipo.Text == "Agregar")
                {
                    conexion.AgregarCaracteristicas(nombreTipo, "tipo");
                    CargarDatos();
                    ocultarId();
                    VaciarGrillas();

                }else if(btnAgregarTipo.Text == "Actualizar")
                {                                        
                    conexion.ActualizarCaracteristicas(idTipo, nombreTipo, "tipo", "idTipo");
                    CargarDatos();
                    ocultarId();
                    VaciarGrillas();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre la nueva marca");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGVTipo.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idTipo = Convert.ToInt32(dataGVTipo.SelectedRows[0].Cells["idTipo"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este tipo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    bool exito = conexion.EliminarObjeto(idTipo, "tipo", "idTipo");

                    if (exito)
                    {
                        MessageBox.Show("Tipo de producto eliminado correctamente.", "Eliminar tipo de producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Recargar los datos
                        CargarDatos();
                        button1.Enabled = false;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el tipo de producto.", "Eliminar tipo de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un tipo de producto para eliminar.", "Eliminar tipo de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGVTipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGVTipo.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGVTipo.SelectedRows[0];

                // Cargar los datos de la fila en los controles
                txtBoxID.Text = filaSeleccionada.Cells["idTipo"].Value.ToString();
                txtBoxTipoNombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();

                string productoSeleccionado = filaSeleccionada.Cells["nombre"].Value.ToString();

                btnAgregarTipo.Text = "Actualizar";

                button1.Enabled = true;

                mostrarId();

                MessageBox.Show("Datos de tipo de producto " + productoSeleccionado + " añadidos a los campos, listos para ser actualizado o eliminado.", "Producto Listo para Actualizar");
            }
        }

        private void VaciarGrillas()
        {
            txtBoxID.Text = string.Empty;
            txtBoxTipoNombre.Text= string.Empty;
        }


        private void mostrarId()
        {
            label9.Visible = true;
            txtBoxID.Visible = true;
        }

        private void ocultarId()
        {
            label9.Visible = false;
            txtBoxID.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            VaciarGrillas();
            ocultarId();
            btnAgregarTipo.Text = "Agregar";
        }
    }
}
