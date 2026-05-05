using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("SEGUIMIENTO_CARGA")]
    public class SeguimientoCarga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SEGUIMIENTO")]
        public int IdSeguimiento { get; set; }
        [Column("ID_ENVIO")]
        public int IdEnvio { get; set; }
        [Column("FECHA_EVENTO")]
        public DateTime FechaEvento { get; set; }
        [Column("UBICACION_ACTUAL")]
        public string UbicacionActual { get; set; } = null!;
        [Column("ESTADO_CARGA")]
        public string EstadoCarga { get; set; } = "EN TRANSITO";
        [Column("COMENTARIOS")]
        public string? Comentarios { get; set; }
    }
}
