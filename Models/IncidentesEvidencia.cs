using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INCIDENTES_EVIDENCIA")]
    public class IncidentesEvidenciaModel
    {
        [Key]
        [Column("ID_EVIDENCIA")]
        public int IdEvidencia { get; set; }

        [Column("ID_INCIDENTE")]
        public int IdIncidente { get; set; }

        [Column("TIPO_EVIDENCIA")]
        public string TipoEvidencia { get; set; } = null!; // FOTO, VIDEO, etc.

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("ARCHIVO_EVIDENCIA")]
        public byte[]? ArchivoEvidencia { get; set; }

        [Column("FECHA_REGISTRO")]
        public DateTime? FechaRegistro { get; set; }

        [Column("REGISTRADO_POR")]
        public string? RegistradoPor { get; set; }
    }
}