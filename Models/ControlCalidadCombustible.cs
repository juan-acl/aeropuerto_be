using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CONTROL_CALIDAD_COMBUSTIBLE")]
    public class ControlCalidadCombustible
    {
        
        [Key]
        [Column("ID_MUESTRA")]
        public int IdMuestra { get; set; }
        
        [Column("ID_TANQUE")]
        public decimal? IdTanque { get; set; }
        
        [Column("FECHA_MUESTRA")]
        public DateTime? FechaMuestra { get; set; }
        
        [Column("FECHA_ANALISIS")]
        public DateTime? FechaAnalisis { get; set; }
        
        [Column("NUMERO_MUESTRA")]
        public string? NumeroMuestra { get; set; }
        
        [Column("TIPO_ANALISIS")]
        public string? TipoAnalisis { get; set; }
        
        [Column("ANALISTA")]
        public decimal? Analista { get; set; }
        
        [Column("DENSIDAD_MEDIDA")]
        public decimal? DensidadMedida { get; set; }
        
        [Column("TEMPERATURA_PRUEBA")]
        public decimal? TemperaturaPrueba { get; set; }
        
        [Column("PRESENCIA_AGUA")]
        public decimal? PresenciaAgua { get; set; }
        
        [Column("PARTICULAS_SUSPENDIDAS")]
        public decimal? ParticulasSuspendidas { get; set; }
        
        [Column("CONDUCTIVIDAD")]
        public decimal? Conductividad { get; set; }
        
        [Column("RESULTADO")]
        public string? Resultado { get; set; }
        
        [Column("APROBADO_POR")]
        public decimal? AprobadoPor { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }

    }
}
