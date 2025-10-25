using Datos;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class LogicaSolicitud
    {
     public async Task<List<Solicitud>> GetAllAsync()
        {
            using var context = new AppDbContext();
        return await context.Solicitudes
   .Include(s => s.Cliente)
 .ToListAsync();
 }
public async Task<Solicitud?> GetByIdAsync(int id)
     {
      using var context = new AppDbContext();
            return await context.Solicitudes
         .Include(s => s.Cliente)
     .Include(s => s.SalonSolicitudes).ThenInclude(ss => ss.Salon)
         .Include(s => s.BarraSolicitudes).ThenInclude(bs => bs.Barra)
        .Include(s => s.GastroSolicitudes).ThenInclude(gs => gs.Gastronomico)
       .Include(s => s.DjSolicitudes).ThenInclude(ds => ds.Dj)
       .FirstOrDefaultAsync(s => s.IdSolicitud == id);
        }

        public async Task<List<Solicitud>> GetByClienteIdAsync(int idCliente)
        {
            using var context = new AppDbContext();
    return await context.Solicitudes
       .Where(s => s.IdCliente == idCliente)
    .Include(s => s.Cliente)
 .Include(s => s.SalonSolicitudes).ThenInclude(ss => ss.Salon)
    .Include(s => s.BarraSolicitudes).ThenInclude(bs => bs.Barra)
  .Include(s => s.GastroSolicitudes).ThenInclude(gs => gs.Gastronomico)
       .Include(s => s.DjSolicitudes).ThenInclude(ds => ds.Dj)
       .ToListAsync();
        }

 public async Task<Solicitud> CreateAsync(Solicitud solicitud)
 {
      using var context = new AppDbContext();
      context.Solicitudes.Add(solicitud);
      await context.SaveChangesAsync();
    return solicitud;
        }

  public async Task<Solicitud?> UpdateAsync(Solicitud solicitud)
   {
         using var context = new AppDbContext();
    var solicitudExistente = await context.Solicitudes.FindAsync(solicitud.IdSolicitud);
     if (solicitudExistente == null)
    return null;

     solicitudExistente.FechaDesde = solicitud.FechaDesde;
            solicitudExistente.MontoDJ = solicitud.MontoDJ;
   solicitudExistente.MontoSalon = solicitud.MontoSalon;
            solicitudExistente.MontoGastro = solicitud.MontoGastro;
    solicitudExistente.MontoBarra = solicitud.MontoBarra;
     solicitudExistente.Estado = solicitud.Estado;

          await context.SaveChangesAsync();
       return solicitudExistente;
  }

        public async Task<bool> DeleteAsync(int id)
        {
       using var context = new AppDbContext();
  var solicitud = await context.Solicitudes.FindAsync(id);
      if (solicitud == null)
      return false;

    context.Solicitudes.Remove(solicitud);
     await context.SaveChangesAsync();
      return true;
        }

        // Métodos para gestionar las relaciones con servicios
  public async Task<bool> AsignarSalonASolicitudAsync(int idSolicitud, int idSalon)
        {
  using var context = new AppDbContext();
       
        var existeRelacion = await context.SalonSolicitudes
     .AnyAsync(ss => ss.IdSolicitud == idSolicitud && ss.IdSalon == idSalon);
            
   if (existeRelacion)
        return false;

var salonSolicitud = new SalonSolicitud
            {
  IdSolicitud = idSolicitud,
      IdSalon = idSalon
       };

   context.SalonSolicitudes.Add(salonSolicitud);
        await context.SaveChangesAsync();
            return true;
     }

  public async Task<bool> AsignarBarraASolicitudAsync(int idSolicitud, int idBarra)
    {
     using var context = new AppDbContext();
            
   var existeRelacion = await context.BarraSolicitudes
       .AnyAsync(bs => bs.IdSolicitud == idSolicitud && bs.IdBarra == idBarra);
   
    if (existeRelacion)
     return false;

 var barraSolicitud = new BarraSolicitud
            {
          IdSolicitud = idSolicitud,
   IdBarra = idBarra
            };

    context.BarraSolicitudes.Add(barraSolicitud);
    await context.SaveChangesAsync();
            return true;
    }

public async Task<bool> AsignarGastronomicoASolicitudAsync(int idSolicitud, int idGastro)
  {
using var context = new AppDbContext();
            
         var existeRelacion = await context.GastroSolicitudes
      .AnyAsync(gs => gs.IdSolicitud == idSolicitud && gs.IdGastro == idGastro);
         
     if (existeRelacion)
  return false;

  var gastroSolicitud = new GastroSolicitud
   {
       IdSolicitud = idSolicitud,
           IdGastro = idGastro
  };

   context.GastroSolicitudes.Add(gastroSolicitud);
   await context.SaveChangesAsync();
       return true;
  }

 public async Task<bool> AsignarDjASolicitudAsync(int idSolicitud, int idDj)
        {
       using var context = new AppDbContext();
         
    var existeRelacion = await context.DjSolicitudes
        .AnyAsync(ds => ds.IdSolicitud == idSolicitud && ds.IdDj == idDj);
     
       if (existeRelacion)
  return false;

  var djSolicitud = new DjSolicitud
    {
    IdSolicitud = idSolicitud,
      IdDj = idDj
  };

 context.DjSolicitudes.Add(djSolicitud);
 await context.SaveChangesAsync();
return true;
 }

   // Métodos para calcular el monto total de una solicitud
   public async Task<decimal> CalcularMontoTotalAsync(int idSolicitud)
{
  using var context = new AppDbContext();
     var solicitud = await context.Solicitudes.FindAsync(idSolicitud);
  if (solicitud == null)
             return 0;

      return solicitud.MontoDJ + solicitud.MontoSalon + 
     solicitud.MontoGastro + solicitud.MontoBarra;
        }

        // Cambiar estado de la solicitud
    public async Task<bool> CambiarEstadoAsync(int idSolicitud, string nuevoEstado)
 {
     using var context = new AppDbContext();
     var solicitud = await context.Solicitudes.FindAsync(idSolicitud);
  if (solicitud == null)
      return false;

       solicitud.Estado = nuevoEstado;
       await context.SaveChangesAsync();
         return true;
        }

 // Obtener solicitudes por estado
     public async Task<List<Solicitud>> GetByEstadoAsync(string estado)
        {
   using var context = new AppDbContext();
         return await context.Solicitudes
     .Where(s => s.Estado == estado)
        .Include(s => s.Cliente)
       .ToListAsync();
  }
    }
}
