using RestauranteTuliette.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using RestauranteTuliette.Modelos;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {
        private readonly IBebidumService _bebidumService;

        public BebidaController(IBebidumService bebidumService)
        {
            _bebidumService = bebidumService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bebidum>>> Get()
        {
            var bebidas = await _bebidumService.ListaBebidas();
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bebidum>> Get(int id)
        {
            var bebida = await _bebidumService.ObtenerBebidaPorId(id);
            if (bebida == null)
                return NotFound();

            return Ok(bebida);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Bebidum bebida)
        {
            var result = await _bebidumService.InsertBebida(bebida);
            if (result)
                return Ok();
            else
                return BadRequest("Debe ingresar datos válidos");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, BebidumDTO bebida)
        {
            var result = await _bebidumService.UpdateBebida(bebida, id);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _bebidumService.DeleteBebida(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
