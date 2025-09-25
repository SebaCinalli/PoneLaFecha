using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void CrearDatosEjemplo()
        {
            using var db = new AppDbContext();
            
            if (!db.Djs.Any())
            {
                var djs = new List<Dj>
                {
                    new Dj
                    {
                        NombreArtistico = "DJ Electro",
                        Estado = "Disponible",
                        MontoDj = 80000.00m
                    },
                    new Dj
                    {
                        NombreArtistico = "DJ Remix",
                        Estado = "Disponible",
                        MontoDj = 65000.00m
                    },
                    new Dj
                    {
                        NombreArtistico = "DJ Sound Master",
                        Estado = "Ocupado",
                        MontoDj = 120000.00m
                    }
                };
                
                db.Djs.AddRange(djs);
                db.SaveChanges();
            }
        }
    }
}