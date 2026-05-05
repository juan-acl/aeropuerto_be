using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PROMOCIONES")]
    public class PromocionesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PROMOCION")]
        public int IdPromocion { get; set; }

        [Column("CODIGO_PROMOCION")]
        public string? CodigoPromocion { get; set; }

        [Column("NOMBRE_PROMOCION")]
        public string? NombrePromocion { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("TIPO_DESCUENTO")]
        public string TipoDescuento { get; set; } = null!; // PORCENTAJE, MONTO_FIJO, 2X1, OTRO

        [Column("VALOR_DESCUENTO")]
        public decimal ValorDescuento { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("USO_MAXIMO")]
        public int? UsoMaximo { get; set; }

        [Column("USOS_ACTUALES")]
        public int UsosActuales { get; set; } = 0;

        [Column("ACTIVA")]
        public int Activa { get; set; } = 1;
    }
}
