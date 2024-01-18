using Microsoft.AspNetCore.Mvc;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;
using RestauranteTuliette.Modelos.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredienteDTO>>> Get()
        {
            var ingredientes = await _ingredienteService.ListaIngredientes();
            return Ok(ingredientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredienteDTO>> Get(int id)
        {
            var ingrediente = await _ingredienteService.ObtenerIngredientePorId(id);
            if (ingrediente == null)
                return NotFound();

            return Ok(ingrediente);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ingrediente ingrediente)
        {
            var result = await _ingredienteService.InsertIngrediente(ingrediente);
            if (result)
                return Ok();
            else
                return BadRequest("Debe ingresar datos válidos");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, IngredienteDTO ingrediente)
        {
            var result = await _ingredienteService.UpdateIngrediente(ingrediente, id);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _ingredienteService.DeleteIngrediente(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
