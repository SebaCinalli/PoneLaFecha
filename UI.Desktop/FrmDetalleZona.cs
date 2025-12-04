using System;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmDetalleZona : Form
    {
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnGuardar;
        private Button btnCancelar;

        private int? _idZona;
        private bool _soloLectura;

        public FrmDetalleZona(int? idZona = null, bool soloLectura = false)
        {
            _idZona = idZona;
            _soloLectura = soloLectura;
            InitializeComponent();
            
            if (_idZona.HasValue)
            {
                CargarZona();
            }

            if (_soloLectura)
            {
                txtNombre.ReadOnly = true;
                btnGuardar.Visible = false;
                btnCancelar.Text = "Cerrar";
                this.Text = "Detalles de Zona";
            }
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(80, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(250, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = _idZona.HasValue ? "Editar Zona" : "Nueva Zona";

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblNombre.Location = new Point(30, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(62, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtNombre.Location = new Point(120, 77);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(250, 23);
            this.txtNombre.TabIndex = 2;

            // btnGuardar
            this.btnGuardar.BackColor = Color.LightGreen;
            this.btnGuardar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnGuardar.Location = new Point(80, 140);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(120, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += BtnGuardar_Click;

            // btnCancelar
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCancelar.Location = new Point(220, 140);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(120, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += BtnCancelar_Click;

            // FrmDetalleZona
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(420, 210);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleZona";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = _idZona.HasValue ? "Editar Zona" : "Nueva Zona";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private async void CargarZona()
        {
            try
            {
                var zona = await LogicaZona.GetByIdAsync(_idZona.Value);
                if (zona != null)
                {
                    txtNombre.Text = zona.Nombre;
                }
                else
                {
                    MessageBox.Show("No se encontró la zona.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la zona: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la zona es obligatorio.", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var zona = new Zona
                {
                    Nombre = txtNombre.Text.Trim()
                };

                if (_idZona.HasValue)
                {
                    zona.IdZona = _idZona.Value;
                    await LogicaZona.UpdateAsync(zona);
                    MessageBox.Show("Zona actualizada correctamente.", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await LogicaZona.CreateAsync(zona);
                    MessageBox.Show("Zona creada correctamente.", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la zona: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
