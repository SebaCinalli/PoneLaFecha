using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmReporteSolicitudes : Form
    {
        private Label lblTitulo;
        private Panel pnlEstadisticas;
        private Label lblTotalSolicitudes;
        private Label lblTotalPendientes;
        private Label lblTotalConfirmadas;
        private Label lblTotalCanceladas;
   private Label lblMontoTotal;
        private Panel pnlGrafico;
  private Button btnCerrar;
        private Button btnExportar;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
    private Label lblDesde;
        private Label lblHasta;
        private Button btnFiltrar;

        private readonly LogicaSolicitud _logicaSolicitud;

        public FrmReporteSolicitudes()
 {
      _logicaSolicitud = new LogicaSolicitud();
     InitializeComponent();
  CargarReporte();
        }

        private void InitializeComponent()
        {
        this.lblTitulo = new Label();
  this.pnlEstadisticas = new Panel();
        this.lblTotalSolicitudes = new Label();
         this.lblTotalPendientes = new Label();
     this.lblTotalConfirmadas = new Label();
     this.lblTotalCanceladas = new Label();
     this.lblMontoTotal = new Label();
            this.pnlGrafico = new Panel();
 this.btnCerrar = new Button();
        this.btnExportar = new Button();
 this.dtpDesde = new DateTimePicker();
            this.dtpHasta = new DateTimePicker();
     this.lblDesde = new Label();
      this.lblHasta = new Label();
   this.btnFiltrar = new Button();

         this.pnlEstadisticas.SuspendLayout();
 this.SuspendLayout();

        // lblTitulo
 this.lblTitulo.AutoSize = true;
   this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
   this.lblTitulo.Location = new Point(300, 20);
          this.lblTitulo.Name = "lblTitulo";
          this.lblTitulo.Size = new Size(300, 26);
     this.lblTitulo.TabIndex = 0;
      this.lblTitulo.Text = "Reporte de Solicitudes";

         // lblDesde
     this.lblDesde.AutoSize = true;
  this.lblDesde.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblDesde.Location = new Point(30, 70);
            this.lblDesde.Name = "lblDesde";
          this.lblDesde.Size = new Size(50, 17);
    this.lblDesde.TabIndex = 1;
  this.lblDesde.Text = "Desde:";

          // dtpDesde
            this.dtpDesde.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
       this.dtpDesde.Format = DateTimePickerFormat.Short;
          this.dtpDesde.Location = new Point(90, 67);
          this.dtpDesde.Name = "dtpDesde";
         this.dtpDesde.Size = new Size(150, 23);
       this.dtpDesde.TabIndex = 2;
  this.dtpDesde.Value = DateTime.Now.AddMonths(-1);

    // lblHasta
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblHasta.Location = new Point(260, 70);
   this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new Size(50, 17);
       this.lblHasta.TabIndex = 3;
        this.lblHasta.Text = "Hasta:";

   // dtpHasta
            this.dtpHasta.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
          this.dtpHasta.Format = DateTimePickerFormat.Short;
      this.dtpHasta.Location = new Point(320, 67);
            this.dtpHasta.Name = "dtpHasta";
         this.dtpHasta.Size = new Size(150, 23);
       this.dtpHasta.TabIndex = 4;

      // btnFiltrar
          this.btnFiltrar.BackColor = Color.LightBlue;
       this.btnFiltrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnFiltrar.Location = new Point(490, 62);
 this.btnFiltrar.Name = "btnFiltrar";
       this.btnFiltrar.Size = new Size(100, 35);
        this.btnFiltrar.TabIndex = 5;
  this.btnFiltrar.Text = "Filtrar";
       this.btnFiltrar.UseVisualStyleBackColor = false;
       this.btnFiltrar.Click += BtnFiltrar_Click;

            // pnlEstadisticas
      this.pnlEstadisticas.BackColor = Color.White;
      this.pnlEstadisticas.BorderStyle = BorderStyle.FixedSingle;
   this.pnlEstadisticas.Controls.Add(this.lblTotalSolicitudes);
            this.pnlEstadisticas.Controls.Add(this.lblTotalPendientes);
     this.pnlEstadisticas.Controls.Add(this.lblTotalConfirmadas);
            this.pnlEstadisticas.Controls.Add(this.lblTotalCanceladas);
            this.pnlEstadisticas.Controls.Add(this.lblMontoTotal);
     this.pnlEstadisticas.Location = new Point(30, 120);
    this.pnlEstadisticas.Name = "pnlEstadisticas";
         this.pnlEstadisticas.Size = new Size(820, 150);
    this.pnlEstadisticas.TabIndex = 6;

            // lblTotalSolicitudes
   this.lblTotalSolicitudes.AutoSize = true;
       this.lblTotalSolicitudes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
         this.lblTotalSolicitudes.Location = new Point(20, 20);
            this.lblTotalSolicitudes.Name = "lblTotalSolicitudes";
            this.lblTotalSolicitudes.Size = new Size(200, 20);
       this.lblTotalSolicitudes.TabIndex = 0;
            this.lblTotalSolicitudes.Text = "Total Solicitudes: 0";

    // lblTotalPendientes
    this.lblTotalPendientes.AutoSize = true;
            this.lblTotalPendientes.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTotalPendientes.ForeColor = Color.Orange;
       this.lblTotalPendientes.Location = new Point(40, 55);
  this.lblTotalPendientes.Name = "lblTotalPendientes";
     this.lblTotalPendientes.Size = new Size(150, 18);
       this.lblTotalPendientes.TabIndex = 1;
        this.lblTotalPendientes.Text = "Pendientes: 0";

     // lblTotalConfirmadas
         this.lblTotalConfirmadas.AutoSize = true;
          this.lblTotalConfirmadas.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
       this.lblTotalConfirmadas.ForeColor = Color.Green;
 this.lblTotalConfirmadas.Location = new Point(40, 85);
  this.lblTotalConfirmadas.Name = "lblTotalConfirmadas";
            this.lblTotalConfirmadas.Size = new Size(150, 18);
this.lblTotalConfirmadas.TabIndex = 2;
            this.lblTotalConfirmadas.Text = "Confirmadas: 0";

        // lblTotalCanceladas
       this.lblTotalCanceladas.AutoSize = true;
    this.lblTotalCanceladas.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTotalCanceladas.ForeColor = Color.Red;
     this.lblTotalCanceladas.Location = new Point(40, 115);
   this.lblTotalCanceladas.Name = "lblTotalCanceladas";
            this.lblTotalCanceladas.Size = new Size(150, 18);
  this.lblTotalCanceladas.TabIndex = 3;
            this.lblTotalCanceladas.Text = "Canceladas: 0";

   // lblMontoTotal
     this.lblMontoTotal.AutoSize = true;
          this.lblMontoTotal.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblMontoTotal.ForeColor = Color.DarkGreen;
            this.lblMontoTotal.Location = new Point(450, 60);
            this.lblMontoTotal.Name = "lblMontoTotal";
       this.lblMontoTotal.Size = new Size(250, 24);
            this.lblMontoTotal.TabIndex = 4;
            this.lblMontoTotal.Text = "Monto Total: $0.00";

       // pnlGrafico
    this.pnlGrafico.BackColor = Color.White;
         this.pnlGrafico.BorderStyle = BorderStyle.FixedSingle;
    this.pnlGrafico.Location = new Point(30, 290);
 this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new Size(820, 300);
            this.pnlGrafico.TabIndex = 7;
       this.pnlGrafico.Paint += PnlGrafico_Paint;

         // btnExportar
      this.btnExportar.BackColor = Color.LightGreen;
 this.btnExportar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
    this.btnExportar.Location = new Point(600, 610);
            this.btnExportar.Name = "btnExportar";
  this.btnExportar.Size = new Size(120, 40);
   this.btnExportar.TabIndex = 8;
        this.btnExportar.Text = "Exportar";
       this.btnExportar.UseVisualStyleBackColor = false;
         this.btnExportar.Click += BtnExportar_Click;

    // btnCerrar
     this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
    this.btnCerrar.Location = new Point(730, 610);
     this.btnCerrar.Name = "btnCerrar";
       this.btnCerrar.Size = new Size(120, 40);
            this.btnCerrar.TabIndex = 9;
          this.btnCerrar.Text = "Cerrar";
      this.btnCerrar.UseVisualStyleBackColor = true;
      this.btnCerrar.Click += BtnCerrar_Click;

  // FrmReporteSolicitudes
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(880, 670);
        this.Controls.Add(this.btnCerrar);
   this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.pnlGrafico);
   this.Controls.Add(this.pnlEstadisticas);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lblHasta);
