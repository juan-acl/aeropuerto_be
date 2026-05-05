using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CATEGORIAS_OBJETOS")]
    public class CategoriasObjetosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CATEGORIA")]
        public int IdCategoria { get; set; }

        [Column("NOMBRE_CATEGORIA")]
        public string NombreCategoria { get; set; } = null!;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
