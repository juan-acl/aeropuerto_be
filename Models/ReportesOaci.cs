using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("REPORTES_OACI")]
    public class ReportesOaci
    {
        
        [Key]
        [Column("ID_REPORTE_OACI")]
        public Int32 IdReporteOaci { get; set; }
        
        [Column("TIPO_REPORTE")]
        public string? TipoReporte { get; set; }
        
        [Column("PERIODO")]
        public string? Periodo { get; set; }
        
        [Column("FECHA_INICIO_PERIODO")]
        public DateTime FechaInicioPeriodo { get; set; }
        
        [Column("FECHA_FIN_PERIODO")]
        public DateTime FechaFinPeriodo { get; set; }
        
        [Column("FECHA_ENVIO")]
        public DateTime? FechaEnvio { get; set; }
        
        [Column("CONTENIDO_REPORTE")]
        public string? ContenidoReporte { get; set; }
        
        [Column("ARCHIVO_REPORTE")]
        public byte[]? ArchivoReporte { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("ENVIADO_POR")]
        public decimal? EnviadoPor { get; set; }
        
        [Column("CONFIRMACION_RECIBIDO")]
        public decimal? ConfirmacionRecibido { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
