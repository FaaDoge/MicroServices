using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioService _Service;
        public UsuarioController(IUsuarioService Service)
        {
            _Service = Service;
        }
        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var result = await _Service.ListaUsuarios();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var result = await _Service.ListarUsuarioID(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
            var result = await _Service.CrearUsuario(usuario);
            if (result)
                return Ok();
            else
                return BadRequest("Debe ingresar datos válidos");
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Usuario usuario)
        {
            var result = await _Service.EditarUsuario(id,usuario);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _Service.BorrarUsuario(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
        //Usuario controller terminado


        [HttpGet("ListarUsuariosAM")]
        public async Task<ActionResult<List<DTOUsuariosReporte>>> ListarUsuariosAM()
        {
            var resultado = await _Service.ListarUsuariosAM();
            return resultado;
        }
    }
}
