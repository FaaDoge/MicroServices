using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos;
using RestauranteTuliette.Modelos.Entity;

namespace RestauranteTuliette.Services.InterfacesService
{
    public interface IPedidoService
    {
        Task<bool> InsertPedido(Pedido pedido);
        Task<bool> UpdatePedido(PedidoDTO pedido, int id);
        Task<bool> DeletePedido(int id);
        Task<List<PedidoDTO>> ListaPedidos();
        Task<PedidoDTO> ObtenerPedidoPorId(int id);
    }
}
