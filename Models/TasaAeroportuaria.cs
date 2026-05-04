using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("TASA_AEROPORTUARIA")]
    public class TasaAeroportuaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_TASA")]
        public int IdTasa { get; set; }
        [Column("NOMBRE_TASA")]
        public string NombreTasa { get; set; } = null!;
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("MONTO")]
        public decimal Monto { get; set; }
        [Column("TIPO_TASA")]
        public string TipoTasa { get; set; } = null!; // NACIONAL, INTERNACIONAL
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
