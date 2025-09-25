using System;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmLogin : Form
    {
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Label lblUsuario;
        private Label lblPassword;
        private Label lblTitulo;
        private Button btnIngresar;
        private Button btnRegistrarse;
        private Button btnSalir;
        private CheckBox chkMostrarPassword;

        public bool LoginExitoso { get; private set; } = false;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtUsuario = new TextBox();
            this.txtPassword = new TextBox();
            this.lblUsuario = new Label();
            this.lblPassword = new Label();
            this.lblTitulo = new Label();
            this.btnIngresar = new Button();
            this.btnRegistrarse = new Button();
            this.btnSalir = new Button();
            this.chkMostrarPassword = new CheckBox();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(80, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(240, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Pone La Fecha";

            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblUsuario.Location = new Point(50, 100);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(61, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";

            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtUsuario.Location = new Point(50, 120);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new Size(300, 23);
            this.txtUsuario.TabIndex = 1;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblPassword.Location = new Point(50, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(85, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña:";

            // 
            // txtPassword
            // 
            this.txtPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtPassword.Location = new Point(50, 180);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new Size(300, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // chkMostrarPassword
            // 
            this.chkMostrarPassword.AutoSize = true;
            this.chkMostrarPassword.Location = new Point(50, 210);
            this.chkMostrarPassword.Name = "chkMostrarPassword";
            this.chkMostrarPassword.Size = new Size(129, 19);
            this.chkMostrarPassword.TabIndex = 3;
            this.chkMostrarPassword.Text = "Mostrar contraseña";
            this.chkMostrarPassword.UseVisualStyleBackColor = true;
            this.chkMostrarPassword.CheckedChanged += ChkMostrarPassword_CheckedChanged;

            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = Color.DarkBlue;
            this.btnIngresar.ForeColor = Color.White;
            this.btnIngresar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnIngresar.Location = new Point(50, 250);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new Size(140, 35);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += BtnIngresar_Click;

            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.BackColor = Color.Green;
            this.btnRegistrarse.ForeColor = Color.White;
            this.btnRegistrarse.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnRegistrarse.Location = new Point(210, 250);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new Size(140, 35);
            this.btnRegistrarse.TabIndex = 5;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = false;
            this.btnRegistrarse.Click += BtnRegistrarse_Click;

            // 
            // btnSalir
            // 
            this.btnSalir.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSalir.Location = new Point(130, 300);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(140, 30);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += BtnSalir_Click;

            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(400, 350);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.chkMostrarPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión - Pone La Fecha";
            this.ResumeLayout(false);
            this.PerformLayout();

            // Configurar Enter key
            this.AcceptButton = this.btnIngresar;
        }

        private void ChkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkMostrarPassword.Checked;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var usuario = LogicaUsuario.Autenticar(txtUsuario.Text.Trim(), txtPassword.Text.Trim());
                
                if (usuario != null)
                {
                    SesionUsuario.UsuarioActual = usuario;
                    LoginExitoso = true;
                    MessageBox.Show($"Bienvenido {usuario.Nombre} {usuario.Apellido}!", 
                        "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", 
                        "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsuario.Focus();
                }
            }
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            var frmRegistro = new FrmRegistro();
            this.Hide();
            
            if (frmRegistro.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Usuario registrado exitosamente. Ahora puede iniciar sesión.", 
                    "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            this.Show();
            txtUsuario.Clear();
            txtPassword.Clear();
            txtUsuario.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }
    }
}