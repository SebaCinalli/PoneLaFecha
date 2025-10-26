using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmReporteIngresos : Form
    {
 private Label lblTitulo;
        private Panel pnlEstadisticas;
   private Label lblIngresoDJ;
  private Label lblIngresoSalon;
     private Label lblIngresoGastro;
   private Label lblIngresoBarra;
        private Label lblIngresoTotal;
 private Panel pnlGrafico;
        private Button btnCerrar;
  private Button btnExportar;
        private ComboBox cboMes;
        private ComboBox cboAnio;
        private Label lblMes;
private Label lblAnio;
   private Button btnFiltrar;

        private readonly LogicaSolicitud _logicaSolicitud;

 public FrmReporteIngresos()
 {
  _logicaSolicitud = new LogicaSolicitud();
      InitializeComponent();
  CargarCombos();
            CargarReporte();
 }

private void InitializeComponent()
        {
 this.lblTitulo = new Label();
            this.pnlEstadisticas = new Panel();
      this.lblIngresoDJ = new Label();
      this.lblIngresoSalon = new Label();
  this.lblIngresoGastro = new Label();
   this.lblIngresoBarra = new Label();
     this.lblIngresoTotal = new Label();
   this.pnlGrafico = new Panel();
 this.btnCerrar = new Button();
     this.btnExportar = new Button();
        this.cboMes = new ComboBox();
   this.cboAnio = new ComboBox();
     this.lblMes = new Label();
       this.lblAnio = new Label();
   this.btnFiltrar = new Button();

      this.pnlEstadisticas.SuspendLayout();
  this.SuspendLayout();

       // lblTitulo
          this.lblTitulo.AutoSize = true;
       this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
  this.lblTitulo.ForeColor = Color.DarkBlue;
 this.lblTitulo.Location = new Point(280, 20);
 this.lblTitulo.Name = "lblTitulo";
       this.lblTitulo.Size = new Size(350, 26);
        this.lblTitulo.TabIndex = 0;
   this.lblTitulo.Text = "Reporte de Ingresos por Servicio";

   // lblMes
     this.lblMes.AutoSize = true;
     this.lblMes.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
       this.lblMes.Location = new Point(30, 70);
  this.lblMes.Name = "lblMes";
            this.lblMes.Size = new Size(35, 17);
     this.lblMes.TabIndex = 1;
    this.lblMes.Text = "Mes:";

   // cboMes
   this.cboMes.DropDownStyle = ComboBoxStyle.DropDownList;
 this.cboMes.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
       this.cboMes.FormattingEnabled = true;
     this.cboMes.Location = new Point(75, 67);
     this.cboMes.Name = "cboMes";
            this.cboMes.Size = new Size(150, 24);
    this.cboMes.TabIndex = 2;

            // lblAnio
       this.lblAnio.AutoSize = true;
     this.lblAnio.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
       this.lblAnio.Location = new Point(250, 70);
  this.lblAnio.Name = "lblAnio";
       this.lblAnio.Size = new Size(35, 17);
   this.lblAnio.TabIndex = 3;
     this.lblAnio.Text = "Año:";

// cboAnio
   this.cboAnio.DropDownStyle = ComboBoxStyle.DropDownList;
  this.cboAnio.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
   this.cboAnio.FormattingEnabled = true;
this.cboAnio.Location = new Point(295, 67);
      this.cboAnio.Name = "cboAnio";
  this.cboAnio.Size = new Size(100, 24);
   this.cboAnio.TabIndex = 4;

// btnFiltrar
   this.btnFiltrar.BackColor = Color.LightBlue;
   this.btnFiltrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnFiltrar.Location = new Point(420, 62);
    this.btnFiltrar.Name = "btnFiltrar";
     this.btnFiltrar.Size = new Size(100, 35);
     this.btnFiltrar.TabIndex = 5;
       this.btnFiltrar.Text = "Filtrar";
     this.btnFiltrar.UseVisualStyleBackColor = false;
    this.btnFiltrar.Click += BtnFiltrar_Click;

// pnlEstadisticas
  this.pnlEstadisticas.BackColor = Color.White;
     this.pnlEstadisticas.BorderStyle = BorderStyle.FixedSingle;
        this.pnlEstadisticas.Controls.Add(this.lblIngresoDJ);
   this.pnlEstadisticas.Controls.Add(this.lblIngresoSalon);
   this.pnlEstadisticas.Controls.Add(this.lblIngresoGastro);
       this.pnlEstadisticas.Controls.Add(this.lblIngresoBarra);
       this.pnlEstadisticas.Controls.Add(this.lblIngresoTotal);
          this.pnlEstadisticas.Location = new Point(30, 120);
   this.pnlEstadisticas.Name = "pnlEstadisticas";
     this.pnlEstadisticas.Size = new Size(820, 160);
       this.pnlEstadisticas.TabIndex = 6;

       // lblIngresoDJ
   this.lblIngresoDJ.AutoSize = true;
 this.lblIngresoDJ.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
       this.lblIngresoDJ.ForeColor = Color.DarkBlue;
 this.lblIngresoDJ.Location = new Point(40, 30);
 this.lblIngresoDJ.Name = "lblIngresoDJ";
   this.lblIngresoDJ.Size = new Size(150, 18);
  this.lblIngresoDJ.TabIndex = 0;
   this.lblIngresoDJ.Text = "Ingresos DJ: $0.00";

   // lblIngresoSalon
       this.lblIngresoSalon.AutoSize = true;
       this.lblIngresoSalon.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
       this.lblIngresoSalon.ForeColor = Color.DarkGreen;
    this.lblIngresoSalon.Location = new Point(40, 60);
       this.lblIngresoSalon.Name = "lblIngresoSalon";
    this.lblIngresoSalon.Size = new Size(180, 18);
 this.lblIngresoSalon.TabIndex = 1;
  this.lblIngresoSalon.Text = "Ingresos Salón: $0.00";

 // lblIngresoGastro
   this.lblIngresoGastro.AutoSize = true;
       this.lblIngresoGastro.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblIngresoGastro.ForeColor = Color.DarkOrange;
            this.lblIngresoGastro.Location = new Point(40, 90);
        this.lblIngresoGastro.Name = "lblIngresoGastro";
   this.lblIngresoGastro.Size = new Size(220, 18);
   this.lblIngresoGastro.TabIndex = 2;
     this.lblIngresoGastro.Text = "Ingresos Gastronómico: $0.00";

       // lblIngresoBarra
  this.lblIngresoBarra.AutoSize = true;
       this.lblIngresoBarra.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblIngresoBarra.ForeColor = Color.DarkRed;
            this.lblIngresoBarra.Location = new Point(40, 120);
            this.lblIngresoBarra.Name = "lblIngresoBarra";
 this.lblIngresoBarra.Size = new Size(170, 18);
   this.lblIngresoBarra.TabIndex = 3;
   this.lblIngresoBarra.Text = "Ingresos Barra: $0.00";

   // lblIngresoTotal
       this.lblIngresoTotal.AutoSize = true;
this.lblIngresoTotal.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
  this.lblIngresoTotal.ForeColor = Color.DarkGreen;
  this.lblIngresoTotal.Location = new Point(450, 65);
       this.lblIngresoTotal.Name = "lblIngresoTotal";
       this.lblIngresoTotal.Size = new Size(250, 24);
        this.lblIngresoTotal.TabIndex = 4;
  this.lblIngresoTotal.Text = "Ingreso Total: $0.00";

       // pnlGrafico
       this.pnlGrafico.BackColor = Color.White;
       this.pnlGrafico.BorderStyle = BorderStyle.FixedSingle;
    this.pnlGrafico.Location = new Point(30, 300);
     this.pnlGrafico.Name = "pnlGrafico";
  this.pnlGrafico.Size = new Size(820, 280);
   this.pnlGrafico.TabIndex = 7;
       this.pnlGrafico.Paint += PnlGrafico_Paint;

   // btnExportar
     this.btnExportar.BackColor = Color.LightGreen;
  this.btnExportar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
       this.btnExportar.Location = new Point(600, 600);
       this.btnExportar.Name = "btnExportar";
     this.btnExportar.Size = new Size(120, 40);
            this.btnExportar.TabIndex = 8;
       this.btnExportar.Text = "Exportar";
       this.btnExportar.UseVisualStyleBackColor = false;
       this.btnExportar.Click += BtnExportar_Click;

       // btnCerrar
 this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
   this.btnCerrar.Location = new Point(730, 600);
  this.btnCerrar.Name = "btnCerrar";
     this.btnCerrar.Size = new Size(120, 40);
       this.btnCerrar.TabIndex = 9;
       this.btnCerrar.Text = "Cerrar";
       this.btnCerrar.UseVisualStyleBackColor = true;
     this.btnCerrar.Click += BtnCerrar_Click;

       // FrmReporteIngresos
       this.AutoScaleDimensions = new SizeF(7F, 15F);
  this.AutoScaleMode = AutoScaleMode.Font;
       this.BackColor = Color.LightSteelBlue;
    this.ClientSize = new Size(880, 660);
       this.Controls.Add(this.btnCerrar);
       this.Controls.Add(this.btnExportar);
       this.Controls.Add(this.pnlGrafico);
       this.Controls.Add(this.pnlEstadisticas);
       this.Controls.Add(this.btnFiltrar);
this.Controls.Add(this.cboAnio);
       this.Controls.Add(this.lblAnio);
  this.Controls.Add(this.cboMes);
       this.Controls.Add(this.lblMes);
 this.Controls.Add(this.lblTitulo);
   this.FormBorderStyle = FormBorderStyle.FixedSingle;
       this.MaximizeBox = false;
       this.Name = "FrmReporteIngresos";
  this.StartPosition = FormStartPosition.CenterScreen;
       this.Text = "Reporte de Ingresos";

       this.pnlEstadisticas.ResumeLayout(false);
       this.pnlEstadisticas.PerformLayout();
       this.ResumeLayout(false);
       this.PerformLayout();
      }

  private void CargarCombos()
        {
       // Cargar meses
       cboMes.Items.Add("Todos");
  for (int i = 1; i <= 12; i++)
  {
  cboMes.Items.Add(new DateTime(2000, i, 1).ToString("MMMM"));
 }
       cboMes.SelectedIndex = DateTime.Now.Month;

       // Cargar años
       int anioActual = DateTime.Now.Year;
       for (int i = anioActual - 5; i <= anioActual + 1; i++)
  {
   cboAnio.Items.Add(i);
            }
            cboAnio.SelectedItem = anioActual;
        }

        private async void CargarReporte()
     {
     try
{
      var solicitudes = await _logicaSolicitud.GetAllAsync();
    
  // Filtrar confirmadas y por período
       var solicitudesFiltradas = solicitudes
        .Where(s => s.Estado == "Confirmada")
      .ToList();

if (cboMes.SelectedIndex > 0 && cboAnio.SelectedItem != null)
       {
      int mes = cboMes.SelectedIndex;
       int anio = (int)cboAnio.SelectedItem;
       solicitudesFiltradas = solicitudesFiltradas
 .Where(s => s.FechaDesde.Month == mes && s.FechaDesde.Year == anio)
  .ToList();
       }
       else if (cboAnio.SelectedItem != null)
  {
       int anio = (int)cboAnio.SelectedItem;
       solicitudesFiltradas = solicitudesFiltradas
      .Where(s => s.FechaDesde.Year == anio)
    .ToList();
       }

    MostrarEstadisticas(solicitudesFiltradas);
       pnlGrafico.Invalidate();
   }
       catch (Exception ex)
            {
   MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", 
  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 }

 private void MostrarEstadisticas(System.Collections.Generic.List<Entidades.Solicitud> solicitudes)
  {
// TODO: decimal ingresoDJ = solicitudes.Sum(s => s.MontoDJ);
  decimal ingresoDJ = 0; // Temporal
       // TODO: decimal ingresoSalon = solicitudes.Sum(s => s.MontoSalon);
       decimal ingresoSalon = 0; // Temporal
     // TODO: decimal ingresoGastro = solicitudes.Sum(s => s.MontoGastro);
          decimal ingresoGastro = 0; // Temporal
     // TODO: decimal ingresoBarra = solicitudes.Sum(s => s.MontoBarra);
    decimal ingresoBarra = 0; // Temporal
decimal ingresoTotal = ingresoDJ + ingresoSalon + ingresoGastro + ingresoBarra;

            lblIngresoDJ.Text = $"Ingresos DJ: {ingresoDJ:C2}";
       lblIngresoSalon.Text = $"Ingresos Salón: {ingresoSalon:C2}";
   lblIngresoGastro.Text = $"Ingresos Gastronómico: {ingresoGastro:C2}";
       lblIngresoBarra.Text = $"Ingresos Barra: {ingresoBarra:C2}";
       lblIngresoTotal.Text = $"Ingreso Total: {ingresoTotal:C2}";

       pnlGrafico.Tag = new { ingresoDJ, ingresoSalon, ingresoGastro, ingresoBarra, ingresoTotal };
      }

     private void PnlGrafico_Paint(object sender, PaintEventArgs e)
        {
     if (pnlGrafico.Tag == null) return;

   dynamic datos = pnlGrafico.Tag;
       decimal ingresoDJ = datos.ingresoDJ;
            decimal ingresoSalon = datos.ingresoSalon;
  decimal ingresoGastro = datos.ingresoGastro;
  decimal ingresoBarra = datos.ingresoBarra;
       decimal ingresoTotal = datos.ingresoTotal;

       if (ingresoTotal == 0) return;

Graphics g = e.Graphics;
       g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

       int ancho = pnlGrafico.Width - 200;
  int alto = pnlGrafico.Height - 100;
int x = 50;
       int y = 50;

       // Calcular alturas de barras
     int alturaDJ = (int)((double)ingresoDJ / (double)ingresoTotal * alto);
       int alturaSalon = (int)((double)ingresoSalon / (double)ingresoTotal * alto);
 int alturaGastro = (int)((double)ingresoGastro / (double)ingresoTotal * alto);
       int alturaBarra = (int)((double)ingresoBarra / (double)ingresoTotal * alto);

       int anchoBarra = ancho / 5;
    int espacioBarra = 15;

     // DJ - Azul
    g.FillRectangle(Brushes.DarkBlue, x, y + alto - alturaDJ, anchoBarra, alturaDJ);
       g.DrawString($"DJ\n{ingresoDJ:C0}", new Font("Arial", 9, FontStyle.Bold), 
  Brushes.Black, x + 5, y + alto + 10);

       // Salón - Verde
       x += anchoBarra + espacioBarra;
    g.FillRectangle(Brushes.DarkGreen, x, y + alto - alturaSalon, anchoBarra, alturaSalon);
 g.DrawString($"Salón\n{ingresoSalon:C0}", new Font("Arial", 9, FontStyle.Bold), 
  Brushes.Black, x + 5, y + alto + 10);

    // Gastronómico - Naranja
       x += anchoBarra + espacioBarra;
       g.FillRectangle(Brushes.DarkOrange, x, y + alto - alturaGastro, anchoBarra, alturaGastro);
       g.DrawString($"Gastro\n{ingresoGastro:C0}", new Font("Arial", 9, FontStyle.Bold), 
  Brushes.Black, x + 5, y + alto + 10);

  // Barra - Rojo
       x += anchoBarra + espacioBarra;
g.FillRectangle(Brushes.DarkRed, x, y + alto - alturaBarra, anchoBarra, alturaBarra);
 g.DrawString($"Barra\n{ingresoBarra:C0}", new Font("Arial", 9, FontStyle.Bold), 
  Brushes.Black, x + 5, y + alto + 10);

  // Título
   g.DrawString("Ingresos por Tipo de Servicio", 
  new Font("Arial", 12, FontStyle.Bold), Brushes.DarkBlue, 250, 10);

  // Línea base
       g.DrawLine(Pens.Black, 40, y + alto, pnlGrafico.Width - 150, y + alto);
 }

 private void BtnFiltrar_Click(object sender, EventArgs e)
   {
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
       FileName = $"Reporte_Ingresos_{DateTime.Now:yyyyMMdd}.txt"
     };

       if (saveFileDialog.ShowDialog() == DialogResult.OK)
       {
   var contenido = $"REPORTE DE INGRESOS POR SERVICIO\n";
   contenido += $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}\n";
       contenido += $"Período: {cboMes.Text} {cboAnio.Text}\n\n";
       contenido += $"{lblIngresoDJ.Text}\n";
       contenido += $"{lblIngresoSalon.Text}\n";
       contenido += $"{lblIngresoGastro.Text}\n";
       contenido += $"{lblIngresoBarra.Text}\n";
       contenido += $"\n{lblIngresoTotal.Text}\n";

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
