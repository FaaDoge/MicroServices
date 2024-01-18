using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteTuliette.Modelos.DTO
{
    public class dtoReportPuma
    {
        public int IdPedido { get; set; }
        public string? NombreCliente { get; set; }
        public string? TipodePago { get; set; }
        public decimal? PrecioTotal { get; set; }
        public string? DescripcionPlato { get; set; }
        public string? Ubicacion { get; set; }
    }
}
