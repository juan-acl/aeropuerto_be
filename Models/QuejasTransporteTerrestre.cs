using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("QUEJAS_TRANSPORTE_TERRESTRE")]
    public class QuejasTransporteTerrestre
    {
        
        [Key]
        [Column("ID_QUEJA_TRANSPORTE")]
        public int IdQuejaTransporte { get; set; }
        
        [Column("ID_RESERVA_TRANSPORTE")]
        public decimal IdReservaTransporte { get; set; }
        
        [Column("ID_PASAJERO")]
        public decimal IdPasajero { get; set; }
        
        [Column("FECHA_QUEJA")]
        public DateTime? FechaQueja { get; set; }
        
        [Column("TIPO_QUEJA")]
        public string? TipoQueja { get; set; }
        
        [Column("DESCRIPCION_QUEJA")]
        public string DescripcionQueja { get; set; } = null!;
        
        [Column("EVIDENCIA")]
        public byte[]? Evidencia { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("FECHA_RESOLUCION")]
        public DateTime? FechaResolucion { get; set; }
        
        [Column("RESOLUCION")]
        public string? Resolucion { get; set; }
        
        [Column("COMPENSACION_OFRECIDA")]
        public string? CompensacionOfrecida { get; set; }
        
        [Column("RESUELTO_POR")]
        public decimal? ResueltoPor { get; set; }
        
        [Column("SATISFACCION_PASAJERO")]
        public decimal? SatisfaccionPasajero { get; set; }
        

    }
}
