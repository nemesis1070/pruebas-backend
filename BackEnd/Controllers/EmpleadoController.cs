using BackEnd.BusinessLogic.Interfaces;
using BackEnd.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoBL _bL;
        protected APIResponse _response;

        public EmpleadoController(IEmpleadoBL bL)
        {
            _bL = bL;
            _response = new APIResponse();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            _response.DatosResultado = await _bL.GetAll();
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            _response.DatosResultado = await _bL.Get(id);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<APIResponse>> Post([FromBody] EmpleadoDTO modelo)
        {
            _response.DatosResultado = await _bL.Create(modelo);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public async Task<ActionResult<APIResponse>> Put([FromBody] EmpleadoDTO modelo)
        {
            _response.DatosResultado = await _bL.Update(modelo);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            _response.DatosResultado = await _bL.Delete(id);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
