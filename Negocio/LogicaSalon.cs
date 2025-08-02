using Entidades;

namespace Negocio
{
    public static class LogicaSalon
    {
        private static List<Salon> salones = new();
        private static int proximoId = 1;

        public static List<Salon> Listar() => salones;

        public static void Crear(Salon s)
        {
            s.IdSalon = proximoId++;
            salones.Add(s);
        }

        public static Salon Obtener(int id) =>
            salones.FirstOrDefault(s => s.IdSalon == id);

        public static void Editar(Salon s)
        {
            var existente = Obtener(s.IdSalon);
            if (existente != null)
            {
                existente.NombreSalon = s.NombreSalon;
                existente.Estado = s.Estado;
                existente.MontoSalon = s.MontoSalon;
            }
        }

        public static void Eliminar(int id)
        {
            var salon = Obtener(id);
            if (salon != null) salones.Remove(salon);
        }
    }
}
