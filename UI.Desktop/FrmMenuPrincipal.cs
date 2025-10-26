using System;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmMenuPrincipal : Form
    {
private Button btnSalones;
   private Button btnBarras;
        private Button btnDjs;
private Button btnGastronomicos;
        private Button btnUsuarios;
        private Button btnZonas;
        private Button btnSolicitudes;
        private Button btnReportes;
        private Button btnCerrarSesion;
        private Button btnSalir;
        private Label lblTitulo;
private Label lblBienvenida;

        public FrmMenuPrincipal()
        {
        InitializeComponent();
    ConfigurarInterfazPorRol();
        }

        private void InitializeComponent()
  {
   this.btnSalones = new Button();
            this.btnBarras = new Button();
            this.btnDjs = new Button();
            this.btnGastronomicos = new Button();
    this.btnUsuarios = new Button();
       this.btnZonas = new Button();
          this.btnSolicitudes = new Button();
        this.btnReportes = new Button();
      this.btnCerrarSesion = new Button();
            this.btnSalir = new Button();
      this.lblTitulo = new Label();
       this.lblBienvenida = new Label();
         this.SuspendLayout();

            // lblTitulo
 this.lblTitulo.AutoSize = true;
   this.lblTitulo.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
   this.lblTitulo.Location = new Point(80, 20);
         this.lblTitulo.Name = "lblTitulo";
     this.lblTitulo.Size = new Size(320, 29);
      this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema Pone La Fecha";

      // lblBienvenida
  this.lblBienvenida.AutoSize = true;
     this.lblBienvenida.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblBienvenida.ForeColor = Color.DarkGreen;
     this.lblBienvenida.Location = new Point(50, 60);
     this.lblBienvenida.Name = "lblBienvenida";
   this.lblBienvenida.Size = new Size(400, 20);
   this.lblBienvenida.TabIndex = 1;
       this.lblBienvenida.Text = $"Bienvenido {SesionUsuario.NombreCompleto} ({SesionUsuario.UsuarioActual?.Rol})";

   // btnSalones
            this.btnSalones.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
  this.btnSalones.Location = new Point(150, 110);
         this.btnSalones.Name = "btnSalones";
            this.btnSalones.Size = new Size(180, 50);
        this.btnSalones.TabIndex = 2;
            this.btnSalones.Text = "Gestión de Salones";
    this.btnSalones.UseVisualStyleBackColor = true;
    this.btnSalones.Click += BtnSalones_Click;

    // btnBarras
            this.btnBarras.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
        this.btnBarras.Location = new Point(150, 175);
      this.btnBarras.Name = "btnBarras";
     this.btnBarras.Size = new Size(180, 50);
         this.btnBarras.TabIndex = 3;
         this.btnBarras.Text = "Gestión de Barras";
      this.btnBarras.UseVisualStyleBackColor = true;
    this.btnBarras.Click += BtnBarras_Click;

            // btnDjs
        this.btnDjs.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
          this.btnDjs.Location = new Point(150, 240);
   this.btnDjs.Name = "btnDjs";
 this.btnDjs.Size = new Size(180, 50);
   this.btnDjs.TabIndex = 4;
this.btnDjs.Text = "Gestión de DJs";
 this.btnDjs.UseVisualStyleBackColor = true;
        this.btnDjs.Click += BtnDjs_Click;

            // btnGastronomicos
 this.btnGastronomicos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
     this.btnGastronomicos.Location = new Point(150, 305);
      this.btnGastronomicos.Name = "btnGastronomicos";
    this.btnGastronomicos.Size = new Size(180, 50);
        this.btnGastronomicos.TabIndex = 5;
            this.btnGastronomicos.Text = "Gestión Gastronomico";
       this.btnGastronomicos.UseVisualStyleBackColor = true;
     this.btnGastronomicos.Click += BtnGastronomicos_Click;

      // btnUsuarios
            this.btnUsuarios.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
        this.btnUsuarios.Location = new Point(150, 370);
            this.btnUsuarios.Name = "btnUsuarios";
      this.btnUsuarios.Size = new Size(180, 50);
        this.btnUsuarios.TabIndex = 6;
          this.btnUsuarios.Text = "Gestión de Usuarios";
this.btnUsuarios.UseVisualStyleBackColor = true;
        this.btnUsuarios.Click += BtnUsuarios_Click;

       // btnZonas
  this.btnZonas.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnZonas.Location = new Point(150, 435);
    this.btnZonas.Name = "btnZonas";
            this.btnZonas.Size = new Size(180, 50);
         this.btnZonas.TabIndex = 9;
  this.btnZonas.Text = "Gestión de Zonas";
       this.btnZonas.UseVisualStyleBackColor = true;
            this.btnZonas.Click += BtnZonas_Click;

            // btnSolicitudes
      this.btnSolicitudes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSolicitudes.Location = new Point(150, 500);
            this.btnSolicitudes.Name = "btnSolicitudes";
   this.btnSolicitudes.Size = new Size(180, 50);
            this.btnSolicitudes.TabIndex = 10;
        this.btnSolicitudes.Text = "Gestión de Solicitudes";
         this.btnSolicitudes.UseVisualStyleBackColor = true;
         this.btnSolicitudes.Click += BtnSolicitudes_Click;

            // btnReportes
       this.btnReportes.BackColor = Color.LightCyan;
            this.btnReportes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
    this.btnReportes.Location = new Point(150, 565);
  this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new Size(180, 50);
            this.btnReportes.TabIndex = 11;
            this.btnReportes.Text = "?? Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
       this.btnReportes.Click += BtnReportes_Click;

         // btnCerrarSesion
            this.btnCerrarSesion.BackColor = Color.Orange;
          this.btnCerrarSesion.ForeColor = Color.White;
            this.btnCerrarSesion.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCerrarSesion.Location = new Point(100, 635);
     this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new Size(120, 40);
   this.btnCerrarSesion.TabIndex = 7;
      this.btnCerrarSesion.Text = "Cerrar Sesión";
         this.btnCerrarSesion.UseVisualStyleBackColor = false;
this.btnCerrarSesion.Click += BtnCerrarSesion_Click;

            // btnSalir
    this.btnSalir.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
       this.btnSalir.Location = new Point(240, 635);
            this.btnSalir.Name = "btnSalir";
      this.btnSalir.Size = new Size(120, 40);
       this.btnSalir.TabIndex = 8;
    this.btnSalir.Text = "Salir";
         this.btnSalir.UseVisualStyleBackColor = true;
     this.btnSalir.Click += BtnSalir_Click;

      // FrmMenuPrincipal
     this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
   this.ClientSize = new Size(480, 700);
   this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnSolicitudes);
   this.Controls.Add(this.btnZonas);
            this.Controls.Add(this.btnSalir);
  this.Controls.Add(this.btnCerrarSesion);
    this.Controls.Add(this.btnUsuarios);
    this.Controls.Add(this.btnGastronomicos);
    this.Controls.Add(this.btnDjs);
this.Controls.Add(this.btnBarras);
  this.Controls.Add(this.btnSalones);
       this.Controls.Add(this.lblBienvenida);
          this.Controls.Add(this.lblTitulo);
    this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
   this.Name = "FrmMenuPrincipal";
this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Menú Principal - Pone La Fecha";
            this.ResumeLayout(false);
   this.PerformLayout();
        }

        private void ConfigurarInterfazPorRol()
        {
            bool esAdmin = SesionUsuario.EsAdministrador;
      
    btnSalones.Visible = esAdmin;
   btnBarras.Visible = esAdmin;
            btnDjs.Visible = esAdmin;
         btnGastronomicos.Visible = esAdmin;
     btnUsuarios.Visible = esAdmin;
   btnZonas.Visible = esAdmin;
          btnSolicitudes.Visible = esAdmin;
       btnReportes.Visible = esAdmin;
        }

        private void BtnSalones_Click(object sender, EventArgs e)
   {
          var frmSalones = new FrmABMSalon();
      frmSalones.ShowDialog();
        }

        private void BtnBarras_Click(object sender, EventArgs e)
  {
   var frmBarras = new FrmABMBarra();
         frmBarras.ShowDialog();
   }

        private void BtnDjs_Click(object sender, EventArgs e)
        {
   var frmDjs = new FrmABMDj();
            frmDjs.ShowDialog();
        }

 private void BtnGastronomicos_Click(object sender, EventArgs e)
        {
     var frmGastronomicos = new FrmABMGastronomico();
frmGastronomicos.ShowDialog();
    }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
var frmUsuarios = new FrmABMUsuario();
         frmUsuarios.ShowDialog();
        }

  private void BtnZonas_Click(object sender, EventArgs e)
        {
            var frmZonas = new FrmABMZona();
            frmZonas.ShowDialog();
        }

        private void BtnSolicitudes_Click(object sender, EventArgs e)
        {
         var frmSolicitudes = new FrmABMSolicitud();
      frmSolicitudes.ShowDialog();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
     {
   var frmMenuReportes = new FrmMenuReportes();
   frmMenuReportes.ShowDialog();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
  var resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", 
    "Confirmar Cierre de Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
   
          if (resultado == DialogResult.Yes)
    {
                SesionUsuario.CerrarSesion();
                this.Hide();
       
             var frmLogin = new FrmLogin();
          if (frmLogin.ShowDialog() == DialogResult.OK && frmLogin.LoginExitoso && SesionUsuario.EstaLogueado)
           {
     if (SesionUsuario.EsAdministrador)
        {
             ConfigurarInterfazPorRol();
  this.Show();
   }
            else if (SesionUsuario.EsCliente)
         {
      var frmMenuCliente = new FrmMenuCliente();
     frmMenuCliente.Show();
              this.Close();
          }
              }
      else
       {
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
