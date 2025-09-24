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
    }
}
