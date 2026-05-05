using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("MANIFIESTO_DETALLE")]
    public class ManifiestoDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DETALLE")]
        public int IdDetalle { get; set; }
        [Column("ID_MANIFIESTO")]
        public int IdManifiesto { get; set; }
        [Column("ID_ENVIO")]
        public int IdEnvio { get; set; }
        [Column("UBICACION_BODEGA")]
        public string UbicacionBodega { get; set; } = null!;
    }
}
