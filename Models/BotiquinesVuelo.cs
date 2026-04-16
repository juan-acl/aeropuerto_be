using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("BOTIQUINES_VUELO")]
    public class BotiquinesVueloModel
    {
        [Key]
        [Column("ID_BOTIQUIN")]
        public int IdBotiquin { get; set; }

        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }

        [Column("FECHA_VERIFICACION")]
        public DateTime? FechaVerificacion { get; set; }

        [Column("CONTENIDO_COMPLETO")]
        public int ContenidoCompleto { get; set; } = 1;

        [Column("MEDICAMENTOS_CADUCADOS")]
        public int MedicamentosCaducados { get; set; } = 0;

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }

        [Column("VERIFICADO_POR")]
        public string? VerificadoPor { get; set; }
    }
}