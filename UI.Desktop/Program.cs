using Microsoft.EntityFrameworkCore;
using Datos;
using Negocio;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Agregar manejo global de excepciones
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            {
                // Ensure DB schema with migrations
                using (var db = new AppDbContext())
                {
                    db.Database.Migrate();
                    
                    // Actualizar clientes existentes que no tengan Clave o Rol
                    var clientesSinClave = db.Clientes.Where(c => c.Clave == null || c.Clave == "").ToList();
                    foreach (var cliente in clientesSinClave)
                    {
                        cliente.Clave = "123456"; // Contraseña temporal por defecto
                        cliente.Rol = "Cliente";  // Rol por defecto
                    }
                    if (clientesSinClave.Any())
                    {
                        db.SaveChanges();
                    }
                }

                // Crear administrador por defecto si no existe
                LogicaUsuario.CrearAdministradorDefault();
                
                // Crear usuarios de ejemplo para testing
                LogicaUsuario.CrearUsuariosEjemplo();
                
                // Crear datos de ejemplo para los servicios
                LogicaSalon.CrearDatosEjemplo();
                LogicaBarra.CrearDatosEjemplo();
                LogicaDj.CrearDatosEjemplo();
                LogicaGastronomico.CrearDatosEjemplo();

                Application.Run(new FrmLogin());
                
                // Después del login, abrir el menú correspondiente
                while (true)
                {
                    var frmLogin = new FrmLogin();
                    Application.Run(frmLogin);
                    
                    if (!frmLogin.LoginExitoso)
                    {
                        break; // Salir si no hubo login exitoso
                    }
                    
                    // Abrir el menú correspondiente según el rol
                    if (SesionUsuario.EsAdministrador)
                    {
                        var frmMenu = new FrmMenuPrincipal();
                        frmMenu.ShowDialog();
                        
                        if (!frmMenu.CerroSesion)
                        {
                            break; // Salir si cerró la aplicación
                        }
                    }
                    else if (SesionUsuario.EsCliente)
                    {
                        var frmMenuCliente = new FrmMenuCliente();
                        frmMenuCliente.ShowDialog();
                        
                        if (!frmMenuCliente.CerroSesion)
                        {
                            break; // Salir si cerró la aplicación
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la aplicación:\n{ex.Message}\n\nDetalles:\n{ex.ToString()}", 
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Error no controlado:\n{e.Exception.Message}\n\nDetalles:\n{e.Exception.ToString()}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                MessageBox.Show($"Error fatal:\n{ex.Message}\n\nDetalles:\n{ex.ToString()}", 
                    "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
