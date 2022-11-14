using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        //TRAER VENTAS
        [HttpGet(Name = "GetVentas")]
        public List<DevolverVentas> Get()
        {
            return ADO_Venta.DevolverVentas();
        }

        //CARGAR VENTA
        [HttpPost]
        public void CargarVenta([FromBody] CargarVenta productos, int IdUsuario)
        {
            ADO_Venta.CargarVenta(productos, IdUsuario);
        }

        //ELIMINAR VENTA
        [HttpDelete]
        public void Eliminar([FromBody] EliminarVenta productos, int id)
        {
            ADO_Venta.EliminarVenta(productos, id);
        }
    }
}

