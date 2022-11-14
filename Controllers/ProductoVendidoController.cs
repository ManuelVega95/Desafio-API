using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        //TRAER PRODUCTOS VENDIDOS
        [HttpGet(Name = "GetProductosVendidos")]
        public List<Producto> DevolverProductoVendido(int idUsuario)
        {
            return ADO_ProductoVendido.DevolverProductoVendido(idUsuario);
        }
    }
}
