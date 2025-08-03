using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FrmABMCliente : Form
    {
        private DataGridView dgvClientes;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtNombreUsuario;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblNombreUsuario;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;

        // Lista para manejar los clientes (simulando base de datos)
        private List<Entidades.Cliente> clientes;
        private Entidades.Cliente clienteSeleccionado;

        public FrmABMCliente()
        {
            InitializeComponent();
            InicializarDatos();
            ConfigurarEventos();
        }

        private void InitializeComponent()
        {
            this.dgvClientes = new DataGridView();
            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtEmail = new TextBox();
            this.txtTelefono = new TextBox();
            this.txtNombreUsuario = new TextBox();
            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblEmail = new Label();
            this.lblTelefono = new Label();
            this.lblNombreUsuario = new Label();
            this.btnAgregar = new Button();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnLimpiar = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new Point(12, 12);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new Size(760, 250);
            this.dgvClientes.TabIndex = 0;

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
            this.txtNombre.Location = new Point(90, 277);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(150, 23);
            this.txtNombre.TabIndex = 2;

            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(260, 280);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(54, 15);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido:";

            // 
            // txtApellido
            // 
            this.txtApellido.Location = new Point(330, 277);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(150, 23);
            this.txtApellido.TabIndex = 4;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(12, 315);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(90, 312);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 23);
            this.txtEmail.TabIndex = 6;

            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new Point(310, 315);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(58, 15);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new Point(380, 312);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(150, 23);
            this.txtTelefono.TabIndex = 8;

            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new Point(12, 350);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new Size(50, 15);
            this.lblNombreUsuario.TabIndex = 9;
            this.lblNombreUsuario.Text = "Usuario:";

            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new Point(90, 347);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new Size(150, 23);
            this.txtNombreUsuario.TabIndex = 10;

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 390);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(100, 30);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;

            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(130, 390);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(100, 30);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(248, 390);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(100, 30);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new Point(366, 390);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 30);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;

            // 
            // FrmABMCliente
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(784, 441);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.dgvClientes);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmABMCliente";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ABM Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigurarEventos()
        {
            this.btnAgregar.Click += BtnAgregar_Click;
            this.btnModificar.Click += BtnModificar_Click;
            this.btnEliminar.Click += BtnEliminar_Click;
            this.btnLimpiar.Click += BtnLimpiar_Click;
            this.dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;
        }

        private void InicializarDatos()
        {
            clientes = new List<Entidades.Cliente>();

            // Datos de ejemplo
            clientes.Add(new Entidades.Cliente
            {
                IdCliente = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan.perez@email.com",
                Telefono = "123456789",
                NombreUsuario = "jperez"
            });

            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes;

            // Ocultar la columna ID si existe
            if (dgvClientes.Columns["IdCliente"] != null)
                dgvClientes.Columns["IdCliente"].Visible = false;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var nuevoCliente = new Entidades.Cliente
                {
                    IdCliente = clientes.Count > 0 ? clientes.Max(c => c.IdCliente) + 1 : 1,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    NombreUsuario = txtNombreUsuario.Text.Trim()
                };

                clientes.Add(nuevoCliente);
                ActualizarGrilla();
                LimpiarCampos();
                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado != null && ValidarCampos())
            {
                clienteSeleccionado.Nombre = txtNombre.Text.Trim();
                clienteSeleccionado.Apellido = txtApellido.Text.Trim();
                clienteSeleccionado.Email = txtEmail.Text.Trim();
                clienteSeleccionado.Telefono = txtTelefono.Text.Trim();
                clienteSeleccionado.NombreUsuario = txtNombreUsuario.Text.Trim();

                ActualizarGrilla();
                LimpiarCampos();
                MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado != null)
            {
                var resultado = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido}?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    clientes.Remove(clienteSeleccionado);
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                clienteSeleccionado = (Entidades.Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
                CargarDatosEnCampos(clienteSeleccionado);
            }
        }

        private void CargarDatosEnCampos(Entidades.Cliente cliente)
        {
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            txtNombreUsuario.Text = cliente.NombreUsuario;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtNombreUsuario.Clear();
            clienteSeleccionado = null;
            dgvClientes.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El email es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreUsuario.Focus();
                return false;
            }

            return true;
        }
    }
}