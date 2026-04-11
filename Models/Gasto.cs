using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class Gasto
    {
        [Key]
        public int IdGasto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public string Categoria { get; set; } = null!;
        public int IdCuentaContable { get; set; }
        public int? IdPresupuesto { get; set; }
    }
}