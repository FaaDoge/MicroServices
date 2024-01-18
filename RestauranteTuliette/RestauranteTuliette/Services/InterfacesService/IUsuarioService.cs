using RestauranteTuliette.Modelos.DTO;
using RestauranteTuliette.Modelos;
using RestauranteTuliette.Modelos.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteTuliette.Services.InterfacesService
{
    public interface IUsuarioService
    {

        /*Task<List<UsuarioDTO>> ListaUsuarios();
        Task<UsuarioDTO> ListarUsuarioID(int id);*/
        Task<List<Usuario>> ListaUsuarios();
        Task<Usuario> ListarUsuarioID(int id);
        Task<bool> CrearUsuario(Usuario usuario);
        Task<bool> EditarUsuario(int id, Usuario usuario);
        Task<bool> BorrarUsuario(int id);
        Task<List<DTOUsuariosReporte>> ListarUsuariosAM();
    }
}