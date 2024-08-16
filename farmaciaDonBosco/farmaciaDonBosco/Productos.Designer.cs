namespace farmaciaDonBosco.FormsGestion
{
    partial class Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.datePickCaducidad = new System.Windows.Forms.DateTimePicker();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.cBoxTipos = new System.Windows.Forms.ComboBox();
            this.cBoxFabricantes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxMarcas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre del producto";
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(179, 60);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(664, 20);
            this.txtBoxNombre.TabIndex = 19;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(453, 463);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(109, 28);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(28, 68);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 388);
            this.dataGridView1.TabIndex = 16;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(453, 581);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(138, 23);
            this.btnRegresar.TabIndex = 15;
            this.btnRegresar.Text = "&Regresar al Dashboard";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1062, 547);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.datePickCaducidad);
            this.tabPage1.Controls.Add(this.numStock);
            this.tabPage1.Controls.Add(this.numPrecio);
            this.tabPage1.Controls.Add(this.cBoxTipos);
            this.tabPage1.Controls.Add(this.cBoxFabricantes);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cBoxMarcas);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtBoxID);
            this.tabPage1.Controls.Add(this.txtBoxNombre);
            this.tabPage1.Controls.Add(this.btnAgregar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1054, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Añadir productos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // datePickCaducidad
            // 
            this.datePickCaducidad.Location = new System.Drawing.Point(182, 352);
            this.datePickCaducidad.MaxDate = new System.DateTime(3000, 8, 15, 0, 0, 0, 0);
            this.datePickCaducidad.MinDate = new System.DateTime(2024, 8, 15, 0, 0, 0, 0);
            this.datePickCaducidad.Name = "datePickCaducidad";
            this.datePickCaducidad.Size = new System.Drawing.Size(200, 20);
            this.datePickCaducidad.TabIndex = 23;
            this.datePickCaducidad.Value = new System.DateTime(2024, 8, 15, 0, 0, 0, 0);
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(409, 244);
            this.numStock.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(191, 20);
            this.numStock.TabIndex = 22;
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new System.Drawing.Point(182, 244);
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(191, 20);
            this.numPrecio.TabIndex = 22;
            // 
            // cBoxTipos
            // 
            this.cBoxTipos.FormattingEnabled = true;
            this.cBoxTipos.Location = new System.Drawing.Point(652, 151);
            this.cBoxTipos.Name = "cBoxTipos";
            this.cBoxTipos.Size = new System.Drawing.Size(191, 21);
            this.cBoxTipos.TabIndex = 21;
            // 
            // cBoxFabricantes
            // 
            this.cBoxFabricantes.FormattingEnabled = true;
            this.cBoxFabricantes.Location = new System.Drawing.Point(409, 151);
            this.cBoxFabricantes.Name = "cBoxFabricantes";
            this.cBoxFabricantes.Size = new System.Drawing.Size(191, 21);
            this.cBoxFabricantes.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tipo:";
            // 
            // cBoxMarcas
            // 
            this.cBoxMarcas.FormattingEnabled = true;
            this.cBoxMarcas.Items.AddRange(new object[] {
            "Marca 1",
            "Marca 2"});
            this.cBoxMarcas.Location = new System.Drawing.Point(182, 151);
            this.cBoxMarcas.Name = "cBoxMarcas";
            this.cBoxMarcas.Size = new System.Drawing.Size(191, 21);
            this.cBoxMarcas.TabIndex = 21;
            this.cBoxMarcas.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fabricante:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(179, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Caducidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Stock:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Precio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Marca:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRecargar);
            this.tabPage2.Controls.Add(this.btnEliminar);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1054, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ver productos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRecargar
            // 
            this.btnRecargar.Location = new System.Drawing.Point(400, 477);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(75, 23);
            this.btnRecargar.TabIndex = 19;
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.UseVisualStyleBackColor = true;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(543, 477);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Lista de productos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "ID producto:";
            this.label9.Visible = false;
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(41, 60);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.ReadOnly = true;
            this.txtBoxID.Size = new System.Drawing.Size(79, 20);
            this.txtBoxID.TabIndex = 19;
            this.txtBoxID.Visible = false;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 616);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnRegresar);
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxMarcas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxFabricantes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxTipos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datePickCaducidad;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxID;
    }
}