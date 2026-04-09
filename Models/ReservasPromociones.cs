using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("RESERVAS_PROMOCIONES")]
    public class ReservasPromocionesModel
    {
        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("ID_PROMOCION")]
        public int IdPromocion { get; set; }

        [Column("DESCUENTO_APLICADO")]
        public decimal DescuentoAplicado { get; set; }

        [Column("FECHA_APLICACION")]
        public DateTime? FechaAplicacion { get; set; }
    }
}