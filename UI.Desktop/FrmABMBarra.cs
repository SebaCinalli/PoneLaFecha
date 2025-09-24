using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmABMBarra : Form
    {
        private DataGridView dgvBarras;
        private TextBox txtNombre;
        private TextBox txtTipoBebida;
        private TextBox txtPrecioPorHora;
        private TextBox txtEstado;
        private TextBox txtDescripcion;
        private Label lblNombre;
        private Label lblTipoBebida;
        private Label lblPrecioPorHora;
        private Label lblEstado;
        private Label lblDescripcion;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnVolver;

        private List<Entidades.Barra> barras;
        private Entidades.Barra barraSeleccionada;

        public FrmABMBarra()
        {
            InitializeComponent();
            InicializarDatos();
            ConfigurarEventos();
        }

        private void InitializeComponent()
        {
            this.dgvBarras = new DataGridView();
            this.txtNombre = new TextBox();
            this.txtTipoBebida = new TextBox();
            this.txtPrecioPorHora = new TextBox();
            this.txtEstado = new TextBox();
            this.txtDescripcion = new TextBox();
            this.lblNombre = new Label();
            this.lblTipoBebida = new Label();
            this.lblPrecioPorHora = new Label();
            this.lblEstado = new Label();
            this.lblDescripcion = new Label();
            this.btnAgregar = new Button();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnLimpiar = new Button();
            this.btnVolver = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvBarras
            // 
            this.dgvBarras.AllowUserToAddRows = false;
            this.dgvBarras.AllowUserToDeleteRows = false;
            this.dgvBarras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBarras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarras.Location = new Point(12, 12);
            this.dgvBarras.MultiSelect = false;
            this.dgvBarras.Name = "dgvBarras";
            this.dgvBarras.ReadOnly = true;
            this.dgvBarras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarras.Size = new Size(760, 200);
            this.dgvBarras.TabIndex = 0;

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(12, 230);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(90, 227);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(150, 23);
            this.txtNombre.TabIndex = 2;

            // 
            // lblTipoBebida
            // 
            this.lblTipoBebida.AutoSize = true;
            this.lblTipoBebida.Location = new Point(260, 230);
            this.lblTipoBebida.Name = "lblTipoBebida";
            this.lblTipoBebida.Size = new Size(75, 15);
            this.lblTipoBebida.TabIndex = 3;
            this.lblTipoBebida.Text = "Tipo Bebida:";

            // 
            // txtTipoBebida
            // 
            this.txtTipoBebida.Location = new Point(345, 227);
            this.txtTipoBebida.Name = "txtTipoBebida";
            this.txtTipoBebida.Size = new Size(150, 23);
            this.txtTipoBebida.TabIndex = 4;

            // 
            // lblPrecioPorHora
            // 
            this.lblPrecioPorHora.AutoSize = true;
            this.lblPrecioPorHora.Location = new Point(12, 265);
            this.lblPrecioPorHora.Name = "lblPrecioPorHora";
            this.lblPrecioPorHora.Size = new Size(86, 15);
            this.lblPrecioPorHora.TabIndex = 5;
            this.lblPrecioPorHora.Text = "Precio por Hora:";

            // 
            // txtPrecioPorHora
            // 
            this.txtPrecioPorHora.Location = new Point(110, 262);
            this.txtPrecioPorHora.Name = "txtPrecioPorHora";
            this.txtPrecioPorHora.Size = new Size(130, 23);
            this.txtPrecioPorHora.TabIndex = 6;

            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new Point(260, 265);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new Size(45, 15);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado:";

            // 
            // txtEstado
            // 
            this.txtEstado.Location = new Point(315, 262);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new Size(130, 23);
            this.txtEstado.TabIndex = 8;

            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new Point(12, 300);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(72, 15);
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "Descripción:";

            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Point(90, 297);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(355, 40);
            this.txtDescripcion.TabIndex = 10;

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 360);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(100, 30);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;

            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(130, 360);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(100, 30);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(248, 360);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(100, 30);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new Point(366, 360);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 30);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;

            // 
            // btnVolver
            // 
            this.btnVolver.Location = new Point(672, 360);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new Size(100, 30);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;

            // 
            // FrmABMBarra
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 411);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtPrecioPorHora);
            this.Controls.Add(this.lblPrecioPorHora);
            this.Controls.Add(this.txtTipoBebida);
            this.Controls.Add(this.lblTipoBebida);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.dgvBarras);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmABMBarra";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ABM Barras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).EndInit();
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
            this.dgvBarras.SelectionChanged += DgvBarras_SelectionChanged;
        }

        private void InicializarDatos()
        {
            barras = LogicaBarra.Listar();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvBarras.DataSource = null;
            dgvBarras.DataSource = barras;

            if (dgvBarras.Columns["IdBarra"] != null)
                dgvBarras.Columns["IdBarra"].Visible = false;

            // Configurar headers amigables
            if (dgvBarras.Columns["TipoBebida"] != null)
                dgvBarras.Columns["TipoBebida"].HeaderText = "Tipo Bebida";
            if (dgvBarras.Columns["PrecioPorHora"] != null)
            {
                dgvBarras.Columns["PrecioPorHora"].HeaderText = "Precio por Hora";
                dgvBarras.Columns["PrecioPorHora"].DefaultCellStyle.Format = "C2";
            }
            if (dgvBarras.Columns["Descripcion"] != null)
                dgvBarras.Columns["Descripcion"].HeaderText = "Descripción";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var nuevaBarra = new Entidades.Barra
                {
                    Nombre = txtNombre.Text.Trim(),
                    TipoBebida = txtTipoBebida.Text.Trim(),
                    PrecioPorHora = decimal.Parse(txtPrecioPorHora.Text.Trim()),
                    Estado = txtEstado.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                try
                {
                    LogicaBarra.Crear(nuevaBarra);
                    barras = LogicaBarra.Listar();
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("Barra agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar barra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (barraSeleccionada != null && ValidarCampos())
            {
                barraSeleccionada.Nombre = txtNombre.Text.Trim();
                barraSeleccionada.TipoBebida = txtTipoBebida.Text.Trim();
                barraSeleccionada.PrecioPorHora = decimal.Parse(txtPrecioPorHora.Text.Trim());
                barraSeleccionada.Estado = txtEstado.Text.Trim();
                barraSeleccionada.Descripcion = txtDescripcion.Text.Trim();

                try
                {
                    LogicaBarra.Editar(barraSeleccionada);
                    barras = LogicaBarra.Listar();
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("Barra modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar barra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una barra para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (barraSeleccionada != null)
            {
                var resultado = MessageBox.Show($"¿Está seguro de eliminar la barra {barraSeleccionada.Nombre}?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        LogicaBarra.Eliminar(barraSeleccionada.IdBarra);
                        barras = LogicaBarra.Listar();
                        ActualizarGrilla();
                        LimpiarCampos();
                        MessageBox.Show("Barra eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar barra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una barra para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void DgvBarras_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBarras.SelectedRows.Count > 0)
            {
                barraSeleccionada = (Entidades.Barra)dgvBarras.SelectedRows[0].DataBoundItem;
                CargarDatosEnCampos(barraSeleccionada);
            }
        }

        private void CargarDatosEnCampos(Entidades.Barra barra)
        {
            txtNombre.Text = barra.Nombre;
            txtTipoBebida.Text = barra.TipoBebida;
            txtPrecioPorHora.Text = barra.PrecioPorHora.ToString("F2");
            txtEstado.Text = barra.Estado;
            txtDescripcion.Text = barra.Descripcion;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTipoBebida.Clear();
            txtPrecioPorHora.Clear();
            txtEstado.Clear();
            txtDescripcion.Clear();
            barraSeleccionada = null;
            dgvBarras.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTipoBebida.Text))
            {
                MessageBox.Show("El tipo de bebida es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTipoBebida.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioPorHora.Text))
            {
                MessageBox.Show("El precio por hora es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioPorHora.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecioPorHora.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio por hora debe ser un número válido mayor o igual a 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioPorHora.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("El estado es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEstado.Focus();
                return false;
            }

            return true;
        }
    }
}