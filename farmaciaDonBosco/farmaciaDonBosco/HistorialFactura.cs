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
    public partial class HistorialFactura : Form
    {
        Conexion conexion = new Conexion();
        public HistorialFactura()
        {
            InitializeComponent();
        }

        private void HistorialFactura_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dtMarcas = conexion.ObtenerFacturas();
                dGVFactura.DataSource = dtMarcas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dGVFactura_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVFactura.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dGVFactura.SelectedRows[0];

                int idFactura = Convert.ToInt32(filaSeleccionada.Cells["idFactura"].Value);

                CargarDatosDetalle(idFactura);
            }
        }

        private void CargarDatosDetalle(int idFactura)
        {
            try
            {
                DataTable dtMarcas = conexion.ObtenerDetallesFactura(idFactura);
                dGVDetalle.DataSource = dtMarcas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
