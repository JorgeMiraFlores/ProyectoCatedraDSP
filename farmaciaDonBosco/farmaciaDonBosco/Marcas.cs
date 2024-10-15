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
    public partial class Marcas : Form
    {
        Conexion conexion = new Conexion();

        public Marcas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Marcas_Load(object sender, EventArgs e)
        {
            CargarDatos();

        }


        private void CargarDatos()
        {
            DataTable dt = conexion.ObtenerDatos("marcas");
            dataGridView1.DataSource = dt;
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();

            dashboard.Show();

            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
          
                string nombreMarca = txtBoxNombre.Text;
                int idMarca = 0;
                if (txtBoxID.Text == string.Empty)
                {
                    txtBoxID.Text = "0";
                }
                else
                {
                    txtBoxID.Text = txtBoxID.Text;
                }
                if (int.TryParse(txtBoxID.Text, out idMarca))
                {
                    // El valor es un número válido, puedes usar idMarca
                }
                else
                {
                    // El valor en txtBoxID no es un número válido
                    MessageBox.Show("Por favor, ingrese un número válido en el campo de ID.");
                    return; // Salir del método para evitar continuar con un valor inválido
                }
                if (txtBoxNombre.Text.Length > 0)
                {
                    if (btnAgregar.Text == "Agregar")
                    {
                        conexion.AgregarCaracteristicas(nombreMarca, "marcas");
                        CargarDatos();
                        ocultarId();
                        VaciarGrillas();

                    }
                    else if (btnAgregar.Text == "Actualizar")
                    {
                        conexion.ActualizarCaracteristicas(idMarca, nombreMarca, "marcas", "idMarca");
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

        private void VaciarGrillas()
        {
            txtBoxID.Text = string.Empty;
            txtBoxNombre.Text = string.Empty;
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
            btnAgregar.Text = "Agregar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtener el ID del producto seleccionado
                    int idMarca = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idMarca"].Value);

                    // Confirmar la eliminación
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta marca?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {

                        bool exito = conexion.EliminarObjeto(idMarca, "marcas", "idMarca");

                        if (exito)
                        {
                            MessageBox.Show("Marca de producto eliminada correctamente.", "Eliminar marca de producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Recargar los datos
                            CargarDatos();
                            btnEliminar.Enabled = false;
                        VaciarGrillas();
                        ocultarId();
                        btnAgregar.Text = "Agregar";


                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la marca de producto.", "Eliminar marca de producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una marca de producto para eliminar.", "Eliminar marca de producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void dataGVTipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                // Cargar los datos de la fila en los controles
                txtBoxID.Text = filaSeleccionada.Cells["idMarca"].Value.ToString();
                txtBoxNombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();

                string productoSeleccionado = filaSeleccionada.Cells["nombre"].Value.ToString();

                btnAgregar.Text = "Actualizar";

                btnEliminar.Enabled = true;

                mostrarId();

                MessageBox.Show("Datos de marca de producto " + productoSeleccionado + " añadidos a los campos, listos para ser actualizado o eliminado.", "Producto Listo para Actualizar");
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            VaciarGrillas();
            ocultarId();
            btnAgregar.Text = "Agregar";
        }
    }
}
