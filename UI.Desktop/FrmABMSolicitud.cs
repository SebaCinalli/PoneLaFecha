using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmABMSolicitud : Form
    {
        private DataGridView dgvSolicitudes;
     private Button btnAgregar;
private Button btnEditar;
  private Button btnEliminar;
        private Button btnCerrar;
        private Button btnDetalles;
     private Label lblTitulo;
   private ComboBox cboEstado;
        private Label lblFiltroEstado;
  private Button btnLimpiarFiltro;

        private readonly LogicaSolicitud _logicaSolicitud;

        public FrmABMSolicitud()
{
  _logicaSolicitud = new LogicaSolicitud();
     InitializeComponent();
       CargarSolicitudes();
   }

        private void InitializeComponent()
        {
this.dgvSolicitudes = new DataGridView();
  this.btnAgregar = new Button();
       this.btnEditar = new Button();
      this.btnEliminar = new Button();
  this.btnCerrar = new Button();
 this.btnDetalles = new Button();
     this.lblTitulo = new Label();
      this.cboEstado = new ComboBox();
       this.lblFiltroEstado = new Label();
  this.btnLimpiarFiltro = new Button();

   ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
 this.SuspendLayout();

            // lblTitulo
 this.lblTitulo.AutoSize = true;
     this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
   this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(350, 15);
      this.lblTitulo.Name = "lblTitulo";
this.lblTitulo.Size = new Size(250, 24);
    this.lblTitulo.TabIndex = 0;
  this.lblTitulo.Text = "Gestión de Solicitudes";

       // lblFiltroEstado
       this.lblFiltroEstado.AutoSize = true;
  this.lblFiltroEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        this.lblFiltroEstado.Location = new Point(12, 55);
       this.lblFiltroEstado.Name = "lblFiltroEstado";
        this.lblFiltroEstado.Size = new Size(100, 17);
  this.lblFiltroEstado.TabIndex = 1;
this.lblFiltroEstado.Text = "Filtrar por Estado:";

  // cboEstado
     this.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
       this.cboEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboEstado.FormattingEnabled = true;
      this.cboEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "Confirmada", "Cancelada" });
            this.cboEstado.Location = new Point(118, 52);
     this.cboEstado.Name = "cboEstado";
     this.cboEstado.Size = new Size(150, 24);
  this.cboEstado.TabIndex = 2;
this.cboEstado.SelectedIndex = 0;
    this.cboEstado.SelectedIndexChanged += CboEstado_SelectedIndexChanged;

  // btnLimpiarFiltro
  this.btnLimpiarFiltro.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
   this.btnLimpiarFiltro.Location = new Point(280, 50);
  this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
      this.btnLimpiarFiltro.Size = new Size(100, 28);
this.btnLimpiarFiltro.TabIndex = 3;
  this.btnLimpiarFiltro.Text = "Limpiar Filtro";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
  this.btnLimpiarFiltro.Click += BtnLimpiarFiltro_Click;

       // dgvSolicitudes
this.dgvSolicitudes.AllowUserToAddRows = false;
   this.dgvSolicitudes.AllowUserToDeleteRows = false;
  this.dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
   this.dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSolicitudes.Location = new Point(12, 90);
   this.dgvSolicitudes.MultiSelect = false;
       this.dgvSolicitudes.Name = "dgvSolicitudes";
  this.dgvSolicitudes.ReadOnly = true;
 this.dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
     this.dgvSolicitudes.Size = new Size(960, 380);
this.dgvSolicitudes.TabIndex = 4;

    // btnAgregar
  this.btnAgregar.BackColor = Color.LightGreen;
     this.btnAgregar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
      this.btnAgregar.Location = new Point(12, 490);
    this.btnAgregar.Name = "btnAgregar";
  this.btnAgregar.Size = new Size(150, 40);
            this.btnAgregar.TabIndex = 5;
this.btnAgregar.Text = "Nueva Solicitud";
   this.btnAgregar.UseVisualStyleBackColor = false;
  this.btnAgregar.Click += BtnAgregar_Click;

      // btnEditar
  this.btnEditar.BackColor = Color.LightYellow;
