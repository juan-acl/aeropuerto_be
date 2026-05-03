using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MANIFIESTOS_CARGA")]
    public class ManifiestoCarga
    {
        [Key]
        [Column("ID_MANIFIESTO")]
        public int id_manifiesto { get; set; }

        [Column("NUMERO_MANIFIESTO")]
        public string? numero_manifiesto { get; set; }

        [Column("ID_VUELO")]
        public int? id_vuelo { get; set; }

        [Column("FECHA_EMISION")]
        public DateTime? fecha_emision { get; set; }

        [Column("TOTAL_BULTOS")]
        public int? total_bultos { get; set; }

        [Column("PESO_TOTAL_KG")]
        public decimal? peso_total_kg { get; set; }

        [Column("VOLUMEN_TOTAL_M3")]
        public decimal? volumen_total_m3 { get; set; }

        [Column("VALOR_TOTAL")]
        public decimal? valor_total { get; set; }

        [Column("AGENTE_CARGA")]
        public string? agente_carga { get; set; }

        [Column("DOCUMENTO_ADJUNTO")]
        public byte[]? documento_adjunto { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; } // EMITIDO, VALIDADO, CERRADO

        [Column("EMITIDO_POR")]
        public int? emitido_por { get; set; }
    }
}