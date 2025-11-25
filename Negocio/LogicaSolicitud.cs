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

        public static Solicitud? Obtener(int id)
        {
            using var context = new AppDbContext();
            return context.Solicitudes
                .Include(s => s.Cliente)
                .FirstOrDefault(s => s.IdSolicitud == id);
        }

        public static void Crear(Solicitud solicitud)
        {
            using var context = new AppDbContext();
            context.Solicitudes.Add(solicitud);
            context.SaveChanges();
        }

        public static async Task<List<Solicitud>> GetByEstadoAsync(string estado)
        {
            using var context = new AppDbContext();
            return await context.Solicitudes
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
    }
}
