using BackEnd.BusinessLogic.Interfaces;
using BackEnd.DTO;
using BackEnd.Utilidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBL _bL;
        protected APIResponse _response;
        public UsuarioController(IUsuarioBL bL)
        {
            _bL = bL;
            _response = new APIResponse() ;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult<APIResponse>> Post([FromBody] LoginDTO modelo)
        {
            _response.StatusCode = HttpStatusCode.OK;
            _response.DatosResultado = await _bL.InicioSesion(modelo);
            return Ok(_response);
        }
    }
}
