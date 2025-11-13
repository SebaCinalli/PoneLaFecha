using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmReporteADO : Form
    {
        private Label lblTitulo;
        private Label lblDescripcion;
        private Panel pnlCards;
        private Panel cardClientes;
        private Panel cardSalones;
        private Panel cardBarras;
        private Panel cardDJs;
        private Panel cardGastro;
        private Panel cardZonas;
        private Label lblTotalClientes;
        private Label lblTotalSalones;
        private Label lblTotalBarras;
        private Label lblTotalDJs;
        private Label lblTotalGastro;
        private Label lblTotalZonas;
        private DataGridView dgvSalones;
        private DataGridView dgvBarras;
        private Button btnActualizar;
        private Button btnCerrar;

        public FrmReporteADO()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.lblDescripcion = new Label();
            this.pnlCards = new Panel();
            this.cardClientes = new Panel();
            this.cardSalones = new Panel();
            this.cardBarras = new Panel();
            this.cardDJs = new Panel();
            this.cardGastro = new Panel();
            this.cardZonas = new Panel();
            this.lblTotalClientes = new Label();
            this.lblTotalSalones = new Label();
            this.lblTotalBarras = new Label();
            this.lblTotalDJs = new Label();
            this.lblTotalGastro = new Label();
            this.lblTotalZonas = new Label();
            this.dgvSalones = new DataGridView();
            this.dgvBarras = new DataGridView();
            this.btnActualizar = new Button();
            this.btnCerrar = new Button();

            this.pnlCards.SuspendLayout();
            this.cardClientes.SuspendLayout();
            this.cardSalones.SuspendLayout();
            this.cardBarras.SuspendLayout();
            this.cardDJs.SuspendLayout();
            this.cardGastro.SuspendLayout();
            this.cardZonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(300, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(420, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Estadísticas del Sistema";

            // lblDescripcion
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic, GraphicsUnit.Point);
            this.lblDescripcion.ForeColor = Color.Gray;
            this.lblDescripcion.Location = new Point(280, 50);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(470, 17);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Consultas realizadas con ADO.NET directo a la base de datos";

            // pnlCards
            this.pnlCards.Location = new Point(20, 85);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new Size(980, 180);
            this.pnlCards.TabIndex = 2;

            // Configurar Cards
            ConfigurarCard(this.cardClientes, "Clientes", Color.FromArgb(0, 123, 255), 0, this.lblTotalClientes);
            ConfigurarCard(this.cardSalones, "Salones", Color.FromArgb(40, 167, 69), 170, this.lblTotalSalones);
            ConfigurarCard(this.cardBarras, "Barras", Color.FromArgb(255, 193, 7), 340, this.lblTotalBarras);
            ConfigurarCard(this.cardDJs, "DJs", Color.FromArgb(23, 162, 184), 510, this.lblTotalDJs);
            ConfigurarCard(this.cardGastro, "Gastronómicos", Color.FromArgb(220, 53, 69), 680, this.lblTotalGastro);
            ConfigurarCard(this.cardZonas, "Zonas", Color.FromArgb(108, 117, 125), 850, this.lblTotalZonas);

            this.pnlCards.Controls.Add(this.cardClientes);
            this.pnlCards.Controls.Add(this.cardSalones);
            this.pnlCards.Controls.Add(this.cardBarras);
            this.pnlCards.Controls.Add(this.cardDJs);
            this.pnlCards.Controls.Add(this.cardGastro);
            this.pnlCards.Controls.Add(this.cardZonas);

            // dgvSalones
            this.dgvSalones.AllowUserToAddRows = false;
            this.dgvSalones.AllowUserToDeleteRows = false;
            this.dgvSalones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalones.BackgroundColor = Color.White;
            this.dgvSalones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalones.Location = new Point(20, 285);
            this.dgvSalones.Name = "dgvSalones";
            this.dgvSalones.ReadOnly = true;
            this.dgvSalones.RowHeadersWidth = 51;
            this.dgvSalones.Size = new Size(480, 250);
            this.dgvSalones.TabIndex = 3;

            // dgvBarras
            this.dgvBarras.AllowUserToAddRows = false;
            this.dgvBarras.AllowUserToDeleteRows = false;
            this.dgvBarras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBarras.BackgroundColor = Color.White;
            this.dgvBarras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarras.Location = new Point(520, 285);
            this.dgvBarras.Name = "dgvBarras";
            this.dgvBarras.ReadOnly = true;
            this.dgvBarras.RowHeadersWidth = 51;
            this.dgvBarras.Size = new Size(480, 250);
            this.dgvBarras.TabIndex = 4;

            // btnActualizar
            this.btnActualizar.BackColor = Color.FromArgb(0, 123, 255);
            this.btnActualizar.FlatStyle = FlatStyle.Flat;
            this.btnActualizar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnActualizar.ForeColor = Color.White;
            this.btnActualizar.Location = new Point(730, 555);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(140, 40);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += BtnActualizar_Click;

            // btnCerrar
            this.btnCerrar.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Location = new Point(880, 555);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(140, 40);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += BtnCerrar_Click;

            // FrmReporteADO
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(1040, 615);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvBarras);
            this.Controls.Add(this.dgvSalones);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmReporteADO";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Estadísticas del Sistema - Pone La Fecha";

            this.pnlCards.ResumeLayout(false);
            this.cardClientes.ResumeLayout(false);
            this.cardSalones.ResumeLayout(false);
            this.cardBarras.ResumeLayout(false);
            this.cardDJs.ResumeLayout(false);
            this.cardGastro.ResumeLayout(false);
            this.cardZonas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigurarCard(Panel card, string titulo, Color color, int x, Label lblValor)
        {
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Location = new Point(x, 10);
            card.Name = $"card{titulo}";
            card.Size = new Size(160, 160);
            card.TabIndex = 0;
            card.Paint += (s, e) => {
                // Borde superior coloreado
                e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, card.Width, 5);
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(10, 15),
                AutoSize = true
            };

            lblValor.Font = new Font("Microsoft Sans Serif", 28F, FontStyle.Bold);
            lblValor.ForeColor = color;
            lblValor.Location = new Point(10, 60);
            lblValor.Size = new Size(140, 50);
            lblValor.Text = "0";
            lblValor.TextAlign = ContentAlignment.MiddleCenter;

            Label lblDescripcion = new Label
            {
                Text = $"Total {titulo}",
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(10, 125),
                Size = new Size(140, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblValor);
            card.Controls.Add(lblDescripcion);
        }

        private void CargarDatos()
        {
            try
            {
                // Usar ADO.NET para salones
                var salones = LogicaSalon.ListarConADO();
                lblTotalSalones.Text = salones.Count.ToString();

                // Usar ADO.NET para clientes
                int totalClientes = LogicaCliente.ObtenerTotalClientesConADO();
                lblTotalClientes.Text = totalClientes.ToString();

                // Otros servicios (sin ADO.NET específico, pero mostramos totales)
                var barras = LogicaBarra.Listar();
                lblTotalBarras.Text = barras.Count.ToString();

                var djs = LogicaDj.Listar();
                lblTotalDJs.Text = djs.Count.ToString();

                var gastros = LogicaGastronomico.Listar();
                lblTotalGastro.Text = gastros.Count.ToString();

                var zonas = new LogicaZona().GetAllAsync().Result;
                lblTotalZonas.Text = zonas.Count.ToString();

                // Cargar grillas
                dgvSalones.DataSource = salones;
                dgvSalones.Columns["IdSalon"].HeaderText = "ID";
                dgvSalones.Columns["NombreSalon"].HeaderText = "Nombre del Salón";
                dgvSalones.Columns["Estado"].HeaderText = "Estado";
                dgvSalones.Columns["MontoSalon"].HeaderText = "Monto";
                dgvSalones.Columns["MontoSalon"].DefaultCellStyle.Format = "C";

                dgvBarras.DataSource = barras;
                dgvBarras.Columns["IdBarra"].HeaderText = "ID";
                dgvBarras.Columns["Nombre"].HeaderText = "Nombre";
                dgvBarras.Columns["TipoBebida"].HeaderText = "Tipo de Bebida";
                dgvBarras.Columns["PrecioPorHora"].HeaderText = "Precio/Hora";
                dgvBarras.Columns["PrecioPorHora"].DefaultCellStyle.Format = "C";
                dgvBarras.Columns["Estado"].HeaderText = "Estado";
                dgvBarras.Columns["Descripcion"].Visible = false;
                dgvBarras.Columns["ZonaBarras"].Visible = false;
                dgvBarras.Columns["BarraSolicitudes"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            MessageBox.Show("Datos actualizados correctamente",
   "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
