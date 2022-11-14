using System.Data;
using System.Data.SqlClient;
using DesafioAPI.Model;
using Microsoft.Extensions.Hosting;

namespace DesafioAPI.Repository
{
    public class ADO_Producto
    {
        //TRAER PRODUCTOS
        public static List<Producto> DevolverProductos()
        {
            var listaProducto = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Producto";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var producto = new Producto();

                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripciones = reader.GetValue(1).ToString();
                    producto.Costo = Convert.ToDouble(reader.GetValue(2));
                    producto.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProducto.Add(producto);
                }
                reader.Close();
                conn.Close();
            }
            return listaProducto;
        }

        //CREAR PRODUCTO
        public static void CrearProducto(Producto pro)
        {
            var listaProducto = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" + "VALUES (@DescripcionesPro, @CostoPro, @PrecioVentaPro, @StockPro, @IdUsuarioPro)", pro.Id, pro.Descripciones, pro.Costo, pro.PrecioVenta, pro.Stock, pro.IdUsuario);

                var paramId = new SqlParameter();
                paramId.ParameterName = "IdPro";
                paramId.SqlDbType = SqlDbType.BigInt;
                paramId.Value = pro.Id;

                var paramDescripciones = new SqlParameter();
                paramDescripciones.ParameterName = "DescripcionesPro";
                paramDescripciones.SqlDbType = SqlDbType.VarChar;
                paramDescripciones.Value = pro.Descripciones;

                var paramCosto = new SqlParameter();
                paramCosto.ParameterName = "CostoPro";
                paramCosto.SqlDbType = SqlDbType.Money;
                paramCosto.Value = pro.Costo;

                var paramPrecioVenta = new SqlParameter();
                paramPrecioVenta.ParameterName = "PrecioVentaPro";
                paramPrecioVenta.SqlDbType = SqlDbType.Money;
                paramPrecioVenta.Value = pro.PrecioVenta;

                var paramStock = new SqlParameter();
                paramStock.ParameterName = "StockPro";
                paramStock.SqlDbType = SqlDbType.Int;
                paramStock.Value = pro.Stock;

                var paramIdUsuario = new SqlParameter();
                paramIdUsuario.ParameterName = "IdUsuarioPro";
                paramIdUsuario.SqlDbType = SqlDbType.BigInt;
                paramIdUsuario.Value = pro.IdUsuario;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramDescripciones);
                cmd.Parameters.Add(paramCosto);
                cmd.Parameters.Add(paramPrecioVenta);
                cmd.Parameters.Add(paramStock);
                cmd.Parameters.Add(paramIdUsuario);

                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = Convert.ToInt32(reader.GetValue(0));
                        producto.Descripciones = reader.GetValue(1).ToString();
                        producto.Costo = Convert.ToDouble(reader.GetValue(2));
                        producto.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                        producto.Stock = Convert.ToInt32(reader.GetValue(4));
                        producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                    }
                    reader.Close();
                    conn.Close();
                }
            }
        }

        //MODIFICAR PRODUCTO
        public static void ActualizarProducto(Producto pro)
        {
            var listaProducto = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("UPDATE Producto SET  Descripciones = '{1}', Costo = {2}, PrecioVenta = {3}, Stock = {4}, IdUsuario = {5} WHERE Id = {0}", pro.Id, pro.Descripciones, pro.Costo, pro.PrecioVenta, pro.Stock, pro.IdUsuario);

                var paramId = new SqlParameter();
                paramId.ParameterName = "Id";
                paramId.SqlDbType = SqlDbType.BigInt;
                paramId.Value = pro.Id;

                var paramDescripciones = new SqlParameter();
                paramDescripciones.ParameterName = "Descripciones";
                paramDescripciones.SqlDbType = SqlDbType.VarChar;
                paramDescripciones.Value = pro.Descripciones;

                var paramCosto = new SqlParameter();
                paramCosto.ParameterName = "Costo";
                paramCosto.SqlDbType = SqlDbType.Money;
                paramCosto.Value = pro.Costo;

                var paramPrecioVenta = new SqlParameter();
                paramPrecioVenta.ParameterName = "PrecioVenta";
                paramPrecioVenta.SqlDbType = SqlDbType.Money;
                paramPrecioVenta.Value = pro.PrecioVenta;

                var paramStock = new SqlParameter();
                paramStock.ParameterName = "Stock";
                paramStock.SqlDbType = SqlDbType.Int;
                paramStock.Value = pro.Stock;

                var paramIdUsuario = new SqlParameter();
                paramIdUsuario.ParameterName = "IdUsuario";
                paramIdUsuario.SqlDbType = SqlDbType.BigInt;
                paramIdUsuario.Value = pro.IdUsuario;

                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramDescripciones);
                cmd.Parameters.Add(paramCosto);
                cmd.Parameters.Add(paramPrecioVenta);
                cmd.Parameters.Add(paramStock);
                cmd.Parameters.Add(paramIdUsuario);

                cmd.ExecuteNonQuery();


                conn.Close();

            }
        }

        //ELIMINAR PRODUCTO
        public static void EliminarProducto(int id)
        {
            var listaProducto = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("DELETE FROM ProductoVendido WHERE IdProducto = {0}", id);
                cmd.ExecuteNonQuery();


                cmd.CommandText = string.Format("DELETE FROM Producto WHERE Id = {0}", id);
                cmd.ExecuteNonQuery();


                conn.Close();
                
            }
        }
    }
}