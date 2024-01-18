using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos.Entity;
using RestauranteTuliette.Services.InterfacesService;

namespace RestauranteTuliette.Services.ImplementationServices
{
    public class RolService : IRolService
    {
        RestauranteTulietteContext _context;
        public RolService(RestauranteTulietteContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteRol(int id)
        {
            var roles = await _context.Rols.FindAsync(id);
            if (roles == null)
                return false;

            _context.Rols.Remove(roles);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertRol(Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<RolDTO>> ListaRol()
        {
            var resultado = await _context.Rols.Select(x => new RolDTO
            {
                Nombre = x.Nombre,
                Estado = x.Estado,
            }).ToListAsync();
            return resultado;
        }

        public async Task<RolDTO> ObtenerRolPorId(int id)
        {
            var roles = await _context.Rols
                .Where(x => x.IdRol == id)
                .Select(x => new RolDTO
                {
                    Nombre = x.Nombre,
                    Estado = x.Estado,
                })
                .FirstOrDefaultAsync();

            return roles;
        }

        public async Task<bool> UpdateRol(RolDTO rol, int id)
        {
            var roles = await _context.Rols.FindAsync(id);
            if (roles == null)
                return false;

            roles.Nombre = rol.Nombre;
            roles.Estado = rol.Estado;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
