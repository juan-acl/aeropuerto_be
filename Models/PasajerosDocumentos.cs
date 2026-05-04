using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS_DOCUMENTOS")]
    public class PasajerosDocumentosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DOCUMENTO")]
        public int IdDocumento { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("TIPO_DOCUMENTO")]
        public string TipoDocumento { get; set; } = null!;

        [Column("NUMERO_DOCUMENTO")]
        public string NumeroDocumento { get; set; } = null!;

        [Column("PAIS_EMISION")]
        public string? PaisEmision { get; set; }

        [Column("FECHA_EMISION")]
        public DateTime? FechaEmision { get; set; }

        [Column("FECHA_EXPIRACION")]
        public DateTime? FechaExpiracion { get; set; }

        [Column("IMAGEN_DOCUMENTO")]
        public byte[]? ImagenDocumento { get; set; }

        [Column("VERIFICADO")]
        public int Verificado { get; set; } // 0 o 1
    }
}
