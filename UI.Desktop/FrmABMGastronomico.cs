using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmABMGastronomico : Form
    {
     private DataGridView dgvGastronomicos;
        private TextBox txtNombre;
     private ComboBox cboTipoComida;
        private TextBox txtMontoG;
        private Label lblNombre;
        private Label lblTipoComida;
        private Label lblMontoG;
        private Button btnAgregar;
    private Button btnModificar;
    private Button btnEliminar;
        private Button btnLimpiar;
private Button btnVolver;

        // Lista para manejar los servicios gastron�micos
  private List<Entidades.Gastronomico> gastronomicos;
 private Entidades.Gastronomico gastronomicoSeleccionado;

   public FrmABMGastronomico()
    {
            InitializeComponent();
  InicializarDatos();
       ConfigurarEventos();
        }

    private void InitializeComponent()
        {
            this.dgvGastronomicos = new DataGridView();
       this.txtNombre = new TextBox();
this.cboTipoComida = new ComboBox();
  this.txtMontoG = new TextBox();
     this.lblNombre = new Label();
     this.lblTipoComida = new Label();
            this.lblMontoG = new Label();
   this.btnAgregar = new Button();
      this.btnModificar = new Button();
            this.btnEliminar = new Button();
       this.btnLimpiar = new Button();
            this.btnVolver = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGastronomicos)).BeginInit();
        this.SuspendLayout();

            // 
   // dgvGastronomicos
      // 
            this.dgvGastronomicos.AllowUserToAddRows = false;
  this.dgvGastronomicos.AllowUserToDeleteRows = false;
          this.dgvGastronomicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
this.dgvGastronomicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
     this.dgvGastronomicos.Location = new Point(12, 12);
          this.dgvGastronomicos.MultiSelect = false;
         this.dgvGastronomicos.Name = "dgvGastronomicos";
    this.dgvGastronomicos.ReadOnly = true;
    this.dgvGastronomicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
 this.dgvGastronomicos.Size = new Size(760, 250);
            this.dgvGastronomicos.TabIndex = 0;

    // 
       // lblNombre
            // 
   this.lblNombre.AutoSize = true;
 this.lblNombre.Location = new Point(12, 280);
       this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
   this.lblNombre.TabIndex = 1;
      this.lblNombre.Text = "Nombre:";

        // 
          // txtNombre
          // 
  this.txtNombre.Location = new Point(85, 277);
            this.txtNombre.Name = "txtNombre";
    this.txtNombre.Size = new Size(200, 23);
          this.txtNombre.TabIndex = 2;

            // 
   // lblTipoComida
        // 
            this.lblTipoComida.AutoSize = true;
          this.lblTipoComida.Location = new Point(300, 280);
    this.lblTipoComida.Name = "lblTipoComida";
     this.lblTipoComida.Size = new Size(95, 15);
       this.lblTipoComida.TabIndex = 3;
    this.lblTipoComida.Text = "Tipo de Comida:";

        // 
 // cboTipoComida
  // 
            this.cboTipoComida.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTipoComida.Location = new Point(405, 277);
     this.cboTipoComida.Name = "cboTipoComida";
            this.cboTipoComida.Size = new Size(150, 23);
            this.cboTipoComida.TabIndex = 4;

            // 
    // lblMontoG
            // 
            this.lblMontoG.AutoSize = true;
            this.lblMontoG.Location = new Point(580, 280);
            this.lblMontoG.Name = "lblMontoG";
          this.lblMontoG.Size = new Size(48, 15);
   this.lblMontoG.TabIndex = 5;
            this.lblMontoG.Text = "Monto:";

            // 
      // txtMontoG
 // 
       this.txtMontoG.Location = new Point(635, 277);
     this.txtMontoG.Name = "txtMontoG";
     this.txtMontoG.Size = new Size(100, 23);
            this.txtMontoG.TabIndex = 6;

          // 
     // btnAgregar
 // 
            this.btnAgregar.Location = new Point(12, 330);
            this.btnAgregar.Name = "btnAgregar";
     this.btnAgregar.Size = new Size(100, 30);
      this.btnAgregar.TabIndex = 7;
    this.btnAgregar.Text = "Agregar";
      this.btnAgregar.UseVisualStyleBackColor = true;

    // 
       // btnModificar
            // 
