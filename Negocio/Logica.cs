using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    internal class Logica
    {
    }

    public static class LogicaBarra
    {
        public static List<Barra> Listar()
        {
            using var db = new AppDbContext();
            return db.Barras.ToList();
        }

        public static int Crear(Barra b)
        {
            using var db = new AppDbContext();
            db.Barras.Add(b);
            db.SaveChanges();
            return b.IdBarra;
        }

        public static Barra? Obtener(int id)
        {
            using var db = new AppDbContext();
            return db.Barras.Find(id);
        }

        public static void Editar(Barra b)
        {
            using var db = new AppDbContext();
            db.Barras.Update(b);
            db.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var barra = db.Barras.Find(id);
            if (barra != null)
            {
                db.Barras.Remove(barra);
                db.SaveChanges();
            }
        }
    }
}
