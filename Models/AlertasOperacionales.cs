using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ALERTAS_OPERACIONALES")]
    public class AlertasOperacionales
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ALERTA_OPERACIONAL")]
        public decimal IdAlertaOperacional { get; set; }
        
        [Column("TIPO_ALERTA")]
        public string? TipoAlerta { get; set; }
        
        [Column("NIVEL_ALERTA")]
        public string? NivelAlerta { get; set; }
        
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        
        [Column("FECHA_HORA_INICIO")]
        public DateTime? FechaHoraInicio { get; set; }
        
        [Column("FECHA_HORA_FIN")]
        public DateTime? FechaHoraFin { get; set; }
        
        [Column("AREA_AFECTADA")]
        public string? AreaAfectada { get; set; }
        
        [Column("VUELOS_AFECTADOS")]
        public decimal? VuelosAfectados { get; set; }
        
        [Column("PASAJEROS_AFECTADOS")]
        public decimal? PasajerosAfectados { get; set; }
        
        [Column("ACCIONES_RECOMENDADAS")]
        public string? AccionesRecomendadas { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("CREADA_POR")]
        public decimal? CreadaPor { get; set; }
        
        [Column("CERRADA_POR")]
        public decimal? CerradaPor { get; set; }
        
    }
}
