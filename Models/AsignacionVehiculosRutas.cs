using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ASIGNACION_VEHICULOS_RUTAS")]
    public class AsignacionVehiculosRutas
    {
        
        [Key]
        [Column("ID_ASIGNACION_VEHICULO_RUTA")]
        public int IdAsignacionVehiculoRuta { get; set; }
        
        [Column("ID_VEHICULO_TRANSPORTE")]
        public decimal IdVehiculoTransporte { get; set; }
        
        [Column("ID_RUTA_TRANSPORTE")]
        public decimal IdRutaTransporte { get; set; }
        
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        
        [Column("FECHA_INICIO_VIGENCIA")]
        public DateTime FechaInicioVigencia { get; set; }
        
        [Column("FECHA_FIN_VIGENCIA")]
        public DateTime? FechaFinVigencia { get; set; }
        
        [Column("HORARIO_SERVICIO")]
        public string? HorarioServicio { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
    }
}
