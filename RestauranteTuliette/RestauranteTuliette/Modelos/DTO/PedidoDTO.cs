using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Validaciones;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteTuliette.Modelos.DTO
{
    public class PedidoDTO
    {
        public string? NombreCliente { get; set; }
        public string? TipodePago { get; set; }
        public decimal? PrecioTotal { get; set; }

        public int? IdUbicacion { get; set; }

        public int? IdPlato { get; set; }

        public int? IdBebida { get; set; }
    }
}
