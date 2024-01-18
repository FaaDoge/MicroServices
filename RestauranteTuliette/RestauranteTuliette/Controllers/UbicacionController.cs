using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteTuliette.Contexto;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Modelos.Entity;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly RestauranteTulietteContext _context;

        public UbicacionController(RestauranteTulietteContext context)
        {
            _context = context;
        }

        // GET: api/Rol
        [HttpGet]
        public async Task<ActionResult<List<Ubicacion>>> Get()
        {
            return await _context.Ubicacions.ToListAsync();
        }

        // GET: api/Rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> Get(int id)
        {
            return await _context.Ubicacions.FirstOrDefaultAsync(x => x.IdUbicacion == id);
        }

        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult> Post(Ubicacion Ubicacions)
        {
            if (Ubicacions != null)
            {
                _context.Ubicacions.Add(Ubicacions);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Debe ingresar datos válidos");
            }
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Ubicacion ubicacion)
        {
            Ubicacion Modificar = await _context.Ubicacions.FirstOrDefaultAsync(x => x.IdUbicacion == id);
            if (Modificar != null)
            {
                Modificar.Tipo = ubicacion.Tipo;
                Modificar.NroMesa = ubicacion.NroMesa;

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Rol/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Ubicacion Eliminar = await _context.Ubicacions.FirstOrDefaultAsync(x => x.IdUbicacion == id);
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
    }
}