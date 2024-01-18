using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteTuliette.Services.InterfacesService
{
    public interface IIngredienteService
    {
        Task<bool> InsertIngrediente(Ingrediente ingrediente);
        Task<bool> UpdateIngrediente(IngredienteDTO ingrediente, int id);
        Task<bool> DeleteIngrediente(int id);
        Task<List<IngredienteDTO>> ListaIngredientes();
        Task<IngredienteDTO> ObtenerIngredientePorId(int id);
    }
}
