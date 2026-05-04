using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Aeropuerto.Backend.Models
{
    [Table("PISTAS_ATERRIZAJE")]
    public class PistaAterrizajeModel
    {
        [Key][Column("ID_PISTA")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPista { get; set; }
        [Column("CODIGO_AEROPUERTO")][StringLength(10)]
        public string? CodigoAeropuerto { get; set; }
        [Column("NUMERO_PISTA")][StringLength(10)]
        public string? NumeroPista { get; set; }
        [Column("LONGITUD_METROS")]
        public decimal? LongitudMetros { get; set; }
        [Column("ANCHURA_METROS")]
        public decimal? AnchoMetros { get; set; }
        [Column("SUPERFICIE")][StringLength(30)]
        public string? Superficie { get; set; }
        [Column("ILUMINACION_NOCTURNA")]
        public int IluminacionNocturna { get; set; } = 0;
        [Column("SISTEMA_ILS")]
        public int SistemaIls { get; set; } = 0;
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
