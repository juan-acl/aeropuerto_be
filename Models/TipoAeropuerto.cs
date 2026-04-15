using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TIPOS_AEROPUERTO")]
    public class TipoAeropuertoModel
    {
        [Key]
        [Column("ID_TIPO_AEROPUERTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoAeropuerto { get; set; }

        [Column("DESCRIPCION")]
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;

        [Column("CODIGO")]
        [StringLength(10)]
        public string? Codigo { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}