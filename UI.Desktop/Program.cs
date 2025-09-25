using Microsoft.EntityFrameworkCore;
using Datos;
using Negocio;

namespace UI.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                // Ensure DB schema with migrations - run any pending migrations
                using (var db = new AppDbContext())
                {
                    db.Database.Migrate();
                }

                // Crear administrador por defecto si no existe
                LogicaUsuario.CrearAdministradorDefault();
                
                // Crear usuarios de ejemplo para testing
                LogicaUsuario.CrearUsuariosEjemplo();
                
                // Crear datos de ejemplo para los servicios
                LogicaSalon.CrearDatosEjemplo();
                LogicaBarra.CrearDatosEjemplo();
                LogicaDj.CrearDatosEjemplo();

                // Mostrar formulario de login
                var frmLogin = new FrmLogin();
                Application.Run(frmLogin);

                // Si el login fue exitoso, mostrar la interfaz correspondiente
                if (frmLogin.LoginExitoso && SesionUsuario.EstaLogueado)
                {
                    if (SesionUsuario.EsAdministrador)
                    {
                        // Mostrar menú completo para administradores
                        Application.Run(new FrmMenuPrincipal());
                    }
                    else if (SesionUsuario.EsCliente)
                    {
                        // Mostrar menú restringido para clientes
                        Application.Run(new FrmMenuCliente());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la aplicación: {ex.Message}", 
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}