this.btnEditar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
  this.btnEditar.Location = new Point(180, 490);
       this.btnEditar.Name = "btnEditar";
   this.btnEditar.Size = new Size(150, 40);
            this.btnEditar.TabIndex = 6;
this.btnEditar.Text = "Editar";
    this.btnEditar.UseVisualStyleBackColor = false;
  this.btnEditar.Click += BtnEditar_Click;

         // btnDetalles
  this.btnDetalles.BackColor = Color.LightBlue;
this.btnDetalles.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
       this.btnDetalles.Location = new Point(348, 490);
  this.btnDetalles.Name = "btnDetalles";
  this.btnDetalles.Size = new Size(150, 40);
         this.btnDetalles.TabIndex = 7;
  this.btnDetalles.Text = "Ver Detalles";
            this.btnDetalles.UseVisualStyleBackColor = false;
this.btnDetalles.Click += BtnDetalles_Click;

       // btnEliminar
this.btnEliminar.BackColor = Color.LightCoral;
       this.btnEliminar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
          this.btnEliminar.Location = new Point(516, 490);
            this.btnEliminar.Name = "btnEliminar";
  this.btnEliminar.Size = new Size(150, 40);
  this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
  this.btnEliminar.UseVisualStyleBackColor = false;
   this.btnEliminar.Click += BtnEliminar_Click;

     // btnCerrar
     this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
 this.btnCerrar.Location = new Point(822, 490);
         this.btnCerrar.Name = "btnCerrar";
    this.btnCerrar.Size = new Size(150, 40);
 this.btnCerrar.TabIndex = 9;
            this.btnCerrar.Text = "Cerrar";
   this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += BtnCerrar_Click;

   // FrmABMSolicitud
   this.AutoScaleDimensions = new SizeF(7F, 15F);
  this.AutoScaleMode = AutoScaleMode.Font;
this.BackColor = Color.LightSteelBlue;
this.ClientSize = new Size(984, 551);
 this.Controls.Add(this.btnCerrar);
          this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnDetalles);
     this.Controls.Add(this.btnEditar);
  this.Controls.Add(this.btnAgregar);
  this.Controls.Add(this.dgvSolicitudes);
