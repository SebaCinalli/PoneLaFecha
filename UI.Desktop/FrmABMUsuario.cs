using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class FrmABMUsuario : Form
    {
        private DataGridView dgvUsuarios;
        private TextBox txtNombreUsuario;
        private TextBox txtPassword;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private ComboBox cmbRol;
        private CheckBox chkActivo;
        private Label lblNombreUsuario;
        private Label lblPassword;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblRol;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnVolver;

        private List<Usuario> usuarios;
        private Usuario usuarioSeleccionado;

        public FrmABMUsuario()
        {
            InitializeComponent();
            InicializarDatos();
            ConfigurarEventos();
        }

        private void InitializeComponent()
        {
            this.dgvUsuarios = new DataGridView();
            this.txtNombreUsuario = new TextBox();
            this.txtPassword = new TextBox();
            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtEmail = new TextBox();
            this.txtTelefono = new TextBox();
            this.cmbRol = new ComboBox();
            this.chkActivo = new CheckBox();
            this.lblNombreUsuario = new Label();
            this.lblPassword = new Label();
            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblEmail = new Label();
            this.lblTelefono = new Label();
            this.lblRol = new Label();
            this.btnAgregar = new Button();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnLimpiar = new Button();
            this.btnVolver = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new Point(12, 12);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new Size(860, 250);
            this.dgvUsuarios.TabIndex = 0;

            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new Point(12, 280);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new Size(103, 15);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre Usuario:";

            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new Point(12, 300);
            this.txtNombreUsuario.MaxLength = 50;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new Size(150, 23);
            this.txtNombreUsuario.TabIndex = 2;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(180, 280);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(70, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña:";

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new Point(180, 300);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new Size(150, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(350, 280);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(54, 15);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(350, 300);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(150, 23);
            this.txtNombre.TabIndex = 6;

            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(520, 280);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(54, 15);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido:";

            // 
            // txtApellido
            // 
            this.txtApellido.Location = new Point(520, 300);
            this.txtApellido.MaxLength = 100;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(150, 23);
            this.txtApellido.TabIndex = 8;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(12, 340);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(12, 360);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 23);
            this.txtEmail.TabIndex = 10;

            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new Point(230, 340);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(58, 15);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new Point(230, 360);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(120, 23);
            this.txtTelefono.TabIndex = 12;

            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new Point(370, 340);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new Size(27, 15);
            this.lblRol.TabIndex = 13;
            this.lblRol.Text = "Rol:";

            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] { "Administrador", "Cliente" });
            this.cmbRol.Location = new Point(370, 360);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new Size(130, 23);
            this.cmbRol.TabIndex = 14;

            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = CheckState.Checked;
            this.chkActivo.Location = new Point(520, 362);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new Size(61, 19);
            this.chkActivo.TabIndex = 15;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;

            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new Point(12, 410);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(100, 30);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;

            // 
            // btnModificar
            // 
            this.btnModificar.Location = new Point(130, 410);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(100, 30);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;

            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new Point(248, 410);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(100, 30);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new Point(366, 410);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(100, 30);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;

            // 
            // btnVolver
            // 
            this.btnVolver.Location = new Point(772, 410);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new Size(100, 30);
            this.btnVolver.TabIndex = 20;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;

            // 
            // FrmABMUsuario
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(884, 461);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.dgvUsuarios);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmABMUsuario";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ABM Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
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
            this.dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;
        }

        private void InicializarDatos()
        {
            usuarios = LogicaUsuario.Listar();
            ActualizarGrilla();
            cmbRol.SelectedIndex = 1; // Cliente por defecto
        }

        private void ActualizarGrilla()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;

            // Configurar columnas
            if (dgvUsuarios.Columns["IdUsuario"] != null)
                dgvUsuarios.Columns["IdUsuario"].Visible = false;
            
            if (dgvUsuarios.Columns["Password"] != null)
                dgvUsuarios.Columns["Password"].Visible = false;
            
            if (dgvUsuarios.Columns["NombreUsuario"] != null)
                dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
            
            if (dgvUsuarios.Columns["FechaCreacion"] != null)
            {
                dgvUsuarios.Columns["FechaCreacion"].HeaderText = "Fecha Creación";
                dgvUsuarios.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    Rol = cmbRol.Text,
                    Activo = chkActivo.Checked,
                    FechaCreacion = DateTime.Now
                };

                try
                {
                    LogicaUsuario.Crear(nuevoUsuario);
                    usuarios = LogicaUsuario.Listar();
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado != null && ValidarCamposEdicion())
            {
                usuarioSeleccionado.Nombre = txtNombre.Text.Trim();
                usuarioSeleccionado.Apellido = txtApellido.Text.Trim();
                usuarioSeleccionado.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                usuarioSeleccionado.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim();
                usuarioSeleccionado.Rol = cmbRol.Text;
                usuarioSeleccionado.Activo = chkActivo.Checked;
                
                // Solo actualizar password si se ingresó uno nuevo
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    usuarioSeleccionado.Password = txtPassword.Text.Trim();
                }

                try
                {
                    LogicaUsuario.Editar(usuarioSeleccionado);
                    usuarios = LogicaUsuario.Listar();
                    ActualizarGrilla();
                    LimpiarCampos();
                    MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado != null)
            {
                // No permitir eliminar el usuario actual
                if (usuarioSeleccionado.IdUsuario == SesionUsuario.UsuarioActual?.IdUsuario)
                {
                    MessageBox.Show("No puede eliminar su propio usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show($"¿Está seguro de eliminar al usuario {usuarioSeleccionado.NombreUsuario}?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        LogicaUsuario.Eliminar(usuarioSeleccionado.IdUsuario);
                        usuarios = LogicaUsuario.Listar();
                        ActualizarGrilla();
                        LimpiarCampos();
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                CargarDatosEnCampos(usuarioSeleccionado);
            }
        }

        private void CargarDatosEnCampos(Usuario usuario)
        {
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtPassword.Clear(); // No mostrar password por seguridad
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email ?? string.Empty;
            txtTelefono.Text = usuario.Telefono ?? string.Empty;
            cmbRol.Text = usuario.Rol;
            chkActivo.Checked = usuario.Activo;
            
            // Deshabilitar edición del nombre de usuario para usuarios existentes
            txtNombreUsuario.Enabled = false;
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            txtPassword.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            cmbRol.SelectedIndex = 1; // Cliente por defecto
            chkActivo.Checked = true;
            usuarioSeleccionado = null;
            dgvUsuarios.ClearSelection();
            
            // Habilitar edición del nombre de usuario para nuevos usuarios
            txtNombreUsuario.Enabled = true;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }

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

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarCamposEdicion()
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

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRol.Focus();
                return false;
            }

            // Si se ingresó password, validar longitud
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }

            return true;
        }
    }
}