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

                // Bucle principal de la aplicación
                bool continuarEjecutando = true;
                
                while (continuarEjecutando)
                {
                    // Mostrar formulario de login
                    var frmLogin = new FrmLogin();
                    Application.Run(frmLogin);
                    
                    // Verificar si el login fue exitoso
                    if (frmLogin.LoginExitoso && SesionUsuario.EstaLogueado)
                    {
                        // Abrir el menú principal
                        var frmMenu = new FrmMenuPrincipal();
                        Application.Run(frmMenu);
                        
                        // Si cerró sesión, volver al login
                        if (frmMenu.CerroSesion)
                        {
                            continue;
                        }
                        else
                        {
                            // Si salió, terminar la aplicación
                            continuarEjecutando = false;
                        }
                    }
                    else
                    {
                        // Si no hizo login (cerró el formulario), salir
                        continuarEjecutando = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la aplicacin:\n{ex.Message}\n\nDetalles:\n{ex.ToString()}", 
                    "Error Crtico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
