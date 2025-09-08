using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    internal class Logica
    {
    }

    public static class LogicaBarra
    {
        private static List<Barra> barras = new();
        private static int proximoId = 1;

        public static List<Barra> Listar() => barras;

        public static void Crear(Barra b)
        {
            b.IdBarra = proximoId++;
            barras.Add(b);
        }

        public static Barra? Obtener(int id) =>
            barras.FirstOrDefault(b => b.IdBarra == id);

        public static void Editar(Barra b)
        {
            var existente = Obtener(b.IdBarra);
            if (existente != null)
            {
                existente.Nombre = b.Nombre;
                existente.TipoBebida = b.TipoBebida;
                existente.PrecioPorHora = b.PrecioPorHora;
                existente.Estado = b.Estado;
                existente.Descripcion = b.Descripcion;
            }
        }

        public static void Eliminar(int id)
        {
            var barra = Obtener(id);
            if (barra != null) barras.Remove(barra);
        }
    }
}
