using Datos;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class LogicaSolicitud
    {
        public static List<Solicitud> Listar()
        {
            using var context = new AppDbContext();
            return context.Solicitudes.Include(s => s.Cliente).ToList();
        }

        public static async Task<List<Solicitud>> GetAllAsync()
        {
            using var context = new AppDbContext();
            return await context.Solicitudes
                .Include(s => s.Cliente)
                .ToListAsync();
        }

        public static Solicitud? Obtener(int id)
        {
            using var context = new AppDbContext();
            return context.Solicitudes
                .Include(s => s.Cliente)
                .FirstOrDefault(s => s.IdSolicitud == id);
        }

        public static async Task<Solicitud?> GetByIdAsync(int id)
        {
            using var context = new AppDbContext();
            return await context.Solicitudes
                .Include(s => s.Cliente)
                .Include(s => s.SalonSolicitudes).ThenInclude(ss => ss.Salon)
                .Include(s => s.DjSolicitudes).ThenInclude(ds => ds.Dj)
                .Include(s => s.BarraSolicitudes).ThenInclude(bs => bs.Barra)
                .Include(s => s.GastroSolicitudes).ThenInclude(gs => gs.Gastronomico)
                .FirstOrDefaultAsync(s => s.IdSolicitud == id);
        }

        public static void Crear(Solicitud solicitud)
        {
            using var context = new AppDbContext();
            context.Solicitudes.Add(solicitud);
            context.SaveChanges();
        }

        public static async Task<int> CreateAsync(Solicitud solicitud)
        {
            using var context = new AppDbContext();
            context.Solicitudes.Add(solicitud);
            await context.SaveChangesAsync();
            return solicitud.IdSolicitud;
        }

        public static async Task<bool> UpdateAsync(Solicitud solicitud)
        {
            using var context = new AppDbContext();
            context.Solicitudes.Update(solicitud);
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using var context = new AppDbContext();
            var solicitud = await context.Solicitudes.FindAsync(id);
            if (solicitud == null) return false;

            context.Solicitudes.Remove(solicitud);
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<List<Solicitud>> GetByClienteIdAsync(int clienteId)
        {
            using var context = new AppDbContext();
            // Use AsNoTracking to avoid circular reference tracking issues
            return await context.Solicitudes
                .AsNoTracking()
                .Where(s => s.IdCliente == clienteId)
                .Select(s => new Solicitud
                {
                    IdSolicitud = s.IdSolicitud,
                    IdCliente = s.IdCliente,
                    FechaDesde = s.FechaDesde,
                    Estado = s.Estado
                    // Don't include Cliente to avoid circular reference
                })
                .OrderByDescending(s => s.FechaDesde)
                .ToListAsync();
        }

        public static async Task<List<Solicitud>> GetByEstadoAsync(string estado)
        {
            using var context = new AppDbContext();
            return await context.Solicitudes
                .AsNoTracking()
                .Where(s => s.Estado == estado)
                .Include(s => s.Cliente)
                .ToListAsync();
        }

        public static async Task<bool> CambiarEstadoAsync(int id, string nuevoEstado)
        {
            using var context = new AppDbContext();
            var solicitud = await context.Solicitudes.FindAsync(id);
            if (solicitud == null) return false;

            solicitud.Estado = nuevoEstado;
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> AsignarSalonASolicitudAsync(int idSolicitud, int idSalon)
        {
            using var context = new AppDbContext();
            var salonSolicitud = new SalonSolicitud
            {
                IdSolicitud = idSolicitud,
                IdSalon = idSalon
            };
            context.SalonSolicitudes.Add(salonSolicitud);
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> AsignarDjASolicitudAsync(int idSolicitud, int idDj)
        {
            using var context = new AppDbContext();
            var djSolicitud = new DjSolicitud
            {
                IdSolicitud = idSolicitud,
                IdDj = idDj
            };
            context.DjSolicitudes.Add(djSolicitud);
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> AsignarBarraASolicitudAsync(int idSolicitud, int idBarra)
        {
            using var context = new AppDbContext();
            var barraSolicitud = new BarraSolicitud
            {
                IdSolicitud = idSolicitud,
                IdBarra = idBarra
            };
            context.BarraSolicitudes.Add(barraSolicitud);
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> AsignarGastronomicoASolicitudAsync(int idSolicitud, int idGastro)
        {
            using var context = new AppDbContext();
            var gastroSolicitud = new GastroSolicitud
            {
                IdSolicitud = idSolicitud,
                IdGastro = idGastro
            };
            context.GastroSolicitudes.Add(gastroSolicitud);
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<int> CrearConServiciosAsync(Solicitud solicitud, 
            List<int>? salonesSeleccionados, 
            List<int>? barrasSeleccionadas,
            List<int>? gastrosSeleccionados, 
            List<int>? djsSeleccionados)
        {
            using var context = new AppDbContext();
            using var transaction = await context.Database.BeginTransactionAsync();
            
            try
            {
                // Crear la solicitud
                context.Solicitudes.Add(solicitud);
                await context.SaveChangesAsync();
                
                // Asignar salones
                if (salonesSeleccionados != null)
                {
                    foreach (var idSalon in salonesSeleccionados)
                    {
                        context.SalonSolicitudes.Add(new SalonSolicitud
                        {
                            IdSolicitud = solicitud.IdSolicitud,
                            IdSalon = idSalon
                        });
                    }
                }
                
                // Asignar barras
                if (barrasSeleccionadas != null)
                {
                    foreach (var idBarra in barrasSeleccionadas)
                    {
                        context.BarraSolicitudes.Add(new BarraSolicitud
                        {
                            IdSolicitud = solicitud.IdSolicitud,
                            IdBarra = idBarra
                        });
                    }
                }
                
                // Asignar servicios gastronómicos
                if (gastrosSeleccionados != null)
                {
                    foreach (var idGastro in gastrosSeleccionados)
                    {
                        context.GastroSolicitudes.Add(new GastroSolicitud
                        {
                            IdSolicitud = solicitud.IdSolicitud,
                            IdGastro = idGastro
                        });
                    }
                }
                
                // Asignar DJs
                if (djsSeleccionados != null)
                {
                    foreach (var idDj in djsSeleccionados)
                    {
                        context.DjSolicitudes.Add(new DjSolicitud
                        {
                            IdSolicitud = solicitud.IdSolicitud,
                            IdDj = idDj
                        });
                    }
                }
                
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                
                return solicitud.IdSolicitud;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public static async Task<decimal> CalcularMontoTotalAsync(int idSolicitud)
        {
            using var context = new AppDbContext();
            
            // Obtener la solicitud with todas sus relaciones
            var solicitud = await context.Solicitudes
                .Include(s => s.SalonSolicitudes).ThenInclude(ss => ss.Salon)
                .Include(s => s.DjSolicitudes).ThenInclude(ds => ds.Dj)
                .Include(s => s.BarraSolicitudes).ThenInclude(bs => bs.Barra)
                .Include(s => s.GastroSolicitudes).ThenInclude(gs => gs.Gastronomico)
                .FirstOrDefaultAsync(s => s.IdSolicitud == idSolicitud);

            if (solicitud == null) return 0;

            decimal total = 0;
            
            // Sumar montos de salones
            total += solicitud.SalonSolicitudes.Sum(ss => ss.Salon.MontoSalon);
            
            // Sumar montos de DJs
            total += solicitud.DjSolicitudes.Sum(ds => ds.Dj.MontoDj);
            
            // Sumar montos de barras
            total += solicitud.BarraSolicitudes.Sum(bs => bs.Barra.PrecioPorHora);
            
            // Sumar montos de gastronómicos
            total += solicitud.GastroSolicitudes.Sum(gs => gs.Gastronomico.MontoG);

            return total;
        }
    }
}
