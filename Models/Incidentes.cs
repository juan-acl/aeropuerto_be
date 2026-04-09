using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INCIDENTES")]
    public class IncidentesModel
    {
        [Key]
        [Column("ID_INCIDENTE")]
        public int IdIncidente { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("FECHA_INCIDENTE")]
        public DateTime? FechaIncidente { get; set; }

        [Column("HORA_INCIDENTE")]
        public DateTime? HoraIncidente { get; set; }

        [Column("TIPO_INCIDENTE")]
        public string TipoIncidente { get; set; } = null!; // ARRESTO, INFRACCION, etc.

        [Column("NIVEL_GRAVEDAD")]
        public string NivelGravedad { get; set; } = "BAJO";

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;

        [Column("LUGAR_INCIDENTE")]
        public string? LugarIncidente { get; set; }

        [Column("AUTORIDAD_INVOLUCRADA")]
        public string? AutoridadInvolucrada { get; set; }

        [Column("OFICIAL_A_CARGO")]
        public string? OficialACargo { get; set; }

        [Column("RESOLUCION")]
        public string? Resolucion { get; set; }

        [Column("FECHA_RESOLUCION")]
        public DateTime? FechaResolucion { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = "ACTIVO";

        [Column("REQUIERE_SEGUIMIENTO")]
        public int RequiereSeguimiento { get; set; } = 0;
    }
}