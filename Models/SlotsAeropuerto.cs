using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SLOTS_AEROPUERTO")]
    public class SlotsAeropuerto
    {
        
        [Key]
        [Column("ID_SLOT")]
        public decimal IdSlot { get; set; }
        
        [Column("ID_AEROLINEA")]
        public decimal IdAerolinea { get; set; }
        
        [Column("FECHA_SLOT")]
        public DateTime FechaSlot { get; set; }
        
        [Column("HORA_SLOT")]
        public DateTime HoraSlot { get; set; }
        
        [Column("TIPO_OPERACION")]
        public string? TipoOperacion { get; set; }
        
        [Column("ID_VUELO_ASIGNADO")]
        public decimal? IdVueloAsignado { get; set; }
        
        [Column("ESTADO_SLOT")]
        public string? EstadoSlot { get; set; }
        
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        
        [Column("ASIGNADO_POR")]
        public decimal? AsignadoPor { get; set; }
        
        [Column("FECHA_LIBERACION")]
        public DateTime? FechaLiberacion { get; set; }
        
        [Column("MOTIVO_CANCELACION")]
        public string? MotivoCancelacion { get; set; }

    }
}
