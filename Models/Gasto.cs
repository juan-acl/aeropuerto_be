using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("GASTOS")]
    public class Gasto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_GASTO")]
        public int IdGasto { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("CONCEPTO")]
        public string Descripcion { get; set; } = null!;
        [Column("MONTO")]
        public decimal Monto { get; set; }
        [Column("TIPO_GASTO")]
        public string? Categoria { get; set; }
        [Column("ID_DEPARTAMENTO")]
        public int? IdDepartamento { get; set; }
        [Column("PROVEEDOR")]
        public string? Proveedor { get; set; }
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        [Column("FACTURA")]
        public string? Factura { get; set; }
        [Column("AUTORIZADO_POR")]
        public int? AutorizadoPor { get; set; }
    }
}
