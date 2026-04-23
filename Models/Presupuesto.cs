using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PRESUPUESTO")]
    public class Presupuesto
    {
        [Key]
        [Column("ID_PRESUPUESTO")]
        public int IdPresupuesto { get; set; }
        [Column("ID_DEPARTAMENTO")]
        public int IdDepartamento { get; set; }
        [Column("MONTO_ASIGNADO")]
        public decimal MontoAsignado { get; set; }
        [Column("MONTO_EJECUTADO")]
        public decimal MontoEjecutado { get; set; } = 0;
        [Column("ANIO_PRESUPUESTARIO")]
        public int AnioPresupuestario { get; set; }
        [Column("FECHA_APROBACION")]
        public DateTime FechaAprobacion { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, APROBADO, AGOTADO
        [Column("NOTAS")]
        public string? Notas { get; set; }
    }
}