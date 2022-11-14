using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //TRAER PRODUCTOS
        [HttpGet(Name = "GetProductos")]
        public IActionResult Get()
        {
            List<Producto> productos = ADO_Producto.DevolverProductos();
            if (productos.Count>0)
            {
                return Ok(productos);
            }
            return NoContent();
        }

        //CREAR PRODUCTO
        [HttpPost]
        public IActionResult Crear([FromBody] Producto pro)
        {
            ADO_Producto.CrearProducto(pro);
            return StatusCode(Convert.ToInt32(HttpStatusCode.Created));
        }

        //MODIFICAR PRODUCTO
        [HttpPut]
        public void Actualizar([FromBody] Producto pro)
        {
            ADO_Producto.ActualizarProducto(pro);
        }

        //ELIMINAR PRODUCTO
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }
    }
}
