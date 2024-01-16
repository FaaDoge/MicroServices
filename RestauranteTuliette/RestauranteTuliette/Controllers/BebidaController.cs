using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {
        private readonly RestauranteTulietteContext _context;
        public BebidaController(RestauranteTulietteContext context)
        {
            _context = context;
        }
        // GET: api/<BebidumController>
        [HttpGet]
        public async Task<ActionResult<List<Bebidum>>> Get()
        {
            return await _context.Bebida.ToListAsync();
        }
        // GET api/<BebidumController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bebidum>> Get(int id)
        {
            return await _context.Bebida.FirstOrDefaultAsync(x => x.IdBebida == id);
        }

        // POST api/<BebidumController>
        [HttpPost]
        public async Task<ActionResult> Post(Bebidum Bebidum)
        {
            if (Bebidum != null)
            {
                _context.Bebida.Add(Bebidum);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest("Debe ingresar datos validos"); }
        }

        // PUT api/<BebidumController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Bebidum Bebidum)
        {
            Bebidum Modificar = await _context.Bebida.FirstOrDefaultAsync(x => x.IdBebida == id);
            if (Modificar != null)
            {
                Modificar.TipoBebida = Bebidum.TipoBebida;
                Modificar.Precio = Bebidum.Precio;
                Modificar.Descripcion = Bebidum.Descripcion;
                Modificar.IdIngrediente = Bebidum.IdIngrediente;

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<BebidumController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id/*,Bebidum Bebidum*/)
        {
            Bebidum BebidumEliminar = await _context.Bebida.FirstOrDefaultAsync(x => x.IdBebida == id);
            if (BebidumEliminar != null)
            {
                _context.Remove(BebidumEliminar);

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
