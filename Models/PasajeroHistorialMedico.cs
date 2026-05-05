using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS_HISTORIAL_MEDICO")]
    public class PasajeroHistorialMedicoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_HISTORIAL_MEDICO")]
        public int IdHistorialMedico { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("CONDICION_MEDICA")]
        public string? CondicionMedica { get; set; }

        [Column("REQUIERE_ATENCION_ESPECIAL")]
        public int RequiereAtencionEspecial { get; set; } // 0 o 1

        [Column("MEDICAMENTOS_AUTORIZADOS")]
        public string? MedicamentosAutorizados { get; set; }

        [Column("CONTACTO_EMERGENCIA_NOMBRE")]
        public string? ContactoEmergenciaNombre { get; set; }

        [Column("CONTACTO_EMERGENCIA_TELEFONO")]
        public string? ContactoEmergenciaTelefono { get; set; }

        [Column("CONTACTO_EMERGENCIA_RELACION")]
        public string? ContactoEmergenciaRelacion { get; set; }

        [Column("ULTIMA_ACTUALIZACION")]
        public DateTime? UltimaActualizacion { get; set; }
    }
}
