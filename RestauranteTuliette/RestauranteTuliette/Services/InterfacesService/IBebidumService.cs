using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos;
using RestauranteTuliette.Modelos.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using APITiendaBDDic.Modelos.DTO;

namespace RestauranteTuliette.Services.InterfacesService
{
    public interface IBebidumService
    {
        Task<bool> InsertBebida(Bebidum bebida);
        Task<bool> UpdateBebida(BebidumDTO bebida, int id);
        Task<bool> DeleteBebida(int id);
        Task<List<BebidumDTO>> ListaBebidas();
        Task<BebidumDTO> ObtenerBebidaPorId(int id);
    }
}
