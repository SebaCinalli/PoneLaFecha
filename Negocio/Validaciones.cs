using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Negocio
{
    public static class Validaciones
    {
public class ResultadoValidacion
   {
    public bool EsValido { get; set; }
    public List<string> Errores { get; set; } = new List<string>();

      public void AgregarError(string error)
      {
     EsValido = false;
        Errores.Add(error);
            }

     public string ObtenerMensajeErrores()
            {
  return string.Join("\n", Errores);
    }
        }

        // Validaciones para Usuario
   public static ResultadoValidacion ValidarUsuario(Entidades.Usuario usuario)
        {
     var resultado = new ResultadoValidacion { EsValido = true };

  if (string.IsNullOrWhiteSpace(usuario.NombreUsuario) || usuario.NombreUsuario.Length < 3)
  {
resultado.AgregarError("El nombre de usuario debe tener al menos 3 caracteres.");
       }

if (string.IsNullOrWhiteSpace(usuario.Password) || usuario.Password.Length < 6)
   {
       resultado.AgregarError("La contraseña debe tener al menos 6 caracteres.");
   }

  if (string.IsNullOrWhiteSpace(usuario.Nombre))
{
 resultado.AgregarError("El nombre es obligatorio.");
    }

      if (string.IsNullOrWhiteSpace(usuario.Apellido))
   {
  resultado.AgregarError("El apellido es obligatorio.");
     }

if (!string.IsNullOrEmpty(usuario.Email) && !EsEmailValido(usuario.Email))
     {
  resultado.AgregarError("El formato del email no es válido.");
 }

     if (usuario.Rol != "Administrador" && usuario.Rol != "Cliente")
       {
  resultado.AgregarError("El rol debe ser 'Administrador' o 'Cliente'.");
     }

return resultado;
 }

      // Validaciones para Cliente
        public static ResultadoValidacion ValidarCliente(Entidades.Cliente cliente)
 {
 var resultado = new ResultadoValidacion { EsValido = true };

   if (string.IsNullOrWhiteSpace(cliente.Nombre))
       {
  resultado.AgregarError("El nombre es obligatorio.");
        }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
     resultado.AgregarError("El apellido es obligatorio.");
  }

   if (string.IsNullOrWhiteSpace(cliente.Email))
   {
       resultado.AgregarError("El email es obligatorio.");
     }
   else if (!EsEmailValido(cliente.Email))
 {
  resultado.AgregarError("El formato del email no es válido.");
       }

  if (string.IsNullOrWhiteSpace(cliente.Telefono))
       {
resultado.AgregarError("El teléfono es obligatorio.");
            }

            return resultado;
        }

   // Validaciones para Solicitud
public static ResultadoValidacion ValidarSolicitud(Entidades.Solicitud solicitud)
     {
  var resultado = new ResultadoValidacion { EsValido = true };

 if (solicitud.IdCliente <= 0)
   {
resultado.AgregarError("Debe seleccionar un cliente válido.");
     }

   if (solicitud.FechaDesde < DateTime.Today)
   {
     resultado.AgregarError("La fecha del evento no puede ser anterior a hoy.");
     }

       if (solicitud.MontoDJ < 0 || solicitud.MontoSalon < 0 || 
       solicitud.MontoGastro < 0 || solicitud.MontoBarra < 0)
       {
   resultado.AgregarError("Los montos no pueden ser negativos.");
         }

     decimal montoTotal = solicitud.MontoDJ + solicitud.MontoSalon + 
solicitud.MontoGastro + solicitud.MontoBarra;
       
if (montoTotal == 0)
    {
       resultado.AgregarError("Debe haber al menos un servicio con monto mayor a cero.");
            }

       if (string.IsNullOrWhiteSpace(solicitud.Estado))
 {
  resultado.AgregarError("El estado es obligatorio.");
 }

         return resultado;
        }

     // Validaciones para Zona
        public static ResultadoValidacion ValidarZona(Entidades.Zona zona)
        {
var resultado = new ResultadoValidacion { EsValido = true };

if (string.IsNullOrWhiteSpace(zona.Nombre) || zona.Nombre.Length < 2)
   {
       resultado.AgregarError("El nombre de la zona debe tener al menos 2 caracteres.");
       }

  return resultado;
        }

   // Validaciones para Salón
   public static ResultadoValidacion ValidarSalon(Entidades.Salon salon)
     {
          var resultado = new ResultadoValidacion { EsValido = true };

   if (string.IsNullOrWhiteSpace(salon.NombreSalon))
       {
  resultado.AgregarError("El nombre del salón es obligatorio.");
   }

   if (salon.MontoSalon <= 0)
       {
  resultado.AgregarError("El monto del salón debe ser mayor a cero.");
        }

 return resultado;
 }

        // Validaciones para Barra
        public static ResultadoValidacion ValidarBarra(Entidades.Barra barra)
        {
            var resultado = new ResultadoValidacion { EsValido = true };

 if (string.IsNullOrWhiteSpace(barra.Nombre))
      {
     resultado.AgregarError("El nombre de la barra es obligatorio.");
  }

       if (barra.PrecioPorHora <= 0)
  {
 resultado.AgregarError("El precio por hora debe ser mayor a cero.");
     }

       return resultado;
        }

        // Validaciones para DJ
   public static ResultadoValidacion ValidarDj(Entidades.Dj dj)
 {
   var resultado = new ResultadoValidacion { EsValido = true };

       if (string.IsNullOrWhiteSpace(dj.NombreArtistico) || dj.NombreArtistico.Length < 2)
            {
 resultado.AgregarError("El nombre artístico debe tener al menos 2 caracteres.");
  }

       if (dj.MontoDj <= 0)
            {
resultado.AgregarError("El monto del DJ debe ser mayor a cero.");
  }

return resultado;
        }

     // Validaciones para Gastronómico
   public static ResultadoValidacion ValidarGastronomico(Entidades.Gastronomico gastro)
      {
var resultado = new ResultadoValidacion { EsValido = true };

   if (string.IsNullOrWhiteSpace(gastro.Nombre))
       {
resultado.AgregarError("El nombre es obligatorio.");
   }

     if (string.IsNullOrWhiteSpace(gastro.TipoComida))
{
       resultado.AgregarError("El tipo de comida es obligatorio.");
  }

    if (gastro.MontoG <= 0)
       {
  resultado.AgregarError("El monto debe ser mayor a cero.");
   }

     return resultado;
     }

   // Métodos auxiliares
        private static bool EsEmailValido(string email)
 {
    if (string.IsNullOrWhiteSpace(email))
   return false;

try
    {
         var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
  return regex.IsMatch(email);
          }
    catch
   {
return false;
            }
        }

        public static bool EsTelefonoValido(string telefono)
        {
  if (string.IsNullOrWhiteSpace(telefono))
      return false;

// Aceptar números con o sin guiones, paréntesis, espacios
       var regex = new Regex(@"^[\d\s\-\(\)]+$");
            return regex.IsMatch(telefono) && telefono.Length >= 7;
        }

public static bool EsMontoValido(decimal monto)
        {
      return monto >= 0 && monto <= 999999;
        }

 public static bool EsFechaValida(DateTime fecha)
        {
            return fecha >= DateTime.Today && fecha <= DateTime.Today.AddYears(2);
        }
}
}
