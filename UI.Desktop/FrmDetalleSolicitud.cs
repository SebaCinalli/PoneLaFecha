using System;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmDetalleSolicitud : Form
    {
        private Label lblTitulo;
        private Label lblCliente;
        private ComboBox cboCliente;
private Label lblFechaEvento;
     private DateTimePicker dtpFechaEvento;
        private Label lblMontoDJ;
private NumericUpDown nudMontoDJ;
        private Label lblMontoSalon;
private NumericUpDown nudMontoSalon;
        private Label lblMontoGastro;
        private NumericUpDown nudMontoGastro;
   private Label lblMontoBarra;
        private NumericUpDown nudMontoBarra;
 private Label lblEstado;
   private ComboBox cboEstado;
        private Button btnGuardar;
  private Button btnCancelar;
        private Label lblMontoTotal;
   private Label lblMontoTotalValor;

        private readonly LogicaSolicitud _logicaSolicitud;
        private int? _idSolicitud;
      private bool _soloLectura;

        public FrmDetalleSolicitud(int? idSolicitud = null, bool soloLectura = false)
   {
            _logicaSolicitud = new LogicaSolicitud();
     _idSolicitud = idSolicitud;
  _soloLectura = soloLectura;
   InitializeComponent();
   CargarClientes();

       if (_idSolicitud.HasValue)
            {
     CargarSolicitud();
       }

     if (_soloLectura)
            {
       cboCliente.Enabled = false;
   dtpFechaEvento.Enabled = false;
    nudMontoDJ.Enabled = false;
       nudMontoSalon.Enabled = false;
     nudMontoGastro.Enabled = false;
      nudMontoBarra.Enabled = false;
  cboEstado.Enabled = false;
btnGuardar.Visible = false;
   btnCancelar.Text = "Cerrar";
    this.Text = "Detalles de Solicitud";
            }
        }

    private void InitializeComponent()
   {
this.lblTitulo = new Label();
  this.lblCliente = new Label();
this.cboCliente = new ComboBox();
     this.lblFechaEvento = new Label();
  this.dtpFechaEvento = new DateTimePicker();
  this.lblMontoDJ = new Label();
       this.nudMontoDJ = new NumericUpDown();
          this.lblMontoSalon = new Label();
  this.nudMontoSalon = new NumericUpDown();
     this.lblMontoGastro = new Label();
     this.nudMontoGastro = new NumericUpDown();
    this.lblMontoBarra = new Label();
  this.nudMontoBarra = new NumericUpDown();
     this.lblEstado = new Label();
this.cboEstado = new ComboBox();
     this.lblMontoTotal = new Label();
this.lblMontoTotalValor = new Label();
  this.btnGuardar = new Button();
  this.btnCancelar = new Button();

       ((System.ComponentModel.ISupportInitialize)(this.nudMontoDJ)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this.nudMontoSalon)).BeginInit();
       ((System.ComponentModel.ISupportInitialize)(this.nudMontoGastro)).BeginInit();
  ((System.ComponentModel.ISupportInitialize)(this.nudMontoBarra)).BeginInit();
this.SuspendLayout();

      // lblTitulo
       this.lblTitulo.AutoSize = true;
  this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
this.lblTitulo.ForeColor = Color.DarkBlue;
    this.lblTitulo.Location = new Point(150, 20);
this.lblTitulo.Name = "lblTitulo";
  this.lblTitulo.Size = new Size(250, 24);
this.lblTitulo.TabIndex = 0;
this.lblTitulo.Text = _idSolicitud.HasValue ? "Editar Solicitud" : "Nueva Solicitud";

  // lblCliente
   this.lblCliente.AutoSize = true;
  this.lblCliente.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblCliente.Location = new Point(30, 70);
     this.lblCliente.Name = "lblCliente";
this.lblCliente.Size = new Size(55, 17);
  this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";

// cboCliente
   this.cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
  this.cboCliente.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
  this.cboCliente.FormattingEnabled = true;
      this.cboCliente.Location = new Point(180, 67);
     this.cboCliente.Name = "cboCliente";
this.cboCliente.Size = new Size(300, 24);
          this.cboCliente.TabIndex = 2;

      // lblFechaEvento
  this.lblFechaEvento.AutoSize = true;
this.lblFechaEvento.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblFechaEvento.Location = new Point(30, 110);
this.lblFechaEvento.Name = "lblFechaEvento";
        this.lblFechaEvento.Size = new Size(100, 17);
  this.lblFechaEvento.TabIndex = 3;
      this.lblFechaEvento.Text = "Fecha Evento:";

// dtpFechaEvento
       this.dtpFechaEvento.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
      this.dtpFechaEvento.Format = DateTimePickerFormat.Short;
  this.dtpFechaEvento.Location = new Point(180, 107);
this.dtpFechaEvento.Name = "dtpFechaEvento";
  this.dtpFechaEvento.Size = new Size(150, 23);
 this.dtpFechaEvento.TabIndex = 4;

      // lblMontoDJ
this.lblMontoDJ.AutoSize = true;
  this.lblMontoDJ.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblMontoDJ.Location = new Point(30, 150);
this.lblMontoDJ.Name = "lblMontoDJ";
     this.lblMontoDJ.Size = new Size(75, 17);
this.lblMontoDJ.TabIndex = 5;
  this.lblMontoDJ.Text = "Monto DJ:";

     // nudMontoDJ
this.nudMontoDJ.DecimalPlaces = 2;
  this.nudMontoDJ.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
this.nudMontoDJ.Location = new Point(180, 147);
  this.nudMontoDJ.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
    this.nudMontoDJ.Name = "nudMontoDJ";
this.nudMontoDJ.Size = new Size(150, 23);
      this.nudMontoDJ.TabIndex = 6;
this.nudMontoDJ.ValueChanged += CalcularMontoTotal;

 // lblMontoSalon
this.lblMontoSalon.AutoSize = true;
       this.lblMontoSalon.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblMontoSalon.Location = new Point(30, 190);
       this.lblMontoSalon.Name = "lblMontoSalon";
  this.lblMontoSalon.Size = new Size(95, 17);
            this.lblMontoSalon.TabIndex = 7;
this.lblMontoSalon.Text = "Monto Salón:";

// nudMontoSalon
  this.nudMontoSalon.DecimalPlaces = 2;
  this.nudMontoSalon.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
       this.nudMontoSalon.Location = new Point(180, 187);
 this.nudMontoSalon.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
  this.nudMontoSalon.Name = "nudMontoSalon";
this.nudMontoSalon.Size = new Size(150, 23);
  this.nudMontoSalon.TabIndex = 8;
       this.nudMontoSalon.ValueChanged += CalcularMontoTotal;

  // lblMontoGastro
  this.lblMontoGastro.AutoSize = true;
this.lblMontoGastro.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblMontoGastro.Location = new Point(30, 230);
  this.lblMontoGastro.Name = "lblMontoGastro";
  this.lblMontoGastro.Size = new Size(100, 17);
    this.lblMontoGastro.TabIndex = 9;
  this.lblMontoGastro.Text = "Monto Gastro:";

     // nudMontoGastro
  this.nudMontoGastro.DecimalPlaces = 2;
       this.nudMontoGastro.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
this.nudMontoGastro.Location = new Point(180, 227);
       this.nudMontoGastro.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
  this.nudMontoGastro.Name = "nudMontoGastro";
  this.nudMontoGastro.Size = new Size(150, 23);
      this.nudMontoGastro.TabIndex = 10;
       this.nudMontoGastro.ValueChanged += CalcularMontoTotal;

  // lblMontoBarra
  this.lblMontoBarra.AutoSize = true;
this.lblMontoBarra.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
  this.lblMontoBarra.Location = new Point(30, 270);
  this.lblMontoBarra.Name = "lblMontoBarra";
  this.lblMontoBarra.Size = new Size(95, 17);
  this.lblMontoBarra.TabIndex = 11;
         this.lblMontoBarra.Text = "Monto Barra:";

         // nudMontoBarra
       this.nudMontoBarra.DecimalPlaces = 2;
  this.nudMontoBarra.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
this.nudMontoBarra.Location = new Point(180, 267);
            this.nudMontoBarra.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
  this.nudMontoBarra.Name = "nudMontoBarra";
  this.nudMontoBarra.Size = new Size(150, 23);
   this.nudMontoBarra.TabIndex = 12;
 this.nudMontoBarra.ValueChanged += CalcularMontoTotal;

       // lblEstado
  this.lblEstado.AutoSize = true;
  this.lblEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
     this.lblEstado.Location = new Point(30, 310);
       this.lblEstado.Name = "lblEstado";
this.lblEstado.Size = new Size(55, 17);
  this.lblEstado.TabIndex = 13;
     this.lblEstado.Text = "Estado:";

     // cboEstado
  this.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
       this.cboEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
      this.cboEstado.FormattingEnabled = true;
this.cboEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Cancelada" });
  this.cboEstado.Location = new Point(180, 307);
       this.cboEstado.Name = "cboEstado";
  this.cboEstado.Size = new Size(150, 24);
  this.cboEstado.TabIndex = 14;
this.cboEstado.SelectedIndex = 0;

       // lblMontoTotal
  this.lblMontoTotal.AutoSize = true;
  this.lblMontoTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
   this.lblMontoTotal.ForeColor = Color.DarkGreen;
this.lblMontoTotal.Location = new Point(30, 360);
  this.lblMontoTotal.Name = "lblMontoTotal";
    this.lblMontoTotal.Size = new Size(118, 20);
   this.lblMontoTotal.TabIndex = 15;
       this.lblMontoTotal.Text = "Monto Total:";

       // lblMontoTotalValor
  this.lblMontoTotalValor.AutoSize = true;
  this.lblMontoTotalValor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
  this.lblMontoTotalValor.ForeColor = Color.DarkGreen;
       this.lblMontoTotalValor.Location = new Point(180, 360);
   this.lblMontoTotalValor.Name = "lblMontoTotalValor";
       this.lblMontoTotalValor.Size = new Size(54, 20);
       this.lblMontoTotalValor.TabIndex = 16;
  this.lblMontoTotalValor.Text = "$0.00";

  // btnGuardar
  this.btnGuardar.BackColor = Color.LightGreen;
            this.btnGuardar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
  this.btnGuardar.Location = new Point(120, 410);
            this.btnGuardar.Name = "btnGuardar";
this.btnGuardar.Size = new Size(150, 40);
  this.btnGuardar.TabIndex = 17;
this.btnGuardar.Text = "Guardar";
  this.btnGuardar.UseVisualStyleBackColor = false;
  this.btnGuardar.Click += BtnGuardar_Click;

       // btnCancelar
  this.btnCancelar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
this.btnCancelar.Location = new Point(290, 410);
  this.btnCancelar.Name = "btnCancelar";
       this.btnCancelar.Size = new Size(150, 40);
  this.btnCancelar.TabIndex = 18;
  this.btnCancelar.Text = "Cancelar";
  this.btnCancelar.UseVisualStyleBackColor = true;
  this.btnCancelar.Click += BtnCancelar_Click;

       // FrmDetalleSolicitud
       this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
this.BackColor = Color.LightSteelBlue;
       this.ClientSize = new Size(520, 470);
  this.Controls.Add(this.btnCancelar);
  this.Controls.Add(this.btnGuardar);
  this.Controls.Add(this.lblMontoTotalValor);
  this.Controls.Add(this.lblMontoTotal);
  this.Controls.Add(this.cboEstado);
  this.Controls.Add(this.lblEstado);
 this.Controls.Add(this.nudMontoBarra);
  this.Controls.Add(this.lblMontoBarra);
  this.Controls.Add(this.nudMontoGastro);
  this.Controls.Add(this.lblMontoGastro);
       this.Controls.Add(this.nudMontoSalon);
  this.Controls.Add(this.lblMontoSalon);
       this.Controls.Add(this.nudMontoDJ);
  this.Controls.Add(this.lblMontoDJ);
  this.Controls.Add(this.dtpFechaEvento);
  this.Controls.Add(this.lblFechaEvento);
  this.Controls.Add(this.cboCliente);
  this.Controls.Add(this.lblCliente);
  this.Controls.Add(this.lblTitulo);
  this.FormBorderStyle = FormBorderStyle.FixedDialog;
  this.MaximizeBox = false;
  this.MinimizeBox = false;
  this.Name = "FrmDetalleSolicitud";
  this.StartPosition = FormStartPosition.CenterParent;
  this.Text = _idSolicitud.HasValue ? "Editar Solicitud" : "Nueva Solicitud";

  ((System.ComponentModel.ISupportInitialize)(this.nudMontoDJ)).EndInit();
  ((System.ComponentModel.ISupportInitialize)(this.nudMontoSalon)).EndInit();
  ((System.ComponentModel.ISupportInitialize)(this.nudMontoGastro)).EndInit();
  ((System.ComponentModel.ISupportInitialize)(this.nudMontoBarra)).EndInit();
  this.ResumeLayout(false);
  this.PerformLayout();
        }

        private void CargarClientes()
        {
try
       {
     var clientes = LogicaCliente.Listar();
  cboCliente.DataSource = clientes;
       cboCliente.DisplayMember = "Nombre";
     cboCliente.ValueMember = "IdCliente";
  }
       catch (Exception ex)
            {
     MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", 
MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
}

        private async void CargarSolicitud()
     {
  try
       {
  var solicitud = await _logicaSolicitud.GetByIdAsync(_idSolicitud.Value);
       if (solicitud != null)
       {
       cboCliente.SelectedValue = solicitud.IdCliente;
dtpFechaEvento.Value = solicitud.FechaDesde;
  nudMontoDJ.Value = solicitud.MontoDJ;
  nudMontoSalon.Value = solicitud.MontoSalon;
  nudMontoGastro.Value = solicitud.MontoGastro;
       nudMontoBarra.Value = solicitud.MontoBarra;
  cboEstado.SelectedItem = solicitud.Estado;
     CalcularMontoTotal(null, null);
  }
       else
       {
     MessageBox.Show("No se encontró la solicitud.", "Error", 
  MessageBoxButtons.OK, MessageBoxIcon.Error);
    this.Close();
 }
       }
  catch (Exception ex)
 {
MessageBox.Show($"Error al cargar la solicitud: {ex.Message}", "Error", 
  MessageBoxButtons.OK, MessageBoxIcon.Error);
  this.Close();
       }
        }

        private void CalcularMontoTotal(object sender, EventArgs e)
     {
  decimal total = nudMontoDJ.Value + nudMontoSalon.Value + 
  nudMontoGastro.Value + nudMontoBarra.Value;
       lblMontoTotalValor.Text = total.ToString("C2");
    }

        private async void BtnGuardar_Click(object sender, EventArgs e)
     {
  if (cboCliente.SelectedValue == null)
  {
   MessageBox.Show("Debe seleccionar un cliente.", "Validación", 
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
  return;
       }

       if (dtpFechaEvento.Value < DateTime.Today)
          {
  MessageBox.Show("La fecha del evento no puede ser anterior a hoy.", "Validación", 
       MessageBoxButtons.OK, MessageBoxIcon.Warning);
  return;
    }

  try
       {
  var solicitud = new Solicitud
       {
     IdCliente = (int)cboCliente.SelectedValue,
     FechaDesde = dtpFechaEvento.Value,
       MontoDJ = nudMontoDJ.Value,
     MontoSalon = nudMontoSalon.Value,
     MontoGastro = nudMontoGastro.Value,
  MontoBarra = nudMontoBarra.Value,
     Estado = cboEstado.SelectedItem.ToString()
       };

if (_idSolicitud.HasValue)
  {
  solicitud.IdSolicitud = _idSolicitud.Value;
await _logicaSolicitud.UpdateAsync(solicitud);
     MessageBox.Show("Solicitud actualizada correctamente.", "Éxito", 
  MessageBoxButtons.OK, MessageBoxIcon.Information);
  }
  else
       {
await _logicaSolicitud.CreateAsync(solicitud);
  MessageBox.Show("Solicitud creada correctamente.", "Éxito", 
MessageBoxButtons.OK, MessageBoxIcon.Information);
  }

       this.DialogResult = DialogResult.OK;
  this.Close();
       }
  catch (Exception ex)
       {
  MessageBox.Show($"Error al guardar la solicitud: {ex.Message}", "Error", 
       MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
        }

private void BtnCancelar_Click(object sender, EventArgs e)
 {
  this.DialogResult = DialogResult.Cancel;
  this.Close();
     }
    }
}
