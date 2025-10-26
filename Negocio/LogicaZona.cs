using Datos;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
 public class LogicaZona
    {
        public async Task<List<Zona>> GetAllAsync()
        {
  using var context = new AppDbContext();
            return await context.Zonas.ToListAsync();
        }

        public async Task<Zona?> GetByIdAsync(int id)
   {
  using var context = new AppDbContext();
      return await context.Zonas.FindAsync(id);
        }

  public async Task<Zona> CreateAsync(Zona zona)
      {
     using var context = new AppDbContext();
         context.Zonas.Add(zona);
            await context.SaveChangesAsync();
            return zona;
 }

  public async Task<Zona?> UpdateAsync(Zona zona)
        {
  using var context = new AppDbContext();
       var zonaExistente = await context.Zonas.FindAsync(zona.IdZona);
         if (zonaExistente == null)
    return null;

  zonaExistente.Nombre = zona.Nombre;
            await context.SaveChangesAsync();
        return zonaExistente;
        }

        public async Task<bool> DeleteAsync(int id)
   {
      using var context = new AppDbContext();
            var zona = await context.Zonas.FindAsync(id);
            if (zona == null)
   return false;

       context.Zonas.Remove(zona);
         await context.SaveChangesAsync();
  return true;
  }

        // Métodos específicos para gestionar relaciones Zona-Salon
     public async Task<bool> AsignarSalonAZonaAsync(int idZona, int idSalon)
        {
         using var context = new AppDbContext();
            
            // Verificar que no existe la relación
     var existeRelacion = await context.ZonaSalones
     .AnyAsync(zs => zs.IdZona == idZona && zs.IdSalon == idSalon);
            
   if (existeRelacion)
      return false;

       var zonaSalon = new ZonaSalon
            {
   IdZona = idZona,
   IdSalon = idSalon
            };

   context.ZonaSalones.Add(zonaSalon);
         await context.SaveChangesAsync();
     return true;
}

        public async Task<bool> RemoverSalonDeZonaAsync(int idZona, int idSalon)
        {
   using var context = new AppDbContext();
   var zonaSalon = await context.ZonaSalones
    .FirstOrDefaultAsync(zs => zs.IdZona == idZona && zs.IdSalon == idSalon);
            
   if (zonaSalon == null)
          return false;

            context.ZonaSalones.Remove(zonaSalon);
       await context.SaveChangesAsync();
       return true;
 }

        // Métodos similares para otras relaciones (Barra, Gastro, DJ)
        public async Task<List<Salon>> GetSalonesPorZonaAsync(int idZona)
   {
   using var context = new AppDbContext();
     return await context.ZonaSalones
                .Where(zs => zs.IdZona == idZona)
   .Include(zs => zs.Salon)
          .Select(zs => zs.Salon)
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

        public async Task<List<Dj>> GetDjsPorZonaAsync(int idZona)
    {
            using var context = new AppDbContext();
      return await context.ZonaDJs
      .Where(zd => zd.IdZona == idZona)
        .Include(zd => zd.Dj)
 .Select(zd => zd.Dj)
        .ToListAsync();
     }
    }
}
