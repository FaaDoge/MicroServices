using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RestauranteTuliette.Modelos.DTO
{
    public class UsuarioDTO
    {
        public string? Nombre { get; set; }
        public string? Contrasena { get; set; }
        public int? Estado { get; set; }
    }
}
