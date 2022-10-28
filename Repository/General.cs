using static DesafioAPI.Controllers.ProductoController;
using static DesafioAPI.Controllers.ProductoVendidoController;
using static DesafioAPI.Controllers.UsuarioController;
using static DesafioAPI.Controllers.VentaController;
using static DesafioAPI.Repository.ADO_Usuario;
using static DesafioAPI.Repository.ADO_Producto;
using static DesafioAPI.Repository.ADO_ProductoVendido;
using static DesafioAPI.Repository.ADO_Venta;
using System.Data.SqlClient;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class General
    {
        public static string connectionString()
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-AJ3GPNR";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;
            return (cs);
        }
    }
}