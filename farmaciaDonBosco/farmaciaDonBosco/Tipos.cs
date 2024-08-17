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
            dataGridView1.DataSource = dt;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            string name = "";
            Dashboard dashboard = new Dashboard(name);

            dashboard.Show();

            this.Hide();
        }

        private void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            if (txtBoxTipoNombre.Text.Length > 0)
            {
                string nombreTipo = txtBoxTipoNombre.Text;
                conexion.AgregarTipos(nombreTipo);

                CargarDatos();

            }
            else
            {
                MessageBox.Show("Ingrese el nombre la nueva marca");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                int idMarca = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idTipo"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    bool exito = conexion.EliminarObjeto(idMarca, "tipo", "idTipo");

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
    }
}
