using Entidades;
using Datos;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Negocio
{
    public static class LogicaCliente
    {
        public static List<Cliente> Listar()
        {
            var lista = new List<Cliente>();
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand(@"SELECT IdCliente, Nombre, Apellido, Email, Telefono, NombreUsuario FROM Clientes", cn);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new Cliente
                {
                    IdCliente = rd.GetInt32(0),
                    Nombre = rd.GetString(1),
                    Apellido = rd.GetString(2),
                    Email = rd.GetString(3),
                    Telefono = rd.GetString(4),
                    NombreUsuario = rd.GetString(5)
                });
            }
            return lista;
        }

        public static int Crear(Cliente c)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand(@"INSERT INTO Clientes (Nombre, Apellido, Email, Telefono, NombreUsuario) 
VALUES (@Nombre, @Apellido, @Email, @Telefono, @NombreUsuario); SELECT SCOPE_IDENTITY();", cn);
            cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
            cmd.Parameters.AddWithValue("@NombreUsuario", c.NombreUsuario);
            cn.Open();
            var id = Convert.ToInt32(cmd.ExecuteScalar());
            c.IdCliente = id;
            return id;
        }

        public static Cliente? Obtener(int id)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand(@"SELECT IdCliente, Nombre, Apellido, Email, Telefono, NombreUsuario FROM Clientes WHERE IdCliente=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;
            return new Cliente
            {
                IdCliente = rd.GetInt32(0),
                Nombre = rd.GetString(1),
                Apellido = rd.GetString(2),
                Email = rd.GetString(3),
                Telefono = rd.GetString(4),
                NombreUsuario = rd.GetString(5)
            };
        }

        public static void Editar(Cliente c)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand(@"UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Telefono=@Telefono, NombreUsuario=@NombreUsuario WHERE IdCliente=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", c.IdCliente);
            cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
            cmd.Parameters.AddWithValue("@NombreUsuario", c.NombreUsuario);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Eliminar(int id)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand("DELETE FROM Clientes WHERE IdCliente=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void EnsureSchema()
        {
            // Crea la BD y la tabla si no existen
            using var master = new SqlConnection(ConnectionHelper.GetMasterConnectionString());
            master.Open();
            using (var cmdDb = new SqlCommand($"IF DB_ID('PoneLaFecha') IS NULL CREATE DATABASE PoneLaFecha;", master))
            {
                cmdDb.ExecuteNonQuery();
            }

            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            cn.Open();
            var sql = @"IF OBJECT_ID('dbo.Clientes','U') IS NULL
                        CREATE TABLE dbo.Clientes(
                            IdCliente INT IDENTITY(1,1) PRIMARY KEY,
                            Nombre NVARCHAR(100) NOT NULL,
                            Apellido NVARCHAR(100) NOT NULL,
                            Email NVARCHAR(200) NOT NULL,
                            Telefono NVARCHAR(50) NOT NULL,
                            NombreUsuario NVARCHAR(100) NOT NULL
                        );";
            using var cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
    }
}
