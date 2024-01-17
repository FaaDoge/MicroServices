using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos;
using System.Text.RegularExpressions;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {
        private readonly RestauranteTulietteContext _context;
        public PlatoController(RestauranteTulietteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Plato>>> GetPlato()
        {
            return await _context.Platos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plato>> Get(int id)
        {
            return await _context.Platos.FirstOrDefaultAsync(x => x.IdPlato == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Plato plato)
        {
            if (plato != null)
            {
                _context.Platos.Add(plato);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("Debe ingresar datos validos"); }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Plato plato)
        {
            Plato modificar = await _context.Platos.FirstOrDefaultAsync(x => x.IdPlato == id);
            if (modificar != null)
            {
                modificar.TipoPlato = plato.TipoPlato;
                modificar.Precio = plato.Precio;

                await _context.SaveChangesAsync();
                return Ok();
            }
            else { return NotFound(); }
        }
        // DELETE api/<BebidumController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id/*,Bebidum Bebidum*/)
        {
            Plato Eliminar = await _context.Platos.FirstOrDefaultAsync(x => x.IdPlato == id);
            if (Eliminar != null)
            {
                _context.Remove(Eliminar);

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        //PlatoController terminado
    }
}
