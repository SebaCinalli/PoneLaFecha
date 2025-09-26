using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmVistaSalones : Form
    {
        private DataGridView dgvSalones;
        private Button btnCerrar;
        private Label lblTitulo;

        public FrmVistaSalones()
        {
            InitializeComponent();
            CargarSalones();
        }

        private void InitializeComponent()
        {
            this.dgvSalones = new DataGridView();
            this.btnCerrar = new Button();
            this.lblTitulo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).BeginInit();
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
            this.lblTitulo.Text = "Salones Disponibles";

            // 
            // dgvSalones
            // 
            this.dgvSalones.AllowUserToAddRows = false;
            this.dgvSalones.AllowUserToDeleteRows = false;
            this.dgvSalones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalones.Location = new Point(12, 50);
            this.dgvSalones.MultiSelect = false;
            this.dgvSalones.Name = "dgvSalones";
            this.dgvSalones.ReadOnly = true;
            this.dgvSalones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalones.Size = new Size(760, 350);
            this.dgvSalones.TabIndex = 1;

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
            // FrmVistaSalones
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(784, 471);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvSalones);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVistaSalones";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Vista de Salones";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CargarSalones()
        {
            var salones = LogicaSalon.Listar();
            dgvSalones.DataSource = salones;

            // Ocultar la columna ID
            if (dgvSalones.Columns["IdSalon"] != null)
                dgvSalones.Columns["IdSalon"].Visible = false;

            // Formatear la columna de monto como moneda
            if (dgvSalones.Columns["MontoSalon"] != null)
            {
                dgvSalones.Columns["MontoSalon"].DefaultCellStyle.Format = "C2";
                dgvSalones.Columns["MontoSalon"].HeaderText = "Precio";
            }

            // Mejorar headers
            if (dgvSalones.Columns["NombreSalon"] != null)
                dgvSalones.Columns["NombreSalon"].HeaderText = "Nombre del Salón";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}