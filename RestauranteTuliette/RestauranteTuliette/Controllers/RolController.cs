using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.ImplementationServices;
using RestauranteTuliette.Services.InterfacesService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RolDTO>>> Get()
        {
            var rols = await _rolService.ListaRol();
            return Ok(rols);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDTO>> Get(int id)
        {
            var rols = await _rolService.ObtenerRolPorId(id);
            if (rols == null)
                return NotFound();

            return Ok(rols);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Rol rol)
        {
            var result = await _rolService.InsertRol(rol);
            if (result)
                return Ok();
            else
                return BadRequest("Debe ingresar datos válidos");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, RolDTO rol)
        {
            var result = await _rolService.UpdateRol(rol, id);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _rolService.DeleteRol(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
        //Rolcontroller terminado
    }
}