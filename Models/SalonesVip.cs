using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SALONES_VIP")]
    public class SalonesVipModel
    {
        [Key]
        [Column("ID_SALON")]
        public int IdSalon { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("NOMBRE_SALON")]
        public string? NombreSalon { get; set; }

        [Column("UBICACION")]
        public string? Ubicacion { get; set; }

        [Column("CAPACIDAD")]
        public int? Capacidad { get; set; }

        [Column("HORARIO_APERTURA")]
        public string? HorarioApertura { get; set; }

        [Column("HORARIO_CIERRE")]
        public string? HorarioCierre { get; set; }

        [Column("SERVICIOS")]
        public string? Servicios { get; set; }

        [Column("REQUISITOS_ACCESO")]
        public string? RequisitosAcceso { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}