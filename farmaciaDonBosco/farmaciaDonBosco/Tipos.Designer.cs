namespace farmaciaDonBosco
{
    partial class Tipos
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
            this.txtBoxTipoNombre = new System.Windows.Forms.TextBox();
            this.btnAgregarTipo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.dataGVTipo = new System.Windows.Forms.DataGridView();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTipo)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nombre del tipo:";
            // 
            // txtBoxTipoNombre
            // 
            this.txtBoxTipoNombre.Location = new System.Drawing.Point(38, 176);
            this.txtBoxTipoNombre.Name = "txtBoxTipoNombre";
            this.txtBoxTipoNombre.Size = new System.Drawing.Size(211, 20);
            this.txtBoxTipoNombre.TabIndex = 12;
            // 
            // btnAgregarTipo
            // 
            this.btnAgregarTipo.Location = new System.Drawing.Point(38, 259);
            this.btnAgregarTipo.Name = "btnAgregarTipo";
            this.btnAgregarTipo.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTipo.TabIndex = 11;
            this.btnAgregarTipo.Text = "Agregar";
            this.btnAgregarTipo.UseVisualStyleBackColor = true;
            this.btnAgregarTipo.Click += new System.EventHandler(this.btnAgregarTipo_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(286, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(690, 384);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 9;
            this.btnRegresar.Text = "&Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // dataGVTipo
            // 
            this.dataGVTipo.AllowUserToAddRows = false;
            this.dataGVTipo.AllowUserToDeleteRows = false;
            this.dataGVTipo.AllowUserToResizeRows = false;
            this.dataGVTipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVTipo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGVTipo.Location = new System.Drawing.Point(286, 44);
            this.dataGVTipo.MultiSelect = false;
            this.dataGVTipo.Name = "dataGVTipo";
            this.dataGVTipo.ReadOnly = true;
            this.dataGVTipo.Size = new System.Drawing.Size(479, 297);
            this.dataGVTipo.TabIndex = 23;
            this.dataGVTipo.SelectionChanged += new System.EventHandler(this.dataGVTipo_SelectionChanged);
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(38, 71);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.ReadOnly = true;
            this.txtBoxID.Size = new System.Drawing.Size(79, 20);
            this.txtBoxID.TabIndex = 21;
            this.txtBoxID.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "ID producto:";
            this.label9.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(155, 259);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 23);
            this.btnLimpiar.TabIndex = 24;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Tipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dataGVTipo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxTipoNombre);
            this.Controls.Add(this.btnAgregarTipo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRegresar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Tipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos";
            this.Load += new System.EventHandler(this.Tipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVTipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxTipoNombre;
        private System.Windows.Forms.Button btnAgregarTipo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.DataGridView dataGVTipo;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLimpiar;
    }
}