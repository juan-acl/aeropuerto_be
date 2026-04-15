using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MOTORES_AVIONES")] 
    public class MotorAvionModel
    {
        [Key]
        [Column("ID_MOTOR")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMotor { get; set; }

        [Column("NOMBRE_MOTOR")]
        [StringLength(50)]
        public string? NombreMotor { get; set; }

        [Column("FABRICANTE_MOTOR")]
        [StringLength(50)]
        public string? FabricanteMotor { get; set; }

        [Column("TIPO_MOTOR")]
        [StringLength(30)]
        public string? TipoMotor { get; set; }

        [Column("EMPUJE_LIBRAS")]
        public decimal? EmpujeLibras { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}