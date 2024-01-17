using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.DTO;

namespace RestauranteTuliette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportPumaController : ControllerBase
    {
        private readonly RestauranteTulietteContext _context;
        public ReportPumaController(RestauranteTulietteContext context)
        {
            _context = context;
        }
        //Listar los 3 pedidos de comida mas caros
        [HttpGet("ReportPuma")]
        public async Task<ActionResult<List<dtoReportPuma>>> Productosmenosvendidos()
        {
            var resultado = await _context.Pedidos
                .Where(x => x.IdBebida == null)
                .Select(g => new dtoReportPuma
                {
                    IdPedido = g.IdPedido,
                    NombreCliente = g.NombreCliente,
                    TipodePago = g.TipodePago,
                    PrecioTotal = g.PrecioTotal,
                    DescripcionPlato = g.IdPlatoNavigation.Descripcion,
                    Ubicacion = g.IdUbicacionNavigation.Tipo +" "+ g.IdUbicacionNavigation.NroMesa
                })
                .OrderBy(p => p.PrecioTotal)
                .Take(3)
                .ToListAsync();

            return resultado;
        }
    }
}
