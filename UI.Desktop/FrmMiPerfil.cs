using System;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmMiPerfil : Form
    {
        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Button btnGuardar;
        private Button btnCancelar;
        private Panel panelInfo;
        private Label lblInfo;

        private Cliente _cliente;

        public FrmMiPerfil(string nombreUsuario)
        {
            InitializeComponent();
            CargarDatosCliente(nombreUsuario);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.panelInfo = new Panel();
            this.lblInfo = new Label();
            this.lblUsuario = new Label();
            this.txtUsuario = new TextBox();
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblApellido = new Label();
            this.txtApellido = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblTelefono = new Label();
            this.txtTelefono = new TextBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();

            this.SuspendLayout();
            this.panelInfo.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(180, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mi Perfil";

            // panelInfo
            this.panelInfo.BackColor = Color.LightYellow;
            this.panelInfo.BorderStyle = BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.lblInfo);
            this.panelInfo.Location = new Point(30, 60);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new Size(520, 40);
            this.panelInfo.TabIndex = 1;

            // lblInfo
            this.lblInfo.AutoSize = false;
            this.lblInfo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblInfo.Location = new Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(500, 20);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "? Actualice su información personal. El nombre de usuario no puede modificarse.";

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblUsuario.Location = new Point(30, 120);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(68, 17);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario:";

            // txtUsuario
            this.txtUsuario.BackColor = Color.LightGray;
            this.txtUsuario.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtUsuario.Location = new Point(150, 117);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new Size(400, 23);
            this.txtUsuario.TabIndex = 3;

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblNombre.Location = new Point(30, 160);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(62, 17);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtNombre.Location = new Point(150, 157);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(400, 23);
            this.txtNombre.TabIndex = 5;

            // lblApellido
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblApellido.Location = new Point(30, 200);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new Size(62, 17);
            this.lblApellido.TabIndex = 6;
            this.lblApellido.Text = "Apellido:";

            // txtApellido
            this.txtApellido.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtApellido.Location = new Point(150, 197);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new Size(400, 23);
            this.txtApellido.TabIndex = 7;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblEmail.Location = new Point(30, 240);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(47, 17);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtEmail.Location = new Point(150, 237);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(400, 23);
            this.txtEmail.TabIndex = 9;

            // lblTelefono
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTelefono.Location = new Point(30, 280);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new Size(68, 17);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono:";

            // txtTelefono
            this.txtTelefono.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtTelefono.Location = new Point(150, 277);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new Size(400, 23);
            this.txtTelefono.TabIndex = 11;

            // btnGuardar
            this.btnGuardar.BackColor = Color.LightGreen;
            this.btnGuardar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnGuardar.Location = new Point(150, 330);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(150, 40);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += BtnGuardar_Click;

            // btnCancelar
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCancelar.Location = new Point(320, 330);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(150, 40);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += BtnCancelar_Click;

            // FrmMiPerfil
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(580, 400);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMiPerfil";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Mi Perfil";

            this.panelInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CargarDatosCliente(string nombreUsuario)
        {
            try
            {
                _cliente = LogicaCliente.ObtenerPorNombreUsuario(nombreUsuario);
                
                if (_cliente == null)
                {
                    MessageBox.Show("No se encontró el perfil del cliente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtUsuario.Text = _cliente.NombreUsuario;
                txtNombre.Text = _cliente.Nombre;
                txtApellido.Text = _cliente.Apellido;
                txtEmail.Text = _cliente.Email;
                txtTelefono.Text = _cliente.Telefono;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                _cliente.Nombre = txtNombre.Text.Trim();
                _cliente.Apellido = txtApellido.Text.Trim();
                _cliente.Email = txtEmail.Text.Trim();
                _cliente.Telefono = txtTelefono.Text.Trim();

                LogicaCliente.Editar(_cliente);

                MessageBox.Show("Su perfil ha sido actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el perfil: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El email es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validación básica de email
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("El email no tiene un formato válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }
    }
}
