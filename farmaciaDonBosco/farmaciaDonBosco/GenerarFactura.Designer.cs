namespace farmaciaDonBosco
{
    partial class GenerarFactura
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
            this.dateFactura = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxProductos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numDescuento = new System.Windows.Forms.NumericUpDown();
            this.radioBtnEfectivo = new System.Windows.Forms.RadioButton();
            this.radioBtnTarjeta = new System.Windows.Forms.RadioButton();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.numTotal = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.dGVProductos = new System.Windows.Forms.DataGridView();
            this.btnAplicarDescuento = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dateFactura
            // 
            this.dateFactura.CustomFormat = "";
            this.dateFactura.Enabled = false;
            this.dateFactura.Location = new System.Drawing.Point(260, 79);
            this.dateFactura.Name = "dateFactura";
            this.dateFactura.Size = new System.Drawing.Size(200, 20);
            this.dateFactura.TabIndex = 0;
            this.dateFactura.Value = new System.DateTime(2024, 8, 23, 20, 2, 5, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Cliente";
            // 
            // cBoxProductos
            // 
            this.cBoxProductos.FormattingEnabled = true;
            this.cBoxProductos.Location = new System.Drawing.Point(29, 201);
            this.cBoxProductos.Name = "cBoxProductos";
            this.cBoxProductos.Size = new System.Drawing.Size(472, 21);
            this.cBoxProductos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Escoger Producto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(643, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monto:";
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(28, 82);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(165, 20);
            this.txtBoxNombre.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(832, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descuento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Monto Total:";
            // 
            // numDescuento
            // 
            this.numDescuento.Location = new System.Drawing.Point(908, 40);
            this.numDescuento.Name = "numDescuento";
            this.numDescuento.Size = new System.Drawing.Size(109, 20);
            this.numDescuento.TabIndex = 10;
            // 
            // radioBtnEfectivo
            // 
            this.radioBtnEfectivo.AutoSize = true;
            this.radioBtnEfectivo.Location = new System.Drawing.Point(950, 373);
            this.radioBtnEfectivo.Name = "radioBtnEfectivo";
            this.radioBtnEfectivo.Size = new System.Drawing.Size(67, 17);
            this.radioBtnEfectivo.TabIndex = 11;
            this.radioBtnEfectivo.TabStop = true;
            this.radioBtnEfectivo.Text = "Efectivo:";
            this.radioBtnEfectivo.UseVisualStyleBackColor = true;
            // 
            // radioBtnTarjeta
            // 
            this.radioBtnTarjeta.AutoSize = true;
            this.radioBtnTarjeta.Location = new System.Drawing.Point(950, 321);
            this.radioBtnTarjeta.Name = "radioBtnTarjeta";
            this.radioBtnTarjeta.Size = new System.Drawing.Size(58, 17);
            this.radioBtnTarjeta.TabIndex = 12;
            this.radioBtnTarjeta.TabStop = true;
            this.radioBtnTarjeta.Text = "Tarjeta";
            this.radioBtnTarjeta.UseVisualStyleBackColor = true;
            // 
            // numMonto
            // 
            this.numMonto.Enabled = false;
            this.numMonto.Location = new System.Drawing.Point(706, 40);
            this.numMonto.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(95, 20);
            this.numMonto.TabIndex = 13;
            // 
            // numTotal
            // 
            this.numTotal.Enabled = false;
            this.numTotal.Location = new System.Drawing.Point(716, 155);
            this.numTotal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numTotal.Name = "numTotal";
            this.numTotal.Size = new System.Drawing.Size(222, 20);
            this.numTotal.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(933, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 36);
            this.button1.TabIndex = 15;
            this.button1.Text = "Pagar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(922, 563);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(138, 23);
            this.btnRegresar.TabIndex = 16;
            this.btnRegresar.Text = "&Regresar al Dashboard";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(524, 199);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(88, 23);
            this.btnAñadir.TabIndex = 17;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // dGVProductos
            // 
            this.dGVProductos.AllowUserToAddRows = false;
            this.dGVProductos.AllowUserToDeleteRows = false;
            this.dGVProductos.AllowUserToResizeRows = false;
            this.dGVProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dGVProductos.Location = new System.Drawing.Point(29, 254);
            this.dGVProductos.MultiSelect = false;
            this.dGVProductos.Name = "dGVProductos";
            this.dGVProductos.ReadOnly = true;
            this.dGVProductos.Size = new System.Drawing.Size(875, 285);
            this.dGVProductos.TabIndex = 18;
            // 
            // btnAplicarDescuento
            // 
            this.btnAplicarDescuento.Location = new System.Drawing.Point(908, 76);
            this.btnAplicarDescuento.Name = "btnAplicarDescuento";
            this.btnAplicarDescuento.Size = new System.Drawing.Size(109, 23);
            this.btnAplicarDescuento.TabIndex = 19;
            this.btnAplicarDescuento.Text = "Aplicar descuento";
            this.btnAplicarDescuento.UseVisualStyleBackColor = true;
            this.btnAplicarDescuento.Click += new System.EventHandler(this.btnAplicarDescuento_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(635, 201);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // GenerarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 613);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAplicarDescuento);
            this.Controls.Add(this.dGVProductos);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numTotal);
            this.Controls.Add(this.numMonto);
            this.Controls.Add(this.radioBtnTarjeta);
            this.Controls.Add(this.radioBtnEfectivo);
            this.Controls.Add(this.numDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBoxProductos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GenerarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Factura";
            this.Load += new System.EventHandler(this.GenerarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numDescuento;
        private System.Windows.Forms.RadioButton radioBtnEfectivo;
        private System.Windows.Forms.RadioButton radioBtnTarjeta;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.NumericUpDown numTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.DataGridView dGVProductos;
        private System.Windows.Forms.Button btnAplicarDescuento;
        private System.Windows.Forms.Button btnEliminar;
    }
}