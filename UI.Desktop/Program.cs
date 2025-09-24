using Microsoft.EntityFrameworkCore;
using Datos;

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

            // Ensure DB schema with migrations - run any pending migrations
            using (var db = new AppDbContext())
            {
                db.Database.Migrate();
            }

            // Show main menu instead of individual forms
            Application.Run(new FrmMenuPrincipal());
        }
    }
}