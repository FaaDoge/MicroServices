using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;

namespace RestauranteTuliette.Services.InterfacesService
{
    public interface IPlatoService
    {
        Task<bool> InsertPlato(Plato plato);
        Task<bool> UpdatePlato(PlatoDTO plato, int id);
        Task<bool> DeletePlato(int id);
        Task<List<PlatoDTO>> ListaPlatos();
        Task<PlatoDTO> ObtenerPlatoPorId(int id);
    }
}
