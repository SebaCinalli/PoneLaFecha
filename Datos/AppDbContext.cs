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
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }

        // Tablas intermedias
        public DbSet<SalonSolicitud> SalonSolicitudes { get; set; }
        public DbSet<BarraSolicitud> BarraSolicitudes { get; set; }
        public DbSet<GastroSolicitud> GastroSolicitudes { get; set; }
        public DbSet<DjSolicitud> DjSolicitudes { get; set; }
        public DbSet<ZonaSalon> ZonaSalones { get; set; }
        public DbSet<ZonaBarra> ZonaBarras { get; set; }
        public DbSet<ZonaGastro> ZonaGastros { get; set; }
        public DbSet<ZonaDJ> ZonaDJs { get; set; }

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

            // Configure decimal precision for Solicitud monetary fields
            modelBuilder.Entity<Solicitud>()
                .Property(s => s.MontoDJ)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Solicitud>()
                .Property(s => s.MontoSalon)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Solicitud>()
                .Property(s => s.MontoGastro)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Solicitud>()
                .Property(s => s.MontoBarra)
                .HasPrecision(18, 2);

            // Configure unique constraints
            modelBuilder.Entity<Dj>()
                .HasIndex(d => d.NombreArtistico)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            // Configure relationships for Solicitud
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Cliente)
                .WithMany(c => c.Solicitudes)
                .HasForeignKey(s => s.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationships for Solicitud
            modelBuilder.Entity<SalonSolicitud>()
                .HasOne(ss => ss.Salon)
                .WithMany(s => s.SalonSolicitudes)
                .HasForeignKey(ss => ss.IdSalon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalonSolicitud>()
                .HasOne(ss => ss.Solicitud)
                .WithMany(s => s.SalonSolicitudes)
                .HasForeignKey(ss => ss.IdSolicitud)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BarraSolicitud>()
                .HasOne(bs => bs.Barra)
                .WithMany(b => b.BarraSolicitudes)
                .HasForeignKey(bs => bs.IdBarra)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BarraSolicitud>()
                .HasOne(bs => bs.Solicitud)
                .WithMany(s => s.BarraSolicitudes)
                .HasForeignKey(bs => bs.IdSolicitud)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GastroSolicitud>()
                .HasOne(gs => gs.Gastronomico)
                .WithMany(g => g.GastroSolicitudes)
                .HasForeignKey(gs => gs.IdGastro)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GastroSolicitud>()
                .HasOne(gs => gs.Solicitud)
                .WithMany(s => s.GastroSolicitudes)
                .HasForeignKey(gs => gs.IdSolicitud)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DjSolicitud>()
                .HasOne(ds => ds.Dj)
                .WithMany(d => d.DjSolicitudes)
                .HasForeignKey(ds => ds.IdDj)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DjSolicitud>()
                .HasOne(ds => ds.Solicitud)
                .WithMany(s => s.DjSolicitudes)
                .HasForeignKey(ds => ds.IdSolicitud)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure many-to-many relationships for Zona
            modelBuilder.Entity<ZonaSalon>()
                .HasOne(zs => zs.Zona)
                .WithMany(z => z.ZonaSalones)
                .HasForeignKey(zs => zs.IdZona)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZonaSalon>()
                .HasOne(zs => zs.Salon)
                .WithMany(s => s.ZonaSalones)
                .HasForeignKey(zs => zs.IdSalon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZonaBarra>()
                .HasOne(zb => zb.Zona)
                .WithMany(z => z.ZonaBarras)
                .HasForeignKey(zb => zb.IdZona)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZonaBarra>()
                .HasOne(zb => zb.Barra)
                .WithMany(b => b.ZonaBarras)
                .HasForeignKey(zb => zb.IdBarra)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZonaGastro>()
                .HasOne(zg => zg.Zona)
                .WithMany(z => z.ZonaGastros)
                .HasForeignKey(zg => zg.IdZona)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZonaGastro>()
                .HasOne(zg => zg.Gastronomico)
                .WithMany(g => g.ZonaGastros)
                .HasForeignKey(zg => zg.IdGastro)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZonaDJ>()
                .HasOne(zd => zd.Zona)
                .WithMany(z => z.ZonaDJs)
                .HasForeignKey(zd => zd.IdZona)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZonaDJ>()
                .HasOne(zd => zd.Dj)
                .WithMany(d => d.ZonaDJs)
                .HasForeignKey(zd => zd.IdDj)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
