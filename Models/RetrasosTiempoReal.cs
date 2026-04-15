using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("RETRASOS_TIEMPO_REAL")]
    public class RetrasosTiempoReal
    {
        
        [Key]
        [Column("ID_RETRASO_TIEMPO_REAL")]
        public decimal IdRetrasoTiempoReal { get; set; }
        
        [Column("ID_VUELO")]
        public decimal IdVuelo { get; set; }
        
        [Column("FECHA_HORA_REGISTRO")]
        public DateTime? FechaHoraRegistro { get; set; }
        
        [Column("TIPO_RETRASO")]
        public string? TipoRetraso { get; set; }
        
        [Column("CAUSA_ESPECIFICA")]
        public string? CausaEspecifica { get; set; }
        
        [Column("MINUTOS_RETRASO_ACTUALES")]
        public decimal? MinutosRetrasoActuales { get; set; }
        
        [Column("MINUTOS_RETRASO_ESTIMADOS")]
        public decimal? MinutosRetrasoEstimados { get; set; }
        
        [Column("IMPACTO_GLOBAL")]
        public decimal? ImpactoGlobal { get; set; }
        
        [Column("AFECTA_CONEXIONES")]
        public decimal? AfectaConexiones { get; set; }
        
        [Column("NOTIFICADO_PASAJEROS")]
        public decimal? NotificadoPasajeros { get; set; }
        
        [Column("ACTUALIZADO_POR")]
        public decimal? ActualizadoPor { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }

    }
}
