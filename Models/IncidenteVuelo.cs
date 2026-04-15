using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aeropuerto.Backend.Models
{
    [Table("INCIDENTES_VUELO")]
    public class IncidenteVueloModel
    {
        [Key][Column("ID_INCIDENTE_VUELO")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIncidenteVuelo { get; set; }
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("FECHA_INCIDENTE")]
        public DateTime? FechaIncidente { get; set; }
        [Column("TIPO_INCIDENTE")][StringLength(30)]
        public string? TipoIncidente { get; set; }
        // TECNICO|MEDICO|SEGURIDAD|CLIMATICO|OPERATIVO|OTRO
        [Column("DESCRIPCION")][StringLength(1000)]
        public string? Descripcion { get; set; }
        [Column("GRAVEDAD")][StringLength(10)]
        public string? Gravedad { get; set; }          // BAJA|MEDIA|ALTA|CRITICA
        [Column("ACCIONES_TOMADAS")][StringLength(1000)]
        public string? AccionesTomadas { get; set; }
        [Column("REPORTADO_POR")][StringLength(100)]
        public string? ReportadoPor { get; set; }
        [Column("ESTADO")][StringLength(20)]
        public string Estado { get; set; } = "ABIERTO";
    }
}
