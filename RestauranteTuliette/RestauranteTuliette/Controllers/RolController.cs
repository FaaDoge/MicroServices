using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RestauranteTulietteContext _context;

        public RolController(RestauranteTulietteContext context)
        {
            _context = context;
        }

        // GET: api/Rol
        [HttpGet]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            return await _context.Rols.ToListAsync();
        }

        // GET: api/Rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> Get(int id)
        {
            return await _context.Rols.FirstOrDefaultAsync(x => x.IdRol == id);
        }

        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult> Post(Rol rol)
        {
            if (rol != null)
            {
                _context.Rols.Add(rol);
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
        public async Task<ActionResult> Put(int id, Rol rol)
        {
            Rol rolModificar = await _context.Rols.FirstOrDefaultAsync(x => x.IdRol == id);
            if (rolModificar != null)
            {
                rolModificar.Nombre = rol.Nombre;
                rolModificar.Estado = rol.Estado;

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
            Rol rolEliminar = await _context.Rols.FirstOrDefaultAsync(x => x.IdRol == id);
            if (rolEliminar != null)
            {
                _context.Remove(rolEliminar);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        //Rolcontroller terminado
    }
}