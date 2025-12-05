using Entidades;
using Datos;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class LogicaUsuario
    {
        // Métodos para trabajar con la entidad Usuario
        public static List<Usuario> Listar()
        {
            using var context = new AppDbContext();
            return context.Usuarios.ToList();
        }

        public static Usuario? Autenticar(string username, string password)
        {
            using var context = new AppDbContext();
            return context.Usuarios.FirstOrDefault(u => 
                u.NombreUsuario == username && 
                u.Password == password && 
                u.Activo);
        }

        public static Usuario? ObtenerPorId(int id)
        {
            using var context = new AppDbContext();
            return context.Usuarios.Find(id);
        }

        public static Usuario? ObtenerPorNombreUsuario(string nombreUsuario)
        {
            using var context = new AppDbContext();
            return context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }

        public static void Crear(Usuario usuario)
        {
            using var context = new AppDbContext();
            
            // Verificar si ya existe un usuario con ese nombre
            var existente = context.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario.NombreUsuario);
            if (existente != null)
            {
                throw new InvalidOperationException("El nombre de usuario ya está en uso");
            }
            
            usuario.FechaCreacion = DateTime.Now;
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public static void Editar(Usuario usuario)
        {
            using var context = new AppDbContext();
            context.Usuarios.Update(usuario);
            context.SaveChanges();
        }

        public static void Eliminar(int id)
        {
            using var context = new AppDbContext();
            var usuario = context.Usuarios.Find(id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
            }
        }

        public static void CrearAdministradorDefault()
        {
            using var context = new AppDbContext();
            
            // Verificar si ya existe un administrador
            var adminExistente = context.Usuarios.FirstOrDefault(u => u.Rol == "Administrador");
            if (adminExistente != null) return;

            var admin = new Usuario
            {
                NombreUsuario = "chiqui123",
                Password = "elchiqui123",
                Rol = "Administrador",
                Nombre = "Administrador",
                Apellido = "Sistema",
                Email = "admin@ponelafecha.com",
                Telefono = "0000000000",
                FechaCreacion = DateTime.Now,
                Activo = true
            };

            context.Usuarios.Add(admin);
            context.SaveChanges();
        }

        public static void CrearUsuariosEjemplo()
        {
            using var context = new AppDbContext();
            
            if (!context.Usuarios.Any())
            {
                var usuarios = new List<Usuario>
                {
                    new Usuario
                    {
                        NombreUsuario = "chiqui123",
                        Password = "elchiqui123",
                        Rol = "Administrador",
                        Nombre = "Administrador",
                        Apellido = "Sistema",
                        Email = "admin@ponelafecha.com",
                        Telefono = "0000000000",
                        Activo = true
                    },
                    new Usuario
                    {
                        NombreUsuario = "cliente1",
                        Password = "cliente123",
                        Rol = "Cliente",
                        Nombre = "Juan",
                        Apellido = "Pérez",
                        Email = "juan.perez@email.com",
                        Telefono = "1234567890",
                        Activo = true
                    },
                    new Usuario
                    {
                        NombreUsuario = "cliente2",
                        Password = "cliente123",
                        Rol = "Cliente",
                        Nombre = "María",
                        Apellido = "González",
                        Email = "maria.gonzalez@email.com",
                        Telefono = "0987654321",
                        Activo = true
                    }
                };

                context.Usuarios.AddRange(usuarios);
                context.SaveChanges();
            }
        }

        // Métodos para trabajar con la entidad Cliente (compatibilidad)
        public static Cliente? LoginCliente(string username, string password)
        {
            using var context = new AppDbContext();
            var cliente = context.Clientes.FirstOrDefault(u => u.NombreUsuario == username);
            
            if (cliente != null && cliente.Clave == password)
            {
                return cliente;
            }
            return null;
        }

        public static Cliente? ObtenerClientePorNombreUsuario(string nombreUsuario)
        {
            using var context = new AppDbContext();
            return context.Clientes.FirstOrDefault(c => c.NombreUsuario == nombreUsuario);
        }

        public static void CrearCliente(Cliente cliente)
        {
             using var context = new AppDbContext();
             
             // Verificar si ya existe un usuario con ese nombre
             var existente = context.Clientes.FirstOrDefault(c => c.NombreUsuario == cliente.NombreUsuario);
             if (existente != null)
             {
                 throw new InvalidOperationException("El nombre de usuario ya está en uso");
             }
             
             context.Clientes.Add(cliente);
             context.SaveChanges();
        }
    }
}
