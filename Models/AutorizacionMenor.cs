using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("AUTORIZACION_MENOR")]
    public class AutorizacionMenor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_AUTORIZACION")]
        public int IdAutorizacion { get; set; }
        [Column("ID_PASAJERO_MENOR")]
        public int IdPasajeroMenor { get; set; }
        [Column("NOMBRE_TUTOR")]
        public string NombreTutor { get; set; } = null!;
        [Column("DPI_TUTOR")]
        public string DpiTutor { get; set; } = null!;
        [Column("TIPO_RELACION")]
        public string TipoRelacion { get; set; } = null!;
        [Column("DOCUMENTO_ADJUNTO")]
        public string DocumentoAdjunto { get; set; } = null!;
        [Column("FECHA_EMISION")]
        public DateTime FechaEmision { get; set; }
    }
}
