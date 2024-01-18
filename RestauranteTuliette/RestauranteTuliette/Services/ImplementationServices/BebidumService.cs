using RestauranteTuliette.Contexto;
using APITiendaBDDic.Modelos.DTO;
using RestauranteTuliette.Services.InterfacesService;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteTuliette.Services.ImplementationServices
{
    public class BebidumService : IBebidumService
    {
        private readonly RestauranteTulietteContext _context;

        public BebidumService(RestauranteTulietteContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBebida(int id)
        {
            var bebida = await _context.Bebida.FindAsync(id);
            if (bebida == null)
                return false;

            _context.Bebida.Remove(bebida);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertBebida(Bebidum bebida)
        {
            _context.Bebida.Add(bebida);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BebidumDTO>> ListaBebidas()
        {
            var resultado = await _context.Bebida.Select(x => new BebidumDTO
            {
                TipoBebida = x.TipoBebida,
                Precio = x.Precio,
                Descripcion = x.Descripcion
            }).ToListAsync();
            return resultado;
        }

        public async Task<bool> UpdateBebida(BebidumDTO bebida, int id)
        {
            var existingBebida = await _context.Bebida.FindAsync(id);
            if (existingBebida == null)
                return false;

            existingBebida.TipoBebida = bebida.TipoBebida;
            existingBebida.Precio = bebida.Precio;
            existingBebida.Descripcion = bebida.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BebidumDTO> ObtenerBebidaPorId(int id)
        {
            var bebida = await _context.Bebida
                .Where(x => x.IdBebida == id)
                .Select(x => new BebidumDTO
                {
                    TipoBebida = x.TipoBebida,
                    Precio = x.Precio,
                    Descripcion = x.Descripcion
                })
                .FirstOrDefaultAsync();

            return bebida;
        }
    }
}
