
namespace WindowsFormsApp1
{
    partial class FrmSistAcadem
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSistAcadem));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConsulta1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConsulta2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConsulta3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConsulta4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVistas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVista1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVista2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProcedimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSP1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSP2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.lstDescripcion = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConsultas,
            this.tsmVistas,
            this.tsmProcedimientos});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmConsultas
            // 
            this.tsmConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConsulta1,
            this.tsmConsulta2,
            this.tsmConsulta3,
            this.tsmConsulta4});
            this.tsmConsultas.Name = "tsmConsultas";
            this.tsmConsultas.Size = new System.Drawing.Size(71, 20);
            this.tsmConsultas.Text = "Consultas";
            // 
            // tsmConsulta1
            // 
            this.tsmConsulta1.Name = "tsmConsulta1";
            this.tsmConsulta1.Size = new System.Drawing.Size(130, 22);
            this.tsmConsulta1.Text = "Consulta 4";
            this.tsmConsulta1.Click += new System.EventHandler(this.tsmConsulta1_Click_1);
            // 
            // tsmConsulta2
            // 
            this.tsmConsulta2.Name = "tsmConsulta2";
            this.tsmConsulta2.Size = new System.Drawing.Size(130, 22);
            this.tsmConsulta2.Text = "Consulta 6";
            this.tsmConsulta2.Click += new System.EventHandler(this.tsmConsulta2_Click_1);
            // 
            // tsmConsulta3
            // 
            this.tsmConsulta3.Name = "tsmConsulta3";
            this.tsmConsulta3.Size = new System.Drawing.Size(130, 22);
            this.tsmConsulta3.Text = "Consulta 7";
            this.tsmConsulta3.Click += new System.EventHandler(this.tsmConsulta3_Click_1);
            // 
            // tsmConsulta4
            // 
            this.tsmConsulta4.Name = "tsmConsulta4";
            this.tsmConsulta4.Size = new System.Drawing.Size(130, 22);
            this.tsmConsulta4.Text = "Consulta 8";
            this.tsmConsulta4.Click += new System.EventHandler(this.tsmConsulta4_Click);
            // 
            // tsmVistas
            // 
            this.tsmVistas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVista1,
            this.tsmVista2});
            this.tsmVistas.Name = "tsmVistas";
            this.tsmVistas.Size = new System.Drawing.Size(49, 20);
            this.tsmVistas.Text = "Vistas";
            // 
            // tsmVista1
            // 
            this.tsmVista1.Name = "tsmVista1";
            this.tsmVista1.Size = new System.Drawing.Size(130, 22);
            this.tsmVista1.Text = "Consulta 1";
            this.tsmVista1.Click += new System.EventHandler(this.tsmVista1_Click_1);
            // 
            // tsmVista2
            // 
            this.tsmVista2.Name = "tsmVista2";
            this.tsmVista2.Size = new System.Drawing.Size(130, 22);
            this.tsmVista2.Text = "Consulta 3";
            this.tsmVista2.Click += new System.EventHandler(this.tsmVista2_Click_1);
            // 
            // tsmProcedimientos
            // 
            this.tsmProcedimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSP1,
            this.tsmSP2});
            this.tsmProcedimientos.Name = "tsmProcedimientos";
            this.tsmProcedimientos.Size = new System.Drawing.Size(37, 20);
            this.tsmProcedimientos.Text = "SPs";
            // 
            // tsmSP1
            // 
            this.tsmSP1.Name = "tsmSP1";
            this.tsmSP1.Size = new System.Drawing.Size(130, 22);
            this.tsmSP1.Text = "Consulta 2";
            this.tsmSP1.Click += new System.EventHandler(this.tsmSP1_Click_1);
            // 
            // tsmSP2
            // 
            this.tsmSP2.Name = "tsmSP2";
            this.tsmSP2.Size = new System.Drawing.Size(130, 22);
            this.tsmSP2.Text = "Consulta 5";
            this.tsmSP2.Click += new System.EventHandler(this.tsmSP2_Click_1);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 35);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 16);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción";
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporte.ColumnHeadersHeight = 25;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReporte.EnableHeadersVisualStyles = false;
            this.dgvReporte.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvReporte.Location = new System.Drawing.Point(39, 124);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReporte.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReporte.Size = new System.Drawing.Size(697, 209);
            this.dgvReporte.TabIndex = 4;
            this.dgvReporte.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(260, 371);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 28);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar Grilla";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(697, 368);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 28);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMostrar.Location = new System.Drawing.Point(22, 371);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(117, 28);
            this.btnMostrar.TabIndex = 0;
            this.btnMostrar.Text = "Mostrar Consulta";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // lstDescripcion
            // 
            this.lstDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDescripcion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lstDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDescripcion.FormattingEnabled = true;
            this.lstDescripcion.ItemHeight = 18;
            this.lstDescripcion.Location = new System.Drawing.Point(12, 67);
            this.lstDescripcion.Name = "lstDescripcion";
            this.lstDescripcion.Size = new System.Drawing.Size(760, 36);
            this.lstDescripcion.TabIndex = 7;
            this.lstDescripcion.TabStop = false;
            // 
            // FrmSistAcadem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lstDescripcion);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSistAcadem";
            this.Text = "Sistema Academico";
            this.Load += new System.EventHandler(this.frmITV_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmConsultas;
        private System.Windows.Forms.ToolStripMenuItem tsmConsulta1;
        private System.Windows.Forms.ToolStripMenuItem tsmConsulta2;
        private System.Windows.Forms.ToolStripMenuItem tsmConsulta3;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmVistas;
        private System.Windows.Forms.ToolStripMenuItem tsmProcedimientos;
        private System.Windows.Forms.ToolStripMenuItem tsmVista1;
        private System.Windows.Forms.ToolStripMenuItem tsmVista2;
        private System.Windows.Forms.ToolStripMenuItem tsmSP1;
        private System.Windows.Forms.ToolStripMenuItem tsmSP2;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.ListBox lstDescripcion;
        private System.Windows.Forms.ToolStripMenuItem tsmConsulta4;
    }
}

