using Google.Protobuf.WellKnownTypes;
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
        Conexion conexion = new Conexion();
        public Productos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            

        }
        private void Productos_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            //this.WindowState = FormWindowState.Maximized;
            CargarDatos();
            datePickCaducidad.Format = DateTimePickerFormat.Custom; // Establece el formato personalizado
            datePickCaducidad.CustomFormat = "dd/MM/yyyy";

            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
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

                    bool exito = conexion.EliminarObjeto(idProducto, "productos", "idProductos");

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

            if (txtBoxNombre.Text.Length > 0) { }
            else { MessageBox.Show("Por favor, añada un nombre al producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
            if (cBoxMarcas.SelectedItem != null) { }
            else { MessageBox.Show("Por favor, selecciona una marca.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
            if (cBoxFabricantes.SelectedItem != null) { }
            else { MessageBox.Show("Por favor, selecciona un fabricante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
            if (cBoxTipos.SelectedItem != null) { }
            else { MessageBox.Show("Por favor, selecciona un tipo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
            if (datePickCaducidad.Value != null) { }
            else { MessageBox.Show("Por favor, selecciona una fecha de caducidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
            if (numPrecio.Value != 0) { }
            else { MessageBox.Show("Por favor, selecciona un precio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
            if (numStock.Value != 0) { }
            else { MessageBox.Show("Por favor, selecciona un stock.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }
            if (datePickCaducidad.Value.Date != DateTime.Today) { }
            else { MessageBox.Show("Por favor, selecciona un fecha diferente a la actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; }


            string marcaSeleccionada = cBoxMarcas.SelectedItem.ToString();
            string tipoSeleccionado = cBoxTipos.SelectedItem.ToString();
            string fabricanteSeleccionado = cBoxFabricantes.SelectedItem.ToString();

            int idProductos = 0;
            if (!string.IsNullOrEmpty(txtBoxID.Text))
            {
                if (int.TryParse(txtBoxID.Text, out idProductos))
                {
                    // La conversión fue exitosa, `idProductos` tiene un valor entero válido.
                }
                else
                {
                    // Manejar el caso donde la conversión falla.
                    MessageBox.Show("El ID del producto no es válido. Por favor, introduce un número entero.");
                }
            }


            string nombreProducto = txtBoxNombre.Text;
            int idMarca = conexion.ObtenerIdMarca(marcaSeleccionada);
            int idFabricante = conexion.ObtenerIdFabricante(fabricanteSeleccionado);
            int idTipo = conexion.ObtenerIdTipo(tipoSeleccionado);
            decimal precio = numPrecio.Value;
            decimal stock = numStock.Value;
            string fechaCaducidad = datePickCaducidad.Value.ToString("yyyy-MM-dd");

            if (idMarca != -1 && idFabricante != -1 && idTipo != -1) { }
            else { MessageBox.Show("No se encontró el ID de la marca seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; }

            if (btnAgregar.Text == "Actualizar") {
                conexion.ActualizarProductos(idProductos, nombreProducto, idMarca, idFabricante, idTipo, precio, fechaCaducidad, stock);

                VaciarGrillas();
                ocultarId();
                btnAgregar.Text = "Agregar";
                tabPage1.Text = "Añadir productos";

                tabControl1.SelectedIndex = 1;
                CargarDatos();
            }
            else if (btnAgregar.Text == "Agregar")
            {
                conexion.AgregarProducto(nombreProducto, idMarca, idFabricante, idTipo, precio, fechaCaducidad, stock);
                VaciarGrillas();
            }
        }
        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                // Cargar los datos de la fila en los controles
                txtBoxID.Text = filaSeleccionada.Cells["idProductos"].Value.ToString();
                txtBoxNombre.Text = filaSeleccionada.Cells["NombreProducto"].Value.ToString();
                cBoxMarcas.SelectedItem = filaSeleccionada.Cells["marca"].Value.ToString(); // Ajusta según el tipo de datos
                cBoxFabricantes.SelectedItem = filaSeleccionada.Cells["fabricante"].Value.ToString(); // Ajusta según el tipo de datos
                cBoxTipos.SelectedItem = filaSeleccionada.Cells["tipo"].Value.ToString(); // Ajusta según el tipo de datos
                numPrecio.Value = Convert.ToDecimal(filaSeleccionada.Cells["precio"].Value);
                numStock.Value = Convert.ToDecimal(filaSeleccionada.Cells["stock"].Value);
                datePickCaducidad.Value = Convert.ToDateTime(filaSeleccionada.Cells["caducidad"].Value);

                string productoSeleccionado = filaSeleccionada.Cells["NombreProducto"].Value.ToString();

                btnAgregar.Text = "Actualizar";

                mostrarId();

                tabPage1.Text = "Actualizar productos";
                MessageBox.Show("Datos de producto " + productoSeleccionado + " añadidos a la pestaña de actualizar, listos para ser actualizados.", "Producto Listo para Actualizar");
            }
        }
            private void CargarDatos()
        {
            try
            {
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
            finally
            {

            }
        }
        private void VaciarGrillas()
        {
            txtBoxID.Text = string.Empty;
            txtBoxNombre.Text = string.Empty;
            cBoxMarcas.SelectedIndex = -1; // Deseleccionar cualquier elemento seleccionado en ComboBox
            cBoxFabricantes.SelectedIndex = -1; // Deseleccionar cualquier elemento seleccionado en ComboBox
            cBoxTipos.SelectedIndex = -1; // Deseleccionar cualquier elemento seleccionado en ComboBox
            numPrecio.Value = 0; // Establecer el valor de NumericUpDown a 0
            numStock.Value = 0; // Establecer el valor de NumericUpDown a 0
            datePickCaducidad.Value = DateTime.Now; // Establecer la fecha actual en DateTimePicker
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

        private void Formulario1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Detiene la aplicación
            Application.Exit();
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
            }
            else if (!ComprobarGrillasLlenas() || txtBoxID.Visible == false || datePickCaducidad.Value == DateTime.Now.Date) {
                MessageBox.Show("Los campos de texto ya están vacios");

            }
        }

        private bool ComprobarGrillasLlenas()
        {
            if (!string.IsNullOrWhiteSpace(txtBoxID.Text) ||
                !string.IsNullOrWhiteSpace(txtBoxNombre.Text) ||
                cBoxMarcas.SelectedIndex != -1 ||
                cBoxFabricantes.SelectedIndex != -1 ||
                cBoxTipos.SelectedIndex != -1 ||
                numPrecio.Value > 0 ||
                numStock.Value > 0 ||
                datePickCaducidad.Value.Date != DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }

    }
}

