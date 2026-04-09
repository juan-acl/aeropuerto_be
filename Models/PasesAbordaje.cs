using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PASES_ABORDAJE")]
    public class PasesAbordajeModel
    {
        [Key]
        [Column("ID_PASE_ABORDAJE")]
        public int IdPaseAbordaje { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("CODIGO_BARRAS")]
        public string? CodigoBarras { get; set; }

        [Column("QR_CODE")]
        public byte[]? QrCode { get; set; }

        [Column("FECHA_GENERACION")]
        public DateTime? FechaGeneracion { get; set; }

        [Column("FECHA_ESCANEO")]
        public DateTime? FechaEscaneo { get; set; }

        [Column("PUERTA_EMBARQUE")]
        public string? PuertaEmbarque { get; set; }

        [Column("GRUPO_EMBARQUE")]
        public string? GrupoEmbarque { get; set; }

        [Column("ASIENTO")]
        public string? Asiento { get; set; }

        [Column("UTILIZADO")]
        public int Utilizado { get; set; } = 0;
    }
}