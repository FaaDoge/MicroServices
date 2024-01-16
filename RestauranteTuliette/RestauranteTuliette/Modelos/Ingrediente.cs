using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestauranteTuliette.Modelos;

[Table("Ingrediente")]
public partial class Ingrediente
{
    [Key]
    public int IdIngrediente { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TipoIngrediente { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NombreIngrediente { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Unidad { get; set; }

    public int? Cantidad { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdIngredienteNavigation")]
    public virtual ICollection<Bebidum> Bebida { get; set; } = new List<Bebidum>();

    [InverseProperty("IdIngredienteNavigation")]
    public virtual ICollection<Plato> Platos { get; set; } = new List<Plato>();
}
