using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IniciarSesionController : ControllerBase
    {
        //INICIAR SESIÓN
        [HttpGet(Name = "IniciarSesion")]
        public IActionResult IniciarSesion(string nombreUsuario, string contraseña)
        {
            using (SqlConnection conn = new SqlConnection(General.connectionString()))
            {
                Usuario usuario = ADO_IniciarSesion.IniciarSesion(nombreUsuario, contraseña, conn);
                if (usuario is null)
                {
                    return BadRequest("El usuario no existe");
                }
                return Ok(usuario);
            }
        }
    }
}

