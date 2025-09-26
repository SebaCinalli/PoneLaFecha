using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Datos;

namespace Negocio
{
    public static class LogicaSalon
    {
        public static List<Salon> Listar()
        {
            using var db = new AppDbContext();
            return db.Salones.ToList();
        }

        public static int Crear(Salon s)
        {
            using var db = new AppDbContext();
            db.Salones.Add(s);
            db.SaveChanges();
            return s.IdSalon;
        }

        public static Salon? Obtener(int id)
        {
            using var db = new AppDbContext();
            return db.Salones.Find(id);
        }

        public static void Editar(Salon s)
        {
            using var db = new AppDbContext();
            db.Salones.Update(s);
            db.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var salon = db.Salones.Find(id);
            if (salon != null)
            {
                db.Salones.Remove(salon);
                db.SaveChanges();
            }
        }

        public static void CrearDatosEjemplo()
        {
            using var db = new AppDbContext();
            
            if (!db.Salones.Any())
            {
                var salones = new List<Salon>
                {
                    new Salon
                    {
                        NombreSalon = "Salón Emperador",
                        Estado = "Disponible",
                        MontoSalon = 250000.00m
                    },
                    new Salon
                    {
                        NombreSalon = "Salón Cristal",
                        Estado = "Disponible", 
                        MontoSalon = 180000.00m
                    },
                    new Salon
                    {
                        NombreSalon = "Salón Garden",
                        Estado = "Ocupado",
                        MontoSalon = 320000.00m
                    }
                };
                
                db.Salones.AddRange(salones);
                db.SaveChanges();
            }
        }
    }
}
