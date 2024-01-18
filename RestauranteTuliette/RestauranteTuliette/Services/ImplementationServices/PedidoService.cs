using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;

namespace RestauranteTuliette.Services.ImplementationServices
{
    public class PedidoService : IPedidoService
    {
        private readonly RestauranteTulietteContext _context;

        public PedidoService(RestauranteTulietteContext context)
        {
            _context = context;
        }

        public async Task<bool> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
                return false;

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PedidoDTO>> ListaPedidos()
        {
            var resultado = await _context.Pedidos
                .Select(x => new PedidoDTO
                {
                    NombreCliente = x.NombreCliente,
                    TipodePago = x.TipodePago,
                    PrecioTotal = x.PrecioTotal,
                    IdUbicacion = x.IdUbicacion,
                    IdPlato = x.IdPlato,
                    IdBebida = x.IdBebida
                })
                .ToListAsync();
            return resultado;
        }

        public async Task<bool> UpdatePedido(PedidoDTO pedido, int id)
        {
            var existingPedido = await _context.Pedidos.FindAsync(id);
            if (existingPedido == null)
                return false;

            existingPedido.NombreCliente = pedido.NombreCliente;
            existingPedido.TipodePago = pedido.TipodePago;
            existingPedido.PrecioTotal = pedido.PrecioTotal;
            existingPedido.IdUbicacion = pedido.IdUbicacion;
            existingPedido.IdPlato = pedido.IdPlato;
            existingPedido.IdBebida = pedido.IdBebida;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PedidoDTO> ObtenerPedidoPorId(int id)
        {
            var pedido = await _context.Pedidos
                .Where(x => x.IdPedido == id)
                .Select(x => new PedidoDTO
                {
                    NombreCliente = x.NombreCliente,
                    TipodePago = x.TipodePago,
                    PrecioTotal = x.PrecioTotal,
                    IdUbicacion = x.IdUbicacion,
                    IdPlato = x.IdPlato,
                    IdBebida = x.IdBebida
                })
                .FirstOrDefaultAsync();

            return pedido;
        }
    }
}
