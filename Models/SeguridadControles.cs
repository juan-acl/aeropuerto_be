using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SEGURIDAD_CONTROLES")]
    public class SeguridadControlesModel
    {
        [Key]
        [Column("ID_CONTROL")]
        public int IdControl { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("FECHA_CONTROL")]
        public DateTime? FechaControl { get; set; }

        [Column("HORA_CONTROL")]
        public DateTime? HoraControl { get; set; }

        [Column("TIPO_CONTROL")]
        public string TipoControl { get; set; } = null!; // RAYOS_X, CANES, etc.

        [Column("NUMERO_PASAJEROS_REVISADOS")]
        public int NumeroPasajerosRevisados { get; set; }

        [Column("NUMERO_INCIDENCIAS")]
        public int NumeroIncidencias { get; set; }

        [Column("SUPERVISOR")]
        public string? Supervisor { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}