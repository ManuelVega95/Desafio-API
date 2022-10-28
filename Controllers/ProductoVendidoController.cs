using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        //TRAER PRODUCTOS VENDIDOS - CLASE 14
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> Get()
        {
            return ADO_ProductoVendido.DevolverProductosVendidos();
        }

        [HttpPost]
        public void Crear([FromBody] ProductoVendido pv)
        {
        }

        [HttpPut]
        public void Actualizar([FromBody] ProductoVendido pv)
        {
        }

        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
        }
    }
}
