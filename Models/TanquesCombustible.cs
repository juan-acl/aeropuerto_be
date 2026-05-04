using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("TANQUES_COMBUSTIBLE")]
    public class TanquesCombustible
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_TANQUE")]
        public int IdTanque { get; set; }
        
        [Column("CODIGO_TANQUE")]
        public string CodigoTanque { get; set; } = null!;
        
        [Column("NOMBRE_TANQUE")]
        public string? NombreTanque { get; set; }
        
        [Column("TIPO_COMBUSTIBLE")]
        public string? TipoCombustible { get; set; }
        
        [Column("CAPACIDAD_LITROS")]
        public decimal? CapacidadLitros { get; set; }
        
        [Column("NIVEL_ACTUAL_LITROS")]
        public decimal? NivelActualLitros { get; set; }
        
        [Column("PORCENTAJE_LLENADO")]
        public decimal? PorcentajeLlenado { get; set; }
        
        [Column("UBICACION")]
        public string? Ubicacion { get; set; }
        
        [Column("FECHA_ULTIMA_INSPECCION")]
        public DateTime? FechaUltimaInspeccion { get; set; }
        
        [Column("FECHA_ULTIMA_CALIBRACION")]
        public DateTime? FechaUltimaCalibracion { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
