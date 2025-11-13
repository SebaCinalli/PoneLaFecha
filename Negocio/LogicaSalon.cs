using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Datos;
using Microsoft.Data.SqlClient;

namespace Negocio
{
    public static class LogicaSalon
    {
        public static List<Salon> Listar()
        {
            using var db = new AppDbContext();
            return db.Salones.ToList();
        }

        /// <summary>
        /// Método que usa ADO.NET puro para listar salones.
        /// Implementado para cumplir con el requisito de usar ADO.NET al menos una vez.
        /// </summary>
        public static List<Salon> ListarConADO()
        {
            var salones = new List<Salon>();
            string connectionString = ConnectionHelper.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT IdSalon, NombreSalon, Estado, MontoSalon FROM Salones";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var salon = new Salon
                            {
                                IdSalon = reader.GetInt32(0),
                                NombreSalon = reader.GetString(1),
                                Estado = reader.GetString(2),
                                MontoSalon = reader.GetDecimal(3)
                            };
                            salones.Add(salon);
                        }
                    }
                }
            }

            return salones;
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
