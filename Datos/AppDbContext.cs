using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Entidades;

namespace Datos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Barra> Barras { get; set; }
        public DbSet<Dj> Djs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Gastronomico> Gastronomicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionHelper.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure decimal precision for monetary fields
            modelBuilder.Entity<Salon>()
                .Property(s => s.MontoSalon)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Barra>()
                .Property(b => b.PrecioPorHora)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Dj>()
                .Property(d => d.MontoDj)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Gastronomico>()
                .Property(g => g.MontoG)
                .HasPrecision(18, 2);

            // Configure unique constraints
            modelBuilder.Entity<Dj>()
                .HasIndex(d => d.NombreArtistico)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