this.Controls.Add(this.dtpDesde);
      this.Controls.Add(this.lblDesde);
   this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
    this.Name = "FrmReporteSolicitudes";
 this.StartPosition = FormStartPosition.CenterScreen;
 this.Text = "Reporte de Solicitudes";

     this.pnlEstadisticas.ResumeLayout(false);
            this.pnlEstadisticas.PerformLayout();
  this.ResumeLayout(false);
        this.PerformLayout();
    }

 private async void CargarReporte()
      {
        try
{
          var solicitudes = await _logicaSolicitud.GetAllAsync();
         
    // Filtrar por rango de fechas
            var solicitudesFiltradas = solicitudes
          .Where(s => s.FechaDesde >= dtpDesde.Value.Date && 
          s.FechaDesde <= dtpHasta.Value.Date)
               .ToList();

                MostrarEstadisticas(solicitudesFiltradas);
                pnlGrafico.Invalidate(); // Redibujar el gráfico
    }
            catch (Exception ex)
       {
 MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", 
   MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }

        private void MostrarEstadisticas(List<Entidades.Solicitud> solicitudes)
        {
            var totalSolicitudes = solicitudes.Count;
            var totalPendientes = solicitudes.Count(s => s.Estado == "Pendiente");
   var totalConfirmadas = solicitudes.Count(s => s.Estado == "Confirmada");
    var totalCanceladas = solicitudes.Count(s => s.Estado == "Cancelada");
    
      decimal montoTotal = solicitudes
  .Where(s => s.Estado != "Cancelada")
     .Sum(s => s.MontoDJ + s.MontoSalon + s.MontoGastro + s.MontoBarra);

      lblTotalSolicitudes.Text = $"Total Solicitudes: {totalSolicitudes}";
    lblTotalPendientes.Text = $"Pendientes: {totalPendientes}";
            lblTotalConfirmadas.Text = $"Confirmadas: {totalConfirmadas}";
 lblTotalCanceladas.Text = $"Canceladas: {totalCanceladas}";
            lblMontoTotal.Text = $"Monto Total: {montoTotal:C2}";

            // Guardar datos para el gráfico
            pnlGrafico.Tag = new { totalPendientes, totalConfirmadas, totalCanceladas };
   }

        private void PnlGrafico_Paint(object sender, PaintEventArgs e)
        {
            if (pnlGrafico.Tag == null) return;

    dynamic datos = pnlGrafico.Tag;
        int totalPendientes = datos.totalPendientes;
     int totalConfirmadas = datos.totalConfirmadas;
     int totalCanceladas = datos.totalCanceladas;
            int total = totalPendientes + totalConfirmadas + totalCanceladas;

          if (total == 0) return;

            Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Dimensiones del gráfico
     int ancho = pnlGrafico.Width - 200;
            int alto = pnlGrafico.Height - 100;
            int x = 50;
    int y = 50;

    // Calcular alturas de barras
      int alturaPendientes = (int)((double)totalPendientes / total * alto);
        int alturaConfirmadas = (int)((double)totalConfirmadas / total * alto);
 int alturaCanceladas = (int)((double)totalCanceladas / total * alto);

     int anchoBarra = ancho / 4;
   int espacioBarra = 20;

    // Dibujar barras
   // Pendientes - Naranja
 g.FillRectangle(Brushes.Orange, x, y + alto - alturaPendientes, anchoBarra, alturaPendientes);
          g.DrawString($"Pendientes\n{totalPendientes}", new Font("Arial", 10, FontStyle.Bold), 
  Brushes.Black, x + 10, y + alto + 10);

   // Confirmadas - Verde
            x += anchoBarra + espacioBarra;
            g.FillRectangle(Brushes.Green, x, y + alto - alturaConfirmadas, anchoBarra, alturaConfirmadas);
 g.DrawString($"Confirmadas\n{totalConfirmadas}", new Font("Arial", 10, FontStyle.Bold), 
       Brushes.Black, x + 10, y + alto + 10);

            // Canceladas - Rojo
       x += anchoBarra + espacioBarra;
        g.FillRectangle(Brushes.Red, x, y + alto - alturaCanceladas, anchoBarra, alturaCanceladas);
        g.DrawString($"Canceladas\n{totalCanceladas}", new Font("Arial", 10, FontStyle.Bold), 
      Brushes.Black, x + 10, y + alto + 10);

       // Título del gráfico
       g.DrawString("Distribución de Solicitudes por Estado", 
new Font("Arial", 12, FontStyle.Bold), Brushes.DarkBlue, 200, 10);

   // Línea base
        g.DrawLine(Pens.Black, 40, y + alto, pnlGrafico.Width - 150, y + alto);
 }

private void BtnFiltrar_Click(object sender, EventArgs e)
    {
            if (dtpDesde.Value > dtpHasta.Value)
   {
     MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Validación", 
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
    }

      CargarReporte();
        }

    private void BtnExportar_Click(object sender, EventArgs e)
        {
   try
        {
      var saveFileDialog = new SaveFileDialog
     {
   Filter = "Archivo de texto|*.txt",
      Title = "Exportar Reporte",
      FileName = $"Reporte_Solicitudes_{DateTime.Now:yyyyMMdd}.txt"
          };

     if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
            var contenido = $"REPORTE DE SOLICITUDES\n";
   contenido += $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}\n";
       contenido += $"Período: {dtpDesde.Value:dd/MM/yyyy} - {dtpHasta.Value:dd/MM/yyyy}\n\n";
       contenido += $"{lblTotalSolicitudes.Text}\n";
        contenido += $"{lblTotalPendientes.Text}\n";
        contenido += $"{lblTotalConfirmadas.Text}\n";
      contenido += $"{lblTotalCanceladas.Text}\n";
  contenido += $"{lblMontoTotal.Text}\n";

        System.IO.File.WriteAllText(saveFileDialog.FileName, contenido);
     MessageBox.Show("Reporte exportado correctamente.", "Éxito", 
   MessageBoxButtons.OK, MessageBoxIcon.Information);
  }
          }
 catch (Exception ex)
   {
            MessageBox.Show($"Error al exportar: {ex.Message}", "Error", 
         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   private void BtnCerrar_Click(object sender, EventArgs e)
        {
     this.Close();
        }
    }
}
