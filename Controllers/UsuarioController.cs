using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //TRAER USUARIOS
        [HttpGet(Name = "GetUsuarios")]
        public IActionResult Get(string nombreUsuario)
        {
            Usuario u = ADO_Usuario.DevolverUsuarios(nombreUsuario);

            if (u is null)
            {
                return BadRequest("El usuario no existe");
            }
            
            return Ok(u);
        }

        //CREAR USUARIOS
        [HttpPost]
        public IActionResult Crear([FromBody] Usuario usu)
        {
            ADO_Usuario.CrearUsuario(usu);
            return StatusCode(Convert.ToInt32(HttpStatusCode.Created));
        }

        //MODIFICAR USUARIOS
        [HttpPut]
        public void Actualizar([FromBody] Usuario usu)
        {
            ADO_Usuario.ModificarUsuario(usu);
        }

        //ELIMINAR USUARIOS
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Usuario.EliminarUsuario(id);
        }
    }
}