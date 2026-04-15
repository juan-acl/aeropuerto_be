using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SURTIDORES_COMBUSTIBLE")]
    public class SurtidoresCombustible
    {
        
        [Key]
        [Column("ID_SURTIDOR")]
        public int IdSurtidor { get; set; }
        
        [Column("CODIGO_SURTIDOR")]
        public string CodigoSurtidor { get; set; } = null!;
        
        [Column("UBICACION")]
        public string Ubicacion { get; set; } = null!;
        
        [Column("TIPO_COMBUSTIBLE")]
        public string? TipoCombustible { get; set; }
        
        [Column("VELOCIDAD_CARGA_LITROS_HORA")]
        public decimal? VelocidadCargaLitrosHora { get; set; }
        
        [Column("DISPONIBLE")]
        public decimal? Disponible { get; set; }
        
        [Column("FECHA_ULTIMO_MANTENIMIENTO")]
        public DateTime? FechaUltimoMantenimiento { get; set; }
        
        [Column("FECHA_PROXIMO_MANTENIMIENTO")]
        public DateTime? FechaProximoMantenimiento { get; set; }
        
        [Column("OPERATIVO")]
        public decimal? Operativo { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
