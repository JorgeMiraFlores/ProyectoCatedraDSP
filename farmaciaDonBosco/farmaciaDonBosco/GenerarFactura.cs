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
    public partial class GenerarFactura : Form
    {
        Conexion conexion = new Conexion();
        public GenerarFactura()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            string name = "";
            Dashboard dashboard = new Dashboard(name);

            dashboard.Show();

            this.Hide();
        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {
            CargarDatos();

            // Configurar las columnas del DataGridView si aún no están configuradas
            if (dGVProductos.Columns.Count == 0)
            {
                dGVProductos.Columns.Add("Producto", "Producto");
                dGVProductos.Columns.Add("Cantidad", "Cantidad");
                dGVProductos.Columns.Add("PrecioUnitario", "Precio Unitario");
                dGVProductos.Columns.Add("Subtotal", "Subtotal");
            }
        }



        private void CargarDatos()
        {
            try
            {
                DataTable dtMarcas = conexion.ObtenerDatos("productos");
                cBoxProductos.Items.Clear();
                foreach (DataRow row in dtMarcas.Rows)
                {
                    cBoxProductos.Items.Add(row[1].ToString());
                }

            }
            finally
            {

            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (cBoxProductos.SelectedItem != null)
            {
                string productoSeleccionado = cBoxProductos.SelectedItem.ToString();
                decimal precioUnitario = conexion.ObtenerPrecioProducto(productoSeleccionado);

                if (precioUnitario > 0)
                {
                    int cantidad = 1;
                    bool productoEncontrado = false;

                    foreach (DataGridViewRow row in dGVProductos.Rows)
                    {
                        if (row.Cells["Producto"].Value != null && row.Cells["Producto"].Value.ToString() == productoSeleccionado)
                        {
                            int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            cantidadActual += cantidad;
                            row.Cells["Cantidad"].Value = cantidadActual;

                            decimal nuevoSubtotal = cantidadActual * precioUnitario;
                            row.Cells["Subtotal"].Value = nuevoSubtotal;

                            productoEncontrado = true;
                            break;
                        }
                    }

                    if (!productoEncontrado)
                    {
                        decimal subtotal = cantidad * precioUnitario;
                        dGVProductos.Rows.Add(productoSeleccionado, cantidad, precioUnitario, subtotal);
                    }

                    // Actualiza el total después de añadir o actualizar un producto
                    ActualizarTotal();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el precio del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarTotal()
        {
            decimal total = 0;

            // Calcular el total de los subtotales
            foreach (DataGridViewRow row in dGVProductos.Rows)
            {
                if (row.Cells["Subtotal"].Value != null &&
                    decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal subtotal))
                {
                    total += subtotal;
                }
            }

            // Mostrar el total en numMonto
            numMonto.Value = total;

            // Aplicar descuento
            decimal descuento = numDescuento.Value;
            decimal montoConDescuento = total - (total * (descuento / 100));

            // Mostrar el total con descuento en numTotal
            numTotal.Value = montoConDescuento;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string fechaFactura = dateFactura.Value.ToString("yyyy-MM-dd");
            string nombreCliente = txtBoxNombre.Text.ToString();
            int tipoPago = 0;

            if (radioBtnEfectivo.Checked)
            {
                tipoPago = 1;
            }else if (radioBtnTarjeta.Checked)
            {
                tipoPago = 2;
            }
            int descuento = Convert.ToInt32(numDescuento.Value);
            //los productos estan en un datagridview

        }

        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            // Actualizar el total considerando el descuento
            ActualizarTotal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dGVProductos.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dGVProductos.SelectedRows[0];

                // Confirmar la eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Eliminar la fila del DataGridView
                    dGVProductos.Rows.Remove(filaSeleccionada);

                    // Actualizar el total después de eliminar el producto
                    ActualizarTotal();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
            }
        }

    }
}
