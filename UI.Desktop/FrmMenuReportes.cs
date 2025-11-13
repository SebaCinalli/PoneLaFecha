using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FrmMenuReportes : Form
    {
        private Label lblTitulo;
        private Button btnReporteIngresos;
        private Button btnReporteServicios;
        private Button btnCerrar;

        public FrmMenuReportes()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
      this.lblTitulo = new Label();
      this.btnReporteIngresos = new Button();
      this.btnReporteServicios = new Button();
            this.btnCerrar = new Button();
            this.SuspendLayout();

            // lblTitulo
  this.lblTitulo.AutoSize = true;
      this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
          this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(120, 30);
   this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(160, 26);
            this.lblTitulo.TabIndex = 0;
          this.lblTitulo.Text = "Reportes";

            // btnReporteIngresos
            this.btnReporteIngresos.BackColor = Color.LightGreen;
        this.btnReporteIngresos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
       this.btnReporteIngresos.Location = new Point(80, 90);
    this.btnReporteIngresos.Name = "btnReporteIngresos";
            this.btnReporteIngresos.Size = new Size(240, 60);
    this.btnReporteIngresos.TabIndex = 1;
    this.btnReporteIngresos.Text = "Reporte de Ingresos\n(con gráfico de barras)";
            this.btnReporteIngresos.UseVisualStyleBackColor = false;
            this.btnReporteIngresos.Click += BtnReporteIngresos_Click;

     // btnReporteServicios
     this.btnReporteServicios.BackColor = Color.LightCoral;
            this.btnReporteServicios.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnReporteServicios.Location = new Point(80, 170);
   this.btnReporteServicios.Name = "btnReporteServicios";
     this.btnReporteServicios.Size = new Size(240, 60);
            this.btnReporteServicios.TabIndex = 2;
            this.btnReporteServicios.Text = "Distribución de Servicios\n(con gráfico circular)";
            this.btnReporteServicios.UseVisualStyleBackColor = false;
 this.btnReporteServicios.Click += BtnReporteServicios_Click;

            // btnCerrar
            this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
    this.btnCerrar.Location = new Point(140, 260);
   this.btnCerrar.Name = "btnCerrar";
        this.btnCerrar.Size = new Size(120, 40);
    this.btnCerrar.TabIndex = 3;
       this.btnCerrar.Text = "Cerrar";
   this.btnCerrar.UseVisualStyleBackColor = true;
     this.btnCerrar.Click += BtnCerrar_Click;

            // FrmMenuReportes
        this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
  this.BackColor = Color.LightSteelBlue;
  this.ClientSize = new Size(400, 330);
  this.Controls.Add(this.btnCerrar);
   this.Controls.Add(this.btnReporteServicios);
         this.Controls.Add(this.btnReporteIngresos);
      this.Controls.Add(this.lblTitulo);
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
       this.MinimizeBox = false;
            this.Name = "FrmMenuReportes";
     this.StartPosition = FormStartPosition.CenterParent;
       this.Text = "Menú de Reportes";
            this.ResumeLayout(false);
            this.PerformLayout();
 }

        private void BtnReporteIngresos_Click(object sender, EventArgs e)
        {
            var frmReporte = new FrmReporteIngresos();
     frmReporte.ShowDialog();
     }

        private void BtnReporteServicios_Click(object sender, EventArgs e)
        {
 var frmReporte = new FrmReporteServiciosMasSolicitados();
        frmReporte.ShowDialog();
        }

     private void BtnCerrar_Click(object sender, EventArgs e)
        {
this.Close();
        }
  }
}
