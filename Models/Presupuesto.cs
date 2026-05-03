using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PRESUPUESTOS")]
    public class Presupuesto
    {
        [Key]
        [Column("ID_PRESUPUESTO")]
        public int id_presupuesto { get; set; }

        [Column("ANIO_FISCAL")]
        public int anio_fiscal { get; set; }

        [Column("MES")]
        public int mes { get; set; }

        [Column("CONCEPTO")]
        public string? concepto { get; set; }

        [Column("ID_DEPARTAMENTO")]
        public int? id_departamento { get; set; }

        [Column("MONTO_ASIGNADO")]
        public decimal? monto_asignado { get; set; }

        [Column("MONTO_EJECUTADO")]
        public decimal? monto_ejecutado { get; set; }

        [Column("TIPO_GASTO")]
        public string? tipo_gasto { get; set; } // OPERATIVO, INVERSION, MANTENIMIENTO, PERSONAL

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? fecha_actualizacion { get; set; }
    }
}