using Entidades;
using Datos;
using System.Security.Cryptography;
using System.Text;

namespace Negocio
{
    public static class LogicaUsuario
    {
        public static List<Usuario> Listar()
        {
            using var db = new AppDbContext();
            return db.Usuarios.Where(u => u.Activo).ToList();
        }

        public static int Crear(Usuario usuario)
        {
            using var db = new AppDbContext();
            // Encriptar password antes de guardar
            usuario.Password = EncriptarPassword(usuario.Password);
            db.Usuarios.Add(usuario);
            db.SaveChanges();
            return usuario.IdUsuario;
        }

        public static Usuario? Obtener(int id)
        {
            using var db = new AppDbContext();
            return db.Usuarios.Find(id);
        }

        public static Usuario? ObtenerPorNombreUsuario(string nombreUsuario)
        {
            using var db = new AppDbContext();
            return db.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Activo);
        }

        public static void Editar(Usuario usuario)
        {
            using var db = new AppDbContext();
            var usuarioExistente = db.Usuarios.Find(usuario.IdUsuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Apellido = usuario.Apellido;
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Telefono = usuario.Telefono;
                usuarioExistente.Rol = usuario.Rol;
                usuarioExistente.Activo = usuario.Activo;
                
                // Solo actualizar password si se proporcionó uno nuevo
                if (!string.IsNullOrWhiteSpace(usuario.Password))
                {
                    usuarioExistente.Password = EncriptarPassword(usuario.Password);
                }
                
                db.SaveChanges();
            }
        }

        public static void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var usuario = db.Usuarios.Find(id);
            if (usuario != null)
            {
                // Eliminación lógica
                usuario.Activo = false;
                db.SaveChanges();
            }
        }

        public static Usuario? Autenticar(string nombreUsuario, string password)
        {
            using var db = new AppDbContext();
            var usuario = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Activo);
            
            if (usuario != null && VerificarPassword(password, usuario.Password))
            {
                return usuario;
            }
            
            return null;
        }

        public static void CrearAdministradorDefault()
        {
            using var db = new AppDbContext();
            
            // Verificar si ya existe el administrador específico
            var adminExistente = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == "chiqui123");
            
            if (adminExistente == null)
            {
                var admin = new Usuario
                {
                    NombreUsuario = "chiqui123",
                    Password = EncriptarPassword("elchiqui123"),
                    Rol = "Administrador",
                    Nombre = "Chiqui",
                    Apellido = "Tapia",
                    Email = "chiquitapia@gmail.com",
                    FechaCreacion = DateTime.Now,
                    Activo = true
                };
                
                db.Usuarios.Add(admin);
                db.SaveChanges();
            }
        }

        public static void CrearUsuariosEjemplo()
        {
            using var db = new AppDbContext();
            
            // Crear algunos usuarios cliente de ejemplo si no existen
            if (!db.Usuarios.Any(u => u.Rol == "Cliente"))
            {
                var clientes = new List<Usuario>
                {
                    new Usuario
                    {
                        NombreUsuario = "cliente1",
                        Password = EncriptarPassword("123456"),
                        Rol = "Cliente",
                        Nombre = "Juan",
                        Apellido = "Pérez",
                        Email = "juan.perez@email.com",
                        Telefono = "1234567890",
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    },
                    new Usuario
                    {
                        NombreUsuario = "cliente2",
                        Password = EncriptarPassword("123456"),
                        Rol = "Cliente",
                        Nombre = "María",
                        Apellido = "González",
                        Email = "maria.gonzalez@email.com",
                        Telefono = "0987654321",
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    }
                };

                db.Usuarios.AddRange(clientes);
                db.SaveChanges();
            }
        }
        
        private static string EncriptarPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                
                return builder.ToString();
            }
        }

        private static bool VerificarPassword(string password, string hash)
        {
            string hashPassword = EncriptarPassword(password);
            return string.Equals(hashPassword, hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}