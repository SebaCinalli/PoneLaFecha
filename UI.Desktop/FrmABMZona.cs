using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmABMZona : Form
    {
      private DataGridView dgvZonas;
        private Button btnAgregar;
    private Button btnEditar;
        private Button btnEliminar;
 private Button btnCerrar;
        private Button btnDetalles;
      private Label lblTitulo;
        private TextBox txtBuscar;
        private Label lblBuscar;

        private readonly LogicaZona _logicaZona;

   public FrmABMZona()
        {
  _logicaZona = new LogicaZona();
            InitializeComponent();
        CargarZonas();
        }

        private void InitializeComponent()
      {
            this.dgvZonas = new DataGridView();
    this.btnAgregar = new Button();
            this.btnEditar = new Button();
       this.btnEliminar = new Button();
      this.btnCerrar = new Button();
     this.btnDetalles = new Button();
       this.lblTitulo = new Label();
          this.txtBuscar = new TextBox();
            this.lblBuscar = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvZonas)).BeginInit();
            this.SuspendLayout();

         // lblTitulo
            this.lblTitulo.AutoSize = true;
    this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
      this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(250, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(200, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Zonas";

     // lblBuscar
    this.lblBuscar.AutoSize = true;
    this.lblBuscar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
     this.lblBuscar.Location = new Point(12, 55);
      this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new Size(55, 17);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar:";

            // txtBuscar
       this.txtBuscar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtBuscar.Location = new Point(73, 52);
   this.txtBuscar.Name = "txtBuscar";
       this.txtBuscar.Size = new Size(250, 23);
       this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += TxtBuscar_TextChanged;

      // dgvZonas
 this.dgvZonas.AllowUserToAddRows = false;
          this.dgvZonas.AllowUserToDeleteRows = false;
   this.dgvZonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvZonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
       this.dgvZonas.Location = new Point(12, 90);
            this.dgvZonas.MultiSelect = false;
   this.dgvZonas.Name = "dgvZonas";
  this.dgvZonas.ReadOnly = true;
  this.dgvZonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
   this.dgvZonas.Size = new Size(660, 350);
     this.dgvZonas.TabIndex = 3;

        // btnAgregar
       this.btnAgregar.BackColor = Color.LightGreen;
      this.btnAgregar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
   this.btnAgregar.Location = new Point(12, 460);
      this.btnAgregar.Name = "btnAgregar";
     this.btnAgregar.Size = new Size(120, 40);
         this.btnAgregar.TabIndex = 4;
 this.btnAgregar.Text = "Agregar";
 this.btnAgregar.UseVisualStyleBackColor = false;
    this.btnAgregar.Click += BtnAgregar_Click;

   // btnEditar
      this.btnEditar.BackColor = Color.LightYellow;
            this.btnEditar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEditar.Location = new Point(145, 460);
 this.btnEditar.Name = "btnEditar";
         this.btnEditar.Size = new Size(120, 40);
    this.btnEditar.TabIndex = 5;
 this.btnEditar.Text = "Editar";
        this.btnEditar.UseVisualStyleBackColor = false;
   this.btnEditar.Click += BtnEditar_Click;

          // btnDetalles
       this.btnDetalles.BackColor = Color.LightBlue;
            this.btnDetalles.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
       this.btnDetalles.Location = new Point(278, 460);
         this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new Size(120, 40);
            this.btnDetalles.TabIndex = 6;
      this.btnDetalles.Text = "Detalles";
     this.btnDetalles.UseVisualStyleBackColor = false;
 this.btnDetalles.Click += BtnDetalles_Click;

          // btnEliminar
            this.btnEliminar.BackColor = Color.LightCoral;
    this.btnEliminar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
      this.btnEliminar.Location = new Point(411, 460);
         this.btnEliminar.Name = "btnEliminar";
    this.btnEliminar.Size = new Size(120, 40);
      this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
         this.btnEliminar.UseVisualStyleBackColor = false;
         this.btnEliminar.Click += BtnEliminar_Click;

       // btnCerrar
        this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCerrar.Location = new Point(552, 460);
     this.btnCerrar.Name = "btnCerrar";
this.btnCerrar.Size = new Size(120, 40);
            this.btnCerrar.TabIndex = 8;
        this.btnCerrar.Text = "Cerrar";
       this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += BtnCerrar_Click;

         // FrmABMZona
            this.AutoScaleDimensions = new SizeF(7F, 15F);
     this.AutoScaleMode = AutoScaleMode.Font;
     this.BackColor = Color.LightSteelBlue;
      this.ClientSize = new Size(684, 521);
            this.Controls.Add(this.btnCerrar);
         this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.btnEditar);
   this.Controls.Add(this.btnAgregar);
     this.Controls.Add(this.dgvZonas);
        this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
     this.Controls.Add(this.lblTitulo);
         this.FormBorderStyle = FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
      this.Name = "FrmABMZona";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ABM Zonas";

            ((System.ComponentModel.ISupportInitialize)(this.dgvZonas)).EndInit();
            this.ResumeLayout(false);
   this.PerformLayout();
}

        private async void CargarZonas()
     {
            try
         {
       var zonas = await _logicaZona.GetAllAsync();
       dgvZonas.DataSource = zonas;

     // Configurar columnas
     if (dgvZonas.Columns["IdZona"] != null)
          dgvZonas.Columns["IdZona"].HeaderText = "ID";

       if (dgvZonas.Columns["Nombre"] != null)
        dgvZonas.Columns["Nombre"].HeaderText = "Nombre de la Zona";

  // Ocultar columnas de navegación
        if (dgvZonas.Columns["ZonaSalones"] != null)
    dgvZonas.Columns["ZonaSalones"].Visible = false;
  if (dgvZonas.Columns["ZonaBarras"] != null)
        dgvZonas.Columns["ZonaBarras"].Visible = false;
 if (dgvZonas.Columns["ZonaGastros"] != null)
   dgvZonas.Columns["ZonaGastros"].Visible = false;
if (dgvZonas.Columns["ZonaDJs"] != null)
 dgvZonas.Columns["ZonaDJs"].Visible = false;
     }
            catch (Exception ex)
{
                MessageBox.Show($"Error al cargar las zonas: {ex.Message}", "Error", 
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
        if (dgvZonas.DataSource is List<Zona> zonas)
            {
                var filtrado = zonas.Where(z => 
         z.Nombre.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
    dgvZonas.DataSource = filtrado;
 }
        }

   private void BtnAgregar_Click(object sender, EventArgs e)
        {
 var frmDetalle = new FrmDetalleZona();
            if (frmDetalle.ShowDialog() == DialogResult.OK)
            {
            CargarZonas();
 }
   }

    private async void BtnEditar_Click(object sender, EventArgs e)
    {
         if (dgvZonas.SelectedRows.Count == 0)
{
                MessageBox.Show("Debe seleccionar una zona para editar.", "Advertencia", 
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
           return;
         }

            var zona = (Zona)dgvZonas.SelectedRows[0].DataBoundItem;
            var frmDetalle = new FrmDetalleZona(zona.IdZona);
 if (frmDetalle.ShowDialog() == DialogResult.OK)
  {
             CargarZonas();
    }
  }

      private async void BtnDetalles_Click(object sender, EventArgs e)
   {
            if (dgvZonas.SelectedRows.Count == 0)
 {
       MessageBox.Show("Debe seleccionar una zona para ver sus detalles.", "Advertencia", 
  MessageBoxButtons.OK, MessageBoxIcon.Warning);
     return;
            }

  var zona = (Zona)dgvZonas.SelectedRows[0].DataBoundItem;
 var frmDetalle = new FrmDetalleZona(zona.IdZona, true);
       frmDetalle.ShowDialog();
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvZonas.SelectedRows.Count == 0)
      {
          MessageBox.Show("Debe seleccionar una zona para eliminar.", "Advertencia", 
 MessageBoxButtons.OK, MessageBoxIcon.Warning);
           return;
       }

            var zona = (Zona)dgvZonas.SelectedRows[0].DataBoundItem;
    var resultado = MessageBox.Show($"¿Está seguro de que desea eliminar la zona '{zona.Nombre}'?", 
        "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
       try
    {
    await _logicaZona.DeleteAsync(zona.IdZona);
         MessageBox.Show("Zona eliminada correctamente.", "Éxito", 
         MessageBoxButtons.OK, MessageBoxIcon.Information);
      CargarZonas();
   }
 catch (Exception ex)
          {
    MessageBox.Show($"Error al eliminar la zona: {ex.Message}", "Error", 
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
