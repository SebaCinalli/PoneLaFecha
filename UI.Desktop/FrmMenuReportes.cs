using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FrmMenuReportes : Form
    {
        private Label lblTitulo;
    private Button btnReporteSolicitudes;
    private Button btnReporteIngresos;
     private Button btnCerrar;

        public FrmMenuReportes()
    {
       InitializeComponent();
    }

        private void InitializeComponent()
        {
         this.lblTitulo = new Label();
   this.btnReporteSolicitudes = new Button();
      this.btnReporteIngresos = new Button();
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

    // btnReporteSolicitudes
            this.btnReporteSolicitudes.BackColor = Color.LightBlue;
          this.btnReporteSolicitudes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnReporteSolicitudes.Location = new Point(80, 100);
      this.btnReporteSolicitudes.Name = "btnReporteSolicitudes";
     this.btnReporteSolicitudes.Size = new Size(240, 60);
            this.btnReporteSolicitudes.TabIndex = 1;
   this.btnReporteSolicitudes.Text = "Reporte de Solicitudes\n(con gráfico)";
 this.btnReporteSolicitudes.UseVisualStyleBackColor = false;
   this.btnReporteSolicitudes.Click += BtnReporteSolicitudes_Click;

   // btnReporteIngresos
      this.btnReporteIngresos.BackColor = Color.LightGreen;
            this.btnReporteIngresos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
        this.btnReporteIngresos.Location = new Point(80, 180);
       this.btnReporteIngresos.Name = "btnReporteIngresos";
         this.btnReporteIngresos.Size = new Size(240, 60);
  this.btnReporteIngresos.TabIndex = 2;
    this.btnReporteIngresos.Text = "Reporte de Ingresos\n(con gráfico)";
            this.btnReporteIngresos.UseVisualStyleBackColor = false;
       this.btnReporteIngresos.Click += BtnReporteIngresos_Click;

     // btnCerrar
            this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCerrar.Location = new Point(140, 270);
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
     this.ClientSize = new Size(400, 340);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnReporteIngresos);
      this.Controls.Add(this.btnReporteSolicitudes);
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

        private void BtnReporteSolicitudes_Click(object sender, EventArgs e)
     {
 var frmReporte = new FrmReporteSolicitudes();
         frmReporte.ShowDialog();
      }

    private void BtnReporteIngresos_Click(object sender, EventArgs e)
        {
            var frmReporte = new FrmReporteIngresos();
            frmReporte.ShowDialog();
    }

   private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
     }
 }
}
