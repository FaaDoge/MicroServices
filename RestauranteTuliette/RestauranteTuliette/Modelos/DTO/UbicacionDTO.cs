using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteTuliette.Modelos.DTO
{
    public class UbicacionDTO
    {
        public string? Tipo { get; set; }

        public string? NroMesa { get; set; }
    }
}
