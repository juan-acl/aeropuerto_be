using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("AUTORIZACIONES_MENORES")]
    public class AutorizacionMenor
    {
        [Key]
        [Column("ID_AUTORIZACION_MENOR")]
        public int id_autorizacion_menor { get; set; }

        [Column("ID_MENOR")]
        public int? id_menor { get; set; }

        [Column("NUMERO_AUTORIZACION")]
        public string? numero_autorizacion { get; set; }

        [Column("FECHA_EMISION")]
        public DateTime? fecha_emision { get; set; }

        [Column("FECHA_EXPIRACION")]
        public DateTime? fecha_expiracion { get; set; }

        [Column("AUTORIDAD_EMISORA")]
        public string? autoridad_emisora { get; set; }

        [Column("DOCUMENTO_AUTORIZACION")]
        public byte[]? documento_autorizacion { get; set; }

        [Column("VERIFICADO")]
        public int? verificado { get; set; }
    }
}