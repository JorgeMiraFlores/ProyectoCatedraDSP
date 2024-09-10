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
    public partial class InscribirMaterias : Form
    {
        Conexion conexion = new Conexion();
        public InscribirMaterias()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

