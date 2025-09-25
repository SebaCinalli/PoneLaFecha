using System;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class FrmRegistro : Form
    {
        private TextBox txtNombreUsuario;
        private TextBox txtPassword;
        private TextBox txtConfirmarPassword;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private Label lblNombreUsuario;
        private Label lblPassword;
        private Label lblConfirmarPassword;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblTitulo;
        private Button btnRegistrar;
        private Button btnCancelar;
        private CheckBox chkMostrarPassword;

        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtNombreUsuario = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmarPassword = new TextBox();
            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtEmail = new TextBox();
            this.txtTelefono = new TextBox();
            this.lblNombreUsuario = new Label();
            this.lblPassword = new Label();
            this.lblConfirmarPassword = new Label();
            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblEmail = new Label();
            this.lblTelefono = new Label();
            this.lblTitulo = new Label();
            this.btnRegistrar = new Button();
            this.btnCancelar = new Button();
            this.chkMostrarPassword = new CheckBox();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(150, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(200, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Cliente";

            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new Point(30, 70);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new Size(103, 15);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre Usuario:*";

            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new Point(30, 90);
            this.txtNombreUsuario.MaxLength = 50;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new Size(200, 23);
            this.txtNombreUsuario.TabIndex = 1;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(270, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(75, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña:*";

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new Point(270, 90);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new Size(200, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Location = new Point(30, 130);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new Size(133, 15);
            this.lblConfirmarPassword.TabIndex = 5;
            this.lblConfirmarPassword.Text = "Confirmar Contraseña:*";

            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Location = new Point(30, 150);
            this.txtConfirmarPassword.MaxLength = 100;
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.Size = new Size(200, 23);
            this.txtConfirmarPassword.TabIndex = 3;
            this.txtConfirmarPassword.UseSystemPasswordChar = true;

            // 
            // chkMostrarPassword
            // 
            this.chkMostrarPassword.AutoSize = true;
            this.chkMostrarPassword.Location = new Point(270, 130);
            this.chkMostrarPassword.Name = "chkMostrarPassword";
            this.chkMostrarPassword.Size = new Size(129, 19);
            this.chkMostrarPassword.TabIndex = 4;
            this.chkMostrarPassword.Text = "Mostrar contraseñas";
            this.chkMostrarPassword.UseVisualStyleBackColor = true;
            this.chkMostrarPassword.CheckedChanged += ChkMostrarPassword_CheckedChanged;

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(30, 190);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(57, 15);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre:*";

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(30, 210);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(200, 23);
            this.txtNombre.TabIndex = 5;

            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new Point(270, 190);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(57, 15);
            this.lblApellido.TabIndex = 9;
            this.lblApellido.Text = "Apellido:*";

            // 
            // txtApellido
            // 
            this.txtApellido.Location = new Point(270, 210);
            this.txtApellido.MaxLength = 100;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(200, 23);
            this.txtApellido.TabIndex = 6;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(30, 250);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(39, 15);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(30, 270);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 23);
            this.txtEmail.TabIndex = 7;

            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new Point(270, 250);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(58, 15);
            this.lblTelefono.TabIndex = 13;
            this.lblTelefono.Text = "Teléfono:";

            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new Point(270, 270);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(200, 23);
            this.txtTelefono.TabIndex = 8;

            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = Color.Green;
            this.btnRegistrar.ForeColor = Color.White;
            this.btnRegistrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnRegistrar.Location = new Point(150, 320);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new Size(120, 35);
            this.btnRegistrar.TabIndex = 9;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += BtnRegistrar_Click;

            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCancelar.Location = new Point(290, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(120, 35);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += BtnCancelar_Click;

            // 
            // FrmRegistro
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(500, 380);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.chkMostrarPassword);
            this.Controls.Add(this.txtConfirmarPassword);
            this.Controls.Add(this.lblConfirmarPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistro";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registro de Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

            // Configurar Enter key
            this.AcceptButton = this.btnRegistrar;
        }

        private void ChkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkMostrarPassword.Checked;
            txtConfirmarPassword.UseSystemPasswordChar = !chkMostrarPassword.Checked;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    var nuevoUsuario = new Usuario
                    {
                        NombreUsuario = txtNombreUsuario.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        Rol = "Cliente", // Siempre se registra como cliente
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                        Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    };

                    LogicaUsuario.Crear(nuevoUsuario);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar usuario: {ex.Message}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidarCampos()
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            // Validar email si se proporciona
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El formato del email no es válido.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Verificar que el nombre de usuario no exista
            var usuarioExistente = LogicaUsuario.ObtenerPorNombreUsuario(txtNombreUsuario.Text.Trim());
            if (usuarioExistente != null)
            {
                MessageBox.Show("El nombre de usuario ya existe. Elija otro.", "Error de Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            return true;
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}