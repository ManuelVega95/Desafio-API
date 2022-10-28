using System.Data;
using System.Data.SqlClient;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class ADO_ProductoVendido
    {
        public static string cs;

        public static List<ProductoVendido> DevolverProductosVendidos()
        {
            var listaProductoVendido = new List<ProductoVendido>();
           

            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM ProductoVendido";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var productoVendido = new ProductoVendido();

                    productoVendido.Id = Convert.ToInt32(reader.GetValue(0));
                    productoVendido.IdProducto = Convert.ToInt32(reader.GetValue(1));
                    productoVendido.Stock = Convert.ToInt32(reader.GetValue(2));
                    productoVendido.IdVenta = Convert.ToInt32(reader.GetValue(3));

                    listaProductoVendido.Add(productoVendido);
                }
                reader.Close();
                conn.Close();
            }
            return listaProductoVendido;
        }
    }
}