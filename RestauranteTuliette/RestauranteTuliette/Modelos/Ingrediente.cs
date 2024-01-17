using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestauranteTuliette.Modelos
{
    [Table("Ingrediente")]
    public partial class Ingrediente
    {
        [Key]
        public int IdIngrediente { get; set; }

        [StringLength(20, ErrorMessage = "El campo {0} no puede exceder los 20 caracteres.")]
        [Unicode(false)]
        public string? TipoIngrediente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede exceder los 50 caracteres.")]
        [Unicode(false)]
        public string? NombreIngrediente { get; set; }

        [StringLength(20, ErrorMessage = "El campo {0} no puede exceder los 20 caracteres.")]
        [Unicode(false)]
        public string? Unidad { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un valor no negativo.")]
        public int? Cantidad { get; set; }

        [StringLength(200, ErrorMessage = "El campo {0} no puede exceder los 200 caracteres.")]
        [Unicode(false)]
        public string? Descripcion { get; set; }

        [InverseProperty("IdIngredienteNavigation")]
        public virtual ICollection<Bebidum> Bebidas { get; set; } = new List<Bebidum>();

        [InverseProperty("IdIngredienteNavigation")]
        public virtual ICollection<Plato> Platos { get; set; } = new List<Plato>();

    }
}
