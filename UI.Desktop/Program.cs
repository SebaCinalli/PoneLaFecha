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

            // Ensure DB schema for ADO.NET persistence
            Negocio.LogicaCliente.EnsureSchema();
            Negocio.LogicaSalon.EnsureSchema();

            Application.Run(new FrmABMCliente());
            //Application.Run(new FrmABMSalon());
            //Application.Run(new FrmABMBarra());
        }
    }
}