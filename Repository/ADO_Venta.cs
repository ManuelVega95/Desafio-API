using System.Data;
using System.Data.SqlClient;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class ADO_Venta
    {

        //TRAER VENTAS
        public static List<DevolverVentas> DevolverVentas()
        {
            var listaVenta = new List<DevolverVentas>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("SELECT v.Id as VentaId, p.Id as ProductoId, p.Descripciones, p.PrecioVenta FROM Venta v inner join ProductoVendido pv on v.Id = pv.IdVenta inner join Producto p on pv.IdProducto = p.Id");
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var venta = new DevolverVentas();

                    venta.VentaId = Convert.ToInt32(reader.GetValue(0));
                    venta.ProductoId = Convert.ToInt32(reader.GetValue(1));
                    venta.Descripciones = reader.GetValue(2).ToString();
                    venta.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    listaVenta.Add(venta);
                }
                reader.Close();
                conn.Close();
            }
            return listaVenta;
        }

        //CARGAR VENTA

        public static void CargarVenta(CargarVenta productos, int IdUsuario)
        {
            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("SELECT NombreUsuario FROM Usuario WHERE Id = {0}", IdUsuario);

                var reader = cmd.ExecuteReader();

                string NombreUsuario = "";

                while (reader.Read())
                {
                    NombreUsuario = (string)reader.GetValue(0);
                }

                reader.Close();

                cmd.CommandText = String.Format("INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@ComentariosVen, @IdUsuario)");

                var paramComentarios = new SqlParameter();
                paramComentarios.ParameterName = "ComentariosVen";
                paramComentarios.SqlDbType = SqlDbType.VarChar;
                paramComentarios.Value = String.Format("Se cargó la venta para el Usuario {0}", NombreUsuario);

                var paramIdUsuario = new SqlParameter();
                paramIdUsuario.ParameterName = "IdUsuario";
                paramIdUsuario.SqlDbType = SqlDbType.BigInt;
                paramIdUsuario.Value = IdUsuario;

                cmd.Parameters.Add(paramComentarios);
                cmd.Parameters.Add(paramIdUsuario);
                cmd.ExecuteNonQuery();

                cmd.CommandText = String.Format("SELECT TOP 1 Id FROM Venta ORDER BY Id DESC");

                reader = cmd.ExecuteReader();

                int IdUltimaVenta = 0;

                while (reader.Read())
                {
                    IdUltimaVenta = Convert.ToInt32(reader.GetValue(0));
                }
                reader.Close();

                foreach (Producto p in productos.productos)
                {
                    cmd.CommandText = String.Format("INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES (@Stock, @IdProducto, @IdVenta)");

                    cmd.Parameters.AddWithValue("Stock", p.Stock);
                    cmd.Parameters.AddWithValue("IdProducto", p.Id);
                    cmd.Parameters.AddWithValue("IdVenta", IdUltimaVenta);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = String.Format("UPDATE Producto set stock = stock-{1} where id = {0}", p.Id, p.Stock);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                conn.Close();
            }
        }

        //ELIMINAR VENTA
        public static void EliminarVenta(EliminarVenta productos, int id)
        {
            var listaVenta = new List<Venta>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM Venta WHERE Id = {0}", id);
                var reader = cmd.ExecuteReader();

                int Id = 0;

                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader.GetValue(0));
                }

                reader.Close();

                cmd.CommandText = String.Format("SELECT TOP 1 Id FROM Venta ORDER BY Id DESC");

                reader = cmd.ExecuteReader();

                int IdUltimaVenta = 0;

                while (reader.Read())
                {
                    IdUltimaVenta = Convert.ToInt32(reader.GetValue(0));
                }
                reader.Close();

                foreach (Producto p in productos.productos)
                {
                    cmd.CommandText = String.Format("DELETE FROM ProductoVendido WHERE idVenta = {0}", IdUltimaVenta);

                    int idUltimaVenta = 0;

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = String.Format("UPDATE Producto set stock = stock+{1} where id = {0}", p.Id, p.Stock);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                }

                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = string.Format("DELETE FROM Venta WHERE Id = {0}", id);
                cmd2.ExecuteNonQuery();

                reader.Close();
                conn.Close();
            }
        }
    }
}