using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CUMPLIMIENTO_NORMATIVO")]
    public class CumplimientoNormativo
    {
        
        [Key]
        [Column("ID_CUMPLIMIENTO_NORMATIVO")]
        public int IdCumplimientoNormativo { get; set; }
        
        [Column("ID_NORMATIVA")]
        public decimal IdNormativa { get; set; }
        
        [Column("FECHA_VERIFICACION")]
        public DateTime? FechaVerificacion { get; set; }
        
        [Column("PERIODO_VERIFICADO")]
        public string? PeriodoVerificado { get; set; }
        
        [Column("RESPONSABLE_VERIFICACION")]
        public decimal ResponsableVerificacion { get; set; }
        
        [Column("CUMPLIMIENTO_PORCENTAJE")]
        public decimal? CumplimientoPorcentaje { get; set; }
        
        [Column("HALLAZGOS")]
        public string? Hallazgos { get; set; }
        
        [Column("ACCIONES_CORRECTIVAS")]
        public string? AccionesCorrectivas { get; set; }
        
        [Column("FECHA_CIERRE_ACCIONES")]
        public DateTime? FechaCierreAcciones { get; set; }
        
        [Column("EVIDENCIA_CUMPLIMIENTO")]
        public byte[]? EvidenciaCumplimiento { get; set; }
        
        [Column("CALIFICACION")]
        public string? Calificacion { get; set; }
        
        [Column("PROXIMA_VERIFICACION")]
        public DateTime? ProximaVerificacion { get; set; }
        
        [Column("VERIFICACION_COMPLETADA")]
        public decimal? VerificacionCompletada { get; set; }
        

    }
}
