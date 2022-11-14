using System.Data;
using System.Data.SqlClient;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class ADO_ProductoVendido
    {
        //TRAER PRODUCTOS VENDIDOS
        public static List<Producto> DevolverProductoVendido(int idUsuario)
        {
            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                conn.Open();
                List<Producto> productos = new List<Producto>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT p.Id, p.Descripciones,p.Costo,p.PrecioVenta, p.Stock,p.IdUsuario FROM ProductoVendido pv inner join Producto p on pv.IdProducto = p.Id inner join usuario u on p.idusuario = u.id where u.id = {0} order by id", idUsuario);
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
                        productos.Add(producto);
                    }
                }
                reader.Close();
                return productos;
            }
        }
    }
}