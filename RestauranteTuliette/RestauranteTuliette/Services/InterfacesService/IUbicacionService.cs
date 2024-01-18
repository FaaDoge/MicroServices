using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;

namespace RestauranteTuliette.Services.InterfacesService
{
    public interface IUbicacionService
    {
        Task<bool> InsertUbicacion(Ubicacion ubicacion);
        Task<bool> UpdateUbicacion(UbicacionDTO ubicacion, int id);
        Task<bool> DeleteUbicacion(int id);
        Task<List<UbicacionDTO>> ListaUbicacion();
        Task<UbicacionDTO> ObtenerUbicacionPorId(int id);
    }
}