this.Controls.Add(this.btnLimpiarFiltro);
          this.Controls.Add(this.cboEstado);
  this.Controls.Add(this.lblFiltroEstado);
       this.Controls.Add(this.lblTitulo);
  this.FormBorderStyle = FormBorderStyle.FixedSingle;
  this.MaximizeBox = false;
  this.Name = "FrmABMSolicitud";
       this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "ABM Solicitudes";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
   this.ResumeLayout(false);
  this.PerformLayout();
        }

        private async void CargarSolicitudes()
 {
   try
  {
    var solicitudes = await _logicaSolicitud.GetAllAsync();
            dgvSolicitudes.DataSource = solicitudes;
       ConfigurarColumnas();
 }
            catch (Exception ex)
   {
     MessageBox.Show($"Error al cargar las solicitudes: {ex.Message}", "Error", 
   MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
    }

        private void ConfigurarColumnas()
   {
  // Ocultar columnas de navegación
  if (dgvSolicitudes.Columns["Cliente"] != null)
    dgvSolicitudes.Columns["Cliente"].Visible = false;
      if (dgvSolicitudes.Columns["SalonSolicitudes"] != null)
     dgvSolicitudes.Columns["SalonSolicitudes"].Visible = false;
 if (dgvSolicitudes.Columns["BarraSolicitudes"] != null)
     dgvSolicitudes.Columns["BarraSolicitudes"].Visible = false;
       if (dgvSolicitudes.Columns["GastroSolicitudes"] != null)
dgvSolicitudes.Columns["GastroSolicitudes"].Visible = false;
     if (dgvSolicitudes.Columns["DjSolicitudes"] != null)
dgvSolicitudes.Columns["DjSolicitudes"].Visible = false;

  // Configurar headers
    if (dgvSolicitudes.Columns["IdSolicitud"] != null)
         {
         dgvSolicitudes.Columns["IdSolicitud"].HeaderText = "ID";
 dgvSolicitudes.Columns["IdSolicitud"].Width = 50;
       }
 if (dgvSolicitudes.Columns["IdCliente"] != null)
         {
   dgvSolicitudes.Columns["IdCliente"].HeaderText = "ID Cliente";
            dgvSolicitudes.Columns["IdCliente"].Width = 80;
   }
 if (dgvSolicitudes.Columns["FechaDesde"] != null)
     {
         dgvSolicitudes.Columns["FechaDesde"].HeaderText = "Fecha Evento";
    dgvSolicitudes.Columns["FechaDesde"].DefaultCellStyle.Format = "dd/MM/yyyy";
      dgvSolicitudes.Columns["FechaDesde"].Width = 120;
  }
       if (dgvSolicitudes.Columns["Estado"] != null)
  {
            dgvSolicitudes.Columns["Estado"].HeaderText = "Estado";
     dgvSolicitudes.Columns["Estado"].Width = 100;
}
  }

        private async void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
            if (cboEstado.SelectedItem.ToString() == "Todos")
   {
    CargarSolicitudes();
  }
    else
       {
       try
        {
       var estado = cboEstado.SelectedItem.ToString();
         var solicitudes = await _logicaSolicitud.GetByEstadoAsync(estado);
         dgvSolicitudes.DataSource = solicitudes;
      ConfigurarColumnas();
     }
       catch (Exception ex)
  {
        MessageBox.Show($"Error al filtrar solicitudes: {ex.Message}", "Error", 
      MessageBoxButtons.OK, MessageBoxIcon.Error);
   }
  }
     }

        private void BtnLimpiarFiltro_Click(object sender, EventArgs e)
 {
cboEstado.SelectedIndex = 0;
    CargarSolicitudes();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
     {
  var frmDetalle = new FrmDetalleSolicitud();
  if (frmDetalle.ShowDialog() == DialogResult.OK)
      {
     CargarSolicitudes();
  }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
   {
  if (dgvSolicitudes.SelectedRows.Count == 0)
   {
      MessageBox.Show("Debe seleccionar una solicitud para editar.", "Advertencia", 
MessageBoxButtons.OK, MessageBoxIcon.Warning);
  return;
   }

var solicitud = (Solicitud)dgvSolicitudes.SelectedRows[0].DataBoundItem;
var frmDetalle = new FrmDetalleSolicitud(solicitud.IdSolicitud);
     if (frmDetalle.ShowDialog() == DialogResult.OK)
     {
       CargarSolicitudes();
  }
    }

        private void BtnDetalles_Click(object sender, EventArgs e)
   {
if (dgvSolicitudes.SelectedRows.Count == 0)
  {
    MessageBox.Show("Debe seleccionar una solicitud para ver sus detalles.", "Advertencia", 
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
         return;
       }

var solicitud = (Solicitud)dgvSolicitudes.SelectedRows[0].DataBoundItem;
       var frmDetalle = new FrmDetalleSolicitud(solicitud.IdSolicitud, true);
frmDetalle.ShowDialog();
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
MessageBox.Show("Debe seleccionar una solicitud para eliminar.", "Advertencia", 
  MessageBoxButtons.OK, MessageBoxIcon.Warning);
return;
            }

    var solicitud = (Solicitud)dgvSolicitudes.SelectedRows[0].DataBoundItem;
   var resultado = MessageBox.Show($"¿Está seguro de que desea eliminar la solicitud #{solicitud.IdSolicitud}?", 
       "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

  if (resultado == DialogResult.Yes)
   {
       try
 {
       await _logicaSolicitud.DeleteAsync(solicitud.IdSolicitud);
  MessageBox.Show("Solicitud eliminada correctamente.", "Éxito", 
       MessageBoxButtons.OK, MessageBoxIcon.Information);
 CargarSolicitudes();
     }
      catch (Exception ex)
     {
       MessageBox.Show($"Error al eliminar la solicitud: {ex.Message}", "Error", 
        MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
      }
    }
}
