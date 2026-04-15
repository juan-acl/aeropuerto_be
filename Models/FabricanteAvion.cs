using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("FABRICANTES_AVIONES")]
    public class FabricanteAvionModel
    {
        [Key]
        [Column("ID_FABRICANTE")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFabricante { get; set; }

        [Column("NOMBRE_FABRICANTE")]
        [Required]
        [StringLength(50)]
        public string NombreFabricante { get; set; } = null!;

        [Column("PAIS_ORIGEN")]
        [StringLength(50)]
        public string? PaisOrigen { get; set; }

        [Column("ANIO_FUNDACION")]
        public int? AnioFundacion { get; set; }

        [Column("SEDE_PRINCIPAL")]
        [StringLength(100)]
        public string? SedePrincipal { get; set; }

        [Column("WEBSITE")]
        [StringLength(100)]
        public string? Website { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}