this.btnModificar.Location = new Point(130, 330);
      this.btnModificar.Name = "btnModificar";
  this.btnModificar.Size = new Size(100, 30);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
   this.btnModificar.UseVisualStyleBackColor = true;

  // 
            // btnEliminar
      // 
      this.btnEliminar.Location = new Point(248, 330);
     this.btnEliminar.Name = "btnEliminar";
          this.btnEliminar.Size = new Size(100, 30);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
        this.btnEliminar.UseVisualStyleBackColor = true;

            // 
            // btnLimpiar
       // 
    this.btnLimpiar.Location = new Point(366, 330);
     this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 30);
    this.btnLimpiar.TabIndex = 10;
          this.btnLimpiar.Text = "Limpiar";
     this.btnLimpiar.UseVisualStyleBackColor = true;

  // 
      // btnVolver
   // 
   this.btnVolver.Location = new Point(484, 330);
            this.btnVolver.Name = "btnVolver";
       this.btnVolver.Size = new Size(100, 30);
          this.btnVolver.TabIndex = 11;
    this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;

            // 
        // FrmABMGastronomico
        // 
    this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 380);
this.Controls.Add(this.btnVolver);
       this.Controls.Add(this.btnLimpiar);
   this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
         this.Controls.Add(this.txtMontoG);
      this.Controls.Add(this.lblMontoG);
            this.Controls.Add(this.cboTipoComida);
         this.Controls.Add(this.lblTipoComida);
    this.Controls.Add(this.txtNombre);
     this.Controls.Add(this.lblNombre);
   this.Controls.Add(this.dgvGastronomicos);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
