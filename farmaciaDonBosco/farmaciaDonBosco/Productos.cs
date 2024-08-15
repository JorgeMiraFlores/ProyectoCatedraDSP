using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmaciaDonBosco.FormsGestion
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            

        }
        private void Productos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            //this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            //this.WindowState = FormWindowState.Maximized;

            datePickCaducidad.Format = DateTimePickerFormat.Custom; // Establece el formato personalizado
            datePickCaducidad.CustomFormat = "dd/MM/yyyy";
        }

        private void CargarDatos()
        {
            Conexion conexion = new Conexion();
            DataTable dt = conexion.ObtenerProductos();
            dataGridView1.DataSource = dt;


            DataTable dtMarcas = conexion.ObtenerDatos("marcas");
            cBoxMarcas.Items.Clear();
            foreach (DataRow row in dtMarcas.Rows)
            {
                cBoxMarcas.Items.Add(row[1].ToString()); 
            }

            DataTable dtFabricantes = conexion.ObtenerDatos("fabricante");
            cBoxFabricantes.Items.Clear();
            foreach (DataRow row in dtFabricantes.Rows)
            {
                cBoxFabricantes.Items.Add(row[1].ToString());
            }

            DataTable dtTipos = conexion.ObtenerDatos("tipo");
            cBoxTipos.Items.Clear();
            foreach (DataRow row in dtTipos.Rows)
            {
                cBoxTipos.Items.Add(row[1].ToString());
            }
        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            string name = "";
            Dashboard dashboard = new Dashboard(name);

            dashboard.Show();

            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idProducto = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idProductos"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Conexion conexion = new Conexion();
                    bool exito = conexion.EliminarProducto(idProducto);

                    if (exito)
                    {
                        MessageBox.Show("Producto eliminado correctamente.", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Recargar los datos
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el producto.", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtBoxNombre.Text.Length > 0)
            {
                // Verificar que se haya seleccionado una marca
                if (cBoxMarcas.SelectedItem != null)
                {
                    if (cBoxFabricantes.SelectedItem != null)
                    {
                        if (cBoxTipos.SelectedItem != null)
                        {
                            if (datePickCaducidad.Value != null)
                            {
                                string marcaSeleccionada = cBoxMarcas.SelectedItem.ToString();
                                string tipoSeleccionado = cBoxTipos.SelectedItem.ToString();
                                string fabricanteSeleccionado = cBoxFabricantes.SelectedItem.ToString();

                                Conexion conexion = new Conexion();

                                string nombreProducto = txtBoxNombre.Text;
                                int idMarca = conexion.ObtenerIdMarca(marcaSeleccionada);
                                int idFabricante = conexion.ObtenerIdFabricante(fabricanteSeleccionado);
                                int idTipo = conexion.ObtenerIdTipo(tipoSeleccionado);
                                decimal precio = numPrecio.Value;
                                decimal stock = numStock.Value;
                                string fechaCaducidad = datePickCaducidad.Value.ToString("yyyy-MM-dd");

                                if (idMarca != -1 && idFabricante != -1 && idTipo != -1)
                                {
                                    conexion.AgregarProducto(nombreProducto, idMarca, idFabricante, idTipo, precio, fechaCaducidad, stock);
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró el ID de la marca seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor, selecciona una fecha de caducidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, selecciona un tipo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un fabricante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una marca.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, añada un nombre al producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
