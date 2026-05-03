using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS_MENORES")]
    public class PasajeroMenor
    {
        [Key]
        [Column("ID_RELACION")]
        public int id_relacion { get; set; }

        [Column("ID_MENOR")]
        public int? id_menor { get; set; }

        [Column("ID_ACOMPANANTE")]
        public int? id_acompanante { get; set; }

        [Column("TIPO_RELACION")]
        public string? tipo_relacion { get; set; } // PADRE, MADRE, TUTOR, FAMILIAR

        [Column("AUTORIZADO")]
        public int? autorizado { get; set; }

        [Column("DOCUMENTO_AUTORIZACION")]
        public byte[]? documento_autorizacion { get; set; }
    }
}