this.MaximizeBox = false;
     this.Name = "FrmABMGastronomico";
   this.StartPosition = FormStartPosition.CenterScreen;
     this.Text = "ABM Gastronomico";
  ((System.ComponentModel.ISupportInitialize)(this.dgvGastronomicos)).EndInit();
    this.ResumeLayout(false);
 this.PerformLayout();
        }

        private void ConfigurarEventos()
     {
    this.btnAgregar.Click += BtnAgregar_Click;
      this.btnModificar.Click += BtnModificar_Click;
        this.btnEliminar.Click += BtnEliminar_Click;
 this.btnLimpiar.Click += BtnLimpiar_Click;
 this.btnVolver.Click += BtnVolver_Click;
            this.dgvGastronomicos.SelectionChanged += DgvGastronomicos_SelectionChanged;
        }

        private void InicializarDatos()
        {
         // Cargar tipos de comida en el ComboBox
         cboTipoComida.Items.AddRange(new string[] {
      "Italiana", "Argentina", "Internacional", "Vegetariana", 
      "Vegana", "Mediterr�nea", "Oriental", "Mexicana", "Francesa", "Otro"
            });

  gastronomicos = LogicaGastronomico.Listar();
 ActualizarGrilla();
   }

        private void ActualizarGrilla()
      {
    dgvGastronomicos.DataSource = null;
         dgvGastronomicos.DataSource = gastronomicos;

            // Ocultar la columna ID
    if (dgvGastronomicos.Columns["IdGastro"] != null)
     dgvGastronomicos.Columns["IdGastro"].Visible = false;

          // Formatear la columna de monto como moneda
    if (dgvGastronomicos.Columns["MontoG"] != null)
            {
        dgvGastronomicos.Columns["MontoG"].DefaultCellStyle.Format = "C2";
          dgvGastronomicos.Columns["MontoG"].HeaderText = "Monto";
  }

      // Cambiar headers para mejor presentaci�n
          if (dgvGastronomicos.Columns["Nombre"] != null)
          dgvGastronomicos.Columns["Nombre"].HeaderText = "Nombre del Servicio";
        
    if (dgvGastronomicos.Columns["TipoComida"] != null)
  dgvGastronomicos.Columns["TipoComida"].HeaderText = "Tipo de Comida";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
       {
         var nuevoGastronomico = new Entidades.Gastronomico
    {
  Nombre = txtNombre.Text.Trim(),
    TipoComida = cboTipoComida.SelectedItem.ToString(),
          MontoG = decimal.Parse(txtMontoG.Text.Trim())
       };

                LogicaGastronomico.Crear(nuevoGastronomico);
     gastronomicos = LogicaGastronomico.Listar();
    ActualizarGrilla();
         LimpiarCampos();
        MessageBox.Show("Gastronomico agregado correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
if (gastronomicoSeleccionado != null && ValidarCampos())
  {
            gastronomicoSeleccionado.Nombre = txtNombre.Text.Trim();
      gastronomicoSeleccionado.TipoComida = cboTipoComida.SelectedItem.ToString();
         gastronomicoSeleccionado.MontoG = decimal.Parse(txtMontoG.Text.Trim());

      LogicaGastronomico.Editar(gastronomicoSeleccionado);
    gastronomicos = LogicaGastronomico.Listar();
       ActualizarGrilla();
         LimpiarCampos();
   MessageBox.Show("Gastronomico modificado correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
 }
     else
     {
       MessageBox.Show("Debe seleccionar un gastronomico para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
     }
        }

  private void BtnEliminar_Click(object sender, EventArgs e)
     {
            if (gastronomicoSeleccionado != null)
            {
    var resultado = MessageBox.Show($"�Est� seguro de eliminar el gastronomico '{gastronomicoSeleccionado.Nombre}'?",
          "Confirmar Eliminaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

       if (resultado == DialogResult.Yes)
       {
            LogicaGastronomico.Eliminar(gastronomicoSeleccionado.IdGastro);
   gastronomicos = LogicaGastronomico.Listar();
 ActualizarGrilla();
              LimpiarCampos();
        MessageBox.Show("Gastronomico eliminado correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
  }
  else
            {
      MessageBox.Show("Debe seleccionar un gastronomico para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
     }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
        LimpiarCampos();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
    {
            this.Close();
        }

        private void DgvGastronomicos_SelectionChanged(object sender, EventArgs e)
        {
     if (dgvGastronomicos.SelectedRows.Count > 0)
            {
  gastronomicoSeleccionado = (Entidades.Gastronomico)dgvGastronomicos.SelectedRows[0].DataBoundItem;
     CargarDatosEnCampos(gastronomicoSeleccionado);
  }
      }

   private void CargarDatosEnCampos(Entidades.Gastronomico gastronomico)
        {
         txtNombre.Text = gastronomico.Nombre;
       cboTipoComida.SelectedItem = gastronomico.TipoComida;
  txtMontoG.Text = gastronomico.MontoG.ToString("F2");
      }

        private void LimpiarCampos()
        {
   txtNombre.Clear();
          cboTipoComida.SelectedIndex = -1;
         txtMontoG.Clear();
      gastronomicoSeleccionado = null;
            dgvGastronomicos.ClearSelection();
        }

      private bool ValidarCampos()
  {
 if (string.IsNullOrWhiteSpace(txtNombre.Text))
     {
        MessageBox.Show("El nombre del servicio es obligatorio.", "Error de Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtNombre.Focus();
  return false;
          }

 if (cboTipoComida.SelectedIndex == -1)
        {
          MessageBox.Show("Debe seleccionar un tipo de comida.", "Error de Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
           cboTipoComida.Focus();
     return false;
 }

            if (string.IsNullOrWhiteSpace(txtMontoG.Text))
            {
 MessageBox.Show("El monto es obligatorio.", "Error de Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
    txtMontoG.Focus();
       return false;
            }

            if (!decimal.TryParse(txtMontoG.Text.Trim(), out decimal monto) || monto < 0)
            {
   MessageBox.Show("El monto debe ser un n�mero v�lido mayor o igual a 0.", "Error de Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
      txtMontoG.Focus();
       return false;
            }

            return true;
    }
    }
}
