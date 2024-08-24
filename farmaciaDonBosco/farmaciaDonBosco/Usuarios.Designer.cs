namespace farmaciaDonBosco
{
    partial class Usuarios
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
            this.dataGVTipo = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnAgregarTipo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxContra = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.txtBoxUsuario = new System.Windows.Forms.TextBox();
            this.cBoxRoles = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTipo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVTipo
            // 
            this.dataGVTipo.AllowUserToAddRows = false;
            this.dataGVTipo.AllowUserToDeleteRows = false;
            this.dataGVTipo.AllowUserToResizeRows = false;
            this.dataGVTipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVTipo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGVTipo.Location = new System.Drawing.Point(492, 27);
            this.dataGVTipo.MultiSelect = false;
            this.dataGVTipo.Name = "dataGVTipo";
            this.dataGVTipo.ReadOnly = true;
            this.dataGVTipo.Size = new System.Drawing.Size(512, 479);
            this.dataGVTipo.TabIndex = 24;
            this.dataGVTipo.SelectionChanged += new System.EventHandler(this.dataGVTipo_SelectionChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "ID Usuarios:";
            this.label9.Visible = false;
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(38, 54);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.ReadOnly = true;
            this.txtBoxID.Size = new System.Drawing.Size(79, 20);
            this.txtBoxID.TabIndex = 25;
            this.txtBoxID.Visible = false;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(660, 544);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 27;
            this.btnRegresar.Text = "&Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click_1);
            // 
            // btnAgregarTipo
            // 
            this.btnAgregarTipo.Location = new System.Drawing.Point(42, 479);
            this.btnAgregarTipo.Name = "btnAgregarTipo";
            this.btnAgregarTipo.Size = new System.Drawing.Size(109, 27);
            this.btnAgregarTipo.TabIndex = 28;
            this.btnAgregarTipo.Text = "Agregar";
            this.btnAgregarTipo.UseVisualStyleBackColor = true;
            this.btnAgregarTipo.Click += new System.EventHandler(this.btnAgregarTipo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Rol";
            // 
            // txtBoxContra
            // 
            this.txtBoxContra.Location = new System.Drawing.Point(249, 345);
            this.txtBoxContra.Name = "txtBoxContra";
            this.txtBoxContra.Size = new System.Drawing.Size(185, 20);
            this.txtBoxContra.TabIndex = 33;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(454, 351);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(38, 162);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(176, 20);
            this.txtBoxNombre.TabIndex = 36;
            // 
            // txtBoxUsuario
            // 
            this.txtBoxUsuario.Location = new System.Drawing.Point(39, 344);
            this.txtBoxUsuario.Name = "txtBoxUsuario";
            this.txtBoxUsuario.Size = new System.Drawing.Size(175, 20);
            this.txtBoxUsuario.TabIndex = 38;
            // 
            // cBoxRoles
            // 
            this.cBoxRoles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBoxRoles.FormattingEnabled = true;
            this.cBoxRoles.Location = new System.Drawing.Point(249, 160);
            this.cBoxRoles.Name = "cBoxRoles";
            this.cBoxRoles.Size = new System.Drawing.Size(185, 21);
            this.cBoxRoles.TabIndex = 39;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(174, 479);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(109, 27);
            this.btnLimpiar.TabIndex = 40;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(325, 479);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 27);
            this.btnEliminar.TabIndex = 41;
            this.btnEliminar.Text = "Eliminar usuario";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 593);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cBoxRoles);
            this.Controls.Add(this.txtBoxUsuario);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtBoxContra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarTipo);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.dataGVTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVTipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnAgregarTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxContra;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.TextBox txtBoxUsuario;
        private System.Windows.Forms.ComboBox cBoxRoles;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
    }
}