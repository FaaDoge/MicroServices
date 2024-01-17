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
    public class UsuarioController : ControllerBase
    {
        private readonly RestauranteTulietteContext _context;

        public UsuarioController(RestauranteTulietteContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
            if (usuario != null)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("Debe ingresar datos válidos");
            }
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Usuario usuario)
        {
            Usuario usuarioModificar = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
            if (usuarioModificar != null)
            {
                usuarioModificar.Nombre = usuario.Nombre;
                usuarioModificar.Contrasena = usuario.Contrasena;
                usuarioModificar.Estado = usuario.Estado;
                usuarioModificar.IdRol = usuario.IdRol;

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Usuario usuarioEliminar = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
            if (usuarioEliminar != null)
            {
                _context.Remove(usuarioEliminar);
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
