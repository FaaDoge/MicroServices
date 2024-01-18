using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestauranteTuliette.Modelos.Entity;

[Table("Ubicacion")]
public partial class Ubicacion
{
    [Key]
    public int IdUbicacion { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Column("nroMesa")]
    [StringLength(15)]
    [Unicode(false)]
    public string? NroMesa { get; set; }

    [InverseProperty("IdUbicacionNavigation")]
    public virtual ICollection<Pedido>? Pedidos { get; set; } = new List<Pedido>();
}
