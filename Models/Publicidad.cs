using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PUBLICIDAD")]
    public class PublicidadModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PUBLICIDAD")]
        public int IdPublicidad { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("UBICACION")]
        public string? Ubicacion { get; set; }

        [Column("TIPO_PUBLICIDAD")]
        public string TipoPublicidad { get; set; } = null!; // VALLA, PANTALLA_DIGITAL, BANNER

        [Column("EMPRESA_ANUNCIANTE")]
        public string? EmpresaAnunciante { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("COSTO")]
        public decimal? Costo { get; set; }

        [Column("CONTRATO")]
        public byte[]? Contrato { get; set; } // Mapeo para el campo BLOB de Oracle

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
