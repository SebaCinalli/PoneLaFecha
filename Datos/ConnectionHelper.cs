using System;
using Microsoft.Data.SqlClient;

namespace Datos
{
    public static class ConnectionHelper
    {
        // Environment variable name for overriding the connection string
        private const string EnvVar = "PLF_DB";

        // Default connection string pointing to localdb
        private const string DefaultDbName = "PoneLaFecha";
        private const string DefaultConn = "Server=(localdb)\\MSSQLLocalDB;Database=" + DefaultDbName + ";Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";

        public static string GetConnectionString()
        {
            var fromEnv = Environment.GetEnvironmentVariable(EnvVar);
            return string.IsNullOrWhiteSpace(fromEnv) ? DefaultConn : fromEnv!;
        }

        public static string GetMasterConnectionString()
        {
            // Connect to master on the same server as the main connection
            var csb = new SqlConnectionStringBuilder(GetConnectionString())
            {
                InitialCatalog = "master"
            };
            return csb.ToString();
        }
    }
}
