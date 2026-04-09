using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("VISITAS_SEGURIDAD")]
    public class VisitasSeguridadModel
    {
        [Key]
        [Column("ID_VISITA")]
        public int IdVisita { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("FECHA_VISITA")]
        public DateTime? FechaVisita { get; set; }

        [Column("HORA_ENTRADA")]
        public DateTime? HoraEntrada { get; set; }

        [Column("HORA_SALIDA")]
        public DateTime? HoraSalida { get; set; }

        [Column("NOMBRE_VISITANTE")]
        public string? NombreVisitante { get; set; }

        [Column("TIPO_DOCUMENTO")]
        public string? TipoDocumento { get; set; }

        [Column("NUMERO_DOCUMENTO")]
        public string? NumeroDocumento { get; set; }

        [Column("EMPRESA")]
        public string? Empresa { get; set; }

        [Column("MOTIVO_VISITA")]
        public string? MotivoVisita { get; set; }

        [Column("PERSONA_AUTORIZA")]
        public string? PersonaAutoriza { get; set; }

        [Column("AREA_VISITADA")]
        public string? AreaVisitada { get; set; }

        [Column("ESCORT_REQUERIDO")]
        public int EscortRequerido { get; set; } = 0;

        [Column("ESCORT_ASIGNADO")]
        public string? EscortAsignado { get; set; }
    }
} 