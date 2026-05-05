using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("DIAS_OPERACION")]
    public class DiaOperacionModel
    {
        [Key]
        [Column("ID_DIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDia { get; set; }

        [Column("NOMBRE_DIA")]
        [Required]
        [StringLength(10)]
        public string NombreDia { get; set; } = null!;

        [Column("NUMERO_DIA")]
        [Range(1, 7)] // Validación para el CHECK (BETWEEN 1 AND 7)
        public int? NumeroDia { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
