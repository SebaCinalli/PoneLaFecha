using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmVistaBarras : Form
    {
        private DataGridView dgvBarras;
        private Button btnCerrar;
        private Label lblTitulo;

        public FrmVistaBarras()
        {
            InitializeComponent();
            CargarBarras();
        }

        private void InitializeComponent()
        {
            this.dgvBarras = new DataGridView();
            this.btnCerrar = new Button();
            this.lblTitulo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(190, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Barras Disponibles";

            // 
            // dgvBarras
            // 
            this.dgvBarras.AllowUserToAddRows = false;
            this.dgvBarras.AllowUserToDeleteRows = false;
            this.dgvBarras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBarras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarras.Location = new Point(12, 50);
            this.dgvBarras.MultiSelect = false;
            this.dgvBarras.Name = "dgvBarras";
            this.dgvBarras.ReadOnly = true;
            this.dgvBarras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarras.Size = new Size(760, 350);
            this.dgvBarras.TabIndex = 1;

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
            // FrmVistaBarras
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(784, 471);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvBarras);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVistaBarras";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Vista de Barras";

            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CargarBarras()
        {
            var barras = LogicaBarra.Listar();
            dgvBarras.DataSource = barras;

            // Ocultar la columna ID
            if (dgvBarras.Columns["IdBarra"] != null)
                dgvBarras.Columns["IdBarra"].Visible = false;

            // Formatear la columna de precio como moneda
            if (dgvBarras.Columns["PrecioPorHora"] != null)
            {
                dgvBarras.Columns["PrecioPorHora"].DefaultCellStyle.Format = "C2";
                dgvBarras.Columns["PrecioPorHora"].HeaderText = "Precio por Hora";
            }

            // Mejorar headers
            if (dgvBarras.Columns["TipoBebida"] != null)
                dgvBarras.Columns["TipoBebida"].HeaderText = "Tipo de Bebida";

            if (dgvBarras.Columns["Descripcion"] != null)
                dgvBarras.Columns["Descripcion"].HeaderText = "Descripción";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}