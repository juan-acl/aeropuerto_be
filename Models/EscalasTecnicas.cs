using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ESCALAS_TECNICAS")]
    public class EscalasTecnicasModel
    {
        [Key]
        [Column("ID_ESCALA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEscala { get; set; }

        [Column("ID_VUELO")]
        [Required]
        public int IdVuelo { get; set; }

        [Column("AEROPUERTO_ESCALA")]
        [Required]
        [StringLength(100)]
        public string AeropuertoEscala { get; set; } = null!;

        [Column("NUMERO_ORDEN")]
        [Required]
        public int NumeroOrden { get; set; }

        [Column("HORA_LLEGADA")]
        [Required]
        public DateTime HoraLlegada { get; set; }

        [Column("HORA_DESPEGUE")]
        [Required]
        public DateTime HoraDespegue { get; set; }

        [Column("TIEMPO_ESCALA_MINUTOS")]
        [Required]
        public int TiempoEscalaMinutos { get; set; }

        [Column("MOTIVO_ESCALA")]
        [StringLength(255)]
        public string? MotivoEscala { get; set; }

        [Column("OBSERVACIONES")]
        [StringLength(1000)]
        public string? Observaciones { get; set; }
    }
}
