using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("SERIES_VUELO_ASIGNADAS")]
    public class SeriesVueloAsignadas
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SERIE_VUELO")]
        public int IdSerieVuelo { get; set; }
        
        [Column("ID_PAIS_OACI")]
        public decimal IdPaisOaci { get; set; }
        
        [Column("ID_AEROLINEA")]
        public decimal IdAerolinea { get; set; }
        
        [Column("RANGO_NUMEROS_INICIO")]
        public string RangoNumerosInicio { get; set; } = null!;
        
        [Column("RANGO_NUMEROS_FIN")]
        public string RangoNumerosFin { get; set; } = null!;
        
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        
        [Column("FECHA_VENCIMIENTO")]
        public DateTime? FechaVencimiento { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("DOCUMENTO_ASIGNACION")]
        public byte[]? DocumentoAsignacion { get; set; }
        

    }
}
