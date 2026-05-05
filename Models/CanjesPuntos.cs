using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CANJES_PUNTOS")]
    public class CanjesPuntos
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CANJE_PUNTOS")]
        public int IdCanjePuntos { get; set; }
        
        [Column("ID_PASAJERO")]
        public decimal IdPasajero { get; set; }
        
        [Column("ID_LEALTAD")]
        public decimal IdLealtad { get; set; }
        
        [Column("FECHA_CANJE")]
        public DateTime? FechaCanje { get; set; }
        
        [Column("PUNTOS_UTILIZADOS")]
        public decimal PuntosUtilizados { get; set; }
        
        [Column("TIPO_CANJE")]
        public string? TipoCanje { get; set; }
        
        [Column("DESCRIPCION_CANJE")]
        public string? DescripcionCanje { get; set; }
        
        [Column("ID_VUELO")]
        public decimal? IdVuelo { get; set; }
        
        [Column("ID_PRODUCTO")]
        public decimal? IdProducto { get; set; }
        
        [Column("VALOR_MONETARIO")]
        public decimal? ValorMonetario { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("ESTADO_CANJE")]
        public string? EstadoCanje { get; set; }
        
        [Column("PROCESADO_POR")]
        public decimal? ProcesadoPor { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        

    }
}
