using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

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
            Dashboard dashboard = new Dashboard();

            dashboard.Show();

            this.Hide();
        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {
            CargarDatos();

            // Configurar las columnas del DataGridView si aún no están configuradas
            if (dGVProductos.Columns.Count == 0)
            {
                dGVProductos.Columns.Add("idProducto", "idProducto");
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
                int idProducto = conexion.ObtenerIdObjeto(productoSeleccionado, "idProductos", "productos");
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
                        // Añadir idProducto en la columna correspondiente
                        dGVProductos.Rows.Add(idProducto, productoSeleccionado, cantidad, precioUnitario, subtotal);
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


        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (txtBoxNombre.Text.Length == 0)
            {
                MessageBox.Show("Por favor, añada el nombre del cliente a la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateFactura.Text.Length == 0)
            {
                MessageBox.Show("Por favor, añada una fecha para la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!radioBtnEfectivo.Checked && !radioBtnTarjeta.Checked)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numDescuento.Text.Length == 0)
            {
                MessageBox.Show("Por favor, añada un descuento. Si no hay un descuento, añada 0 (cero).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dGVProductos.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, añada un producto a la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fechaFactura = dateFactura.Value.ToString("yyyy-MM-dd");
            string nombreCliente = txtBoxNombre.Text;
            string tipoPago = radioBtnEfectivo.Checked ? "Efectivo" : "Tarjeta";
            int descuento = Convert.ToInt32(numDescuento.Value);
            decimal subtotal = numMonto.Value;
            decimal total = numTotal.Value;

            try
            {
                // Insertar la factura en la base de datos
                int idFactura = conexion.InsertarFactura(DateTime.Now, nombreCliente, tipoPago == "Efectivo" ? 1 : 2, descuento, subtotal, total);

                if (idFactura > 0)
                {
                    conexion.InsertarDetallesFactura(idFactura, dGVProductos);
                    GenerarPDF(nombreCliente, fechaFactura, tipoPago, subtotal, descuento, total);
                    MessageBox.Show("Compra realizada con éxito y PDF generado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VaciarGrillas();
                }
                else
                {
                    MessageBox.Show("Error al realizar la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void VaciarGrillas()
        {
            txtBoxNombre.Text = string.Empty;
            cBoxProductos.SelectedIndex = -1;
            numDescuento.Value = 0; // Establecer el valor de NumericUpDown a 0
            numMonto.Value = 0; // Establecer el valor de NumericUpDown a 0
            numTotal.Value = 0;
            dateFactura.Value = DateTime.Now; // Establecer la fecha actual en DateTimePicker
            radioBtnEfectivo.Checked = false;
            radioBtnTarjeta.Checked = false;
            dGVProductos.Rows.Clear();

        }

        private void dateFactura_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GenerarPDF(string nombreCliente, string fecha, string tipoPago, decimal subtotal, int descuento, decimal total)
        {
            Document documento = new Document(PageSize.A4);
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Factura.pdf");

            try
            {
                PdfWriter.GetInstance(documento, new FileStream(ruta, FileMode.Create));
                documento.Open();

                // Título
                Paragraph titulo = new Paragraph("Factura de Compra\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20));
                titulo.Alignment = Element.ALIGN_CENTER;
                documento.Add(titulo);

                // Información del cliente y fecha
                documento.Add(new Paragraph($"FARMACIA DON BOSCO\n\n"));
                documento.Add(new Paragraph($"*********************")); // Add the ID to the doument.
                documento.Add(new Paragraph($"Cliente: {nombreCliente}"));
                documento.Add(new Paragraph($"Fecha: {fecha}"));
                documento.Add(new Paragraph($"Método de pago: {tipoPago}\n\n"));

                // Tabla con los productos
                PdfPTable tabla = new PdfPTable(5);
                tabla.WidthPercentage = 100;
                tabla.AddCell("ID");
                tabla.AddCell("Producto");
                tabla.AddCell("Cantidad");
                tabla.AddCell("Precio Unitario");
                tabla.AddCell("Subtotal");

                foreach (DataGridViewRow row in dGVProductos.Rows)
                {
                    if (row.Cells["idProducto"].Value != null)
                    {
                        tabla.AddCell(row.Cells["idProducto"].Value.ToString());
                        tabla.AddCell(row.Cells["Producto"].Value.ToString());
                        tabla.AddCell(row.Cells["Cantidad"].Value.ToString());
                        tabla.AddCell(row.Cells["PrecioUnitario"].Value.ToString());
                        tabla.AddCell(row.Cells["Subtotal"].Value.ToString());
                    }
                }

                documento.Add(tabla);

                // Totales y descuento
                documento.Add(new Paragraph($"\nSubtotal: ${subtotal}"));
                documento.Add(new Paragraph($"Descuento: {descuento}%"));
                documento.Add(new Paragraph($"Total: ${total}\n"));

                documento.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
