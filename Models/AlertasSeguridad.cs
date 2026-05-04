using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ALERTAS_SEGURIDAD")]
    public class AlertasSeguridadModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ALERTA")]
        public int IdAlerta { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("NIVEL_ALERTA")]
        public string NivelAlerta { get; set; } = "VERDE"; // VERDE, AMARILLO, NARANJA, ROJO

        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("MOTIVO")]
        public string? Motivo { get; set; }

        [Column("MEDIDAS_ADICIONALES")]
        public string? MedidasAdicionales { get; set; }

        [Column("ACTIVA")]
        public int Activa { get; set; } = 1;

        [Column("EMITIDA_POR")]
        public string? EmitidaPor { get; set; }
    }
}
