using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //TRAER USUARIOS - CLASE 14
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> Get()
        {
            return ADO_Usuario.DevolverUsuarios();
        }

        [HttpPost]
        public void Crear([FromBody] Usuario usu)
        {
        }

        //MODIFICAR USUARIOS - DESAFÍO ENTREGABLE
        [HttpPut]
        public void Actualizar([FromBody] Usuario usu)
        {
            ADO_Usuario.ModificarUsuario(usu);
        }

        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
        }
    }
}
