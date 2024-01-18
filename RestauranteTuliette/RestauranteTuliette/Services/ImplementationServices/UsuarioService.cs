using RestauranteTuliette.Contexto;
using RestauranteTuliette.Modelos.DTO;
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
    public class UsuarioService : IUsuarioService
    {
        RestauranteTulietteContext context;

        public UsuarioService(RestauranteTulietteContext _Context)
        {
            context = _Context;
        }
        public async Task<List<Usuario>> ListaUsuarios()
        {
            var resultado = await context.Usuarios.ToListAsync();
            return resultado;
        }
        public async Task<Usuario> ListarUsuarioID(int id)
        {
            var resultado = await context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
            return resultado;
        }
        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                context.Usuarios.Add(usuario);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> EditarUsuario(int id, Usuario usuario)
        {
            Usuario usuarioModificar = await context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
            if (usuarioModificar != null)
            {
                usuarioModificar.Nombre = usuario.Nombre;
                usuarioModificar.Contrasena = usuario.Contrasena;
                usuarioModificar.Estado = usuario.Estado;
                usuarioModificar.IdRol = usuario.IdRol;

                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> BorrarUsuario(int id)
        {
            Usuario usuarioEliminar = await context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);
            if (usuarioEliminar != null)
            {
                context.Remove(usuarioEliminar);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<DTOUsuariosReporte>> ListarUsuariosAM()
        {
            var resultado = await context.Usuarios
                .Where(u => u.Nombre != null && u.Nombre.ToUpper()[0] >= 'A' && u.Nombre.ToUpper()[0] <= 'M')
                .Select(u => new DTOUsuariosReporte
                {
                    IdUsuario = u.IdUsuario,
                    NombreUsuario = u.Nombre,
                })
                .ToListAsync();
            return resultado;
        }
    }
}
