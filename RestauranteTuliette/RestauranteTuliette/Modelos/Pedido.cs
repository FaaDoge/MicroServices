using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Validaciones;

namespace RestauranteTuliette.Modelos;

[Table("Pedido")]
public partial class Pedido
{
    [Key]
    public int IdPedido { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [SoloLetras]
    public string? NombreCliente { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TipodePago { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    [SoloNumber]
    public decimal? PrecioTotal { get; set; }

    [Column("idUbicacion")]
    public int? IdUbicacion { get; set; }

    public int? IdPlato { get; set; }

    public int? IdBebida { get; set; }

    [ForeignKey("IdBebida")]
    [InverseProperty("Pedidos")]
    public virtual Bebidum? IdBebidaNavigation { get; set; }

    [ForeignKey("IdPlato")]
    [InverseProperty("Pedidos")]
    public virtual Plato? IdPlatoNavigation { get; set; }

    [ForeignKey("IdUbicacion")]
    [InverseProperty("Pedidos")]
    public virtual Ubicacion? IdUbicacionNavigation { get; set; }
}
