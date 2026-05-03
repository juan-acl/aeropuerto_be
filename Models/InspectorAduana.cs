using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INSPECTORES_ADUANAS")]
    public class InspectorAduanas
    {
        [Key]
        [Column("ID_INSPECTOR")]
        public int id_inspector { get; set; }

        [Column("ID_EMPLEADO")]
        public int? id_empleado { get; set; }

        [Column("NUMERO_LICENCIA")]
        public string? numero_licencia { get; set; }

        [Column("NIVEL_AUTORIZACION")]
        public int? nivel_autorizacion { get; set; }

        [Column("FECHA_CERTIFICACION")]
        public DateTime? fecha_certificacion { get; set; }

        [Column("FECHA_VENCIMIENTO_CERTIFICACION")]
        public DateTime? fecha_vencimiento_certificacion { get; set; }

        [Column("ESPECIALIDAD")]
        public string? especialidad { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}