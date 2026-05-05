using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("RESTAURANTES_MENUS")]
    public class RestaurantesMenusModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MENU")]
        public int IdMenu { get; set; }

        [Column("ID_CONCESION")]
        public int? IdConcesion { get; set; }

        [Column("NOMBRE_PLATO")]
        public string? NombrePlato { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("CATEGORIA_MENU")]
        public string CategoriaMenu { get; set; } = null!; // DESAYUNO, ALMUERZO, CENA, etc.

        [Column("PRECIO")]
        public decimal? Precio { get; set; }

        [Column("MONEDA")]
        public string? Moneda { get; set; }

        [Column("DISPONIBLE")]
        public int Disponible { get; set; } = 1;

        [Column("TIEMPO_PREPARACION_MINUTOS")]
        public int? TiempoPreparacionMinutos { get; set; }

        [Column("CALORIAS")]
        public int? Calorias { get; set; }

        [Column("RESTRICCIONES_ALIMENTICIAS")]
        public string? RestriccionesAlimenticias { get; set; }
    }
}
