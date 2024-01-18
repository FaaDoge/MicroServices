using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Validaciones;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteTuliette.Modelos.DTO
{
    public class PlatoDTO
    {
        public int IdPlato { get; set; }
        public string? TipoPlato { get; set; }

        public decimal? Precio { get; set; }

        public string? Descripcion { get; set; }

        public int? IdIngrediente { get; set; }

    }
}
