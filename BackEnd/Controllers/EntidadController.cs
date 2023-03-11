using BackEnd.BusinessLogic.Interfaces;
using BackEnd.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadController : ControllerBase
    {
        private readonly IEntidadBL _bL;
        protected APIResponse _response;

        public EntidadController(IEntidadBL bL)
        {
            _bL = bL;
            _response = new APIResponse();
        }

        // GET: api/<EntidadController>
       
        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            _response.DatosResultado = await _bL.GetAll();
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        // GET api/<EntidadController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            _response.DatosResultado = await _bL.Get(id);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        // POST api/<EntidadController>
        [HttpPost]
        public async Task<ActionResult<APIResponse>> Post([FromBody] EntidadDTO modelo)
        {
            _response.DatosResultado = await _bL.Create(modelo);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        // PUT api/<EntidadController>/5
        [HttpPut]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromBody] EntidadDTO modelo) {

            _response.DatosResultado = await _bL.Update(modelo);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        // DELETE api/<EntidadController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            _response.DatosResultado = await _bL.Delete(id);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
