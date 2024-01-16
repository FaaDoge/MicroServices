using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestauranteTuliette.Modelos;

public partial class Bebidum
{
    [Key]
    public int IdBebida { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? TipoBebida { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Precio { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("idIngrediente")]
    public int? IdIngrediente { get; set; }

    [ForeignKey("IdIngrediente")]
    [InverseProperty("Bebida")]
    public virtual Ingrediente? IdIngredienteNavigation { get; set; }

    [InverseProperty("IdBebidaNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
