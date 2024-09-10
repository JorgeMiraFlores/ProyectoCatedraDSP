using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace farmaciaDonBosco
{
    public partial class AnadirMateria : Form
    {
        Conexion conexion = new Conexion();
        public AnadirMateria()
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




    }
}
