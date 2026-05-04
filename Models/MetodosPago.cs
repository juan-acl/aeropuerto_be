using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("METODOS_PAGO")]
    public class MetodosPagoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_METODO_PAGO")]
        public int IdMetodoPago { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("TIPO_PAGO")]
        public string TipoPago { get; set; } = null!; // TARJETA_CREDITO, EFECTIVO, etc.

        [Column("PROCESADOR")]
        public string? Procesador { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
