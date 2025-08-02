using Datos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TPIntegrador.Entidades;

namespace TPIntegrador.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet = Tabla en la BD
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Salon> Salones { get; set; }

        // Agregá aquí los demás DbSet más adelante
        // public DbSet<Barra> Barras { get; set; }
        // public DbSet<Gastronomico> Gastronomicos { get; set; }
        // etc.
    }
}
