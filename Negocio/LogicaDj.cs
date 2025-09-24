using Entidades;
using Datos;

namespace Negocio
{
    public static class LogicaDj
    {
        public static List<Dj> Listar()
        {
            using var db = new AppDbContext();
            return db.Djs.ToList();
        }

        public static int Crear(Dj dj)
        {
            using var db = new AppDbContext();
            db.Djs.Add(dj);
            db.SaveChanges();
            return dj.IdDj;
        }

        public static Dj? Obtener(int id)
        {
            using var db = new AppDbContext();
            return db.Djs.Find(id);
        }

        public static void Editar(Dj dj)
        {
            using var db = new AppDbContext();
            db.Djs.Update(dj);
            db.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var dj = db.Djs.Find(id);
            if (dj != null)
            {
                db.Djs.Remove(dj);
                db.SaveChanges();
            }
        }
    }
}