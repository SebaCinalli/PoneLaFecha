using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmVistaGastronomicos : Form
    {
        private DataGridView dgvGastronomicos;
        private Button btnCerrar;
        private Label lblTitulo;

        public FrmVistaGastronomicos()
        {
            InitializeComponent();
            CargarGastronomicos();
        }

        private void InitializeComponent()
        {
            this.dgvGastronomicos = new DataGridView();
            this.btnCerrar = new Button();
            this.lblTitulo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGastronomicos)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(200, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gastronomicos";

            // 
            // dgvGastronomicos
            // 
            this.dgvGastronomicos.AllowUserToAddRows = false;
            this.dgvGastronomicos.AllowUserToDeleteRows = false;
            this.dgvGastronomicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGastronomicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastronomicos.Location = new Point(12, 50);
            this.dgvGastronomicos.MultiSelect = false;
            this.dgvGastronomicos.Name = "dgvGastronomicos";
            this.dgvGastronomicos.ReadOnly = true;
            this.dgvGastronomicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGastronomicos.Size = new Size(760, 350);
            this.dgvGastronomicos.TabIndex = 1;

            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCerrar.Location = new Point(360, 420);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(100, 35);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += BtnCerrar_Click;

            // 
            // FrmVistaGastronomicos
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(784, 471);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvGastronomicos);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVistaGastronomicos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Vista de Gastronomicos";

            ((System.ComponentModel.ISupportInitialize)(this.dgvGastronomicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CargarGastronomicos()
        {
            var gastronomicos = LogicaGastronomico.Listar();
            dgvGastronomicos.DataSource = gastronomicos;

            // Ocultar las columnas ID y Foto
            if (dgvGastronomicos.Columns["IdGastro"] != null)
                dgvGastronomicos.Columns["IdGastro"].Visible = false;
            
            if (dgvGastronomicos.Columns["Foto"] != null)
                dgvGastronomicos.Columns["Foto"].Visible = false;

            // Formatear la columna de monto como moneda
            if (dgvGastronomicos.Columns["MontoG"] != null)
            {
                dgvGastronomicos.Columns["MontoG"].DefaultCellStyle.Format = "C2";
                dgvGastronomicos.Columns["MontoG"].HeaderText = "Precio";
            }

            // Mejorar headers
            if (dgvGastronomicos.Columns["Nombre"] != null)
                dgvGastronomicos.Columns["Nombre"].HeaderText = "Servicio";
            
            if (dgvGastronomicos.Columns["TipoComida"] != null)
                dgvGastronomicos.Columns["TipoComida"].HeaderText = "Tipo de Comida";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}