using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("RESERVAS_PROMOCIONES")]
    public class ReservasPromocionesModel
    {
        [Key]
        [Column("ID_RESERVA", Order = 0)]
        public int IdReserva { get; set; }

        [Column("ID_PROMOCION", Order = 1)]
        public int IdPromocion { get; set; }

        [Column("DESCUENTO_APLICADO")]
        public decimal DescuentoAplicado { get; set; }

        [Column("FECHA_APLICACION")]
        public DateTime? FechaAplicacion { get; set; }
    }
}
