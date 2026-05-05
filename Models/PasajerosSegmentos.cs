using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS_SEGMENTOS")]
    [PrimaryKey(nameof(IdPasajero), nameof(IdSegmentoCliente))]
    public class PasajerosSegmentos
    {
        
        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }
        
        [Column("ID_SEGMENTO_CLIENTE")]
        public decimal? IdSegmentoCliente { get; set; }
        
        [Column("FECHA_ASIGNACION")]
        public DateTime? FechaAsignacion { get; set; }
        
        [Column("AUTOMATICO")]
        public decimal? Automatico { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
        
    }
}
