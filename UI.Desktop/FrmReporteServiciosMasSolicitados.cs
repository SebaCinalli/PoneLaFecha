using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmReporteServiciosMasSolicitados : Form
  {
        private Label lblTitulo;
 private Panel pnlEstadisticas;
  private Label lblTotalSalones;
   private Label lblTotalBarras;
        private Label lblTotalDJs;
     private Label lblTotalGastro;
        private Panel pnlGrafico;
        private Button btnCerrar;
        private Button btnExportar;

        public FrmReporteServiciosMasSolicitados()
        {
     InitializeComponent();
   CargarReporte();
    }

   private void InitializeComponent()
      {
          this.lblTitulo = new Label();
            this.pnlEstadisticas = new Panel();
            this.lblTotalSalones = new Label();
            this.lblTotalBarras = new Label();
            this.lblTotalDJs = new Label();
            this.lblTotalGastro = new Label();
     this.pnlGrafico = new Panel();
        this.btnCerrar = new Button();
    this.btnExportar = new Button();

       this.pnlEstadisticas.SuspendLayout();
            this.SuspendLayout();

    // lblTitulo
     this.lblTitulo.AutoSize = true;
  this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
          this.lblTitulo.Location = new Point(220, 20);
        this.lblTitulo.Name = "lblTitulo";
    this.lblTitulo.Size = new Size(420, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Distribución de Servicios Disponibles";

        // pnlEstadisticas
        this.pnlEstadisticas.BackColor = Color.White;
this.pnlEstadisticas.BorderStyle = BorderStyle.FixedSingle;
            this.pnlEstadisticas.Controls.Add(this.lblTotalSalones);
   this.pnlEstadisticas.Controls.Add(this.lblTotalBarras);
       this.pnlEstadisticas.Controls.Add(this.lblTotalDJs);
   this.pnlEstadisticas.Controls.Add(this.lblTotalGastro);
 this.pnlEstadisticas.Location = new Point(30, 70);
      this.pnlEstadisticas.Name = "pnlEstadisticas";
        this.pnlEstadisticas.Size = new Size(820, 120);
      this.pnlEstadisticas.TabIndex = 1;

    // lblTotalSalones
            this.lblTotalSalones.AutoSize = true;
            this.lblTotalSalones.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotalSalones.ForeColor = Color.Green;
          this.lblTotalSalones.Location = new Point(40, 20);
      this.lblTotalSalones.Name = "lblTotalSalones";
            this.lblTotalSalones.Size = new Size(180, 18);
            this.lblTotalSalones.TabIndex = 0;
    this.lblTotalSalones.Text = "Salones: 0 (0%)";

            // lblTotalBarras
        this.lblTotalBarras.AutoSize = true;
            this.lblTotalBarras.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
      this.lblTotalBarras.ForeColor = Color.Orange;
            this.lblTotalBarras.Location = new Point(40, 50);
            this.lblTotalBarras.Name = "lblTotalBarras";
         this.lblTotalBarras.Size = new Size(180, 18);
         this.lblTotalBarras.TabIndex = 1;
          this.lblTotalBarras.Text = "Barras: 0 (0%)";

      // lblTotalDJs
            this.lblTotalDJs.AutoSize = true;
            this.lblTotalDJs.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
this.lblTotalDJs.ForeColor = Color.Blue;
this.lblTotalDJs.Location = new Point(40, 80);
    this.lblTotalDJs.Name = "lblTotalDJs";
        this.lblTotalDJs.Size = new Size(180, 18);
            this.lblTotalDJs.TabIndex = 2;
        this.lblTotalDJs.Text = "DJs: 0 (0%)";

     // lblTotalGastro
   this.lblTotalGastro.AutoSize = true;
 this.lblTotalGastro.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
 this.lblTotalGastro.ForeColor = Color.Red;
     this.lblTotalGastro.Location = new Point(450, 50);
            this.lblTotalGastro.Name = "lblTotalGastro";
       this.lblTotalGastro.Size = new Size(250, 18);
    this.lblTotalGastro.TabIndex = 3;
      this.lblTotalGastro.Text = "Gastronómicos: 0 (0%)";

   // pnlGrafico
  this.pnlGrafico.BackColor = Color.White;
  this.pnlGrafico.BorderStyle = BorderStyle.FixedSingle;
 this.pnlGrafico.Location = new Point(30, 210);
      this.pnlGrafico.Name = "pnlGrafico";
    this.pnlGrafico.Size = new Size(820, 380);
   this.pnlGrafico.TabIndex = 2;
         this.pnlGrafico.Paint += PnlGrafico_Paint;

            // btnExportar
          this.btnExportar.BackColor = Color.LightGreen;
        this.btnExportar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
     this.btnExportar.Location = new Point(600, 610);
       this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new Size(120, 40);
     this.btnExportar.TabIndex = 3;
       this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += BtnExportar_Click;

            // btnCerrar
         this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
     this.btnCerrar.Location = new Point(730, 610);
this.btnCerrar.Name = "btnCerrar";
   this.btnCerrar.Size = new Size(120, 40);
   this.btnCerrar.TabIndex = 4;
   this.btnCerrar.Text = "Cerrar";
 this.btnCerrar.UseVisualStyleBackColor = true;
     this.btnCerrar.Click += BtnCerrar_Click;

            // FrmReporteServiciosMasSolicitados
            this.AutoScaleDimensions = new SizeF(7F, 15F);
    this.AutoScaleMode = AutoScaleMode.Font;
       this.BackColor = Color.LightSteelBlue;
     this.ClientSize = new Size(880, 670);
          this.Controls.Add(this.btnCerrar);
this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.pnlGrafico);
            this.Controls.Add(this.pnlEstadisticas);
   this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
   this.MaximizeBox = false;
       this.Name = "FrmReporteServiciosMasSolicitados";
    this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Distribución de Servicios";

    this.pnlEstadisticas.ResumeLayout(false);
      this.pnlEstadisticas.PerformLayout();
        this.ResumeLayout(false);
  this.PerformLayout();
        }

        private void CargarReporte()
        {
          try
    {
         // Obtener totales de servicios disponibles
          int totalSalones = LogicaSalon.Listar().Count;
          int totalBarras = LogicaBarra.Listar().Count;
    int totalDJs = LogicaDj.Listar().Count;
    int totalGastro = LogicaGastronomico.Listar().Count;

  MostrarEstadisticas(totalSalones, totalBarras, totalDJs, totalGastro);
       pnlGrafico.Invalidate();
      }
   catch (Exception ex)
       {
  MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", 
    MessageBoxButtons.OK, MessageBoxIcon.Error);
   }
      }

        private void MostrarEstadisticas(int totalSalones, int totalBarras, int totalDJs, int totalGastro)
 {
    int total = totalSalones + totalBarras + totalDJs + totalGastro;

       if (total > 0)
       {
          double porcSalones = (double)totalSalones / total * 100;
    double porcBarras = (double)totalBarras / total * 100;
              double porcDJs = (double)totalDJs / total * 100;
 double porcGastro = (double)totalGastro / total * 100;

     lblTotalSalones.Text = $"Salones: {totalSalones} ({porcSalones:F1}%)";
     lblTotalBarras.Text = $"Barras: {totalBarras} ({porcBarras:F1}%)";
    lblTotalDJs.Text = $"DJs: {totalDJs} ({porcDJs:F1}%)";
           lblTotalGastro.Text = $"Gastronómicos: {totalGastro} ({porcGastro:F1}%)";
            }
     else
    {
        lblTotalSalones.Text = "Salones: 0 (0%)";
    lblTotalBarras.Text = "Barras: 0 (0%)";
        lblTotalDJs.Text = "DJs: 0 (0%)";
         lblTotalGastro.Text = "Gastronómicos: 0 (0%)";
        }

          pnlGrafico.Tag = new { totalSalones, totalBarras, totalDJs, totalGastro, total };
        }

        private void PnlGrafico_Paint(object sender, PaintEventArgs e)
        {
            if (pnlGrafico.Tag == null) return;

     dynamic datos = pnlGrafico.Tag;
   int totalSalones = datos.totalSalones;
     int totalBarras = datos.totalBarras;
            int totalDJs = datos.totalDJs;
  int totalGastro = datos.totalGastro;
            int total = datos.total;

   if (total == 0) return;

          Graphics g = e.Graphics;
     g.SmoothingMode = SmoothingMode.AntiAlias;

            // Dimensiones y posición del gráfico circular
      int diametro = 300;
            int x = (pnlGrafico.Width - diametro) / 2 - 100;
       int y = (pnlGrafico.Height - diametro) / 2;
  Rectangle rect = new Rectangle(x, y, diametro, diametro);

        // Ángulo inicial
            float anguloInicio = 0;

            // Colores para cada servicio
            Brush[] colores = new Brush[] { 
          Brushes.Green,      // Salones
        Brushes.Orange,     // Barras
     Brushes.Blue,       // DJs
                Brushes.Red // Gastronómicos
         };

            int[] valores = new int[] { totalSalones, totalBarras, totalDJs, totalGastro };
   string[] nombres = new string[] { "Salones", "Barras", "DJs", "Gastronómicos" };

            // Dibujar cada porción del gráfico circular
            for (int i = 0; i < valores.Length; i++)
            {
     if (valores[i] > 0)
            {
    float angulo = (float)valores[i] / total * 360;
      g.FillPie(colores[i], rect, anguloInicio, angulo);
  
            // Dibujar borde de la porción
       g.DrawPie(Pens.White, rect, anguloInicio, angulo);

        anguloInicio += angulo;
}
      }

       // Dibujar leyenda
   int leyendaX = x + diametro + 50;
         int leyendaY = y + 50;
int espacioLeyenda = 40;

g.DrawString("Leyenda:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, leyendaX, leyendaY - 30);

            for (int i = 0; i < valores.Length; i++)
         {
                // Cuadro de color
     g.FillRectangle(colores[i], leyendaX, leyendaY + (i * espacioLeyenda), 25, 25);
      g.DrawRectangle(Pens.Black, leyendaX, leyendaY + (i * espacioLeyenda), 25, 25);

    // Texto
  double porcentaje = (double)valores[i] / total * 100;
        string texto = $"{nombres[i]}: {valores[i]} ({porcentaje:F1}%)";
      g.DrawString(texto, new Font("Arial", 10, FontStyle.Regular), 
     Brushes.Black, leyendaX + 35, leyendaY + (i * espacioLeyenda) + 5);
            }

    // Título del gráfico
            g.DrawString("Distribución de Servicios Disponibles", 
     new Font("Arial", 12, FontStyle.Bold), Brushes.DarkBlue, x + 20, 20);
        }

    private void BtnExportar_Click(object sender, EventArgs e)
  {
            try
    {
         var saveFileDialog = new SaveFileDialog
     {
 Filter = "Archivo de texto|*.txt",
            Title = "Exportar Reporte",
        FileName = $"Reporte_DistribucionServicios_{DateTime.Now:yyyyMMdd}.txt"
      };

          if (saveFileDialog.ShowDialog() == DialogResult.OK)
  {
       var contenido = $"REPORTE DE DISTRIBUCIÓN DE SERVICIOS DISPONIBLES\n";
contenido += $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n";
    contenido += $"{lblTotalSalones.Text}\n";
             contenido += $"{lblTotalBarras.Text}\n";
   contenido += $"{lblTotalDJs.Text}\n";
         contenido += $"{lblTotalGastro.Text}\n";

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
