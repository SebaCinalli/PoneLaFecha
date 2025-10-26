using Entidades;
using Datos;

namespace Negocio
{
    public static class LogicaCliente
    {
        public static List<Cliente> Listar()
        {
            using var db = new AppDbContext();
            return db.Clientes.ToList();
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
                NombreUsuario = usuario.NombreUsuario
            };

            db.Clientes.Add(nuevoCliente);
            db.SaveChanges();
            return nuevoCliente;
        }
    }
}
