using Entidades;
using Datos;
using Microsoft.Data.SqlClient;

namespace Negocio
{
    public static class LogicaCliente
    {
        public static List<Cliente> Listar()
        {
            using var db = new AppDbContext();
            return db.Clientes.ToList();
        }

        /// <summary>
        /// Método que usa ADO.NET puro para contar el total de clientes.
        /// Implementado para cumplir con el requisito de usar ADO.NET al menos una vez.
        /// </summary>
        public static int ObtenerTotalClientesConADO()
        {
            int total = 0;
            string connectionString = ConnectionHelper.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Clientes";

                using (var command = new SqlCommand(query, connection))
                {
                    total = (int)command.ExecuteScalar();
                }
            }

            return total;
        }

        public static int Crear(Cliente c)
        {
            using var db = new AppDbContext();
            db.Clientes.Add(c);
            db.SaveChanges();
            return c.IdCliente;
        }

        public static Cliente? Obtener(int id)
        {
            using var db = new AppDbContext();
            return db.Clientes.Find(id);
        }

        public static Cliente? ObtenerPorNombreUsuario(string nombreUsuario)
        {
            using var db = new AppDbContext();
            return db.Clientes.FirstOrDefault(c => c.NombreUsuario == nombreUsuario);
        }

        public static void Editar(Cliente c)
        {
            using var db = new AppDbContext();
            db.Clientes.Update(c);
            db.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var cliente = db.Clientes.Find(id);
            if (cliente != null)
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
        }

        // Crear cliente automáticamente desde un usuario
        public static Cliente CrearDesdeUsuario(Usuario usuario)
        {
            using var db = new AppDbContext();
            
            // Verificar si ya existe un cliente con ese nombre de usuario
            var clienteExistente = db.Clientes.FirstOrDefault(c => c.NombreUsuario == usuario.NombreUsuario);
            if (clienteExistente != null)
            {
                return clienteExistente;
            }

            var nuevoCliente = new Cliente
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email ?? string.Empty,
                Telefono = usuario.Telefono ?? string.Empty,
                NombreUsuario = usuario.NombreUsuario,
                Clave = usuario.Password,  // Agregar la clave desde el usuario
                Rol = usuario.Rol          // Agregar el rol desde el usuario
            };

            db.Clientes.Add(nuevoCliente);
            db.SaveChanges();
            return nuevoCliente;
        }
    }
}
