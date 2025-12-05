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

        public static void CrearDatosEjemplo()
        {
            using var db = new AppDbContext();
            
            if (!db.Barras.Any())
            {
                var barras = new List<Barra>
                {
                    new Barra
                    {
                        Nombre = "Barra Premium",
                        TipoBebida = "Mixta",
                        Descripcion = "Barra completa con bebidas alcohólicas premium y sin alcohol",
                        PrecioPorHora = 5000.00m,
                        Estado = "Disponible"
                    },
                    new Barra
                    {
                        Nombre = "Barra Estándar",
                        TipoBebida = "Estándar",
                        Descripcion = "Barra con bebidas alcohólicas y sin alcohol básicas",
                        PrecioPorHora = 3000.00m,
                        Estado = "Disponible"
                    },
                    new Barra
                    {
                        Nombre = "Barra Sin Alcohol",
                        TipoBebida = "Sin Alcohol",
                        Descripcion = "Barra con jugos, gaseosas y tragos sin alcohol",
                        PrecioPorHora = 1500.00m,
                        Estado = "Disponible"
                    }
                };
                
                db.Barras.AddRange(barras);
                db.SaveChanges();
            }
        }
    }
}
