using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;

namespace RestauranteTuliette.Services.ImplementationServices
{
    public class UbicacionService : IUbicacionService
    {
        RestauranteTulietteContext _context;
        public UbicacionService(RestauranteTulietteContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteUbicacion(int id)
        {
            var ubicaciones = await _context.Ubicacions.FindAsync(id);
            if (ubicaciones == null)
                return false;

            _context.Ubicacions.Remove(ubicaciones);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertUbicacion(Ubicacion ubicacion)
        {
            _context.Ubicacions.Add(ubicacion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UbicacionDTO>> ListaUbicacion()
        {
            var resultado = await _context.Ubicacions.Select(x => new UbicacionDTO
            {
                Tipo = x.Tipo,
                NroMesa = x.NroMesa,
            }).ToListAsync();
            return resultado;
        }

        public async Task<UbicacionDTO> ObtenerUbicacionPorId(int id)
        {
            var ubicacions = await _context.Ubicacions
                .Where(x => x.IdUbicacion == id)
                .Select(x => new UbicacionDTO
                {
                    Tipo = x.Tipo,
                    NroMesa = x.NroMesa,
                })
                .FirstOrDefaultAsync();

            return ubicacions;
        }

        public async Task<bool> UpdateUbicacion(UbicacionDTO ubicacion, int id)
        {
            var ubicaciones = await _context.Ubicacions.FindAsync(id);
            if (ubicaciones == null)
                return false;

            ubicaciones.Tipo = ubicacion.Tipo;
            ubicaciones.NroMesa = ubicacion.NroMesa;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
