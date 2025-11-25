using Datos;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class LogicaZona
    {
        public static List<Zona> Listar()
        {
            using var context = new AppDbContext();
            return context.Zonas.ToList();
        }

        public static Zona? Obtener(int id)
        {
            using var context = new AppDbContext();
            return context.Zonas.Find(id);
        }

        public static void Crear(Zona zona)
        {
            using var context = new AppDbContext();
            context.Zonas.Add(zona);
            context.SaveChanges();
        }

        public static void Editar(Zona zona)
        {
            using var context = new AppDbContext();
            context.Zonas.Update(zona);
            context.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var context = new AppDbContext();
            var zona = context.Zonas.Find(id);
            if (zona != null)
            {
                context.Zonas.Remove(zona);
                context.SaveChanges();
            }
        }

        public async Task<List<Dj>> GetDjsPorZonaAsync(int idZona)
        {
            using var context = new AppDbContext();
            return await context.ZonaDJs
                .Where(zd => zd.IdZona == idZona)
                .Include(zd => zd.Dj)
                .Select(zd => zd.Dj)
                .ToListAsync();
        }

        public async Task<List<Barra>> GetBarrasPorZonaAsync(int idZona)
        {
            using var context = new AppDbContext();
            return await context.ZonaBarras
                .Where(zb => zb.IdZona == idZona)
                .Include(zb => zb.Barra)
                .Select(zb => zb.Barra)
                .ToListAsync();
        }

        public async Task<List<Gastronomico>> GetGastronomicosPorZonaAsync(int idZona)
        {
            using var context = new AppDbContext();
            return await context.ZonaGastros
                .Where(zg => zg.IdZona == idZona)
                .Include(zg => zg.Gastronomico)
                .Select(zg => zg.Gastronomico)
                .ToListAsync();
        }
    }
}
