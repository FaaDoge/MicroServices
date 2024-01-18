using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestauranteTuliette.Modelos.Entity;

[Table("Rol")]
public partial class Rol
{
    [Key]
    public int IdRol { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    public int? Estado { get; set; }

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Usuario>? Usuarios { get; set; } = new List<Usuario>();
}
