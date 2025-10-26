using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Datos;

namespace Negocio
{
    public static class LogicaGastronomico
    {
        public static List<Gastronomico> Listar()
        {
            using var db = new AppDbContext();
            return db.Gastronomicos.ToList();
        }

        public static int Crear(Gastronomico g)
        {
            using var db = new AppDbContext();
            db.Gastronomicos.Add(g);
            db.SaveChanges();
            return g.IdGastro;
        }

        public static Gastronomico? Obtener(int id)
        {
            using var db = new AppDbContext();
            return db.Gastronomicos.Find(id);
        }

        public static void Editar(Gastronomico g)
        {
            using var db = new AppDbContext();
            db.Gastronomicos.Update(g);
            db.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var gastronomico = db.Gastronomicos.Find(id);
            if (gastronomico != null)
            {
                db.Gastronomicos.Remove(gastronomico);
                db.SaveChanges();
            }
        }

        public static void CrearDatosEjemplo()
        {
            using var db = new AppDbContext();
            
            if (!db.Gastronomicos.Any())
            {
                var gastronomicos = new List<Gastronomico>
                {
                    new Gastronomico
                    {
                        TipoComida = "Italiana",
                        Nombre = "Pasta & Pizza Deluxe",
                        MontoG = 25000.00m
                    },
                    new Gastronomico
                    {
                        TipoComida = "Argentina",
                        Nombre = "Parrilla Premium",
                        MontoG = 35000.00m
                    },
                    new Gastronomico
                    {
                        TipoComida = "Internacional",
                        Nombre = "Buffet Internacional",
                        MontoG = 40000.00m
                    },
                    new Gastronomico
                    {
                        TipoComida = "Vegetariana",
                        Nombre = "Garden Fresh",
                        MontoG = 22000.00m
                    }
                };
                
                db.Gastronomicos.AddRange(gastronomicos);
                db.SaveChanges();
            }
        }
    }
}