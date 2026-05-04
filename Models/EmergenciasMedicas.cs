using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("EMERGENCIAS_MEDICAS")]
    public class EmergenciasMedicasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_EMERGENCIA")]
        public int IdEmergencia { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("FECHA_EMERGENCIA")]
        public DateTime? FechaEmergencia { get; set; }

        [Column("TIPO_EMERGENCIA")]
        public string? TipoEmergencia { get; set; }

        [Column("SINTOMAS")]
        public string? Sintomas { get; set; }

        [Column("DIAGNOSTICO_INICIAL")]
        public string? DiagnosticoInicial { get; set; }

        [Column("PERSONAL_ATENDIO")]
        public string? PersonalAtendio { get; set; }

        [Column("TRATAMIENTO")]
        public string? Tratamiento { get; set; }

        [Column("REQUIERE_HOSPITALIZACION")]
        public int RequiereHospitalizacion { get; set; } = 0;

        [Column("HOSPITAL_DESTINO")]
        public string? HospitalDestino { get; set; }

        [Column("FECHA_ALTA")]
        public DateTime? FechaAlta { get; set; }
    }
}
