using Entidades;
using Datos;
using Microsoft.Data.SqlClient;

namespace Negocio
{
    public static class LogicaSalon
    {
        public static List<Salon> Listar()
        {
            var lista = new List<Salon>();
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand("SELECT IdSalon, NombreSalon, Estado, MontoSalon FROM Salones", cn);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new Salon
                {
                    IdSalon = rd.GetInt32(0),
                    NombreSalon = rd.GetString(1),
                    Estado = rd.GetString(2),
                    MontoSalon = rd.GetDecimal(3)
                });
            }
            return lista;
        }

        public static int Crear(Salon s)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand(@"INSERT INTO Salones (NombreSalon, Estado, MontoSalon) 
VALUES (@NombreSalon, @Estado, @MontoSalon); SELECT SCOPE_IDENTITY();", cn);
            cmd.Parameters.AddWithValue("@NombreSalon", s.NombreSalon);
            cmd.Parameters.AddWithValue("@Estado", s.Estado);
            cmd.Parameters.AddWithValue("@MontoSalon", s.MontoSalon);
            cn.Open();
            var id = Convert.ToInt32(cmd.ExecuteScalar());
            s.IdSalon = id;
            return id;
        }

        public static Salon? Obtener(int id)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand("SELECT IdSalon, NombreSalon, Estado, MontoSalon FROM Salones WHERE IdSalon=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            using var rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;
            return new Salon
            {
                IdSalon = rd.GetInt32(0),
                NombreSalon = rd.GetString(1),
                Estado = rd.GetString(2),
                MontoSalon = rd.GetDecimal(3)
            };
        }

        public static void Editar(Salon s)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand(@"UPDATE Salones SET NombreSalon=@NombreSalon, Estado=@Estado, MontoSalon=@MontoSalon WHERE IdSalon=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", s.IdSalon);
            cmd.Parameters.AddWithValue("@NombreSalon", s.NombreSalon);
            cmd.Parameters.AddWithValue("@Estado", s.Estado);
            cmd.Parameters.AddWithValue("@MontoSalon", s.MontoSalon);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void Eliminar(int id)
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            using var cmd = new SqlCommand("DELETE FROM Salones WHERE IdSalon=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void EnsureSchema()
        {
            using var cn = new SqlConnection(ConnectionHelper.GetConnectionString());
            cn.Open();
            var sql = @"IF OBJECT_ID('dbo.Salones','U') IS NULL
                        CREATE TABLE dbo.Salones(
                            IdSalon INT IDENTITY(1,1) PRIMARY KEY,
                            NombreSalon NVARCHAR(150) NOT NULL,
                            Estado NVARCHAR(50) NOT NULL,
                            MontoSalon DECIMAL(18,2) NOT NULL
                        );";
            using var cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
    }
}
