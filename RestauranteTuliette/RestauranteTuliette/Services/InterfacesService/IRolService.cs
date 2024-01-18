using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;

namespace RestauranteTuliette.Services.InterfacesService
{
    public interface IRolService
    {
        Task<bool> InsertRol(Rol rol);
        Task<bool> UpdateRol(RolDTO rol, int id);
        Task<bool> DeleteRol(int id);
        Task<List<RolDTO>> ListaRol();
        Task<RolDTO> ObtenerRolPorId(int id);
    }
}
