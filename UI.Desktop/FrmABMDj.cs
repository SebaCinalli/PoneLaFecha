using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmABMDj : Form
    {
        private DataGridView dgvDjs;
        private TextBox txtNombreArtistico;
        private TextBox txtEstado;
        private TextBox txtMontoDj;
        private TextBox txtFoto;
        private Label lblNombreArtistico;
        private Label lblEstado;
        private Label lblMontoDj;
        private Label lblFoto;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnVolver;

        private List<Entidades.Dj> djs;
        private Entidades.Dj djSeleccionado;

        public FrmABMDj()
        {
            InitializeComponent();
            InicializarDatos();
            ConfigurarEventos();
        }

        private void InitializeComponent()
        {
            this.dgvDjs = new DataGridView();
            this.txtNombreArtistico = new TextBox();
            this.txtEstado = new TextBox();
            this.txtMontoDj = new TextBox();
            this.txtFoto = new TextBox();
            this.lblNombreArtistico = new Label();
            this.lblEstado = new Label();
            this.lblMontoDj = new Label();
            this.lblFoto = new Label();
            this.btnAgregar = new Button();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnLimpiar = new Button();
            this.btnVolver = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDjs)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvDjs
            // 
            this.dgvDjs.AllowUserToAddRows = false;
            this.dgvDjs.AllowUserToDeleteRows = false;
            this.dgvDjs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDjs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDjs.Location = new Point(12, 12);
            this.dgvDjs.MultiSelect = false;
            this.dgvDjs.Name = "dgvDjs";
            this.dgvDjs.ReadOnly = true;
            this.dgvDjs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDjs.Size = new Size(760, 250);
            this.dgvDjs.TabIndex = 0;

            // 
            // lblNombreArtistico
            // 
            this.lblNombreArtistico.AutoSize = true;
            this.lblNombreArtistico.Location = new Point(12, 280);
            this.lblNombreArtistico.Name = "lblNombreArtistico";
            this.lblNombreArtistico.Size = new Size(95, 15);
            this.lblNombreArtistico.TabIndex = 1;
            this.lblNombreArtistico.Text = "Nombre Artístico:";

            // 
            // txtNombreArtistico
            // 
            this.txtNombreArtistico.Location = new Point(120, 277);
            this.txtNombreArtistico.Name = "txtNombreArtistico";
            this.txtNombreArtistico.Size = new Size(200, 23);
            this.txtNombreArtistico.TabIndex = 2;

            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new Point(340, 280);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new Size(45, 15);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";

            // 
            // txtEstado
            // 
            this.txtEstado.Location = new Point(395, 277);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new Size(150, 23);
            this.txtEstado.TabIndex = 4;

            // 
            // lblMontoDj
            // 
            this.lblMontoDj.AutoSize = true;
            this.lblMontoDj.Location = new Point(12, 315);
            this.lblMontoDj.Name = "lblMontoDj";
            this.lblMontoDj.Size = new Size(58, 15);
            this.lblMontoDj.TabIndex = 5;
            this.lblMontoDj.Text = "Monto DJ:";

            // 
            // txtMontoDj
            // 
            this.txtMontoDj.Location = new Point(120, 312);
            this.txtMontoDj.Name = "txtMontoDj";
            this.txtMontoDj.Size = new Size(150, 23);
            this.txtMontoDj.TabIndex = 6;

            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new Point(290, 315);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new Size(32, 15);
            this.lblFoto.TabIndex = 7;
            this.lblFoto.Text = "Foto:";

            // 
            // txtFoto
            // 
            this.txtFoto.Location = new Point(330, 312);
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.Size = new Size(215, 23);
            this.txtFoto.TabIndex = 8;

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 360);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(100, 30);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;

            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(130, 360);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(100, 30);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(248, 360);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(100, 30);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new Point(366, 360);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 30);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;

            // 
            // btnVolver
            // 
            this.btnVolver.Location = new Point(672, 360);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new Size(100, 30);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;

            // 
            // FrmABMDj
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 411);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtFoto);
            this.Controls.Add(this.lblFoto);
            this.Controls.Add(this.txtMontoDj);
            this.Controls.Add(this.lblMontoDj);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtNombreArtistico);
            this.Controls.Add(this.lblNombreArtistico);
            this.Controls.Add(this.dgvDjs);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmABMDj";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ABM DJs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDjs)).EndInit();
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
            this.dgvDjs.SelectionChanged += DgvDjs_SelectionChanged;
        }

        private void InicializarDatos()
        {
            djs = LogicaDj.Listar();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvDjs.DataSource = null;
            dgvDjs.DataSource = djs;

            if (dgvDjs.Columns["IdDj"] != null)
                dgvDjs.Columns["IdDj"].Visible = false;

            // Configurar headers amigables
            if (dgvDjs.Columns["NombreArtistico"] != null)
                dgvDjs.Columns["NombreArtistico"].HeaderText = "Nombre Artístico";
            if (dgvDjs.Columns["MontoDj"] != null)
                dgvDjs.Columns["MontoDj"].HeaderText = "Monto DJ";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var nuevoDj = new Entidades.Dj
                {
                    NombreArtistico = txtNombreArtistico.Text.Trim(),
                    Estado = txtEstado.Text.Trim(),
                    MontoDj = decimal.Parse(txtMontoDj.Text.Trim()),
                    Foto = string.IsNullOrWhiteSpace(txtFoto.Text) ? null : txtFoto.Text.Trim()
                };

                try
                {
                    LogicaDj.Crear(nuevoDj);
                    djs = LogicaDj.Listar();
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("DJ agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar DJ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (djSeleccionado != null && ValidarCampos())
            {
                djSeleccionado.NombreArtistico = txtNombreArtistico.Text.Trim();
                djSeleccionado.Estado = txtEstado.Text.Trim();
                djSeleccionado.MontoDj = decimal.Parse(txtMontoDj.Text.Trim());
                djSeleccionado.Foto = string.IsNullOrWhiteSpace(txtFoto.Text) ? null : txtFoto.Text.Trim();

                try
                {
                    LogicaDj.Editar(djSeleccionado);
                    djs = LogicaDj.Listar();
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("DJ modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar DJ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un DJ para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (djSeleccionado != null)
            {
                var resultado = MessageBox.Show($"¿Está seguro de eliminar al DJ {djSeleccionado.NombreArtistico}?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        LogicaDj.Eliminar(djSeleccionado.IdDj);
                        djs = LogicaDj.Listar();
                        ActualizarGrilla();
                        LimpiarCampos();
                        MessageBox.Show("DJ eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar DJ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un DJ para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void DgvDjs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDjs.SelectedRows.Count > 0)
            {
                djSeleccionado = (Entidades.Dj)dgvDjs.SelectedRows[0].DataBoundItem;
                CargarDatosEnCampos(djSeleccionado);
            }
        }

        private void CargarDatosEnCampos(Entidades.Dj dj)
        {
            txtNombreArtistico.Text = dj.NombreArtistico;
            txtEstado.Text = dj.Estado;
            txtMontoDj.Text = dj.MontoDj.ToString("F2");
            txtFoto.Text = dj.Foto ?? string.Empty;
        }

        private void LimpiarCampos()
        {
            txtNombreArtistico.Clear();
            txtEstado.Clear();
            txtMontoDj.Clear();
            txtFoto.Clear();
            djSeleccionado = null;
            dgvDjs.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreArtistico.Text))
            {
                MessageBox.Show("El nombre artístico es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreArtistico.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("El estado es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEstado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMontoDj.Text))
            {
                MessageBox.Show("El monto DJ es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontoDj.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMontoDj.Text, out decimal monto) || monto < 0)
            {
                MessageBox.Show("El monto DJ debe ser un número válido mayor o igual a 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontoDj.Focus();
                return false;
            }

            return true;
        }
    }
}