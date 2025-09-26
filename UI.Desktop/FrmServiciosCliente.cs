using System;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class FrmServiciosCliente : Form
    {
        private TabControl tabServicios;
        private TabPage tabSalones;
        private TabPage tabBarras;
        private TabPage tabDjs;
        private DataGridView dgvSalones;
        private DataGridView dgvBarras;
        private DataGridView dgvDjs;
        private Label lblBienvenida;
        private Button btnCerrarSesion;
        private Button btnSalir;

        private List<Salon> salones;
        private List<Barra> barras;
        private List<Dj> djs;

        public FrmServiciosCliente()
        {
            InitializeComponent();
            InicializarDatos();
        }

        private void InitializeComponent()
        {
            this.tabServicios = new TabControl();
            this.tabSalones = new TabPage();
            this.tabBarras = new TabPage();
            this.tabDjs = new TabPage();
            this.dgvSalones = new DataGridView();
            this.dgvBarras = new DataGridView();
            this.dgvDjs = new DataGridView();
            this.lblBienvenida = new Label();
            this.btnCerrarSesion = new Button();
            this.btnSalir = new Button();

            this.tabServicios.SuspendLayout();
            this.tabSalones.SuspendLayout();
            this.tabBarras.SuspendLayout();
            this.tabDjs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDjs)).BeginInit();
            this.SuspendLayout();

            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblBienvenida.ForeColor = Color.DarkBlue;
            this.lblBienvenida.Location = new Point(20, 20);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new Size(400, 24);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = $"Bienvenido {SesionUsuario.NombreCompleto}";

            // 
            // tabServicios
            // 
            this.tabServicios.Controls.Add(this.tabSalones);
            this.tabServicios.Controls.Add(this.tabBarras);
            this.tabServicios.Controls.Add(this.tabDjs);
            this.tabServicios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.tabServicios.Location = new Point(20, 60);
            this.tabServicios.Name = "tabServicios";
            this.tabServicios.SelectedIndex = 0;
            this.tabServicios.Size = new Size(940, 450);
            this.tabServicios.TabIndex = 1;

            // 
            // tabSalones
            // 
            this.tabSalones.Controls.Add(this.dgvSalones);
            this.tabSalones.Location = new Point(4, 26);
            this.tabSalones.Name = "tabSalones";
            this.tabSalones.Padding = new Padding(3);
            this.tabSalones.Size = new Size(932, 420);
            this.tabSalones.TabIndex = 0;
            this.tabSalones.Text = "?? Salones Disponibles";
            this.tabSalones.UseVisualStyleBackColor = true;

            // 
            // dgvSalones
            // 
            this.dgvSalones.AllowUserToAddRows = false;
            this.dgvSalones.AllowUserToDeleteRows = false;
            this.dgvSalones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalones.BackgroundColor = Color.White;
            this.dgvSalones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalones.Location = new Point(10, 10);
            this.dgvSalones.Name = "dgvSalones";
            this.dgvSalones.ReadOnly = true;
            this.dgvSalones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalones.Size = new Size(912, 400);
            this.dgvSalones.TabIndex = 0;

            // 
            // tabBarras
            // 
            this.tabBarras.Controls.Add(this.dgvBarras);
            this.tabBarras.Location = new Point(4, 26);
            this.tabBarras.Name = "tabBarras";
            this.tabBarras.Padding = new Padding(3);
            this.tabBarras.Size = new Size(932, 420);
            this.tabBarras.TabIndex = 1;
            this.tabBarras.Text = "?? Barras Disponibles";
            this.tabBarras.UseVisualStyleBackColor = true;

            // 
            // dgvBarras
            // 
            this.dgvBarras.AllowUserToAddRows = false;
            this.dgvBarras.AllowUserToDeleteRows = false;
            this.dgvBarras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBarras.BackgroundColor = Color.White;
            this.dgvBarras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarras.Location = new Point(10, 10);
            this.dgvBarras.Name = "dgvBarras";
            this.dgvBarras.ReadOnly = true;
            this.dgvBarras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarras.Size = new Size(912, 400);
            this.dgvBarras.TabIndex = 0;

            // 
            // tabDjs
            // 
            this.tabDjs.Controls.Add(this.dgvDjs);
            this.tabDjs.Location = new Point(4, 26);
            this.tabDjs.Name = "tabDjs";
            this.tabDjs.Padding = new Padding(3);
            this.tabDjs.Size = new Size(932, 420);
            this.tabDjs.TabIndex = 2;
            this.tabDjs.Text = "?? DJs Disponibles";
            this.tabDjs.UseVisualStyleBackColor = true;

            // 
            // dgvDjs
            // 
            this.dgvDjs.AllowUserToAddRows = false;
            this.dgvDjs.AllowUserToDeleteRows = false;
            this.dgvDjs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDjs.BackgroundColor = Color.White;
            this.dgvDjs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDjs.Location = new Point(10, 10);
            this.dgvDjs.Name = "dgvDjs";
            this.dgvDjs.ReadOnly = true;
            this.dgvDjs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDjs.Size = new Size(912, 400);
            this.dgvDjs.TabIndex = 0;

            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = Color.Orange;
            this.btnCerrarSesion.ForeColor = Color.White;
            this.btnCerrarSesion.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCerrarSesion.Location = new Point(700, 530);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new Size(120, 35);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += BtnCerrarSesion_Click;

            // 
            // btnSalir
            // 
            this.btnSalir.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnSalir.Location = new Point(840, 530);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new Size(120, 35);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += BtnSalir_Click;

            // 
            // FrmServiciosCliente
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(984, 581);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.tabServicios);
            this.Controls.Add(this.lblBienvenida);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmServiciosCliente";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Servicios Disponibles - Pone La Fecha";
            this.tabServicios.ResumeLayout(false);
            this.tabSalones.ResumeLayout(false);
            this.tabBarras.ResumeLayout(false);
            this.tabDjs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDjs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InicializarDatos()
        {
            CargarSalones();
            CargarBarras();
            CargarDjs();
        }

        private void CargarSalones()
        {
            salones = LogicaSalon.Listar();
            
            // Filtrar solo salones disponibles
            var salonesDisponibles = salones.Where(s => s.Estado.ToLower() == "disponible").ToList();
            
            dgvSalones.DataSource = salonesDisponibles;
            
            // Configurar columnas
            if (dgvSalones.Columns["IdSalon"] != null)
                dgvSalones.Columns["IdSalon"].Visible = false;
            
            if (dgvSalones.Columns["NombreSalon"] != null)
                dgvSalones.Columns["NombreSalon"].HeaderText = "Nombre del Salón";
            
            if (dgvSalones.Columns["MontoSalon"] != null)
            {
                dgvSalones.Columns["MontoSalon"].HeaderText = "Precio";
                dgvSalones.Columns["MontoSalon"].DefaultCellStyle.Format = "C2";
            }
        }

        private void CargarBarras()
        {
            barras = LogicaBarra.Listar();
            
            // Filtrar solo barras disponibles
            var barrasDisponibles = barras.Where(b => b.Estado.ToLower() == "disponible").ToList();
            
            dgvBarras.DataSource = barrasDisponibles;
            
            // Configurar columnas
            if (dgvBarras.Columns["IdBarra"] != null)
                dgvBarras.Columns["IdBarra"].Visible = false;
            
            if (dgvBarras.Columns["TipoBebida"] != null)
                dgvBarras.Columns["TipoBebida"].HeaderText = "Tipo de Bebida";
            
            if (dgvBarras.Columns["PrecioPorHora"] != null)
            {
                dgvBarras.Columns["PrecioPorHora"].HeaderText = "Precio por Hora";
                dgvBarras.Columns["PrecioPorHora"].DefaultCellStyle.Format = "C2";
            }
            
            if (dgvBarras.Columns["Descripcion"] != null)
                dgvBarras.Columns["Descripcion"].HeaderText = "Descripción";
        }

        private void CargarDjs()
        {
            djs = LogicaDj.Listar();
            
            // Filtrar solo DJs disponibles
            var djsDisponibles = djs.Where(d => d.Estado.ToLower() == "disponible").ToList();
            
            dgvDjs.DataSource = djsDisponibles;
            
            // Configurar columnas
            if (dgvDjs.Columns["IdDj"] != null)
                dgvDjs.Columns["IdDj"].Visible = false;
            
            if (dgvDjs.Columns["NombreArtistico"] != null)
                dgvDjs.Columns["NombreArtistico"].HeaderText = "Nombre Artístico";
            
            if (dgvDjs.Columns["MontoDj"] != null)
            {
                dgvDjs.Columns["MontoDj"].HeaderText = "Precio";
                dgvDjs.Columns["MontoDj"].DefaultCellStyle.Format = "C2";
            }
            
            if (dgvDjs.Columns["Foto"] != null)
                dgvDjs.Columns["Foto"].HeaderText = "Foto";
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", 
                "Confirmar Cierre de Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.Yes)
            {
                SesionUsuario.CerrarSesion();
                this.Close();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de que desea salir de la aplicación?", 
                "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}