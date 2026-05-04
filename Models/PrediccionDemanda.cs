using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PREDICCION_DEMANDA")]
    public class PrediccionDemanda
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PREDICCION")]
        public decimal IdPrediccion { get; set; }
        
        [Column("FECHA_PREDICCION")]
        public DateTime FechaPrediccion { get; set; }
        
        [Column("HORA_PREDICCION")]
        public DateTime? HoraPrediccion { get; set; }
        
        [Column("TIPO_PREDICCION")]
        public string? TipoPrediccion { get; set; }
        
        [Column("VALOR_PREDICHO")]
        public decimal? ValorPredicho { get; set; }
        
        [Column("INTERVALO_CONFIANZA_INFERIOR")]
        public decimal? IntervaloConfianzaInferior { get; set; }
        
        [Column("INTERVALO_CONFIANZA_SUPERIOR")]
        public decimal? IntervaloConfianzaSuperior { get; set; }
        
        [Column("MODELO_UTILIZADO")]
        public string? ModeloUtilizado { get; set; }
        
        [Column("PRECISION_HISTORICA")]
        public decimal? PrecisionHistorica { get; set; }
        
        [Column("FECHA_GENERACION")]
        public DateTime? FechaGeneracion { get; set; }
        
        [Column("GENERADO_POR")]
        public string? GeneradoPor { get; set; }
    }
}
