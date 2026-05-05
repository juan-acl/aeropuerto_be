using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("TIPOS_AEROLINEA")]
    public class TipoAerolineaModel
    {
        [Key]
        [Column("ID_TIPO_AEROLINEA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoAerolinea { get; set; }

        [Column("DESCRIPCION")]
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
