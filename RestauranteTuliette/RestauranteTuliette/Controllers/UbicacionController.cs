using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteTuliette.Contexto;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Services.ImplementationServices;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        IUbicacionService _ubicacionService;

        public UbicacionController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UbicacionDTO>>> Get()
        {
            var ubicacions = await _ubicacionService.ListaUbicacion();
            return Ok(ubicacions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UbicacionDTO>> Get(int id)
        {
            var ubicacions = await _ubicacionService.ObtenerUbicacionPorId(id);
            if (ubicacions == null)
                return NotFound();

            return Ok(ubicacions);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ubicacion ubicacion)
        {
            var result = await _ubicacionService.InsertUbicacion(ubicacion);
            if (result)
                return Ok();
            else
                return BadRequest("Debe ingresar datos válidos");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UbicacionDTO ubicacion)
        {
            var result = await _ubicacionService.UpdateUbicacion(ubicacion, id);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _ubicacionService.DeleteUbicacion(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }

    }
}