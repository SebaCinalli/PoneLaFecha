using Entidades;

namespace Negocio
{
    public static class LogicaCliente
    {
        private static List<Cliente> clientes = new();
        private static int proximoId = 1;

        public static List<Cliente> Listar() => clientes;

        public static void Crear(Cliente c)
        {
            c.IdCliente = proximoId++;
            clientes.Add(c);
        }

        public static Cliente Obtener(int id) =>
            clientes.FirstOrDefault(c => c.IdCliente == id);

        public static void Editar(Cliente c)
        {
            var existente = Obtener(c.IdCliente);
            if (existente != null)
            {
                existente.Nombre = c.Nombre;
                existente.Apellido = c.Apellido;
                existente.Email = c.Email;
                existente.Telefono = c.Telefono;
                existente.NombreUsuario = c.NombreUsuario;
            }
        }

        public static void Eliminar(int id)
        {
            var cliente = Obtener(id);
            if (cliente != null) clientes.Remove(cliente);
        }
    }
}
