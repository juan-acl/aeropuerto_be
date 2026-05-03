using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MANIFIESTOS_DETALLE")]
    public class ManifiestoDetalle
    {
        [Key]
        [Column("ID_DETALLE")]
        public int id_detalle { get; set; }

        [Column("ID_MANIFIESTO")]
        public int? id_manifiesto { get; set; }

        [Column("ID_ENVIO")]
        public int? id_envio { get; set; }

        [Column("NUMERO_ORDEN")]
        public int? numero_orden { get; set; }

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }
    }
}