using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.DTO;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly RestauranteTulietteContext _context;

        public PedidoController(RestauranteTulietteContext context)
        {
            _context = context;
        }

        // GET: api/Rol
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == id);
        }

        [HttpGet("PedidoPlato")]
        public async Task<ActionResult<List<PedidoPlatoDTO>>> ListaPedidoPlato()
        {
            return await _context.Pedidos.Select(x => new PedidoPlatoDTO
            {
                IdPedido = x.IdPedido,
                NombreCliente = x.NombreCliente,
                TipodePago = x.TipodePago,
                PrecioTotal = x.PrecioTotal,
                nroMesa = x.IdUbicacionNavigation.NroMesa,
                Descripcion = x.IdPlatoNavigation.Descripcion,
            }).ToListAsync();
        }

        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult> Post(Pedido pedidos)
        {
            if (pedidos != null)
            {
                _context.Pedidos.Add(pedidos);
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
        public async Task<ActionResult> Put(int id, Pedido pedido)
        {
            Pedido Modificar = await _context.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == id);
            if (Modificar != null)
            {
                Modificar.NombreCliente = pedido.NombreCliente;
                Modificar.TipodePago = pedido.TipodePago;
                Modificar.PrecioTotal = pedido.PrecioTotal;
                Modificar.IdUbicacion = pedido.IdUbicacion;

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
            Pedido Eliminar = await _context.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == id);
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
