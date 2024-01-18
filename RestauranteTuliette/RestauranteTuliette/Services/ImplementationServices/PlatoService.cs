using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;

namespace RestauranteTuliette.Services.ImplementationServices
{
    public class PlatoService : IPlatoService
    {
        private readonly RestauranteTulietteContext _context;

        public PlatoService(RestauranteTulietteContext context)
        {
            _context = context;
        }

        public async Task<bool> DeletePlato(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
                return false;

            _context.Platos.Remove(plato);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertPlato(Plato plato)
        {
            _context.Platos.Add(plato);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PlatoDTO>> ListaPlatos()
        {
            var resultado = await _context.Platos
                .Select(x => new PlatoDTO
                {
                    IdPlato = x.IdPlato,
                    TipoPlato = x.TipoPlato,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion,
                    IdIngrediente = x.IdIngrediente
                })
                .ToListAsync();
            return resultado;
        }

        public async Task<bool> UpdatePlato(PlatoDTO plato, int id)
        {
            var existingPlato = await _context.Platos.FindAsync(id);
            if (existingPlato == null)
                return false;

            existingPlato.TipoPlato = plato.TipoPlato;
            existingPlato.Precio = plato.Precio;
            existingPlato.Descripcion = plato.Descripcion;
            existingPlato.IdIngrediente = plato.IdIngrediente;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PlatoDTO> ObtenerPlatoPorId(int id)
        {
            var plato = await _context.Platos
                .Where(x => x.IdPlato == id)
                .Select(x => new PlatoDTO
                {
                    IdPlato = x.IdPlato,
                    TipoPlato = x.TipoPlato,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion,
                    IdIngrediente = x.IdIngrediente
                })
                .FirstOrDefaultAsync();

            return plato;
        }
    }

}
