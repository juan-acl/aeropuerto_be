using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("INCIDENTES_INVOLUCRADOS")]
    public class IncidentesInvolucradosModel
    {
        [Key]
        [Column("ID_INVOLUCRADO")]
        public int IdInvolucrado { get; set; }

        [Column("ID_INCIDENTE")]
        public int IdIncidente { get; set; }

        [Column("TIPO_PERSONA")]
        public string TipoPersona { get; set; } = null!; // PASAJERO, TRIPULANTE, EMPLEADO, etc.

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_TRIPULANTE")]
        public int? IdTripulante { get; set; }

        [Column("NOMBRE_COMPLETO")]
        public string? NombreCompleto { get; set; }

        [Column("TIPO_DOCUMENTO")]
        public string? TipoDocumento { get; set; }

        [Column("NUMERO_DOCUMENTO")]
        public string? NumeroDocumento { get; set; }

        [Column("NACIONALIDAD")]
        public string? Nacionalidad { get; set; }

        [Column("ROL_EN_INCIDENTE")]
        public string? RolEnIncidente { get; set; } // Ejemplo: TESTIGO, AFECTADO, INFRACTOR

        [Column("DECLARACION")]
        public string? Declaracion { get; set; }
    }
}