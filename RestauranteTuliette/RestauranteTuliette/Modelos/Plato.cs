using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RestauranteTuliette.Validaciones;

namespace RestauranteTuliette.Modelos;

[Table("Plato")]
public partial class Plato
{
    [Key]
    public int IdPlato { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? TipoPlato { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    [SoloNumber]
    public decimal? Precio { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    [SoloLetras]
    public string? Descripcion { get; set; }

    [Column("idIngrediente")]
    public int? IdIngrediente { get; set; }

    [ForeignKey("IdIngrediente")]
    [InverseProperty("Platos")]
    public virtual Ingrediente? IdIngredienteNavigation { get; set; }

    [InverseProperty("IdPlatoNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
