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
        //TRAER VENTAS - CLASE 14
        [HttpGet(Name = "GetVentas")]
        public List<Venta> Get()
        {
            return ADO_Venta.DevolverVentas();
        }

        //CARGAR VENTA - DESAFÍO ENTREGABLE
        [HttpPost]
        public void CargarVenta([FromBody] CargarVenta productos, int IdUsuario)
        {
            ADO_Venta.CargarVenta(productos, IdUsuario);
        }

        [HttpPut]
        public void Actualizar([FromBody] Venta ven)
        {
        }

        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
        }
    }
}

