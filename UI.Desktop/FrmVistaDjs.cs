using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmVistaDjs : Form
    {
        private DataGridView dgvDjs;
        private Button btnCerrar;
        private Label lblTitulo;

        public FrmVistaDjs()
        {
            InitializeComponent();
            CargarDjs();
        }

        private void InitializeComponent()
        {
            this.dgvDjs = new DataGridView();
            this.btnCerrar = new Button();
            this.lblTitulo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDjs)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(170, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DJs Disponibles";

            // 
            // dgvDjs
            // 
            this.dgvDjs.AllowUserToAddRows = false;
            this.dgvDjs.AllowUserToDeleteRows = false;
            this.dgvDjs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDjs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDjs.Location = new Point(12, 50);
            this.dgvDjs.MultiSelect = false;
            this.dgvDjs.Name = "dgvDjs";
            this.dgvDjs.ReadOnly = true;
            this.dgvDjs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDjs.Size = new Size(760, 350);
            this.dgvDjs.TabIndex = 1;

            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCerrar.Location = new Point(352, 420);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(100, 35);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += BtnCerrar_Click;

            // 
            // FrmVistaDjs
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(784, 471);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvDjs);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVistaDjs";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Vista de DJs";

            ((System.ComponentModel.ISupportInitialize)(this.dgvDjs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CargarDjs()
        {
            var djs = LogicaDj.Listar();
            dgvDjs.DataSource = djs;

            // Ocultar la columna ID
            if (dgvDjs.Columns["IdDj"] != null)
                dgvDjs.Columns["IdDj"].Visible = false;

            // Ocultar la columna Foto por ahora
            if (dgvDjs.Columns["Foto"] != null)
                dgvDjs.Columns["Foto"].Visible = false;

            // Formatear la columna de monto como moneda
            if (dgvDjs.Columns["MontoDj"] != null)
            {
                dgvDjs.Columns["MontoDj"].DefaultCellStyle.Format = "C2";
                dgvDjs.Columns["MontoDj"].HeaderText = "Precio";
            }

            // Mejorar headers
            if (dgvDjs.Columns["NombreArtistico"] != null)
                dgvDjs.Columns["NombreArtistico"].HeaderText = "Nombre Artístico";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}