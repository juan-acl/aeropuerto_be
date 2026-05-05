using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ASIGNACION_SERVICIOS_TRANSPORTE")]
    public class AsignacionServiciosTransporte
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ASIGNACION_SERVICIO")]
        public int IdAsignacionServicio { get; set; }
        
        [Column("ID_RESERVA_TRANSPORTE")]
        public decimal IdReservaTransporte { get; set; }
        
        [Column("ID_VEHICULO_TRANSPORTE")]
        public decimal? IdVehiculoTransporte { get; set; }
        
        [Column("ID_CHOFER_TRANSPORTE")]
        public decimal? IdChoferTransporte { get; set; }
        
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        
        [Column("ASIGNADO_POR")]
        public decimal? AsignadoPor { get; set; }
        
        [Column("HORA_LLEGADA_VEHICULO")]
        public DateTime? HoraLlegadaVehiculo { get; set; }
        
        [Column("HORA_INICIO_SERVICIO")]
        public DateTime? HoraInicioServicio { get; set; }
        
        [Column("HORA_FIN_SERVICIO")]
        public DateTime? HoraFinServicio { get; set; }
        
        [Column("KILOMETRAJE_INICIO")]
        public decimal? KilometrajeInicio { get; set; }
        
        [Column("KILOMETRAJE_FIN")]
        public decimal? KilometrajeFin { get; set; }
        
        [Column("INCIDENCIAS")]
        public string? Incidencias { get; set; }
        
        [Column("CALIFICACION_PASAJERO")]
        public decimal? CalificacionPasajero { get; set; }
        
        [Column("COMENTARIOS_PASAJERO")]
        public string? ComentariosPasajero { get; set; }
        
    }
}
