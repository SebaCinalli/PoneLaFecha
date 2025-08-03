using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FrmABMSalon : Form
    {
        private DataGridView dgvSalones;
        private TextBox txtNombreSalon;
        private TextBox txtEstado;
        private TextBox txtMontoSalon;
        private Label lblNombreSalon;
        private Label lblEstado;
        private Label lblMontoSalon;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;

        // Lista para manejar los salones (simulando base de datos)
        private List<Entidades.Salon> salones;
        private Entidades.Salon salonSeleccionado;

        public FrmABMSalon()
        {
            InitializeComponent();
            InicializarDatos();
            ConfigurarEventos();
        }

        private void InitializeComponent()
        {
            this.dgvSalones = new DataGridView();
            this.txtNombreSalon = new TextBox();
            this.txtEstado = new TextBox();
            this.txtMontoSalon = new TextBox();
            this.lblNombreSalon = new Label();
            this.lblEstado = new Label();
            this.lblMontoSalon = new Label();
            this.btnAgregar = new Button();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnLimpiar = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvSalones
            // 
            this.dgvSalones.AllowUserToAddRows = false;
            this.dgvSalones.AllowUserToDeleteRows = false;
            this.dgvSalones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalones.Location = new Point(12, 12);
            this.dgvSalones.MultiSelect = false;
            this.dgvSalones.Name = "dgvSalones";
            this.dgvSalones.ReadOnly = true;
            this.dgvSalones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalones.Size = new Size(760, 250);
            this.dgvSalones.TabIndex = 0;

            // 
            // lblNombreSalon
            // 
            this.lblNombreSalon.AutoSize = true;
            this.lblNombreSalon.Location = new Point(12, 280);
            this.lblNombreSalon.Name = "lblNombreSalon";
            this.lblNombreSalon.Size = new Size(85, 15);
            this.lblNombreSalon.TabIndex = 1;
            this.lblNombreSalon.Text = "Nombre Salón:";

            // 
            // txtNombreSalon
            // 
            this.txtNombreSalon.Location = new Point(110, 277);
            this.txtNombreSalon.Name = "txtNombreSalon";
            this.txtNombreSalon.Size = new Size(200, 23);
            this.txtNombreSalon.TabIndex = 2;

            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new Point(330, 280);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new Size(45, 15);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";

            // 
            // txtEstado
            // 
            this.txtEstado.Location = new Point(385, 277);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new Size(150, 23);
            this.txtEstado.TabIndex = 4;

            // 
            // lblMontoSalon
            // 
            this.lblMontoSalon.AutoSize = true;
            this.lblMontoSalon.Location = new Point(12, 315);
            this.lblMontoSalon.Name = "lblMontoSalon";
            this.lblMontoSalon.Size = new Size(78, 15);
            this.lblMontoSalon.TabIndex = 5;
            this.lblMontoSalon.Text = "Monto Salón:";

            // 
            // txtMontoSalon
            // 
            this.txtMontoSalon.Location = new Point(110, 312);
            this.txtMontoSalon.Name = "txtMontoSalon";
            this.txtMontoSalon.Size = new Size(150, 23);
            this.txtMontoSalon.TabIndex = 6;

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 360);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(100, 30);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;

            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(130, 360);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(100, 30);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(248, 360);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(100, 30);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new Point(366, 360);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 30);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;

            // 
            // FrmABMSalon
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 411);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMontoSalon);
            this.Controls.Add(this.lblMontoSalon);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtNombreSalon);
            this.Controls.Add(this.lblNombreSalon);
            this.Controls.Add(this.dgvSalones);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmABMSalon";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ABM Salones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigurarEventos()
        {
            this.btnAgregar.Click += BtnAgregar_Click;
            this.btnModificar.Click += BtnModificar_Click;
            this.btnEliminar.Click += BtnEliminar_Click;
            this.btnLimpiar.Click += BtnLimpiar_Click;
            this.dgvSalones.SelectionChanged += DgvSalones_SelectionChanged;
        }

        private void InicializarDatos()
        {
            salones = new List<Entidades.Salon>();

            // Datos de ejemplo
            salones.Add(new Entidades.Salon
            {
                IdSalon = 1,
                NombreSalon = "Salón Primavera",
                Estado = "Disponible",
                MontoSalon = 25000.00m
            });

            salones.Add(new Entidades.Salon
            {
                IdSalon = 2,
                NombreSalon = "Salón Elegante",
                Estado = "Ocupado",
                MontoSalon = 35000.00m
            });

            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvSalones.DataSource = null;
            dgvSalones.DataSource = salones;

            // Ocultar la columna ID si existe
            if (dgvSalones.Columns["IdSalon"] != null)
                dgvSalones.Columns["IdSalon"].Visible = false;

            // Formatear la columna de monto como moneda
            if (dgvSalones.Columns["MontoSalon"] != null)
            {
                dgvSalones.Columns["MontoSalon"].DefaultCellStyle.Format = "C2";
                dgvSalones.Columns["MontoSalon"].HeaderText = "Monto";
            }

            // Cambiar headers para mejor presentación
            if (dgvSalones.Columns["NombreSalon"] != null)
                dgvSalones.Columns["NombreSalon"].HeaderText = "Nombre del Salón";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var nuevoSalon = new Entidades.Salon
                {
                    IdSalon = salones.Count > 0 ? salones.Max(s => s.IdSalon) + 1 : 1,
                    NombreSalon = txtNombreSalon.Text.Trim(),
                    Estado = txtEstado.Text.Trim(),
                    MontoSalon = decimal.Parse(txtMontoSalon.Text.Trim())
                };

                salones.Add(nuevoSalon);
                ActualizarGrilla();
                LimpiarCampos();
                MessageBox.Show("Salón agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (salonSeleccionado != null && ValidarCampos())
            {
                salonSeleccionado.NombreSalon = txtNombreSalon.Text.Trim();
                salonSeleccionado.Estado = txtEstado.Text.Trim();
                salonSeleccionado.MontoSalon = decimal.Parse(txtMontoSalon.Text.Trim());

                ActualizarGrilla();
                LimpiarCampos();
                MessageBox.Show("Salón modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un salón para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (salonSeleccionado != null)
            {
                var resultado = MessageBox.Show($"¿Está seguro de eliminar el salón '{salonSeleccionado.NombreSalon}'?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    salones.Remove(salonSeleccionado);
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("Salón eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un salón para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void DgvSalones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalones.SelectedRows.Count > 0)
            {
                salonSeleccionado = (Entidades.Salon)dgvSalones.SelectedRows[0].DataBoundItem;
                CargarDatosEnCampos(salonSeleccionado);
            }
        }

        private void CargarDatosEnCampos(Entidades.Salon salon)
        {
            txtNombreSalon.Text = salon.NombreSalon;
            txtEstado.Text = salon.Estado;
            txtMontoSalon.Text = salon.MontoSalon.ToString("F2");
        }

        private void LimpiarCampos()
        {
            txtNombreSalon.Clear();
            txtEstado.Clear();
            txtMontoSalon.Clear();
            salonSeleccionado = null;
            dgvSalones.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreSalon.Text))
            {
                MessageBox.Show("El nombre del salón es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreSalon.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("El estado es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEstado.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMontoSalon.Text))
            {
                MessageBox.Show("El monto del salón es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontoSalon.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMontoSalon.Text.Trim(), out decimal monto) || monto < 0)
            {
                MessageBox.Show("El monto debe ser un número válido mayor o igual a 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMontoSalon.Focus();
                return false;
            }

            return true;
        }
    }
}