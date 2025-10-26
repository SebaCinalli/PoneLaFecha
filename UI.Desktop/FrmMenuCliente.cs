using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmMenuCliente : Form
    {
        private Button btnSalones;
        private Button btnBarras;
        private Button btnDjs;
        private Button btnGastronomicos;
        private Button btnMisSolicitudes;
        private Button btnNuevaSolicitud;
        private Button btnCerrarSesion;
        private Button btnSalir;
        private Label lblTitulo;
        private Label lblBienvenida;

        public FrmMenuCliente()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnSalones = new Button();
            this.btnBarras = new Button();
            this.btnDjs = new Button();
            this.btnGastronomicos = new Button();
            this.btnMisSolicitudes = new Button();
            this.btnNuevaSolicitud = new Button();
            this.btnCerrarSesion = new Button();
            this.btnSalir = new Button();
            this.lblTitulo = new Label();
            this.lblBienvenida = new Label();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(80, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(320, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema Pone La Fecha";

            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblBienvenida.ForeColor = Color.DarkGreen;
            this.lblBienvenida.Location = new Point(50, 60);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new Size(400, 20);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = $"Bienvenido {SesionUsuario.NombreCompleto} - Cliente";

            // 
            // btnNuevaSolicitud
            // 
            this.btnNuevaSolicitud.BackColor = Color.LightGreen;
            this.btnNuevaSolicitud.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnNuevaSolicitud.Location = new Point(100, 110);
            this.btnNuevaSolicitud.Name = "btnNuevaSolicitud";
            this.btnNuevaSolicitud.Size = new Size(280, 55);
            this.btnNuevaSolicitud.TabIndex = 2;
            this.btnNuevaSolicitud.Text = "Nueva Solicitud";
            this.btnNuevaSolicitud.UseVisualStyleBackColor = false;
            this.btnNuevaSolicitud.Click += BtnNuevaSolicitud_Click;

            // 
            // btnMisSolicitudes
            // 
            this.btnMisSolicitudes.BackColor = Color.LightBlue;
            this.btnMisSolicitudes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnMisSolicitudes.Location = new Point(100, 180);
            this.btnMisSolicitudes.Name = "btnMisSolicitudes";
            this.btnMisSolicitudes.Size = new Size(280, 55);
            this.btnMisSolicitudes.TabIndex = 3;
            this.btnMisSolicitudes.Text = "Mis Solicitudes";
            this.btnMisSolicitudes.UseVisualStyleBackColor = false;
            this.btnMisSolicitudes.Click += BtnMisSolicitudes_Click;

            // 
            // btnSalones
            // 
            this.btnSalones.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSalones.Location = new Point(150, 260);
            this.btnSalones.Name = "btnSalones";
            this.btnSalones.Size = new Size(180, 45);
            this.btnSalones.TabIndex = 4;
            this.btnSalones.Text = "Ver Salones";
            this.btnSalones.UseVisualStyleBackColor = true;
            this.btnSalones.Click += BtnSalones_Click;

            // 
            // btnBarras
            // 
            this.btnBarras.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnBarras.Location = new Point(150, 320);
            this.btnBarras.Name = "btnBarras";
            this.btnBarras.Size = new Size(180, 45);
            this.btnBarras.TabIndex = 5;
            this.btnBarras.Text = "Ver Barras";
            this.btnBarras.UseVisualStyleBackColor = true;
            this.btnBarras.Click += BtnBarras_Click;

            // 
            // btnDjs
            // 
            this.btnDjs.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnDjs.Location = new Point(150, 380);
            this.btnDjs.Name = "btnDjs";
            this.btnDjs.Size = new Size(180, 45);
            this.btnDjs.TabIndex = 6;
            this.btnDjs.Text = "Ver DJs";
            this.btnDjs.UseVisualStyleBackColor = true;
            this.btnDjs.Click += BtnDjs_Click;

            // 
            // btnGastronomicos
            // 
            this.btnGastronomicos.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnGastronomicos.Location = new Point(150, 440);
            this.btnGastronomicos.Name = "btnGastronomicos";
            this.btnGastronomicos.Size = new Size(180, 45);
            this.btnGastronomicos.TabIndex = 7;
            this.btnGastronomicos.Text = "Ver Gastronomico";
            this.btnGastronomicos.UseVisualStyleBackColor = true;
            this.btnGastronomicos.Click += BtnGastronomicos_Click;

            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = Color.Orange;
            this.btnCerrarSesion.ForeColor = Color.White;
            this.btnCerrarSesion.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCerrarSesion.Location = new Point(100, 510);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new Size(120, 40);
            this.btnCerrarSesion.TabIndex = 8;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += BtnCerrarSesion_Click;

            // 
            // btnSalir
            // 
            this.btnSalir.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSalir.Location = new Point(240, 510);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(120, 40);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += BtnSalir_Click;

            // 
            // FrmMenuCliente
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(480, 570);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnGastronomicos);
            this.Controls.Add(this.btnDjs);
            this.Controls.Add(this.btnBarras);
            this.Controls.Add(this.btnSalones);
            this.Controls.Add(this.btnMisSolicitudes);
            this.Controls.Add(this.btnNuevaSolicitud);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMenuCliente";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Menú Cliente - Pone La Fecha";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnNuevaSolicitud_Click(object sender, EventArgs e)
        {
            var frmDetalle = new FrmDetalleSolicitud();
            frmDetalle.ShowDialog();
        }

        private void BtnMisSolicitudes_Click(object sender, EventArgs e)
        {
            // Mostrar solo las solicitudes del cliente actual
            var frmMisSolicitudes = new FrmMisSolicitudes();
            frmMisSolicitudes.ShowDialog();
        }

        private void BtnSalones_Click(object sender, EventArgs e)
        {
            var frmSalonesVista = new FrmVistaSalones();
            frmSalonesVista.ShowDialog();
        }

        private void BtnBarras_Click(object sender, EventArgs e)
        {
            var frmBarrasVista = new FrmVistaBarras();
            frmBarrasVista.ShowDialog();
        }

        private void BtnDjs_Click(object sender, EventArgs e)
        {
            var frmDjsVista = new FrmVistaDjs();
            frmDjsVista.ShowDialog();
        }

        private void BtnGastronomicos_Click(object sender, EventArgs e)
        {
            var frmGastronomicosVista = new FrmVistaGastronomicos();
            frmGastronomicosVista.ShowDialog();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", 
                "Confirmar Cierre de Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.Yes)
            {
                SesionUsuario.CerrarSesion();
                this.Hide();
                
                // Mostrar formulario de login nuevamente
                var frmLogin = new FrmLogin();
                if (frmLogin.ShowDialog() == DialogResult.OK && frmLogin.LoginExitoso && SesionUsuario.EstaLogueado)
                {
                    if (SesionUsuario.EsAdministrador)
                    {
                        // Si es administrador, abrir menú principal
                        var frmMenuPrincipal = new FrmMenuPrincipal();
                        frmMenuPrincipal.Show();
                        this.Close();
                    }
                    else if (SesionUsuario.EsCliente)
                    {
                        // Si es cliente, seguir en este formulario
                        this.Show();
                    }
                }
                else
                {
                    // Si no hay login exitoso, cerrar la aplicación
                    this.Close();
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de que desea salir?", 
                "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}