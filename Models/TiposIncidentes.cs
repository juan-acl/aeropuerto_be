using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TIPOS_INCIDENTES")]
    public class TiposIncidentesModel
    {
        [Key]
        [Column("ID_TIPO_INCIDENTE")]
        public int IdTipoIncidente { get; set; }

        [Column("NOMBRE_TIPO")]
        public string? NombreTipo { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("PROTOCOLO_ACCION")]
        public string? ProtocoloAccion { get; set; }

        [Column("TIEMPO_RESPUESTA_ESTIMADO")]
        public int? TiempoRespuestaEstimado { get; set; } // En minutos

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}