using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("GASTOS")]
    public class Gasto
    {
        [Key]
        [Column("ID_GASTO")]
        public int id_gasto { get; set; }

        [Column("FECHA")]
        public DateTime? fecha { get; set; }

        [Column("CONCEPTO")]
        public string? concepto { get; set; }

        [Column("TIPO_GASTO")]
        public string? tipo_gasto { get; set; } // SERVICIOS, MANTENIMIENTO, PERSONAL, SUMINISTROS, SEGURIDAD, OTROS

        [Column("ID_DEPARTAMENTO")]
        public int? id_departamento { get; set; }

        [Column("PROVEEDOR")]
        public string? proveedor { get; set; }

        [Column("MONTO")]
        public decimal? monto { get; set; }

        [Column("MONEDA")]
        public string? moneda { get; set; }

        [Column("FACTURA")]
        public string? factura { get; set; }

        [Column("AUTORIZADO_POR")]
        public int? autorizado_por { get; set; }
    }
}