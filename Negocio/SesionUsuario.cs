using Entidades;

namespace Negocio
{
    public static class SesionUsuario
    {
        private static Usuario? _usuarioActual;

        public static Usuario? UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        public static bool EstaLogueado => _usuarioActual != null;

        public static bool EsAdministrador => _usuarioActual != null && _usuarioActual.Rol == "Administrador";

        public static bool EsCliente => _usuarioActual != null && _usuarioActual.Rol == "Cliente";

        public static void CerrarSesion()
        {
            _usuarioActual = null;
        }

        public static string NombreCompleto => _usuarioActual != null ? 
            $"{_usuarioActual.Nombre} {_usuarioActual.Apellido}" : string.Empty;
    }
}