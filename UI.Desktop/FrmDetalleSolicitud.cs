using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmDetalleSolicitud : Form
    {
        private Label lblTitulo;
        private Label lblCliente;
        private ComboBox cboCliente;
        private Label lblFechaEvento;
        private DateTimePicker dtpFechaEvento;
        
        // Selectores de servicios
        private Label lblSalon;
        private ComboBox cboSalon;
        private Label lblMontoSalon;
        private Button btnLimpiarSalon;
        
        private Label lblDJ;
        private ComboBox cboDJ;
        private Label lblMontoDJ;
        private Button btnLimpiarDJ;
        
        private Label lblBarra;
        private ComboBox cboBarra;
        private Label lblMontoBarra;
        private Button btnLimpiarBarra;
        
        private Label lblGastronomico;
        private ComboBox cboGastronomico;
        private Label lblMontoGastro;
        private Button btnLimpiarGastro;
        
        private Label lblEstado;
        private ComboBox cboEstado;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblMontoTotal;
        private Label lblMontoTotalValor;

        private readonly int? _idSolicitud;
        private bool _soloLectura;
        private int _idClienteActual;

        public FrmDetalleSolicitud(int? idSolicitud = null, bool soloLectura = false)
        {
            _idSolicitud = idSolicitud;
            _soloLectura = soloLectura;
            InitializeComponent();
            
            // Determinar el cliente actual
            if (SesionUsuario.EsCliente)
            {
                var cliente = LogicaCliente.ObtenerPorNombreUsuario(SesionUsuario.UsuarioActual.NombreUsuario);
                if (cliente == null)
                {
                    cliente = LogicaCliente.CrearDesdeUsuario(SesionUsuario.UsuarioActual);
                }
                _idClienteActual = cliente.IdCliente;
                
                // Ocultar selector de cliente para usuarios tipo Cliente
                lblCliente.Visible = false;
                cboCliente.Visible = false;
            }
            else
            {
                // Es administrador, mostrar selector
                CargarClientes();
            }

            // Cargar servicios disponibles
            CargarServicios();

            if (_idSolicitud.HasValue)
            {
                CargarSolicitud();
            }
            else
            {
                // Para nuevas solicitudes, ocultar el selector de estado
                lblEstado.Visible = false;
                cboEstado.Visible = false;
            }

            if (_soloLectura)
            {
                cboCliente.Enabled = false;
                dtpFechaEvento.Enabled = false;
                cboSalon.Enabled = false;
                cboDJ.Enabled = false;
                cboBarra.Enabled = false;
                cboGastronomico.Enabled = false;
                cboEstado.Enabled = false;
                btnGuardar.Visible = false;
                btnCancelar.Text = "Cerrar";
                btnLimpiarSalon.Visible = false;
                btnLimpiarDJ.Visible = false;
                btnLimpiarBarra.Visible = false;
                btnLimpiarGastro.Visible = false;
                this.Text = "Detalles de Solicitud";
            }
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.lblCliente = new Label();
            this.cboCliente = new ComboBox();
            this.lblFechaEvento = new Label();
            this.dtpFechaEvento = new DateTimePicker();
            
            this.lblSalon = new Label();
            this.cboSalon = new ComboBox();
            this.lblMontoSalon = new Label();
            this.btnLimpiarSalon = new Button();
            
            this.lblDJ = new Label();
            this.cboDJ = new ComboBox();
            this.lblMontoDJ = new Label();
            this.btnLimpiarDJ = new Button();
            
            this.lblBarra = new Label();
            this.cboBarra = new ComboBox();
            this.lblMontoBarra = new Label();
            this.btnLimpiarBarra = new Button();
            
            this.lblGastronomico = new Label();
            this.cboGastronomico = new ComboBox();
            this.lblMontoGastro = new Label();
            this.btnLimpiarGastro = new Button();
            
            this.lblEstado = new Label();
            this.cboEstado = new ComboBox();
            this.lblMontoTotal = new Label();
            this.lblMontoTotalValor = new Label();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();

            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(180, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(250, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = _idSolicitud.HasValue ? "Editar Solicitud" : "Nueva Solicitud";

            // lblCliente
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblCliente.Location = new Point(30, 70);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(55, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";

            // cboCliente
            this.cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCliente.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new Point(150, 67);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new Size(300, 24);
            this.cboCliente.TabIndex = 2;

            // lblFechaEvento
            this.lblFechaEvento.AutoSize = true;
            this.lblFechaEvento.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblFechaEvento.Location = new Point(30, 110);
            this.lblFechaEvento.Name = "lblFechaEvento";
            this.lblFechaEvento.Size = new Size(100, 17);
            this.lblFechaEvento.TabIndex = 3;
            this.lblFechaEvento.Text = "Fecha Evento:";

            // dtpFechaEvento
            this.dtpFechaEvento.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.dtpFechaEvento.Format = DateTimePickerFormat.Short;
            this.dtpFechaEvento.Location = new Point(150, 107);
            this.dtpFechaEvento.Name = "dtpFechaEvento";
            this.dtpFechaEvento.Size = new Size(150, 23);
            this.dtpFechaEvento.TabIndex = 4;

            // lblSalon
            this.lblSalon.AutoSize = true;
            this.lblSalon.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblSalon.Location = new Point(30, 155);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new Size(120, 17);
            this.lblSalon.TabIndex = 5;
            this.lblSalon.Text = "Seleccionar Salón:";

            // cboSalon
            this.cboSalon.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboSalon.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboSalon.FormattingEnabled = true;
            this.cboSalon.Location = new Point(150, 152);
            this.cboSalon.Name = "cboSalon";
            this.cboSalon.Size = new Size(250, 24);
            this.cboSalon.TabIndex = 6;
            this.cboSalon.SelectedIndexChanged += CboSalon_SelectedIndexChanged;

            // lblMontoSalon
            this.lblMontoSalon.AutoSize = true;
            this.lblMontoSalon.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMontoSalon.ForeColor = Color.DarkGreen;
            this.lblMontoSalon.Location = new Point(420, 155);
            this.lblMontoSalon.Name = "lblMontoSalon";
            this.lblMontoSalon.Size = new Size(45, 17);
            this.lblMontoSalon.TabIndex = 7;
            this.lblMontoSalon.Text = "$0.00";

            // btnLimpiarSalon
            this.btnLimpiarSalon.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnLimpiarSalon.Location = new Point(520, 152);
            this.btnLimpiarSalon.Name = "btnLimpiarSalon";
            this.btnLimpiarSalon.Size = new Size(60, 24);
            this.btnLimpiarSalon.TabIndex = 23;
            this.btnLimpiarSalon.Text = "Limpiar";
            this.btnLimpiarSalon.UseVisualStyleBackColor = true;
            this.btnLimpiarSalon.Visible = false;
            this.btnLimpiarSalon.Click += BtnLimpiarSalon_Click;

            // lblDJ
            this.lblDJ.AutoSize = true;
            this.lblDJ.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblDJ.Location = new Point(30, 195);
            this.lblDJ.Name = "lblDJ";
            this.lblDJ.Size = new Size(100, 17);
            this.lblDJ.TabIndex = 8;
            this.lblDJ.Text = "Seleccionar DJ:";

            // cboDJ
            this.cboDJ.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboDJ.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboDJ.FormattingEnabled = true;
            this.cboDJ.Location = new Point(150, 192);
            this.cboDJ.Name = "cboDJ";
            this.cboDJ.Size = new Size(250, 24);
            this.cboDJ.TabIndex = 9;
            this.cboDJ.SelectedIndexChanged += CboDJ_SelectedIndexChanged;

            // lblMontoDJ
            this.lblMontoDJ.AutoSize = true;
            this.lblMontoDJ.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMontoDJ.ForeColor = Color.DarkGreen;
            this.lblMontoDJ.Location = new Point(420, 195);
            this.lblMontoDJ.Name = "lblMontoDJ";
            this.lblMontoDJ.Size = new Size(45, 17);
            this.lblMontoDJ.TabIndex = 10;
            this.lblMontoDJ.Text = "$0.00";

            // btnLimpiarDJ
            this.btnLimpiarDJ.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnLimpiarDJ.Location = new Point(520, 192);
            this.btnLimpiarDJ.Name = "btnLimpiarDJ";
            this.btnLimpiarDJ.Size = new Size(60, 24);
            this.btnLimpiarDJ.TabIndex = 24;
            this.btnLimpiarDJ.Text = "Limpiar";
            this.btnLimpiarDJ.UseVisualStyleBackColor = true;
            this.btnLimpiarDJ.Visible = false;
            this.btnLimpiarDJ.Click += BtnLimpiarDJ_Click;

            // lblBarra
            this.lblBarra.AutoSize = true;
            this.lblBarra.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblBarra.Location = new Point(30, 235);
            this.lblBarra.Name = "lblBarra";
            this.lblBarra.Size = new Size(120, 17);
            this.lblBarra.TabIndex = 11;
            this.lblBarra.Text = "Seleccionar Barra:";

            // cboBarra
            this.cboBarra.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboBarra.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboBarra.FormattingEnabled = true;
            this.cboBarra.Location = new Point(150, 232);
            this.cboBarra.Name = "cboBarra";
            this.cboBarra.Size = new Size(250, 24);
            this.cboBarra.TabIndex = 12;
            this.cboBarra.SelectedIndexChanged += CboBarra_SelectedIndexChanged;

            // lblMontoBarra
            this.lblMontoBarra.AutoSize = true;
            this.lblMontoBarra.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMontoBarra.ForeColor = Color.DarkGreen;
            this.lblMontoBarra.Location = new Point(420, 235);
            this.lblMontoBarra.Name = "lblMontoBarra";
            this.lblMontoBarra.Size = new Size(45, 17);
            this.lblMontoBarra.TabIndex = 13;
            this.lblMontoBarra.Text = "$0.00";

            // btnLimpiarBarra
            this.btnLimpiarBarra.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnLimpiarBarra.Location = new Point(520, 232);
            this.btnLimpiarBarra.Name = "btnLimpiarBarra";
            this.btnLimpiarBarra.Size = new Size(60, 24);
            this.btnLimpiarBarra.TabIndex = 25;
            this.btnLimpiarBarra.Text = "Limpiar";
            this.btnLimpiarBarra.UseVisualStyleBackColor = true;
            this.btnLimpiarBarra.Visible = false;
            this.btnLimpiarBarra.Click += BtnLimpiarBarra_Click;

            // lblGastronomico
            this.lblGastronomico.AutoSize = true;
            this.lblGastronomico.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblGastronomico.Location = new Point(30, 275);
            this.lblGastronomico.Name = "lblGastronomico";
            this.lblGastronomico.Size = new Size(100, 17);
            this.lblGastronomico.TabIndex = 14;
            this.lblGastronomico.Text = "Seleccionar Gastronomico:";

            // cboGastronomico
            this.cboGastronomico.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGastronomico.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboGastronomico.FormattingEnabled = true;
            this.cboGastronomico.Location = new Point(150, 272);
            this.cboGastronomico.Name = "cboGastronomico";
            this.cboGastronomico.Size = new Size(250, 24);
            this.cboGastronomico.TabIndex = 15;
            this.cboGastronomico.SelectedIndexChanged += CboGastronomico_SelectedIndexChanged;

            // lblMontoGastro
            this.lblMontoGastro.AutoSize = true;
            this.lblMontoGastro.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblMontoGastro.ForeColor = Color.DarkGreen;
            this.lblMontoGastro.Location = new Point(420, 275);
            this.lblMontoGastro.Name = "lblMontoGastro";
            this.lblMontoGastro.Size = new Size(45, 17);
            this.lblMontoGastro.TabIndex = 16;
            this.lblMontoGastro.Text = "$0.00";

            // btnLimpiarGastro
            this.btnLimpiarGastro.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnLimpiarGastro.Location = new Point(520, 272);
            this.btnLimpiarGastro.Name = "btnLimpiarGastro";
            this.btnLimpiarGastro.Size = new Size(60, 24);
            this.btnLimpiarGastro.TabIndex = 26;
            this.btnLimpiarGastro.Text = "Limpiar";
            this.btnLimpiarGastro.UseVisualStyleBackColor = true;
            this.btnLimpiarGastro.Visible = false;
            this.btnLimpiarGastro.Click += BtnLimpiarGastro_Click;

            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblEstado.Location = new Point(30, 320);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new Size(55, 17);
            this.lblEstado.TabIndex = 17;
            this.lblEstado.Text = "Estado:";

            // cboEstado
            this.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Cancelada" });
            this.cboEstado.Location = new Point(150, 317);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new Size(150, 24);
            this.cboEstado.TabIndex = 18;
            this.cboEstado.SelectedIndex = 0;

            // lblMontoTotal
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblMontoTotal.ForeColor = Color.DarkBlue;
            this.lblMontoTotal.Location = new Point(30, 370);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new Size(118, 20);
            this.lblMontoTotal.TabIndex = 19;
            this.lblMontoTotal.Text = "TOTAL A PAGAR:";

            // lblMontoTotalValor
            this.lblMontoTotalValor.AutoSize = true;
            this.lblMontoTotalValor.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblMontoTotalValor.ForeColor = Color.DarkGreen;
            this.lblMontoTotalValor.Location = new Point(200, 368);
            this.lblMontoTotalValor.Name = "lblMontoTotalValor";
            this.lblMontoTotalValor.Size = new Size(65, 24);
            this.lblMontoTotalValor.TabIndex = 20;
            this.lblMontoTotalValor.Text = "$0.00";

            // btnGuardar
            this.btnGuardar.BackColor = Color.LightGreen;
            this.btnGuardar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnGuardar.Location = new Point(150, 420);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(150, 45);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += BtnGuardar_Click;

            // btnCancelar
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCancelar.Location = new Point(320, 420);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(150, 45);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += BtnCancelar_Click;

            // FrmDetalleSolicitud
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(600, 490);
            this.Controls.Add(this.btnLimpiarGastro);
            this.Controls.Add(this.btnLimpiarBarra);
            this.Controls.Add(this.btnLimpiarDJ);
            this.Controls.Add(this.btnLimpiarSalon);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblMontoTotalValor);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblMontoGastro);
            this.Controls.Add(this.cboGastronomico);
            this.Controls.Add(this.lblGastronomico);
            this.Controls.Add(this.lblMontoBarra);
            this.Controls.Add(this.cboBarra);
            this.Controls.Add(this.lblBarra);
            this.Controls.Add(this.lblMontoDJ);
            this.Controls.Add(this.cboDJ);
            this.Controls.Add(this.lblDJ);
            this.Controls.Add(this.lblMontoSalon);
            this.Controls.Add(this.cboSalon);
            this.Controls.Add(this.lblSalon);
            this.Controls.Add(this.dtpFechaEvento);
            this.Controls.Add(this.lblFechaEvento);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleSolicitud";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = _idSolicitud.HasValue ? "Editar Solicitud" : "Nueva Solicitud";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = LogicaCliente.Listar();
                cboCliente.DataSource = clientes;
                cboCliente.DisplayMember = "Nombre";
                cboCliente.ValueMember = "IdCliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarServicios()
        {
            try
            {
                // Cargar Salones
                var salones = LogicaSalon.Listar();
                cboSalon.Items.Add("-- Sin salón --");
                foreach (var salon in salones)
                {
                    cboSalon.Items.Add(salon);
                }
                cboSalon.DisplayMember = "NombreSalon";
                cboSalon.SelectedIndex = 0;

                // Cargar DJs
                var djs = LogicaDj.Listar();
                cboDJ.Items.Add("-- Sin DJ --");
                foreach (var dj in djs)
                {
                    cboDJ.Items.Add(dj);
                }
                cboDJ.DisplayMember = "NombreArtistico";
                cboDJ.SelectedIndex = 0;

                // Cargar Barras
                var barras = LogicaBarra.Listar();
                cboBarra.Items.Add("-- Sin barra --");
                foreach (var barra in barras)
                {
                    cboBarra.Items.Add(barra);
                }
                cboBarra.DisplayMember = "Nombre";
                cboBarra.SelectedIndex = 0;

                // Cargar Gastronomicos
                var gastronomicos = LogicaGastronomico.Listar();
                cboGastronomico.Items.Add("-- Sin servicio gastronómico --");
                foreach (var gastro in gastronomicos)
                {
                    cboGastronomico.Items.Add(gastro);
                }
                cboGastronomico.DisplayMember = "Nombre";
                cboGastronomico.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los servicios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSalon.SelectedIndex > 0 && cboSalon.SelectedItem is Salon salon)
            {
                lblMontoSalon.Text = salon.MontoSalon.ToString("C2");
                // Mostrar el botón de limpiar y bloquear el combo
                BloquearComboConBotonLimpiar(cboSalon, btnLimpiarSalon);
            }
            else
            {
                lblMontoSalon.Text = "$0.00";
                btnLimpiarSalon.Visible = false;
            }
            CalcularMontoTotal();
        }

        private void CboDJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDJ.SelectedIndex > 0 && cboDJ.SelectedItem is Dj dj)
            {
                lblMontoDJ.Text = dj.MontoDj.ToString("C2");
                // Mostrar el botón de limpiar y bloquear el combo
                BloquearComboConBotonLimpiar(cboDJ, btnLimpiarDJ);
            }
            else
            {
                lblMontoDJ.Text = "$0.00";
                btnLimpiarDJ.Visible = false;
            }
            CalcularMontoTotal();
        }

        private void CboBarra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBarra.SelectedIndex > 0 && cboBarra.SelectedItem is Barra barra)
            {
                lblMontoBarra.Text = barra.PrecioPorHora.ToString("C2");
                // Mostrar el botón de limpiar y bloquear el combo
                BloquearComboConBotonLimpiar(cboBarra, btnLimpiarBarra);
            }
            else
            {
                lblMontoBarra.Text = "$0.00";
                btnLimpiarBarra.Visible = false;
            }
            CalcularMontoTotal();
        }

        private void CboGastronomico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGastronomico.SelectedIndex > 0 && cboGastronomico.SelectedItem is Gastronomico gastro)
            {
                lblMontoGastro.Text = gastro.MontoG.ToString("C2");
                // Mostrar el botón de limpiar y bloquear el combo
                BloquearComboConBotonLimpiar(cboGastronomico, btnLimpiarGastro);
            }
            else
            {
                lblMontoGastro.Text = "$0.00";
                btnLimpiarGastro.Visible = false;
            }
            CalcularMontoTotal();
        }

        // Método para bloquear un combo cuando se selecciona un servicio y mostrar botón de limpiar
        private void BloquearComboConBotonLimpiar(ComboBox combo, Button btnLimpiar)
        {
            if (combo.SelectedIndex > 0)
            {
                combo.Enabled = false;
                btnLimpiar.Visible = true;
            }
        }

        // Métodos para limpiar las selecciones
        private void BtnLimpiarSalon_Click(object sender, EventArgs e)
        {
            cboSalon.Enabled = true;
            cboSalon.SelectedIndex = 0;
            btnLimpiarSalon.Visible = false;
            lblMontoSalon.Text = "$0.00";
            CalcularMontoTotal();
        }

        private void BtnLimpiarDJ_Click(object sender, EventArgs e)
        {
            cboDJ.Enabled = true;
            cboDJ.SelectedIndex = 0;
            btnLimpiarDJ.Visible = false;
            lblMontoDJ.Text = "$0.00";
            CalcularMontoTotal();
        }

        private void BtnLimpiarBarra_Click(object sender, EventArgs e)
        {
            cboBarra.Enabled = true;
            cboBarra.SelectedIndex = 0;
            btnLimpiarBarra.Visible = false;
            lblMontoBarra.Text = "$0.00";
            CalcularMontoTotal();
        }

        private void BtnLimpiarGastro_Click(object sender, EventArgs e)
        {
            cboGastronomico.Enabled = true;
            cboGastronomico.SelectedIndex = 0;
            btnLimpiarGastro.Visible = false;
            lblMontoGastro.Text = "$0.00";
            CalcularMontoTotal();
        }

        private void CalcularMontoTotal()
        {
            decimal total = 0;

            if (cboSalon.SelectedIndex > 0 && cboSalon.SelectedItem is Salon salon)
                total += salon.MontoSalon;

            if (cboDJ.SelectedIndex > 0 && cboDJ.SelectedItem is Dj dj)
                total += dj.MontoDj;

            if (cboBarra.SelectedIndex > 0 && cboBarra.SelectedItem is Barra barra)
                total += barra.PrecioPorHora;

            if (cboGastronomico.SelectedIndex > 0 && cboGastronomico.SelectedItem is Gastronomico gastro)
                total += gastro.MontoG;

            lblMontoTotalValor.Text = total.ToString("C2");
        }

        private async void CargarSolicitud()
        {
            try
            {
                var solicitud = await LogicaSolicitud.GetByIdAsync(_idSolicitud.Value);
                if (solicitud != null)
                {
                    if (!SesionUsuario.EsCliente)
                    {
                        cboCliente.SelectedValue = solicitud.IdCliente;
                    }
                    dtpFechaEvento.Value = solicitud.FechaDesde;
                    
                    // Cargar servicios desde las relaciones
                    // Salon
                    if (solicitud.SalonSolicitudes?.Any() == true)
                    {
                        var primerSalon = solicitud.SalonSolicitudes.First().Salon;
                        for (int i = 1; i < cboSalon.Items.Count; i++)
                        {
                            if (cboSalon.Items[i] is Salon s && s.IdSalon == primerSalon.IdSalon)
                            {
                                cboSalon.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                
                    // DJ
                    if (solicitud.DjSolicitudes?.Any() == true)
                    {
                        var primerDj = solicitud.DjSolicitudes.First().Dj;
                        for (int i = 1; i < cboDJ.Items.Count; i++)
                        {
                            if (cboDJ.Items[i] is Dj d && d.IdDj == primerDj.IdDj)
                            {
                                cboDJ.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                
                    // Barra
                    if (solicitud.BarraSolicitudes?.Any() == true)
                    {
                        var primeraBarra = solicitud.BarraSolicitudes.First().Barra;
                        for (int i = 1; i < cboBarra.Items.Count; i++)
                        {
                            if (cboBarra.Items[i] is Barra b && b.IdBarra == primeraBarra.IdBarra)
                            {
                                cboBarra.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                
                    // Gastronomico
                    if (solicitud.GastroSolicitudes?.Any() == true)
                    {
                        var primerGastro = solicitud.GastroSolicitudes.First().Gastronomico;
                        for (int i = 1; i < cboGastronomico.Items.Count; i++)
                        {
                            if (cboGastronomico.Items[i] is Gastronomico g && g.IdGastro == primerGastro.IdGastro)
                            {
                                cboGastronomico.SelectedIndex = i;
                                break;
                            }
                        }
                    }
 
                    cboEstado.SelectedItem = solicitud.Estado;
                    CalcularMontoTotal();
                }
                else
                {
                    MessageBox.Show("No se encontr? la solicitud.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la solicitud: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void SeleccionarServicioPorMonto(ComboBox combo, decimal monto)
        {
            if (monto == 0)
            {
                combo.SelectedIndex = 0;
                return;
            }

            for (int i = 1; i < combo.Items.Count; i++)
            {
                var item = combo.Items[i];
                decimal itemMonto = 0;

                if (item is Salon salon)
                    itemMonto = salon.MontoSalon;
                else if (item is Dj dj)
                    itemMonto = dj.MontoDj;
                else if (item is Barra barra)
                    itemMonto = barra.PrecioPorHora;
                else if (item is Gastronomico gastro)
                    itemMonto = gastro.MontoG;

                if (itemMonto == monto)
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener el IdCliente
            int idCliente;
            if (SesionUsuario.EsCliente)
            {
                idCliente = _idClienteActual;
            }
            else
            {
                if (cboCliente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Validaci?n",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idCliente = (int)cboCliente.SelectedValue;
            }

            if (dtpFechaEvento.Value < DateTime.Today)
            {
                MessageBox.Show("La fecha del evento no puede ser anterior a hoy.", "Validaci?n",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que al menos un servicio est? seleccionado
            if (cboSalon.SelectedIndex == 0 && cboDJ.SelectedIndex == 0 && 
                cboBarra.SelectedIndex == 0 && cboGastronomico.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un servicio para la solicitud.", "Validaci?n",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var solicitud = new Solicitud
                {
                    IdCliente = idCliente,
                    FechaDesde = dtpFechaEvento.Value,
                    // Si es nueva solicitud, siempre asignar "Pendiente"
                    // Si es edición, tomar el valor del combo (que está visible)
                    Estado = _idSolicitud.HasValue ? cboEstado.SelectedItem.ToString() : "Pendiente"
                };

                if (_idSolicitud.HasValue)
                {
                    solicitud.IdSolicitud = _idSolicitud.Value;
                    await LogicaSolicitud.UpdateAsync(solicitud);
                }
                else
                {
                    await LogicaSolicitud.CreateAsync(solicitud);
                    
                    // Asignar servicios seleccionados a la nueva solicitud
                    if (cboSalon.SelectedIndex > 0 && cboSalon.SelectedItem is Salon salon)
                    {
                        await LogicaSolicitud.AsignarSalonASolicitudAsync(solicitud.IdSolicitud, salon.IdSalon);
                    }
                
                    if (cboDJ.SelectedIndex > 0 && cboDJ.SelectedItem is Dj dj)
                    {
                         await LogicaSolicitud.AsignarDjASolicitudAsync(solicitud.IdSolicitud, dj.IdDj);
                     }
                     
                     if (cboBarra.SelectedIndex > 0 && cboBarra.SelectedItem is Barra barra)
                     {
                         await LogicaSolicitud.AsignarBarraASolicitudAsync(solicitud.IdSolicitud, barra.IdBarra);
                     }
                    
                    if (cboGastronomico.SelectedIndex > 0 && cboGastronomico.SelectedItem is Gastronomico gastro)
                    {
                         await LogicaSolicitud.AsignarGastronomicoASolicitudAsync(solicitud.IdSolicitud, gastro.IdGastro);
                     }
                }

                // Calcular monto total para mostrarlo
                decimal montoTotal = await LogicaSolicitud.CalcularMontoTotalAsync(solicitud.IdSolicitud);
                
                if (_idSolicitud.HasValue)
                {
                    MessageBox.Show("Solicitud actualizada correctamente.", "?xito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Solicitud creada correctamente con estado 'Pendiente'.\n\nTotal: {montoTotal:C2}", 
 "?xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la solicitud: {ex.Message}", "Error",
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
