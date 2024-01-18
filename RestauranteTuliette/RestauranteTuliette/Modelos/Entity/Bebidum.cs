using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteTuliette.Modelos
{
    public partial class Bebidum
    {
        [Key]
        public int IdBebida { get; set; }

        [StringLength(30, ErrorMessage = "El campo {0} no puede exceder los 30 caracteres.")]
        public string? TipoBebida { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Precio { get; set; }

        [StringLength(200, ErrorMessage = "El campo {0} no puede exceder los 200 caracteres.")]
        public string? Descripcion { get; set; }

        [Column("idIngrediente")]
        public int? IdIngrediente { get; set; }

        [ForeignKey("IdIngrediente")]
        [InverseProperty("Bebidas")]
        public virtual Ingrediente? IdIngredienteNavigation { get; set; }

        [InverseProperty("IdBebidaNavigation")]
        public virtual ICollection<Pedido> PedidosNavigation { get; set; } = new List<Pedido>();
    }
}
