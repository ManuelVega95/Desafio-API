using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombreController : ControllerBase
    {
        //TRAER NOMBRE
        [HttpGet(Name = "GetNombre")]
        public NombreApp Get()
        {
            return ADO_NombreApp.DevolverNombre();
        }
    }
}

