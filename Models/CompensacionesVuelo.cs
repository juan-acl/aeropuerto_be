using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("COMPENSACIONES_VUELO")]
    public class CompensacionesVuelo
    {
        
        [Key]
        [Column("ID_COMPENSACION_VUELO")]
        public int IdCompensacionVuelo { get; set; }
        
        [Column("ID_HUELLA_CARBONO")]
        public decimal IdHuellaCarbono { get; set; }
        
        [Column("ID_PROGRAMA_COMPENSACION")]
        public decimal IdProgramaCompensacion { get; set; }
        
        [Column("FECHA_COMPENSACION")]
        public DateTime? FechaCompensacion { get; set; }
        
        [Column("CANTIDAD_COMPENSADA_KG")]
        public decimal? CantidadCompensadaKg { get; set; }
        
        [Column("PORCENTAJE_COMPENSADO")]
        public decimal? PorcentajeCompensado { get; set; }
        
        [Column("MONTO_APORTADO")]
        public decimal? MontoAportado { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("COMPROBANTE_COMPENSACION")]
        public byte[]? ComprobanteCompensacion { get; set; }
        
        [Column("VERIFICADA")]
        public decimal? Verificada { get; set; }

    }
}
