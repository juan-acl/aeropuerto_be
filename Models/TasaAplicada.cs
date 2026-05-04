using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("TASA_APLICADA")]
    public class TasaAplicada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_APLICACION")]
        public int IdAplicacion { get; set; }
        [Column("ID_TASA")]
        public int IdTasa { get; set; }
        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("FECHA_COBRO")]
        public DateTime FechaCobro { get; set; }
        [Column("MONTO_COBRADO")]
        public decimal MontoCobrado { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; } = "PAGADO";
    }
}
