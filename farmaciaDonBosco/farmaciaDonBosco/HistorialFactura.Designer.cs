namespace farmaciaDonBosco
{
    partial class HistorialFactura
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
            this.dGVDetalle = new System.Windows.Forms.DataGridView();
            this.dGVFactura = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVDetalle
            // 
            this.dGVDetalle.AllowUserToAddRows = false;
            this.dGVDetalle.AllowUserToDeleteRows = false;
            this.dGVDetalle.AllowUserToResizeRows = false;
            this.dGVDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVDetalle.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dGVDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dGVDetalle.Location = new System.Drawing.Point(12, 372);
            this.dGVDetalle.MultiSelect = false;
            this.dGVDetalle.Name = "dGVDetalle";
            this.dGVDetalle.ReadOnly = true;
            this.dGVDetalle.Size = new System.Drawing.Size(1159, 222);
            this.dGVDetalle.TabIndex = 19;
            // 
            // dGVFactura
            // 
            this.dGVFactura.AllowUserToAddRows = false;
            this.dGVFactura.AllowUserToDeleteRows = false;
            this.dGVFactura.AllowUserToResizeRows = false;
            this.dGVFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVFactura.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dGVFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFactura.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dGVFactura.Location = new System.Drawing.Point(12, 92);
            this.dGVFactura.MultiSelect = false;
            this.dGVFactura.Name = "dGVFactura";
            this.dGVFactura.ReadOnly = true;
            this.dGVFactura.Size = new System.Drawing.Size(1159, 208);
            this.dGVFactura.TabIndex = 20;
            this.dGVFactura.SelectionChanged += new System.EventHandler(this.dGVFactura_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Facturas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Detalle Facturas:";
            // 
            // HistorialFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(217)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(1199, 617);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGVFactura);
            this.Controls.Add(this.dGVDetalle);
            this.Name = "HistorialFactura";
            this.Text = "HistorialFactura";
            this.Load += new System.EventHandler(this.HistorialFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVDetalle;
        private System.Windows.Forms.DataGridView dGVFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}