using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Services.InterfacesService;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteTuliette.Services.ImplementationServices
{
    public class IngredienteService : IIngredienteService
    {
        private readonly RestauranteTulietteContext _tiendabdContext;

        public IngredienteService(RestauranteTulietteContext tiendabdContext)
        {
            _tiendabdContext = tiendabdContext;
        }

        public async Task<bool> DeleteIngrediente(int id)
        {
            var ingrediente = await _tiendabdContext.Ingredientes.FindAsync(id);
            if (ingrediente == null)
                return false;

            _tiendabdContext.Ingredientes.Remove(ingrediente);
            await _tiendabdContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertIngrediente(Ingrediente ingrediente)
        {
            _tiendabdContext.Ingredientes.Add(ingrediente);
            await _tiendabdContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<IngredienteDTO>> ListaIngredientes()
        {
            var resultado = await _tiendabdContext.Ingredientes.Select(x => new IngredienteDTO
            {
                TipoIngrediente = x.TipoIngrediente,
                NombreIngrediente = x.NombreIngrediente,
                Unidad = x.Unidad,
                Cantidad = x.Cantidad,
                Descripcion = x.Descripcion
            }).ToListAsync();
            return resultado;
        }

        public async Task<bool> UpdateIngrediente(IngredienteDTO ingrediente, int id)
        {
            var existingIngrediente = await _tiendabdContext.Ingredientes.FindAsync(id);
            if (existingIngrediente == null)
                return false;

            existingIngrediente.TipoIngrediente = ingrediente.TipoIngrediente;
            existingIngrediente.NombreIngrediente = ingrediente.NombreIngrediente;
            existingIngrediente.Unidad = ingrediente.Unidad;
            existingIngrediente.Cantidad = ingrediente.Cantidad;
            existingIngrediente.Descripcion = ingrediente.Descripcion;

            await _tiendabdContext.SaveChangesAsync();
            return true;
        }

        public async Task<IngredienteDTO> ObtenerIngredientePorId(int id)
        {
            var ingrediente = await _tiendabdContext.Ingredientes
                .Where(x => x.IdIngrediente == id)
                .Select(x => new IngredienteDTO
                {
                    TipoIngrediente = x.TipoIngrediente,
                    NombreIngrediente = x.NombreIngrediente,
                    Unidad = x.Unidad,
                    Cantidad = x.Cantidad,
                    Descripcion = x.Descripcion
                })
                .FirstOrDefaultAsync();

            return ingrediente;
        }
    }
}
