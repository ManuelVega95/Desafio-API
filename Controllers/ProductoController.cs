using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //TRAER PRODUCTOS - CLASE 14
        [HttpGet(Name = "GetProductos")]
        public List<Producto> Get()
        {
            return ADO_Producto.DevolverProductos();
        }

        //CREAR PRODUCTO - DESAFÍO ENTREGABLE
        [HttpPost]
        public void Crear([FromBody] Producto pro)
        {
            ADO_Producto.CrearProducto(pro);
        }

        //MODIFICAR PRODUCTO - DESAFÍO ENTREGABLE
        [HttpPut]
        public void Actualizar([FromBody] Producto pro)
        {
            ADO_Producto.ActualizarProducto(pro);
        }

        //ELIMINAR PRODUCTO - DESAFÍO ENTREGABLE
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }
    }
}
