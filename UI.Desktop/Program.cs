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

            // Ciclo de login/menú
   bool continuarAplicacion = true;
       
                while (continuarAplicacion)
    {
  // Mostrar formulario de login
        var frmLogin = new FrmLogin();
                    Application.Run(frmLogin);

 // Si el login fue exitoso, mostrar la interfaz correspondiente
        if (frmLogin.LoginExitoso && SesionUsuario.EstaLogueado)
        {
            try
               {
             if (SesionUsuario.EsAdministrador)
    {
        Application.Run(new FrmMenuPrincipal());
        // Si el administrador cierra su menú, salir de la aplicación
     continuarAplicacion = false;
           }
      else if (SesionUsuario.EsCliente)
   {
               var frmMenuCliente = new FrmMenuCliente();
      Application.Run(frmMenuCliente);
     
        // Si el cliente cerró sesión, volver al login
        if (frmMenuCliente.CerroSesion)
        {
 continuarAplicacion = true; // Continuar al login
            }
          else
         {
  // Si cerró el formulario sin cerrar sesión (salir), terminar
  continuarAplicacion = false;
   }
        }
      }
      catch (Exception ex)
             {
        MessageBox.Show($"Error al abrir el menú:\n{ex.Message}\n\nDetalles:\n{ex.ToString()}", 
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                continuarAplicacion = false;
            }
  }
         else
    {
        // Si no hay login exitoso, salir
      continuarAplicacion = false;
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
