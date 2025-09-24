using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FrmMenuPrincipal : Form
    {
        private Button btnClientes;
        private Button btnSalones;
        private Button btnBarras;
        private Button btnDjs;
        private Button btnSalir;
        private Label lblTitulo;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnClientes = new Button();
            this.btnSalones = new Button();
            this.btnBarras = new Button();
            this.btnDjs = new Button();
            this.btnSalir = new Button();
            this.lblTitulo = new Label();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.Location = new Point(120, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(240, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema Pone La Fecha";

            // 
            // btnClientes
            // 
            this.btnClientes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnClientes.Location = new Point(150, 80);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new Size(180, 50);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Gestión de Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += BtnClientes_Click;

            // 
            // btnSalones
            // 
            this.btnSalones.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSalones.Location = new Point(150, 150);
            this.btnSalones.Name = "btnSalones";
            this.btnSalones.Size = new Size(180, 50);
            this.btnSalones.TabIndex = 2;
            this.btnSalones.Text = "Gestión de Salones";
            this.btnSalones.UseVisualStyleBackColor = true;
            this.btnSalones.Click += BtnSalones_Click;

            // 
            // btnBarras
            // 
            this.btnBarras.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnBarras.Location = new Point(150, 220);
            this.btnBarras.Name = "btnBarras";
            this.btnBarras.Size = new Size(180, 50);
            this.btnBarras.TabIndex = 3;
            this.btnBarras.Text = "Gestión de Barras";
            this.btnBarras.UseVisualStyleBackColor = true;
            this.btnBarras.Click += BtnBarras_Click;

            // 
            // btnDjs
            // 
            this.btnDjs.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnDjs.Location = new Point(150, 290);
            this.btnDjs.Name = "btnDjs";
            this.btnDjs.Size = new Size(180, 50);
            this.btnDjs.TabIndex = 4;
            this.btnDjs.Text = "Gestión de DJs";
            this.btnDjs.UseVisualStyleBackColor = true;
            this.btnDjs.Click += BtnDjs_Click;

            // 
            // btnSalir
            // 
            this.btnSalir.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSalir.Location = new Point(150, 370);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(180, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += BtnSalir_Click;

            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(480, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnDjs);
            this.Controls.Add(this.btnBarras);
            this.Controls.Add(this.btnSalones);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Menú Principal - Pone La Fecha";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            var frmClientes = new FrmABMCliente();
            frmClientes.ShowDialog();
        }

        private void BtnSalones_Click(object sender, EventArgs e)
        {
            var frmSalones = new FrmABMSalon();
            frmSalones.ShowDialog();
        }

        private void BtnBarras_Click(object sender, EventArgs e)
        {
            var frmBarras = new FrmABMBarra();
            frmBarras.ShowDialog();
        }

        private void BtnDjs_Click(object sender, EventArgs e)
        {
            var frmDjs = new FrmABMDj();
            frmDjs.ShowDialog();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de que desea salir?", 
                "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}