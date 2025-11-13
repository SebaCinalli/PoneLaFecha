using System;
using System.Drawing;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmReporteADO : Form
    {
        private Label lblTitulo;
        private Label lblDescripcion;
        private GroupBox grpSalones;
        private Label lblTotalSalones;
        private ListBox lstSalones;
        private GroupBox grpClientes;
        private Label lblTotalClientes;
        private Button btnActualizar;
        private Button btnCerrar;

        public FrmReporteADO()
        {
            InitializeComponent();
            CargarDatos();
     }

        private void InitializeComponent()
        {
        this.lblTitulo = new Label();
      this.lblDescripcion = new Label();
            this.grpSalones = new GroupBox();
            this.lblTotalSalones = new Label();
 this.lstSalones = new ListBox();
            this.grpClientes = new GroupBox();
            this.lblTotalClientes = new Label();
            this.btnActualizar = new Button();
         this.btnCerrar = new Button();

            this.grpSalones.SuspendLayout();
      this.grpClientes.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
    this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
    this.lblTitulo.Location = new Point(180, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(380, 26);
      this.lblTitulo.TabIndex = 0;
     this.lblTitulo.Text = "Estadísticas con ADO.NET";

 // lblDescripcion
    this.lblDescripcion.AutoSize = true;
       this.lblDescripcion.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point);
            this.lblDescripcion.ForeColor = Color.DarkSlateGray;
         this.lblDescripcion.Location = new Point(100, 55);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(550, 15);
 this.lblDescripcion.TabIndex = 1;
        this.lblDescripcion.Text = "Este reporte demuestra el uso de ADO.NET directo para consultas a la base de datos";

          // grpSalones
            this.grpSalones.Controls.Add(this.lstSalones);
        this.grpSalones.Controls.Add(this.lblTotalSalones);
            this.grpSalones.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
    this.grpSalones.ForeColor = Color.DarkBlue;
       this.grpSalones.Location = new Point(30, 90);
   this.grpSalones.Name = "grpSalones";
    this.grpSalones.Size = new Size(500, 280);
            this.grpSalones.TabIndex = 2;
            this.grpSalones.TabStop = false;
   this.grpSalones.Text = "Listado de Salones (ADO.NET)";

 // lblTotalSalones
       this.lblTotalSalones.AutoSize = true;
            this.lblTotalSalones.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTotalSalones.ForeColor = Color.Black;
        this.lblTotalSalones.Location = new Point(15, 30);
      this.lblTotalSalones.Name = "lblTotalSalones";
     this.lblTotalSalones.Size = new Size(150, 17);
        this.lblTotalSalones.TabIndex = 0;
            this.lblTotalSalones.Text = "Total de Salones: 0";

         // lstSalones
 this.lstSalones.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
  this.lstSalones.FormattingEnabled = true;
      this.lstSalones.ItemHeight = 14;
            this.lstSalones.Location = new Point(15, 55);
            this.lstSalones.Name = "lstSalones";
     this.lstSalones.Size = new Size(470, 200);
 this.lstSalones.TabIndex = 1;

       // grpClientes
     this.grpClientes.Controls.Add(this.lblTotalClientes);
            this.grpClientes.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
 this.grpClientes.ForeColor = Color.DarkGreen;
  this.grpClientes.Location = new Point(550, 90);
            this.grpClientes.Name = "grpClientes";
   this.grpClientes.Size = new Size(220, 120);
  this.grpClientes.TabIndex = 3;
         this.grpClientes.TabStop = false;
      this.grpClientes.Text = "Estadísticas Clientes";

         // lblTotalClientes
            this.lblTotalClientes.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotalClientes.ForeColor = Color.DarkGreen;
this.lblTotalClientes.Location = new Point(20, 40);
         this.lblTotalClientes.Name = "lblTotalClientes";
      this.lblTotalClientes.Size = new Size(180, 60);
 this.lblTotalClientes.TabIndex = 0;
    this.lblTotalClientes.Text = "Total: 0";
         this.lblTotalClientes.TextAlign = ContentAlignment.MiddleCenter;

       // btnActualizar
            this.btnActualizar.BackColor = Color.LightBlue;
            this.btnActualizar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnActualizar.Location = new Point(500, 390);
       this.btnActualizar.Name = "btnActualizar";
       this.btnActualizar.Size = new Size(140, 40);
    this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
       this.btnActualizar.UseVisualStyleBackColor = false;
         this.btnActualizar.Click += BtnActualizar_Click;

            // btnCerrar
   this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCerrar.Location = new Point(660, 390);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(140, 40);
            this.btnCerrar.TabIndex = 5;
  this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
   this.btnCerrar.Click += BtnCerrar_Click;

            // FrmReporteADO
   this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
  this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(820, 450);
     this.Controls.Add(this.btnCerrar);
       this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.grpClientes);
    this.Controls.Add(this.grpSalones);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
     this.Name = "FrmReporteADO";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Reporte con ADO.NET - Pone La Fecha";

   this.grpSalones.ResumeLayout(false);
            this.grpSalones.PerformLayout();
    this.grpClientes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

      private void CargarDatos()
        {
            try
     {
    // Usar método con ADO.NET para listar salones
         var salones = LogicaSalon.ListarConADO();
 lblTotalSalones.Text = $"Total de Salones: {salones.Count}";

    lstSalones.Items.Clear();
      lstSalones.Items.Add(string.Format("{0,-5} {1,-25} {2,-15} {3,12}",
         "ID", "Nombre", "Estado", "Monto"));
           lstSalones.Items.Add(new string('-', 60));

          foreach (var salon in salones)
           {
        string linea = string.Format("{0,-5} {1,-25} {2,-15} {3,12:C}",
            salon.IdSalon,
           salon.NombreSalon.Length > 23 ? salon.NombreSalon.Substring(0, 23) + ".." : salon.NombreSalon,
          salon.Estado,
 salon.MontoSalon);
  lstSalones.Items.Add(linea);
  }

     // Usar método con ADO.NET para contar clientes
  int totalClientes = LogicaCliente.ObtenerTotalClientesConADO();
      lblTotalClientes.Text = $"Total:\n{totalClientes}\nClientes";
            }
      catch (Exception ex)
   {
       MessageBox.Show($"Error al cargar datos con ADO.NET:\n{ex.Message}",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
     }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
         CargarDatos();
        MessageBox.Show("Datos actualizados correctamente usando ADO.NET",
       "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
    this.Close();
     }
    }
}
