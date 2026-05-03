using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CAPACITACIONES")]
    public class Capacitacion
    {
        [Key]
        [Column("ID_CAPACITACION")]
        public int id_capacitacion { get; set; }

        [Column("NOMBRE_CURSO")]
        public string? nombre_curso { get; set; }

        [Column("DESCRIPCION")]
        public string? descripcion { get; set; }

        [Column("TIPO_CAPACITACION")]
        public string? tipo_capacitacion { get; set; } // SEGURIDAD, TECNICA, ATENCION_CLIENTE, IDIOMAS, LIDERAZGO

        [Column("DURACION_HORAS")]
        public decimal? duracion_horas { get; set; }

        [Column("COSTO")]
        public decimal? costo { get; set; }

        [Column("PROVEEDOR")]
        public string? proveedor { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime? fecha_inicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? fecha_fin { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}