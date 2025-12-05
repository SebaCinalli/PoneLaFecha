using Datos;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class LogicaGastronomico
    {
        // Métodos para Gastronomico (Comida)
        public static List<Gastronomico> Listar()
        {
            using var context = new AppDbContext();
            return context.Gastronomicos.ToList();
        }

        public static List<Comida> ListarComidas()
        {
            using var context = new AppDbContext();
            // Asumiendo que Comida es un tipo de Gastronomico o mapeado
            // Si Comida no es una entidad en DB, esto podría requerir ajuste.
            // Por ahora asumo que Gastronomico es la entidad base y Comida es lo que se usa en UI
            // Pero el error decía 'Comida' no encontrado en API, así que usaré Gastronomico
            return context.Gastronomicos.Select(g => new Comida 
            { 
                IdServicio = g.IdGastro, 
                Nombre = g.Nombre,
                // Mapear otras propiedades si es necesario
            }).ToList();
        }
        
        // Ajuste: Si Comida es una clase en Entidades que hereda o es un DTO, necesito ver su definición.
        // Viendo los archivos en Entidades: Gastronomico.cs existe. Comida no la vi en la lista de archivos de Entidades en el paso 239.
        // Espera, el paso 239 NO mostró Comida.cs. Mostró Gastronomico.cs.
        // Pero el controlador GastronomicoController usaba Comida.
        // Ah, el error de compilación decía: "El nombre del tipo o del espacio de nombres 'Comida' no se encontró".
        // Entonces Comida NO existe en Entidades. Debo usar Gastronomico.
        
        public static Gastronomico? Obtener(int id)
        {
            using var context = new AppDbContext();
            return context.Gastronomicos.Find(id);
        }

        public static void Crear(Gastronomico comida)
        {
            using var context = new AppDbContext();
            context.Gastronomicos.Add(comida);
            context.SaveChanges();
        }

        public static void Editar(Gastronomico comida)
        {
            using var context = new AppDbContext();
            context.Gastronomicos.Update(comida);
            context.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var context = new AppDbContext();
            var comida = context.Gastronomicos.Find(id);
            if (comida != null)
            {
                context.Gastronomicos.Remove(comida);
                context.SaveChanges();
            }
        }

        // Métodos para Barra
        public static List<Barra> ListarBarras()
        {
            using var context = new AppDbContext();
            return context.Barras.ToList();
        }

        public static Barra? ObtenerBarra(int id)
        {
            using var context = new AppDbContext();
            return context.Barras.Find(id);
        }

        public static void CrearBarra(Barra barra)
        {
            using var context = new AppDbContext();
            context.Barras.Add(barra);
            context.SaveChanges();
        }

        public static void EditarBarra(Barra barra)
        {
            using var context = new AppDbContext();
            context.Barras.Update(barra);
            context.SaveChanges();
        }

        public static void EliminarBarra(int id)
        {
            using var context = new AppDbContext();
            var barra = context.Barras.Find(id);
            if (barra != null)
            {
                context.Barras.Remove(barra);
                context.SaveChanges();
            }
        }

        public static void CrearDatosEjemplo()
        {
            using var context = new AppDbContext();
            if (!context.Gastronomicos.Any())
            {
                context.Gastronomicos.Add(new Gastronomico 
                { 
                    Nombre = "Pizza Party",
                    TipoComida = "Pizzas",
                    MontoG = 5000,
                    Estado = "Disponible"
                });
                context.Gastronomicos.Add(new Gastronomico 
                { 
                    Nombre = "Catering Completo",
                    TipoComida = "Buffet",
                    MontoG = 8000,
                    Estado = "Disponible"
                });
                context.SaveChanges();
            }
            if (!context.Barras.Any())
            {
                context.Barras.Add(new Barra 
                { 
                    Nombre = "Barra Libre Premium",
                    TipoBebida = "Mixta",
                    Descripcion = "Barra con bebidas alcohólicas y sin alcohol",
                    PrecioPorHora = 3000,
                    Estado = "Disponible"
                });
                context.Barras.Add(new Barra 
                { 
                    Nombre = "Barra Sin Alcohol",
                    TipoBebida = "Sin Alcohol",
                    Descripcion = "Barra con jugos, gaseosas y tragos sin alcohol",
                    PrecioPorHora = 1500,
                    Estado = "Disponible"
                });
                context.SaveChanges();
            }
        }
    }
    
    // Helper class if Comida is needed for compatibility, but better to fix Controller to use Gastronomico
    public class Comida : Gastronomico 
    {
        public int IdServicio { get => IdGastro; set => IdGastro = value; }
    }
}
