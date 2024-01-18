namespace RestauranteTuliette.Modelos.DTO
{
    public class PedidoPlatoDTO
    {
        public int IdPedido { get; set; }
        public string? NombreCliente { get; set; }
        public string? TipodePago { get; set; }
        public decimal? PrecioTotal { get; set; }
        public string nroMesa { get; set; } = null;
        public string Descripcion { get; set; } = null;
    }
}
