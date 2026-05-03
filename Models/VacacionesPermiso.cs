using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("VACACIONES_PERMISOS")]
    public class VacacionPermiso
    {
        [Key]
        [Column("ID_SOLICITUD")]
        public int id_solicitud { get; set; }

        [Column("ID_EMPLEADO")]
        public int? id_empleado { get; set; }

        [Column("TIPO_SOLICITUD")]
        public string? tipo_solicitud { get; set; } // VACACIONES, PERMISO, LICENCIA, INCAPACIDAD

        [Column("FECHA_INICIO")]
        public DateTime? fecha_inicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? fecha_fin { get; set; }

        [Column("DIAS_SOLICITADOS")]
        public int? dias_solicitados { get; set; }

        [Column("MOTIVO")]
        public string? motivo { get; set; }

        [Column("FECHA_SOLICITUD")]
        public DateTime? fecha_solicitud { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; }

        [Column("AUTORIZADO_POR")]
        public int? autorizado_por { get; set; }

        [Column("FECHA_AUTORIZACION")]
        public DateTime? fecha_autorizacion { get; set; }

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }
    }
}