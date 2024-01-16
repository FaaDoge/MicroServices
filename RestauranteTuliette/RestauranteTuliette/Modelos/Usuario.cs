using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestauranteTuliette.Modelos;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    public int? Nombre { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Contrasena { get; set; }

    public int? Estado { get; set; }

    public int? IdRol { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("Usuarios")]
    public virtual Rol? IdRolNavigation { get; set; }
}
