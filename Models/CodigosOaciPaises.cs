using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CODIGOS_OACI_PAISES")]
    public class CodigosOaciPaises
    {
        
        [Key]
        [Column("ID_PAIS_OACI")]
        public decimal IdPaisOaci { get; set; }
        
        [Column("NOMBRE_PAIS")]
        public string NombrePais { get; set; } = null!;
        
        [Column("CODIGO_OACI_PAIS")]
        public string CodigoOaciPais { get; set; } = null!;
        
        [Column("RANGO_INICIO")]
        public string? RangoInicio { get; set; }
        
        [Column("RANGO_FIN")]
        public string? RangoFin { get; set; }
        
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
