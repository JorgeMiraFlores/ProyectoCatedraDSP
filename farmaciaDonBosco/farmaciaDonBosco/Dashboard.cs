﻿using farmaciaDonBosco.FormsGestion;
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
    public partial class Dashboard : Form
    {
        public Dashboard(string usuario)
        {
            
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
           //this.WindowState = FormWindowState.Maximized;
        }

    }
}
