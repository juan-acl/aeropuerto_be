using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("GASTO")]
    public class Gasto
    {
        [Key]
        [Column("ID_GASTO")]
        public int IdGasto { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("MONTO")]
        public decimal Monto { get; set; }
        [Column("CATEGORIA")]
        public string Categoria { get; set; } = null!;
        [Column("ID_CUENTA_CONTABLE")]
        public int IdCuentaContable { get; set; }
        [Column("ID_PRESUPUESTO")]
        public int? IdPresupuesto { get; set; }
    }
}