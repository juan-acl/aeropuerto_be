using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("EMPRESAS_TRANSPORTE")]
    public class EmpresasTransporte
    {
        
        [Key]
        [Column("ID_EMPRESA_TRANSPORTE")]
        public int IdEmpresaTransporte { get; set; }
        
        [Column("NOMBRE_EMPRESA")]
        public string NombreEmpresa { get; set; } = null!;
        
        [Column("NIT")]
        public string? Nit { get; set; }
        
        [Column("TIPO_EMPRESA")]
        public string? TipoEmpresa { get; set; }
        
        [Column("TELEFONO_CONTACTO")]
        public string? TelefonoContacto { get; set; }
        
        [Column("EMAIL_CONTACTO")]
        public string? EmailContacto { get; set; }
        
        [Column("WEBSITE")]
        public string? Website { get; set; }
        
        [Column("PERSONA_CONTACTO")]
        public string? PersonaContacto { get; set; }
        
        [Column("TELEFONO_EMERGENCIA")]
        public string? TelefonoEmergencia { get; set; }
        
        [Column("HORARIO_ATENCION")]
        public string? HorarioAtencion { get; set; }
        
        [Column("CALIFICACION_PROMEDIO")]
        public decimal? CalificacionPromedio { get; set; }
        
        [Column("AUTORIZADA_AEROPUERTO")]
        public decimal? AutorizadaAeropuerto { get; set; }
        
        [Column("FECHA_AUTORIZACION")]
        public DateTime? FechaAutorizacion { get; set; }
        
        [Column("FECHA_VENCIMIENTO_AUTORIZACION")]
        public DateTime? FechaVencimientoAutorizacion { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
    }
}
