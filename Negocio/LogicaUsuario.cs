using Entidades;
using Datos;

namespace Negocio
{
    public static class LogicaUsuario
    {
        public static Cliente? Login(string username, string password)
        {
            using var context = new AppDbContext();
            var cliente = context.Clientes.FirstOrDefault(u => u.NombreUsuario == username);
            
            if (cliente != null && cliente.Clave == password)
            {
                return cliente;
            }
            return null;
        }

        public static void Crear(Cliente cliente)
        {
             using var context = new AppDbContext();
             context.Clientes.Add(cliente);
             context.SaveChanges();
        }
    }
}
