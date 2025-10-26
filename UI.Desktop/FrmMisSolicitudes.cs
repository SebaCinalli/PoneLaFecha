using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class FrmMisSolicitudes : Form
    {
        private DataGridView dgvSolicitudes;
        private Button btnNuevaSolicitud;
        private Button btnVerDetalles;
        private Button btnEditar;
        private Button btnCancelar;
        private Button btnCerrar;
        private Label lblTitulo;
        private ComboBox cboEstado;
        private Label lblFiltroEstado;
        private Button btnLimpiarFiltro;
        private Label lblInfo;

        private readonly LogicaSolicitud _logicaSolicitud;

        public FrmMisSolicitudes()
        {
            _logicaSolicitud = new LogicaSolicitud();
            InitializeComponent();
            CargarSolicitudes();
        }

        private void InitializeComponent()
        {
            this.dgvSolicitudes = new DataGridView();
            this.btnNuevaSolicitud = new Button();
            this.btnVerDetalles = new Button();
            this.btnEditar = new Button();
            this.btnCancelar = new Button();
            this.btnCerrar = new Button();
            this.lblTitulo = new Label();
            this.cboEstado = new ComboBox();
            this.lblFiltroEstado = new Label();
            this.btnLimpiarFiltro = new Button();
            this.lblInfo = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitulo.ForeColor = Color.DarkBlue;
            this.lblTitulo.Location = new Point(300, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(200, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mis Solicitudes";

            // lblInfo
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblInfo.ForeColor = Color.DarkGreen;
            this.lblInfo.Location = new Point(12, 50);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(400, 17);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Aquí puedes ver y gestionar todas tus solicitudes de eventos";

            // lblFiltroEstado
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblFiltroEstado.Location = new Point(12, 85);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new Size(118, 17);
            this.lblFiltroEstado.TabIndex = 2;
            this.lblFiltroEstado.Text = "Filtrar por Estado:";

            // cboEstado
            this.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "Confirmada", "Cancelada" });
            this.cboEstado.Location = new Point(136, 82);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new Size(150, 24);
            this.cboEstado.TabIndex = 3;
            this.cboEstado.SelectedIndex = 0;
            this.cboEstado.SelectedIndexChanged += CboEstado_SelectedIndexChanged;

            // btnLimpiarFiltro
            this.btnLimpiarFiltro.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnLimpiarFiltro.Location = new Point(298, 80);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new Size(100, 28);
            this.btnLimpiarFiltro.TabIndex = 4;
            this.btnLimpiarFiltro.Text = "Limpiar Filtro";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += BtnLimpiarFiltro_Click;

            // dgvSolicitudes
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Location = new Point(12, 120);
            this.dgvSolicitudes.MultiSelect = false;
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudes.Size = new Size(760, 300);
            this.dgvSolicitudes.TabIndex = 5;

            // btnNuevaSolicitud
            this.btnNuevaSolicitud.BackColor = Color.LightGreen;
            this.btnNuevaSolicitud.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnNuevaSolicitud.Location = new Point(12, 440);
            this.btnNuevaSolicitud.Name = "btnNuevaSolicitud";
            this.btnNuevaSolicitud.Size = new Size(150, 40);
            this.btnNuevaSolicitud.TabIndex = 6;
            this.btnNuevaSolicitud.Text = "Nueva Solicitud";
            this.btnNuevaSolicitud.UseVisualStyleBackColor = false;
            this.btnNuevaSolicitud.Click += BtnNuevaSolicitud_Click;

            // btnVerDetalles
            this.btnVerDetalles.BackColor = Color.LightBlue;
            this.btnVerDetalles.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnVerDetalles.Location = new Point(180, 440);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new Size(150, 40);
            this.btnVerDetalles.TabIndex = 7;
            this.btnVerDetalles.Text = "Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = false;
            this.btnVerDetalles.Click += BtnVerDetalles_Click;

            // btnEditar
            this.btnEditar.BackColor = Color.LightYellow;
            this.btnEditar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEditar.Location = new Point(348, 440);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new Size(150, 40);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += BtnEditar_Click;

            // btnCancelar
            this.btnCancelar.BackColor = Color.LightCoral;
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCancelar.Location = new Point(516, 440);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(120, 40);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += BtnCancelar_Click;

            // btnCerrar
            this.btnCerrar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnCerrar.Location = new Point(652, 440);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(120, 40);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += BtnCerrar_Click;

            // FrmMisSolicitudes
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightSteelBlue;
            this.ClientSize = new Size(784, 501);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.btnNuevaSolicitud);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.lblFiltroEstado);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMisSolicitudes";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Mis Solicitudes";

            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private async void CargarSolicitudes()
        {
            try
            {
                if (!SesionUsuario.EstaLogueado)
                {
                    MessageBox.Show("Debe iniciar sesión para ver sus solicitudes.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // Obtener el cliente asociado al usuario actual
                var cliente = LogicaCliente.ObtenerPorNombreUsuario(SesionUsuario.UsuarioActual.NombreUsuario);
                
                if (cliente == null)
                {
                    // Si no existe un cliente, crearlo automáticamente
                    cliente = LogicaCliente.CrearDesdeUsuario(SesionUsuario.UsuarioActual);
                }

                // Cargar solicitudes del cliente actual
                var solicitudes = await _logicaSolicitud.GetByClienteIdAsync(cliente.IdCliente);
                dgvSolicitudes.DataSource = solicitudes;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las solicitudes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            // Ocultar columnas de navegación
            if (dgvSolicitudes.Columns["Cliente"] != null)
                dgvSolicitudes.Columns["Cliente"].Visible = false;
            if (dgvSolicitudes.Columns["SalonSolicitudes"] != null)
                dgvSolicitudes.Columns["SalonSolicitudes"].Visible = false;
            if (dgvSolicitudes.Columns["BarraSolicitudes"] != null)
                dgvSolicitudes.Columns["BarraSolicitudes"].Visible = false;
            if (dgvSolicitudes.Columns["GastroSolicitudes"] != null)
                dgvSolicitudes.Columns["GastroSolicitudes"].Visible = false;
            if (dgvSolicitudes.Columns["DjSolicitudes"] != null)
                dgvSolicitudes.Columns["DjSolicitudes"].Visible = false;
            if (dgvSolicitudes.Columns["IdCliente"] != null)
                dgvSolicitudes.Columns["IdCliente"].Visible = false;

            // Configurar headers
            if (dgvSolicitudes.Columns["IdSolicitud"] != null)
                dgvSolicitudes.Columns["IdSolicitud"].HeaderText = "Nro.";
            if (dgvSolicitudes.Columns["FechaDesde"] != null)
            {
                dgvSolicitudes.Columns["FechaDesde"].HeaderText = "Fecha Evento";
                dgvSolicitudes.Columns["FechaDesde"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvSolicitudes.Columns["MontoDJ"] != null)
            {
                dgvSolicitudes.Columns["MontoDJ"].HeaderText = "Monto DJ";
                dgvSolicitudes.Columns["MontoDJ"].DefaultCellStyle.Format = "C2";
            }
            if (dgvSolicitudes.Columns["MontoSalon"] != null)
            {
                dgvSolicitudes.Columns["MontoSalon"].HeaderText = "Monto Salón";
                dgvSolicitudes.Columns["MontoSalon"].DefaultCellStyle.Format = "C2";
            }
            if (dgvSolicitudes.Columns["MontoGastro"] != null)
            {
                dgvSolicitudes.Columns["MontoGastro"].HeaderText = "Monto Gastro";
                dgvSolicitudes.Columns["MontoGastro"].DefaultCellStyle.Format = "C2";
            }
            if (dgvSolicitudes.Columns["MontoBarra"] != null)
            {
                dgvSolicitudes.Columns["MontoBarra"].HeaderText = "Monto Barra";
                dgvSolicitudes.Columns["MontoBarra"].DefaultCellStyle.Format = "C2";
            }
        }

        private async void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstado.SelectedItem.ToString() == "Todos")
            {
                CargarSolicitudes();
            }
            else
            {
                try
                {
                    // Obtener el cliente asociado al usuario actual
                    var cliente = LogicaCliente.ObtenerPorNombreUsuario(SesionUsuario.UsuarioActual.NombreUsuario);
                    if (cliente == null)
                    {
                        cliente = LogicaCliente.CrearDesdeUsuario(SesionUsuario.UsuarioActual);
                    }

                    var estado = cboEstado.SelectedItem.ToString();
                    var todasSolicitudes = await _logicaSolicitud.GetByClienteIdAsync(cliente.IdCliente);
                    var solicitudesFiltradas = todasSolicitudes.Where(s => s.Estado == estado).ToList();
                    dgvSolicitudes.DataSource = solicitudesFiltradas;
                    ConfigurarColumnas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al filtrar solicitudes: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0;
            CargarSolicitudes();
        }

        private void BtnNuevaSolicitud_Click(object sender, EventArgs e)
        {
            var frmDetalle = new FrmDetalleSolicitud();
            if (frmDetalle.ShowDialog() == DialogResult.OK)
            {
                CargarSolicitudes();
            }
        }

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una solicitud para ver sus detalles.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var solicitud = (Solicitud)dgvSolicitudes.SelectedRows[0].DataBoundItem;
            var frmDetalle = new FrmDetalleSolicitud(solicitud.IdSolicitud, true);
            frmDetalle.ShowDialog();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una solicitud para editar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var solicitud = (Solicitud)dgvSolicitudes.SelectedRows[0].DataBoundItem;

            // Solo permitir editar si está en estado Pendiente
            if (solicitud.Estado != "Pendiente")
            {
                MessageBox.Show("Solo puede editar solicitudes en estado Pendiente.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frmDetalle = new FrmDetalleSolicitud(solicitud.IdSolicitud);
            if (frmDetalle.ShowDialog() == DialogResult.OK)
            {
                CargarSolicitudes();
            }
        }

        private async void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una solicitud para cancelar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var solicitud = (Solicitud)dgvSolicitudes.SelectedRows[0].DataBoundItem;

            // Solo permitir cancelar si no está cancelada
            if (solicitud.Estado == "Cancelada")
            {
                MessageBox.Show("Esta solicitud ya está cancelada.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show($"¿Está seguro de que desea cancelar la solicitud #{solicitud.IdSolicitud}?",
                "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    await _logicaSolicitud.CambiarEstadoAsync(solicitud.IdSolicitud, "Cancelada");
                    MessageBox.Show("Solicitud cancelada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarSolicitudes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cancelar la solicitud: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
